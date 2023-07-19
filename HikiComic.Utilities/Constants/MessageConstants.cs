using HikiComic.Utilities.Enums;

namespace HikiComic.Utilities.Constants
{
    public class MessageConstants
    {
        public static string DoNotHavePermission = "Access Denied, You Don't Have Permission.";
        public static string NotImplemented(string nameFuction, string? condition)
        {
            if (condition != null)
                return nameFuction + " NotImplemented with condition: " + condition;

            return nameFuction + " NotImplemented";
        }


        public static string AnErrorOccurredInFunction(string nameFunction, string message)
        {
            return $"An error occurred in function '{nameFunction}': {message}";
        }

        public static string GetObjectSuccess(string name)  
        {
            return $"Retrieved {name} successfully.";
        }

        public static string ObjectNotFound(string name)
        {
            return name + " is not found.";
        }

        public static string ObjectAlreadyExists(string name)
        {
            return name + " already exists";
        }

        public static string ObjectActionSuccess(string name)
        {
            return name + " successfully.";
        }

        public static string CreateSuccess(string name)
        {
            return name + " created successfully.";
        }

        public static string UpdateSuccess(string name)
        {
            return name + " updated successfully.";
        }

        public static string DeleteSuccess(string name)
        {
            return name + " deleted successfully.";
        }

        public static string CurrentObjectDeleted(string name)
        {
            return name + " is deleted.";
        }

        public static string CurrentObjectNotDeleted(string name)
        {
            return name + " is not deleted.";
        }

        public static string TurnOnIsActive(string name)
        {
            return name + " is activated.";
        }

        public static string ModelStateIsNotValid(string name)
        {
            return "ModelState " + name + " is not valid.";
        }

        public static string ModelStateIsNotValid(string nameFunction, string nameModel)
        {
            return nameFunction + " Model State " + nameModel + " is not valid.";
        }

        public static string RestoreObjectSuccess(string name)
        {
            return name + " restored successfully.";
        }

        #region message success CRUD
        public static string OperationSuccess(OperationTypeEnum operationType, string objectType, dynamic objectId, string fieldName = "ID")
        {
            if (operationType == OperationTypeEnum.MultipleDelete)
                return $"Successfully deleted {objectId} {objectType}";

            string operation = GetOperationName(operationType);

            if (operationType == OperationTypeEnum.Create)
                return $"Successfully {operation} {objectType}";

            return $"Successfully {operation} {objectType} with {fieldName} {objectId}.";
        }

        private static string GetOperationName(OperationTypeEnum operationType)
        {
            switch (operationType)
            {
                case OperationTypeEnum.Create:
                    return "created";
                case OperationTypeEnum.Update:
                    return "updated";
                case OperationTypeEnum.Delete:
                    return "deleted";
                case OperationTypeEnum.Restore:
                    return "restored";
                default:
                    throw new ArgumentException("Invalid operation type.");
            }
        }
        #endregion

        #region message already [deleted & restored]
        public static string ObjectAlreadyDeleted(string objectType, int objectId)
        {
            return $"The {objectType} with ID {objectId} has already been deleted and cannot be deleted again.";
        }

        public static string ObjectAlreadyRestored(string objectType, dynamic objectId)
        {
            return $"The {objectType} with ID {objectId} has already been restored and cannot be restored again.";
        }
        #endregion


        public static string NoSelectedComic = "There is no selected Comic.";

        public static string NoSelectedChapter = "There is no selected Chapter.";

        public static string ServiceDoesNotExist = "This service does not exist in the system.";

        public static string FeatureAnErrorOccurred(string name)
        {
            return "An error " + name + " occurred.";
        }
           
        public static string AnErrorOccurred = "An error occurred.";

        public static string InvalidGuidFormat = "Invalid GUID format. The value should be a string of 32 digits and 4 dashes in the format xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.";

        public static string AccessDenied = "Access Denied: You do not have permission to perform this action. Please contact your administrator for assistance.";

        #region
        public static string LoginWithThirdPartyError = "We're sorry, but the login information provided is incorrect.";
        #endregion

        #region token
        public static string InvalidRefreshToken = "Sorry, we couldn't refresh your token. The refresh token provided is not correct. Please try logging in again to generate a new refresh token.";

        public static string TokenExpired = "Sorry, your session has expired. Please log in again to continue using our services. Thank you!";
        #endregion

        #region user
        public static string UsernameAlreadyExists = "It appears that the username you have chosen is already in use. Please try a different username or contact our support team if you need assistance.";

