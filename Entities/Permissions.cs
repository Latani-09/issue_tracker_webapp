
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
        {
            $"Permissions.{module}.Create",
            $"Permissions.{module}.View",
            $"Permissions.{module}.Assign",
            $"Permissions.{module}.Edit",
            $"Permissions.{module}.Delete",
        };
        }
        public static class Project
        {
            public const string View = "Permissions.Projects.View";
        public const string Assign = "Permissions.Projects.Assign";
        public const string Create = "Permissions.Projects.Create";
            public const string Edit = "Permissions.Projects.Edit";
            public const string Delete = "Permissions.Projects.Delete";
        }

    public static class Issue
    {
        public const string View = "Permissions.Issues.View";
        public const string Assign = "Permissions.Issues.Assign";
        public const string Create = "Permissions.Issues.Create";
        public const string Edit = "Permissions.Issues.Edit";
        public const string Delete = "Permissions.Issues.Delete";
    }
}
