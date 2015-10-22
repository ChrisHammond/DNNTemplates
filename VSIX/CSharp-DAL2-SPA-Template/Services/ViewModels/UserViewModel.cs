using DotNetNuke.Entities.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace $rootnamespace$$safeprojectname$.Services.ViewModels
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UserViewModel
    {
        public UserViewModel(UserInfo t)
        {
            Id = t.UserID;
            Name = t.DisplayName;
        }

        public UserViewModel() { }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}