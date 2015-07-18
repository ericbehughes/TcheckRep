using System;
using Microsoft.WindowsAzure.Mobile.Service;

namespace rentproofService.DataObjects
{
    public class User : EntityData
    {
        public DateTime DOB { get; set; }

        public int SSN { get; set; }

        public byte[] PictureId { get; set; }

        public string Email { get; set; }
    }
}