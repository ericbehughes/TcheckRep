using System.Threading.Tasks;
using System.Collections.Generic;

namespace TCheck.Droid
{
	public static class ReportListController
	{
		public static async Task<List<Report>> GetAllReportsAsync()
		{
			return await Task.Factory.StartNew(() => GetAllReports());
		}

		public static List<Report> GetAllReports()
		{
			var reportList = new List<Report>();

			const int numberOfPermutations = 1;
			for(int i = 0; i < numberOfPermutations; i++)
			{
				reportList.Add(new Report()
					{
						FirstName = "Eric",
						ProfileReportPhoto = Resource.Drawable.picEric

					});

				reportList.Add(new Report()
					{
						FirstName = "Eric",
						ProfileReportPhoto = Resource.Drawable.picEric
					});

			}

			return reportList;
		}
	}
}
