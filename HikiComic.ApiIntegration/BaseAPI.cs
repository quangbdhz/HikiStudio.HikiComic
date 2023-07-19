using HikiComic.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HikiComic.ApiIntegration
{
    public class BaseAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseAPI(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress] ?? "https://localhost:7068/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                TResponse? myDeserializedObjList = (TResponse?)JsonConvert.DeserializeObject(body, typeof(TResponse));

                return myDeserializedObjList ?? throw new ArgumentNullException(nameof(myDeserializedObjList));
            }
            return JsonConvert.DeserializeObject<TResponse>(body) ?? throw new ArgumentNullException(MessageConstants.AnErrorOccurred);
        }

        public async Task<List<T>> GetListAsync<T>(string url, bool requiredLogin = false)
        {
            var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress] ?? "https://localhost:7068/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = (List<T>?)JsonConvert.DeserializeObject(body, typeof(List<T>)) ?? throw new ArgumentException("GetListAsync");
                return data;
            }
            throw new Exception(body);
        }

        public async Task<TResponse> GetAsync<TResponse>(string url, string? token)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.BaseAddress = new Uri(url);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse?)JsonConvert.DeserializeObject(body, typeof(TResponse)) ?? throw new ArgumentException("GetListAsync");

                if (myDeserializedObjList != null)
                    return myDeserializedObjList;
            }
            else
            {
                TResponse myDeserializedObjList = (TResponse?)JsonConvert.DeserializeObject(body, typeof(TResponse)) ?? throw new ArgumentException("GetListAsync");

                if (myDeserializedObjList != null)
                    return myDeserializedObjList;
            }

            throw new Exception(response.StatusCode.ToString());
        }

        public async Task<TResponse> PostAsync<TResponse, TData>(TData payload, string url)
        {
            var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString(SystemConstants.AppSettings.Token);

            var json = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress] ?? "https://localhost:7068/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.PostAsync(url, httpContent);

            return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync()) ?? throw new ArgumentException("PostAsync");
        }

        public async Task<TResponse> PutAsync<TResponse, TData>(TData payload, string url)
        {
            var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString(SystemConstants.AppSettings.Token);

            var json = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress] ?? "https://localhost:7068/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.PutAsync(url, httpContent);

            return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync()) ?? throw new ArgumentException("PutAsync");
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string url)
        {
            var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress] ?? "https://localhost:7068/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.DeleteAsync(url);
            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                TResponse? myDeserializedObjList = (TResponse?)JsonConvert.DeserializeObject(body, typeof(TResponse));

                return myDeserializedObjList ?? throw new ArgumentNullException(nameof(myDeserializedObjList));
            }
            return JsonConvert.DeserializeObject<TResponse>(body) ?? throw new ArgumentNullException(MessageConstants.AnErrorOccurred);
        }

        public async Task<TResponse> DeleteWithBodyAsync<TResponse, TData>(TData payload, string url)
        {
            var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString(SystemConstants.AppSettings.Token);

            var json = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress] ?? "https://localhost:7068/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.DeleteAsync(url);

            return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync()) ?? throw new ArgumentException("GetListAsync");
        }
    }
}