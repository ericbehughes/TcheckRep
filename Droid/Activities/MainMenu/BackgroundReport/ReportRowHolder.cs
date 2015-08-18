using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using OnFido.API.Models;
using Newtonsoft.Json;
using Android.Content;

namespace TCheck.Droid
{
	//The ViewHolder Pattern is built into the RecyclerView,
	//So we must create a view holder as this will act as a cache
	//for our View references.
	public class ReportRowHolder : RecyclerView.ViewHolder
	{
		
		public ReportRowHolder(View itemView, Action<int> listener) 
			: base (itemView)
		{
			//Creates and caches our views defined in our layout
			TextView ID,FirstName,LastName,Gender,DateOfBirth;

			itemView.FindViewById<TextView>(Resource.Id.txtReportRowViewID) = ID;
			itemView.FindViewById<TextView>(Resource.Id.txtReportRowViewFirstName)= FirstName;
			itemView.FindViewById<TextView>(Resource.Id.txtReportRowViewLastName) = LastName;
			itemView.FindViewById<TextView>(Resource.Id.txtReportRowViewGender) = Gender;
			itemView.FindViewById<TextView>(Resource.Id.txtReportRowViewDateOfBirth) = DateOfBirth;

			// Detect user clicks on the item view and report which item
			// was clicked (by position) to the listener:
			itemView.Click += delegate (object sender, EventArgs e) {

				listener (base.AdapterPosition);
			};


		}

	}
}