        public static string UserIsNotLogin = "Sorry, you are not currently logged in. Please log in to continue.";

        #endregion

        #region user email
        public static string EmailNotFound = "We're sorry, but we could not find an account with the email address you provided. Please double-check the email address and try again, or create a new account if you have not yet registered.";
        
        public static string EmailUnverified = "Email verification required. Please check your email for instructions.";

        public static string EmailVerification = "Thank you for registering with us! To complete your registration, please check your email inbox for a verification email from us. Follow the instructions in the email to verify your email address.";

        public static string EmailAlreadyExists = "We're sorry, but the email address you provided is already registered with our system. Please try logging in with your existing credentials or use a different email address to create a new account.";
        #endregion

        #region send otp phone number
        public static string UserAccountPhoneNumberExists = "Your user account already has a phone number associated with it. Please remove the existing phone number to update it with a new one.";
        
        public static string PhoneNumberAlreadyUsed = "The phone number has already been used. Please use a different phone number.";

        public static string CheckOTPOnYourSmartPhone = "An OTP has been sent to your phone, please check your phone. Alternatively, please retry after 15 minutes.";

        public static string PhoneNumberIsNullOrEmpty = "User hasn't updated phone number.";

        public static string OTPVerificationCodeNotFound = "No OTP verification code data found for the phone number.";

        public static string OTPVerificationCodeExpired = "The OTP verification code has expired. Please click on 'Resend OTP' to receive a new verification code.";

        public static string IncorrectOTPVerificationCode = "Incorrect OTP verification code. Please check again.";

        public static string PhoneNumberVerificationSuccess = "Congratulations! You have successfully verified your phone number.";

        public static string FormatPhoneNumberInvalid = "Invalid phone number. Format phone number valid is: '+XX XXX XXX XXX'";

        public static string AnErrorOccureSendOTP = "Error sending OTP verification code to the provided phone number.";

        public static string SendOTPVerificationPhoneNumberSuccess = "Please check your phone and enter the OTP code to verify your phone number.";

        public static string PhoneNumberVerifiedSuccess = "Phone number verified successfully!";

        public static string PhoneNumberDeletionSuccess = "Successfully deleted the phone number.";
        #endregion

        #region account status
        public static string AccountDeleted = "Your account has been deleted.";

        public static string AccountLocked = "Your account has been temporarily locked. Please contact support for assistance.";

        public static string AccountUnlocked = "The temporary lock on your account has been lifted. You can now access your account.";
        #endregion

        #region account nickname
        public static string NicknameIsRequired = "Please enter the nick name you want to change.";

        public static string ChangeNicknameSuccess = "Change Nickname is success.";
        #endregion

        #region account password
        public static string CompareNewPasswordAndCurrentPassword = "New Password cannot be the same as Current Password.";

        public static string CompareNewPasswordAndConfirmPassword = "Confirm Password must be the same as the New Password.";

        public static string IncorrectPassword = "Incorrect password.";

        public static string ChangePasswordSuccess = "Password changed successfully.";

        public static string ChangePasswordNotSuccess = "Password change failed.";
        #endregion

        #region account avatar
        public static string ChangeAvatarSuccess = "Change Avatar is success.";

        public static string ChangeAvatarNotSuccess = "Change Avatar is not success.";
        #endregion

        #region account coins
        public static string NotEnoughMoney = "There is not enough COINS left in your account to use this service.";

        #endregion

        #region otp email verification
        public static string EmailVerificationOTPHasExpired = "Your OTP code has expired, and we are unable to verify your email address at this time. Please click on the \"Resend OTP\" button to receive a new code and complete the verification process.";

        public static string EmailVerificationOTPUnverified = "We're sorry, but the OTP code you entered is not correct. Please check your email again for the correct OTP code and try again.";

        public static string EmailVerificationSuccess = "Congratulations! Your email address has been successfully verified. Thank you for completing the verification process.";

        public static string EmailVerificationNotSuccess = "We're sorry, but the email verification process has failed. Please try again later or contact customer support for assistance.";
        #endregion

        #region otp forgot password
        public static string ForgotPasswordOTPHasExpired = "Your password reset time has expired. To continue using our service, please reset your password.";

        public static string ForgotPasswordOTPUnverified = "OTP forgot password has not been verified or you have not used the forgot password service.";

        public static string ForgotPasswordSuccess = "Congratulations! You have successfully verified the OTP code, and you can now proceed to create a new password.";
        #endregion

