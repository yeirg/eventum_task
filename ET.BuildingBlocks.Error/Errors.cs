using ET.BuildingBlocks.Error.Exceptions.Business;
using ET.BuildingBlocks.Error.Exceptions.Validation;

namespace ET.BuildingBlocks.Error;

public static partial class Errors
{
    public static class Users
    {
        public static class Business
        {
            public static class InvalidCredentials
            {
                public const string Code = "ERR_AUTH_0000";
                public const string Message = "Invalid login or password";

                public static BusinessException New()
                {
                    return new BusinessException(Code, Message);
                }
            }
        }
        
        public static class Validation
        {
            /// <summary>
            /// Ошибка связанная с передачей пустого логина.
            /// </summary>
            public static class EmptyLogin
            {
                public const string Code = "ERR_AUTH_0010";
                public const string Message = "Login cannot be empty";

                public static ValidationException New()
                {
                    return new ValidationException("Login", Code, Message);
                }
            }

            /// <summary>
            /// Ошибка связанная с передачей пустого хэша пароля.
            /// </summary>
            public static class EmptyPasswordHash
            {
                public const string Code = "ERR_AUTH_0011";
                public const string Message = "Password hash cannot be empty";

                public static ValidationException New()
                {
                    return new ValidationException("PasswordHash", Code, Message);
                }
            }
        }
    }
}