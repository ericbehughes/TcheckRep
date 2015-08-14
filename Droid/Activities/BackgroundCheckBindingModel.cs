using Newtonsoft.Json;
using System;

namespace TCheck.Droid
{
	public class BackgroundCheckBindingModel
	{
		public string id { get; set; }
		public int PhotoResourceId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string gender { get; set; }
		public string dob { get; set; }
		public string href { get; set; }
		public string TenantScore { get; set; }
		public string Biography { get; set; }
		/*
		[JsonProperty(PropertyName = "id")]
		public Guid Id { get; set; }

		[JsonProperty(PropertyName = "first_name")]
		public string FirstName { get; set; }

		[JsonProperty(PropertyName = "last_name")]
		public string LastName { get; set; }

		[JsonProperty(PropertyName = "gender")]
		public string Gender { get; set; }

		[JsonProperty(PropertyName = "dob")]
		public string DateOfBirth { get; set; }
		*/
	}
}