        #region send mail [Verification Code]
        public static string SubjectOTPMailVerification = "Email Verification";

        public static string MessageTextOTPMailVerification(string fullName, string otp)
        {
            return $"<div style=\"background-image: linear-gradient(#ffffff, #9bf1ff); width: 100%; height: 100%; max-width: 680px; \r\n            margin: 20px auto; border-radius: 5px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;\">\r\n            <header>\r\n                <div style=\"display: flex;\">\r\n                    <img style=\"height: 25px; margin: 10px auto;\"\r\n                    src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676489337/HikiComic/Logo/HikiComic-Logo_kxfdme.png\">\r\n                </div>\r\n            </header>\r\n\r\n            <div style=\"width: 85%; margin: auto; border-radius: 5px; box-shadow: 4px; background-color: #fff;\">\r\n                <div style=\"background-color: #225881; width: 100%; display: flex; border-radius: 5px 5px 0 0 ;\">\r\n                    <div style=\"margin: 10px auto; width: 66px; height: 66px; border-radius: 50%; background: white; display: flex;\">\r\n                        <img style=\"height: 60px;margin: auto;object-fit: cover;border-radius: 50%;\" \r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1687535889/HikiComic/Icon/vecteezy_verification-code-has-been-send-concept-illustration-flat_14905312_mndnbw.jpg\">\r\n                    </div>\r\n                </div>\r\n\r\n                <div style=\"margin-top: 30px;\">\r\n                    <p style=\"text-align: center; font-size: 26px; font-weight: 700; color: #000000; margin: 0; font-family: system-ui;\">Verification Code</p>\r\n\r\n                    <div style=\"border-bottom: 2px; border-top: 0; border-left: 0; border-right: 0; border-color: #cec9c9; \r\n                        border-style: solid; margin: 20px 60px; display: block;\">\r\n                    </div>\r\n\r\n                    <div style=\"margin: 0 60px; font-family:system-ui; \">\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">Dear {fullName},</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">To ensure the security of our platform and the privacy of our users, we require email content verification for all new users. Please enter the following verification code in the space provided to continue with your account registration:</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">Verification Code: </span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:center; font-size: 23px; font-weight: 700; margin: 0; padding: 0; margin-top: 8px; letter-spacing: 3px;\">\r\n                            {otp}\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui; color: #888888;\">If you did not attempt to register for an account on our platform, please disregard this email and do not enter the verification code.</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 18px; padding-bottom: 20px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">Thank you for your cooperation.</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; padding-bottom: 20px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">Sincerely,</span>\r\n                            <span style=\"font-size: 14px; font-family: system-ui; display: block; font-weight: 800; margin-top: 4px;\">HikiStudio</span>\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n            <footer style=\"margin: 20px 0 0 0;\">\r\n                <div style=\"display: flex;\">\r\n                    <div style=\"margin: auto;\">\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/facebook_njuhc3.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px; margin: 0 6px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/instagram_u8zmrn.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px; background: white; border-radius: 2px; margin-right: 6px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/linkedin_rqd73m.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/pinterest_cwfypv.png\">\r\n                        </a>\r\n                    </div>\r\n                </div>\r\n\r\n                <div>\r\n                    <p style=\"text-align: center; margin: 0; font-family: system-ui; font-size: 13px; margin-top: 10px;\">The White House, 1600 Pennsylvania Ave NW, Washington, DC 20500, USA</p>\r\n                </div>\r\n\r\n                <div style=\"font-family:system-ui; font-size:12px; font-weight:400; letter-spacing:.4px; line-height:1.4; \r\n                    text-align:center;color:#444\">\r\n                    <p style=\"text-align:center\">\r\n                        <strong>| Privacy Policy | Contact Details | &nbsp;&nbsp;</strong>\r\n                    </p>\r\n                </div>\r\n            </footer>\r\n        </div>";
        }

        public static string SendMailOTPVerificationSuccess = "We have successfully sent a verification email to the address you provided. Please check your inbox and follow the instructions to verify your email.";
        #endregion

        #region send mail [Forgot Password]
        public static string SubjectOTPForgotPassword = "One-time password (OTP) for resetting your password";

