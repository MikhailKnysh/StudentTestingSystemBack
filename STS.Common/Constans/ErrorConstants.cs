using Microsoft.AspNetCore.Hosting;

namespace STS.Common.Constans
{
    public static class ErrorConstants
    {
        public static class CommonErrors
        {
            public const string DataNotFound = "Data not found.";
        }

        public static class UserError
        {
            public const string UserNotCreated = "User not been created.";
            public const string UserNotUpdated = "User not been updated.";
            public const string UserNotDeleted = "User not been deleted.";
            public const string PasswordNotUpdated = "Password not been updated.";
        }
        
        public static class SubjectErrors
        {
            public const string SubjectNotCreated = "Subject not been created.";
            public const string SubjectNotUpdated = "Subject not been updated.";
            public const string SubjectNotDeleted = "Subject not been deleted.";
        }

        public static class SessionErrors
        {
            public const string SessionNotCreated = "Session not been created.";
            public const string InvalidAuthData = "Invalid Auth data.";
        }

        public static class ThemeErrors
        {
            public const string ThemeNotCreated = "Theme not been created.";
            public const string ThemeNotUpdated = "Theme not been updated.";
            public const string ThemeNotDeleted = "Theme not been deleted.";
        }

        public static class GroupErrors
        {
            public const string GroupNotCreated = "Group not been created.";
            public const string GroupNotUpdated = "Group not been updated.";
            public const string GroupNotDeleted = "Group not been deleted.";
            public const string UserNotAdded = "User not been added to group";
        }
    }
}