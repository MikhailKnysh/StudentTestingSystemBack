namespace STS.Common.Constans
{
    public static class ErrorConstants
    {
        public static class CommonErrors
        {
            public const string DataNotFound = "Data not found.";
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
    }
}