        public static string MessageTextOTPForgotPassword(string fullName, string otp)
        {
            return $"<div style=\"display:flex;background-color: #e9ebed;\">\r\n        <div style=\"background-image: linear-gradient(#ffffff, #9bf1ff); width: 100%; height: 100%; max-width: 680px; \r\n            margin: 20px auto; border-radius: 5px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;\">\r\n            <header>\r\n                <div style=\"display: flex;\">\r\n                    <img style=\"height: 25px; margin: 10px auto;\"\r\n                    src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676489337/HikiComic/Logo/HikiComic-Logo_kxfdme.png\">\r\n                </div>\r\n            </header>\r\n\r\n            <div style=\"width: 85%; margin: auto; border-radius: 5px; box-shadow: 4px; background-color: #fff;\">\r\n                <div style=\"background-color: #225881; width: 100%; display: flex; border-radius: 5px 5px 0 0 ;\">\r\n                    <div style=\"margin: 10px auto; width: 66px; height: 66px; border-radius: 50%; background: white; display: flex;\">\r\n                        <img style=\"height: 60px;margin: auto;object-fit: cover;border-radius: 50%;\" \r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1687537487/HikiComic/Icon/vecteezy_change-password-protection-concept-illustration-flat-design_24741863_hgonei.jpg\">\r\n                    </div>\r\n                </div>\r\n\r\n                <div style=\"margin-top: 30px;\">\r\n                    <p style=\"text-align: center; font-size: 26px; font-weight: 700; color: #000000; margin: 0; font-family: system-ui;\">Reset Password</p>\r\n\r\n                    <div style=\"border-bottom: 2px; border-top: 0; border-left: 0; border-right: 0; border-color: #cec9c9; \r\n                        border-style: solid; margin: 20px 60px; display: block;\">\r\n                    </div>\r\n\r\n                    <div style=\"margin: 0 60px; font-family:system-ui; \">\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">Hello {fullName}!</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">\r\n                                As per your request to reset your password, we have generated a one-time password (OTP) that you will need to enter in order to change your password.\r\n                            </span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">Your OTP is:  </span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:center; font-size: 23px; font-weight: 700; margin: 0; padding: 0; margin-top: 8px; letter-spacing: 3px;\">\r\n                            {otp}\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">\r\n                                Please note that this OTP is valid only for a limited time, and must be used before it expires.\r\n                            </span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui; color: #888888;\">\r\n                                If you did not request to reset your password, please contact our support team immediately.\r\n                            </span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; padding-bottom: 20px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">Thank you for your cooperation.</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; padding-bottom: 20px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">Sincerely,</span>\r\n                            <span style=\"font-size: 14px; font-family: system-ui; display: block; font-weight: 800; margin-top: 4px;\">HikiStudio</span>\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n            <footer style=\"margin: 20px 0 0 0;\">\r\n                <div style=\"display: flex;\">\r\n                    <div style=\"margin: auto;\">\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/facebook_njuhc3.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px; margin: 0 6px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/instagram_u8zmrn.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px; background: white; border-radius: 2px; margin-right: 6px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/linkedin_rqd73m.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/pinterest_cwfypv.png\">\r\n                        </a>\r\n                    </div>\r\n                </div>\r\n\r\n                <div>\r\n                    <p style=\"text-align: center; margin: 0; font-family: system-ui; font-size: 13px; margin-top: 10px;\">The White House, 1600 Pennsylvania Ave NW, Washington, DC 20500, USA</p>\r\n                </div>\r\n\r\n                <div style=\"font-family:system-ui; font-size:12px; font-weight:400; letter-spacing:.4px; line-height:1.4; \r\n                    text-align:center;color:#444\">\r\n                    <p style=\"text-align:center\">\r\n                        <strong>| Privacy Policy | Contact Details | &nbsp;&nbsp;</strong>\r\n                    </p>\r\n                </div>\r\n            </footer>\r\n        </div>\r\n    </div>";
        }

        public static string SendMailOTPForgotPasswordSuccess = "To reset your password, please enter the OTP code we sent to your registered email address. Once verified, you will be able to create a new password.";
        #endregion

        #region send mail [Congratulations] (role reader -> creator)
        public static string SubjectEmailCongratulations = "Congratulations! Your Account has been Accepted on the System";

