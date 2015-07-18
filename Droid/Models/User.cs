using System;
using Newtonsoft.Json;

namespace TCheck.Droid.Models
{
    public class User
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "dob")]
        public DateTime DOB { get; set; }

        [JsonProperty(PropertyName = "ssn")]
        public int SSN { get; set; }

        [JsonProperty(PropertyName = "pictureid")]
        public byte[] PictureID { get; set; }
    }

    public class UserWrapper : Java.Lang.Object
    {
        public UserWrapper(User item)
        {
            User = item;
        }

        public User User { get; private set; }
    }
}