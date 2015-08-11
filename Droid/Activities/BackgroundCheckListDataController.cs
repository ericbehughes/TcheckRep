using System.Threading.Tasks;
using System.Collections.Generic;


namespace TCheck.Droid
{
	public static class BackgroundCheckListDataController
	{
		public static async Task<List<BackgroundCheckBindingModel>> GetAllChecksAsync()
		{
			return await Task.Factory.StartNew(() => GetAllChecks());
		}

		public static List<BackgroundCheckBindingModel> GetAllChecks()
		{
			var backgroundCheckList = new List<BackgroundCheckBindingModel>();

			const int numberOfPermutations = 1;
			for(int i = 0; i < numberOfPermutations; i++)

			{
				backgroundCheckList.Add(new BackgroundCheckBindingModel()
					{
						id = "87654321",
						PhotoResourceId = Resource.Drawable.ericAngelList,
						FirstName = "eric",
						LastName = "Hughes",
						dob = "21 august 1992",
						TenantScore = "tenantScore",
						Biography = "My name is eric"

					});

				backgroundCheckList.Add(new BackgroundCheckBindingModel()
					{
						id = "87654321",
						PhotoResourceId = Resource.Drawable.ericAngelList,
						FirstName = "eric",
						LastName = "Hughes",
						dob = "Human",
						href = "gafsdfgqeadfs",
						Biography = "gafsdfgqeadfs"

					});



			}

			return backgroundCheckList;
		}
	}
}