        public static string MessageTextEmailCongratulations(string fullName, string link, string html)
        {
            return $" <div style=\"display:flex;background-color: #e9ebed;\">\r\n        <div style=\"background-image: linear-gradient(#ffffff, #9bf1ff); width: 100%; height: 100%; max-width: 680px; \r\n            margin: 20px auto; border-radius: 5px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;\">\r\n            <header>\r\n                <div style=\"display: flex;\">\r\n                    <img style=\"height: 25px; margin: 10px auto;\"\r\n                    src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676489337/HikiComic/Logo/HikiComic-Logo_kxfdme.png\">\r\n                </div>\r\n            </header>\r\n\r\n            <div style=\"width: 85%; margin: auto; border-radius: 5px; box-shadow: 4px; background-color: #fff;\">\r\n                <div style=\"background-color: #225881; width: 100%; display: flex; border-radius: 5px 5px 0 0 ;\">\r\n                    <div style=\"margin: 10px auto; width: 66px; height: 66px; border-radius: 50%; background: white; display: flex;\">\r\n                        <img style=\"height: 60px;margin: auto;object-fit: cover;border-radius: 50%;\" \r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1687536436/HikiComic/Icon/congratulations-postcard-congrats-text-with-ribbon-banner-concept-illustration-flat-design-eps10-modern-graphic-element-for-landing-page-empty-state-ui-infographic-icon-vector_jqoeea.jpg\">\r\n                    </div>\r\n                </div>\r\n\r\n                <div style=\"margin-top: 18px;\">\r\n                    <p style=\"text-align: center; font-size: 26px; font-weight: 700; color: #000000; margin: 0; font-family: system-ui;\">Congratulations</p>\r\n\r\n                    <div style=\"border-bottom: 2px; border-top: 0; border-left: 0; border-right: 0; border-color: #cec9c9; \r\n                        border-style: solid; margin: 20px 60px; display: block;\">\r\n                    </div>\r\n\r\n                    <div style=\"margin: 0 60px; font-family:system-ui; \">\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">Dear {fullName},</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">I am delighted to inform you that your account has been approved to publish comics on our platform. This is fantastic news, and we warmly welcome you to become an active member of our creative community.</span>\r\n                        </p>\r\n                        \r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">With your account, you will have the opportunity to share your comic creations with thousands of readers worldwide. Imagine your stories and artwork being conveyed and inspiring others. We believe in your unique talents and ideas, and we are more than willing to support you in your journey of growth and promotion of your work.</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">\r\n                                To get started, please visit the following link to access your account: \r\n                            </span>\r\n                        </p>\r\n\r\n                        <div style=\"text-align: center; margin: 10px;\">\r\n                            <a href=\"{link}\" style=\"background-color: rgb(224, 66, 66); font-weight: bold; border: none; color: white; padding: 9px; text-decoration: none; display: inline-block; font-size: 16px; margin: 4px 2px; cursor: pointer; width: 80%; text-align: center; border-radius: 20px;\" onmouseover=\"this.style.backgroundColor='rgb(204, 0, 0)'\" onmouseout=\"this.style.backgroundColor='rgb(224, 66, 66)'\">\r\n                                Go To Page\r\n                            </a>\r\n                        </div>\r\n                        \r\n                        \r\n                        {html}<p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">\r\n                                Here, you can create and manage your comics, engage with the comic-loving community, and discover diverse works from other authors.\r\n                            </span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">We would like to express our gratitude for choosing us and trusting our platform to share your passion and creativity. Furthermore, we hope that you will stay committed and accompany us on the journey of development, bringing exciting experiences to the online comic community.</span>\r\n                        </p>\r\n                        \r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">If you have any questions or need assistance, please feel free to contact us via email or through our online support system. We are always here to help you.</span>\r\n                        </p>\r\n                        \r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">Once again, we sincerely thank you and hope that you will have a wonderful experience on our comic platform.</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; padding-bottom: 20px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">Sincerely,</span>\r\n                            <span style=\"font-size: 14px; font-family: system-ui; display: block; font-weight: 800; margin-top: 4px;\">HikiStudio</span>\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n            <footer style=\"margin: 20px 0 0 0;\">\r\n                <div style=\"display: flex;\">\r\n                    <div style=\"margin: auto;\">\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/facebook_njuhc3.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px; margin: 0 6px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/instagram_u8zmrn.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px; background: white; border-radius: 2px; margin-right: 6px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/linkedin_rqd73m.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/pinterest_cwfypv.png\">\r\n                        </a>\r\n                    </div>\r\n                </div>\r\n\r\n                <div>\r\n                    <p style=\"text-align: center; margin: 0; font-family: system-ui; font-size: 13px; margin-top: 10px;\">The White House, 1600 Pennsylvania Ave NW, Washington, DC 20500, USA</p>\r\n                </div>\r\n\r\n                <div style=\"font-family:system-ui; font-size:12px; font-weight:400; letter-spacing:.4px; line-height:1.4; \r\n                    text-align:center;color:#444\">\r\n                    <p style=\"text-align:center\">\r\n                        <strong>| Privacy Policy | Contact Details | &nbsp;&nbsp;</strong>\r\n                    </p>\r\n                </div>\r\n            </footer>\r\n        </div>\r\n    </div>";    
        }

