﻿namespace Issue_tracker_webapp.Models
{
    public class ManageUserRolesViewModel
    {
        public string UserId { get; set; }
        public string userName { get; set; }
        public IList<UserRolesViewModel> UserRoles { get; set; }
    }
    public class UserRolesViewModel
    {
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}
