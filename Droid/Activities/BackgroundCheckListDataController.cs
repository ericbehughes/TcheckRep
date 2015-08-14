using System.Threading.Tasks;
using System.Collections.Generic;
using OnFido.API.Models;



namespace TCheck.Droid
{
	public static class BackgroundCheckListDataController
	{
		public static async Task<List<Applicant>> GetAllChecksAsync()
		{
			return await Task.Factory.StartNew(() => GetAllChecks());
		}

		public static List<Applicant> GetAllChecks()
		{
			var backgroundCheckList = new List<Applicant>();

			const int numberOfPermutations = 1;
			for(int i = 0; i < numberOfPermutations; i++)

			{
				backgroundCheckList.Add(new Applicant()
					{
						



					});

			


			}

			return backgroundCheckList;
		}
	}
}