        public static string SendMailEmailCongratulationSuccess = "Email has been successfully sent.";

        #endregion

        #region send mail [Email Confirmation]
        public static string SubjectEmailConfirmations = "Welcome! Confirm Your Email to Get Started";

        public static string MessageTextEmailConfirmations(string fullName, string link)
        {
            return $"<div style=\"display: flex; background-color: #e0f5fd;\">\r\n        <div style=\"background-image: linear-gradient(#ffffff, #c2c1c1); width: 100%; height: 100%; max-width: 600px; \r\n            margin: 20px auto; border-radius: 5px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;\">\r\n            <header>\r\n                <div style=\"display: flex;\">\r\n                    <img style=\"height: 25px; margin: 10px auto;\"\r\n                    src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676489337/HikiComic/Logo/HikiComic-Logo_kxfdme.png\">\r\n                </div>\r\n            </header>\r\n\r\n            <div style=\"width: 85%; margin: auto; border-radius: 5px; box-shadow: 4px; background-color: #fff;\">\r\n                <div style=\"background-color: #225881; width: 100%; display: flex; border-radius: 5px 5px 0 0 ;\">\r\n                    <div style=\"margin: 10px auto; width: 66px; height: 66px; border-radius: 50%; background: white; display: flex;\">\r\n                        <img style=\"height: 60px;margin: auto;object-fit: cover;border-radius: 50%;\" \r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1687535139/HikiComic/Icon/mail_checkmark_wjskjj.jpg\">\r\n                    </div>\r\n                </div>\r\n\r\n                <div style=\"margin-top: 40px;\">\r\n                    <p style=\"text-align: center; font-size: 25px; font-weight: bold; color: #5c5a65; margin: 0; font-family: 'Open Sans';\">Verify Your Email Address</p>\r\n\r\n                    <div style=\"border-bottom: 2px; border-top: 0; border-left: 0; border-right: 0; border-color: #cec9c9; \r\n                        border-style: solid; margin: 20px 60px; display: block;\">\r\n                    </div>\r\n\r\n                    <div style=\"margin: 0 60px;\">\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0;\">\r\n                            <span style=\"font-size: 14px; font-family: 'Open Sans';\">Hi {fullName},</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: 'Open Sans';\">You're almost set to start enjoying <strong>HikiComic</strong>. Simply click the link below to verify your email address and get started. The link expires in 48 hours.</span>\r\n                        </p>\r\n\r\n                        <div style=\"text-align: center; margin-top: 20px;\">\r\n                            <a href=\"{link}\" style=\"font-weight: bold; font-family: 'Open Sans'; background-color: rgb(47, 137, 207); border: none; color: white; padding: 9px; text-decoration: none; display: inline-block; font-size: 14px; cursor: pointer; width: 80%; text-align: center; border-radius: 20px; display: block; margin: 0 auto;\" onmouseover=\"this.style.backgroundColor='rgb(0, 83, 147)'\" onmouseout=\"this.style.backgroundColor='#2f89cf'\">\r\n                                Verify Email Address\r\n                            </a>\r\n                        </div>\r\n                        \r\n\r\n                        <div style=\"border-bottom: 2px; border-top: 0; border-left: 0; border-right: 0; border-color: #cec9c9; \r\n                            border-style: solid; margin: 22px 150px;\">\r\n                        </div>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; padding-bottom: 20px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 13px; font-family: 'Open Sans'; color: #a5a0a0;\">If you did not sign up for this account you can ignore this email and the account will be deleted.</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; padding-bottom: 20px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">Sincerely,</span>\r\n                            <span style=\"font-size: 14px; font-family: system-ui; display: block; font-weight: 800; margin-top: 4px;\">HikiStudio</span>\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n            <footer style=\"margin: 20px 0 0 0;\">\r\n                <div style=\"display: flex;\">\r\n                    <div style=\"margin: auto;\">\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/facebook_njuhc3.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px; margin: 0 6px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/instagram_u8zmrn.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px; background: white; border-radius: 2px; margin-right: 6px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/linkedin_rqd73m.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/pinterest_cwfypv.png\">\r\n                        </a>\r\n                    </div>\r\n                </div>\r\n\r\n                <div>\r\n                    <p style=\"text-align: center; margin: 0; font-family: 'Open Sans'; font-size: 13px; margin-top: 10px;\">The White House, 1600 Pennsylvania Ave NW, Washington, DC 20500, USA</p>\r\n                </div>\r\n\r\n                <div style=\"font-family:'Open Sans'; font-size:12px; font-weight:400; letter-spacing:.4px; line-height:1.4; \r\n                    text-align:center;color:#444\">\r\n                    <p style=\"text-align:center\">\r\n                        <strong>| Privacy Policy | Contact Details | &nbsp;&nbsp;</strong>\r\n                    </p>\r\n                </div>\r\n            </footer>\r\n        </div>\r\n    </div>";
        }

