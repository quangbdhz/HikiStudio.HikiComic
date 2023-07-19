using HikiComic.Application.UserContext;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace HikiComic.Application.Base
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly DbContext _context;

        private readonly IUserContextService _userContextService;

        public BaseService(DbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }

        /// <summary>
        /// Feature: Gets the ID of the specified entity.
        /// Implement this method in derived classes to retrieve the ID of the entity.
        /// </summary>
        /// <param name="entity">The entity for which to retrieve the ID.</param>
        /// <returns>The ID of the entity.</returns>
        protected abstract int GetObjectId(T entity);

        /// <summary>
        /// Feature: Gets the name of the object represented by the specified request.
        /// Implement this method in derived classes to provide the object name based on the request.
        /// </summary>
        /// <param name="request">The request object representing the object.</param>
        /// <returns>The name of the object.</returns>
        protected abstract Task<string> GetObjectName(object request);

        /// <summary>
        /// Feature: Gets the name of the object represented by the specified entity.
        /// Implement this method in derived classes to provide the object name based on the entity.
        /// </summary>
        /// <param name="entity">The entity representing the object.</param>
        /// <returns>The name of the object.</returns>
        protected abstract Task<string> GetObjectName(T entity);

        /// <summary>
        /// Feature: Creates the object properties based on the provided request.
        /// Implement this method in derived classes to customize the logic for creating object properties.
        /// </summary>
        /// <param name="request">The request object containing the data for creating the object.</param>
        /// <returns>The created object with populated properties.</returns>
        protected abstract Task<T?> CreateObjectProperties(object request);

        /// <summary>
        /// Feature: Creates an object based on the provided request.
        /// </summary>
        /// <param name="request">The request object containing the data for creating the object.</param>
        /// <returns>An API result containing the ID of the created object.</returns>
        public async Task<ApiResult<int>> CreateObject(object request)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<int>();

            var objectName = await GetObjectName(request);

            // Check if the entity already exists
            var checkEntityAlreadyExists = await Task.Run(() => _context.Set<T>().AsEnumerable().FirstOrDefault( x =>  GetObjectName(x).Result == objectName));

            if (checkEntityAlreadyExists != null)
                return new ApiErrorResult<int>()
                {
                    Message = MessageConstants.ObjectAlreadyExists(typeof(T).Name),
                    ResultObj = GetObjectId(checkEntityAlreadyExists)
                };

            // Create a new instance of the entity
            var entity = await CreateObjectProperties(request);

            if(entity is null)
                return new ApiErrorResult<int>()
                {
                    Message = MessageConstants.ObjectAlreadyExists(typeof(T).Name)
                };

            // Set additional properties
            entity.GetType().GetProperty("DateCreated")?.SetValue(entity, DateTime.Now);
            entity.GetType().GetProperty("IsDeleted")?.SetValue(entity, false);
            entity.GetType().GetProperty("CreatedBy")?.SetValue(entity, userResult.ResultObj);

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<int>()
            {
                ResultObj = GetObjectId(entity),
                Message = MessageConstants.OperationSuccess(OperationTypeEnum.Create, typeof(T).Name, 0)
            };
        }

        /// <summary>
        /// Feature: Updates the properties of an existing object based on the properties of a request object.
        /// Implement this method in derived classes to customize the logic for updating object properties.
        /// </summary>
        /// <param name="existingObject">The existing object to be updated.</param>
        /// <param name="request">The request object containing the updated property values.</param>
        protected abstract void UpdateObjectProperties(T existingObject, object request);

        /// <summary>
        /// Feature: Updates an object with the specified object ID and request.
        /// </summary>
        /// <param name="objectId">The ID of the object to update.</param>
        /// <param name="request">The request object containing updated properties.</param>
        /// <returns>An API result indicating the success or failure of the update operation.</returns>
        public async Task<ApiResult<bool>> UpdateObject(int objectId, object request)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var existingObject = await _context.Set<T>().FindAsync(objectId);

            if (existingObject is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound(typeof(T).Name) };

            //this query place needs to switch to asynchronous
            var duplicateObject = _context.Set<T>().AsEnumerable().Where(x => GetObjectName(x) == GetObjectName(request) && objectId != GetObjectId(x)).FirstOrDefault();

            if (duplicateObject != null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectAlreadyExists(typeof(T).Name) };

            // Update the properties of the existing object using the properties of the request object
            UpdateObjectProperties(existingObject, request);

            existingObject.GetType().GetProperty("DateUpdated")?.SetValue(existingObject, DateTime.Now);
            existingObject.GetType().GetProperty("UpdatedBy")?.SetValue(existingObject, userResult.ResultObj);

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.OperationSuccess(OperationTypeEnum.Update, typeof(T).Name, objectId) };
        }

        /// <summary>
        /// Feature: Deletes an object with the specified objectId by setting its IsDeleted property to true.
        /// </summary>
        /// <param name="objectId">The identifier of the object to be deleted.</param>
        /// <returns>An ApiResult<bool> indicating the success or failure of the delete operation. The result contains a boolean value indicating whether the operation was successful and a message describing the outcome.</returns>
        public async Task<ApiResult<bool>> DeleteObject(int objectId)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var existingObject = await _context.Set<T>().FindAsync(objectId);

            if (existingObject is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound($"{typeof(T).Name} With Id: {objectId}") };

            var isDeletedProperty = existingObject.GetType().GetProperty("IsDeleted");

            if (isDeletedProperty == null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurred };

            if ((bool)(isDeletedProperty.GetValue(existingObject) ?? true))
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectAlreadyDeleted(typeof(T).Name, objectId) };

            isDeletedProperty.SetValue(existingObject, true);
            existingObject.GetType().GetProperty("DateUpdated")?.SetValue(existingObject, DateTime.Now);
            existingObject.GetType().GetProperty("UpdatedBy")?.SetValue(existingObject, userResult.ResultObj);

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.OperationSuccess(OperationTypeEnum.Delete, typeof(T).Name, objectId) };
        }

        /// <summary>
        /// Deletes multiple objects identified by the specified object IDs.
        /// </summary>
        /// <param name="objectIds">The object IDs of the objects to delete.</param>
        /// <returns>An ApiResult<bool> indicating the success or failure of the delete operation. The result contains a boolean value indicating whether the operation was successful and a message describing the outcome.</returns>
        public async Task<ApiResult<bool>> DeleteObjects(IEnumerable<int> objectIds)
        {
            var userResult = _userContextService.GetUserIdFromToken();
            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var existingObjects = await _context.Set<T>().ToListAsync();

            var validObjectIds = objectIds.Where(id => id > 0).ToList();

            var filteredObjects = existingObjects.Where(x => validObjectIds.Contains(GetObjectId(x))).ToList();

            var errorMessageBuilder = new StringBuilder();

            foreach (var existingObject in filteredObjects)
            {
                var isDeletedProperty = existingObject.GetType().GetProperty("IsDeleted");
                if (isDeletedProperty == null)
                {
                    errorMessageBuilder.AppendLine(MessageConstants.AnErrorOccurred);
                    continue;
                }

                var objectId = GetObjectId(existingObject);

                if ((bool)(isDeletedProperty.GetValue(existingObject) ?? true))
                {
                    errorMessageBuilder.AppendLine(MessageConstants.ObjectAlreadyDeleted(typeof(T).Name, objectId));
                    continue;
                }

                isDeletedProperty.SetValue(existingObject, true);
                existingObject.GetType().GetProperty("DateUpdated")?.SetValue(existingObject, DateTime.Now);
                existingObject.GetType().GetProperty("UpdatedBy")?.SetValue(existingObject, userResult.ResultObj);
            }

            if (errorMessageBuilder.Length > 0)
            {
                var errorMessage = errorMessageBuilder.ToString().Trim();
                return new ApiErrorResult<bool>(errorMessage);
            }

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>()
            {
                Message = MessageConstants.OperationSuccess(OperationTypeEnum.MultipleDelete, typeof(T).Name.Pluralize(), filteredObjects.Count)
            };
        }

        /// <summary>
        /// Feature: Restores a deleted object by setting its IsDeleted property to false and updating the DateUpdated and UpdatedBy properties.
        /// </summary>
        /// <param name="objectId">The ID of the object to restore.</param>
        /// <returns>An API result indicating the success or failure of the restore operation.</returns>
        public async Task<ApiResult<bool>> RestoreDeletedObject(int objectId)
        {
            var userResult = _userContextService.GetUserIdFromToken();

            if (!userResult.IsSuccessed)
                return userResult.MapToResult<bool>();

            var existingObject = await _context.Set<T>().FindAsync(objectId);

            if (existingObject == null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound($"{typeof(T).Name} With Id: {objectId}") };

            var isDeletedProperty = existingObject.GetType().GetProperty("IsDeleted");

            if (isDeletedProperty == null || !((bool?)isDeletedProperty.GetValue(existingObject) ?? false))
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectAlreadyRestored(typeof(T).Name, objectId) };

            isDeletedProperty.SetValue(existingObject, false);
            existingObject.GetType().GetProperty("DateUpdated")?.SetValue(existingObject, DateTime.Now);
            existingObject.GetType().GetProperty("UpdatedBy")?.SetValue(existingObject, userResult.ResultObj);

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.OperationSuccess(OperationTypeEnum.Restore, typeof(T).Name, objectId) };
        }
    }
}
