using System.Threading.Tasks;
using System.Collections.Generic;
using OnFido.API.Models;
using Newtonsoft.Json;
using Android.Content;

namespace TCheck.Droid
{
	public static class ReportListController
	{
		
		public static async Task<List<Applicant>> GetAllReportsAsync()
		{
			
			return await Task.Factory.StartNew(() => GetAllReports());
		}

		public static List<Applicant> GetAllReports()
		{
			var reportList = new List<Applicant>();

			const int numberOfPermutations = 1;
			for(int i = 0; i < numberOfPermutations; i++)
			{
				reportList.Add(new Applicant{

					FirstName = "eric"

				});
					
				

			

			}

			return reportList;
		}
	}
}