        public static string SendMailEmailConfirmationSuccess = "Email has been successfully sent.";


        public static string EmailConfirmationInstructionsSuccess = "Please check your email inbox and follow the instructions to verify your email.";
        #endregion

        #region send mail [payment confirmation]
        public static string SubjectPaymentConfirmation(string transactionId)
        {
            return $"Payment Confirmation - Transaction Code: {transactionId}";
        }

        public static string MessageTextPaymentConfirmation(string fullName, string transactionId, string paymentMethod, string amount)
        {
            return $"<div style=\"display: flex; background-color: #e0f5fd;\">\r\n        <div style=\"background-image: linear-gradient(#ffffff, #c2c1c1); width: 100%; height: 100%; max-width: 600px; \r\n            margin: 20px auto; border-radius: 5px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;\">\r\n            <header>\r\n                <div style=\"display: flex;\">\r\n                    <img style=\"height: 25px; margin: 10px auto;\"\r\n                    src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676489337/HikiComic/Logo/HikiComic-Logo_kxfdme.png\">\r\n                </div>\r\n            </header>\r\n\r\n            <div style=\"width: 85%; margin: auto; border-radius: 5px; box-shadow: 4px; background-color: #fff;\">\r\n                <div style=\"background-color: #225881; width: 100%; display: flex; border-radius: 5px 5px 0 0 ;\">\r\n                    <div style=\"margin: 10px auto; width: 66px; height: 66px; border-radius: 50%; background: white; display: flex;\">\r\n                        <img style=\"height: 60px;margin: auto;object-fit: cover;border-radius: 50%;\" \r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1689511909/HikiComic/Icon/debit-card_1086741_nprwzs.png\">\r\n                    </div>\r\n                </div>\r\n\r\n                <div style=\"margin-top: 40px;\">\r\n                    <p style=\"text-align: center; font-size: 25px; font-weight: bold; color: #5c5a65; margin: 0; font-family: 'Open Sans';\">Payment Confirmation</p>\r\n\r\n                    <div style=\"border-bottom: 2px; border-top: 0; border-left: 0; border-right: 0; border-color: #cec9c9; \r\n                        border-style: solid; margin: 20px 60px; display: block;\">\r\n                    </div>\r\n\r\n                    <div style=\"margin: 0 60px;\">\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0;\">\r\n                            <span style=\"font-size: 14px; font-family: 'Open Sans';\">Dear {fullName},</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: 'Open Sans';\">I hope this email finds you well. I am writing to inform you that your payment has been successfully processed. Please find below the details of the transaction:</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: 'Open Sans';\">Transaction Code: <strong>{transactionId}</strong></span>\r\n                            <br/>\r\n                            <span style=\"font-size: 14px; font-family: 'Open Sans';\">Payment Method: <strong>{paymentMethod}</strong></span>\r\n                            <br/>\r\n                            <span style=\"font-size: 14px; font-family: 'Open Sans';\">Amount: <strong>{amount}</strong></span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: 'Open Sans';\">We would like to express our gratitude for your prompt payment. Should you have any questions or require further assistance, please do not hesitate to reach out to our customer support team.</span>\r\n                        </p>\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: 'Open Sans';\">Thank you once again for your payment. We truly appreciate your business.</span>\r\n                        </p>\r\n\r\n\r\n                        <p style=\"text-align:justify; margin: 0; padding: 0; margin-top: 8px; padding-bottom: 20px; letter-spacing: .3px;\">\r\n                            <span style=\"font-size: 14px; font-family: system-ui;\">Sincerely,</span>\r\n                            <span style=\"font-size: 14px; font-family: system-ui; display: block; font-weight: 800; margin-top: 4px;\">HikiStudio</span>\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n            <footer style=\"margin: 20px 0 0 0;\">\r\n                <div style=\"display: flex;\">\r\n                    <div style=\"margin: auto;\">\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/facebook_njuhc3.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px; margin: 0 6px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/instagram_u8zmrn.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px; background: white; border-radius: 2px; margin-right: 6px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/linkedin_rqd73m.png\">\r\n                        </a>\r\n\r\n                        <a href=\"#\" style=\"text-decoration: none;\">\r\n                            <img style=\"width: 30px;\"\r\n                            src=\"https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1676563217/HikiComic/Icon/pinterest_cwfypv.png\">\r\n                        </a>\r\n                    </div>\r\n                </div>\r\n\r\n                <div>\r\n                    <p style=\"text-align: center; margin: 0; font-family: 'Open Sans'; font-size: 13px; margin-top: 10px;\">800 Broadway Suit 1500 New York, NY 000423, USA</p>\r\n                </div>\r\n\r\n                <div style=\"font-family:'Open Sans'; font-size:12px; font-weight:400; letter-spacing:.4px; line-height:1.4; \r\n                    text-align:center;color:#444\">\r\n                    <p style=\"text-align:center\">\r\n                        <strong>| Privacy Policy | Contact Details | &nbsp;&nbsp;</strong>\r\n                    </p>\r\n                </div>\r\n            </footer>\r\n        </div>\r\n    </div>";
        }

