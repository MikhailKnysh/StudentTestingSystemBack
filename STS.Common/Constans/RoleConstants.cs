namespace STS.Common.Constans
{
    public static class RoleConstants
    {
        public const string Admin = "Admin";
        public const string Teacher = "Teacher";
        public const string Student = "Student";

        public static class PolicyConstants
        {
            public const string AdminPolicy = "AdminPolicy";
            public const string CommonPolicy = "CommonPolicy";
            public const string AdminAndTeacherPolicy = "AdminAndTeacherPolicy";
        }
    }
}