        public static string SendMailPaymentConfirmationSuccess = "Email has been successfully sent.";
        #endregion

        #region comic detail
        public static string ComicFollowingSuccess = "You have successfully added the manga series to your comics list.";

        public static string UnfollowComicSuccess = "The comic series has been successfully unfollowed.";
        #endregion

        #region coin deposit
        public static string DepositSuccess = "The deposit has been successfully made into the account.";

        public static string PendingDeposit = "We're sorry to inform you that your deposit transaction is currently unresolved. Please contact our customer service team immediately to help you resolve this issue. Our team is available to assist you daily.";

        public static string DepositNotSuccess = "An error occurred. Coin deposit failed.";

        public static string DepositStatusCompleted = "We couldn't change the status as requested. But, we want to assure you that your payment has been processed without any issues.";

        public static string DepositStatusFailed = "We're sorry to inform you that the request to change payment status has failed because your payment transaction was unsuccessful.";

        public static string DepositStatusPendingToFailed = "We regret to inform you that the payment status has been changed from pending to failed. Please check your payment details and try again.";

        public static string DepositStatusPendingToCompleted = "Payment status update: Completed. Your payment has been processed successfully.";

        public static string CoinDepositHistoryClean = "Your COIN deposit history has been wiped clean. You're ready to start fresh.";
        #endregion

        #region coin usage
        public static string BuyChapterComicSuccess = "Buy comic chapter successfully.";

        public static string BoughtThisChapterBefore = "Bought this chapter before.";

        public static string HaveNotPurchasedChapter = "Oops! It looks like you don't have access to this chapter. To purchase it, please visit our website and complete the checkout process.";

        public static string CoinUsageHistoryClean = "Your COIN usage history has been wiped clean. You're ready to start fresh.";
        #endregion

        #region notifications
        public static string InvalidNotificationMethod = "Choose the wrong method to generate the message. Please try again later.";

        public static string UnableToDeleteNotification = "Unable to delete this notification because it is not a system notification.";

        public static string UnableToReadNotification = "You can only read your own notifications, you cannot read notifications from others.";

        public static string MarkAllNotificationsAsRead = "You have successfully marked all your notifications as read."; 
        
        public static string UserDeleteAllNotifications = "You have successfully deleted all your notifications.";


        #endregion

        #region user role upgrade request
        public static string UserApprovalSuccess = "User has been successfully approved.";

        public static string UserRejectSuccess = "User has been successfully rejected.";

        #endregion

        #region user email confirmation
        public static string UserEmailConfirmationInvalidToken = "Invalid token.";

        public static string UserEmailConfirmationTokenExpired = "Token has expired.";

        public static string UserEmailConfirmationVerificationFailed = "Verification failed.";

        public static string UserEmailConfirmationVerificationSuccess = "Congratulations! Your email has been successfully verified.";
        #endregion

        #region approve & reject | comic & chapter
        public static string ApproveSuccess = "The comic has been approved successfully.";

        public static string RejectSuccess = "Reject to approve the comic successfully.";
        #endregion
    }
}
