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
		public TextView ID, FirstName, LastName, Gender, DateOfBirth,
			Mobile, Country;

		public ReportRowHolder(View itemView, Action<int> listener) 
			: base (itemView)
		{
			//Creates and caches our views defined in our layout

			ID = itemView.FindViewById<TextView> (Resource.Id.txtReportRowViewID);
			FirstName = itemView.FindViewById<TextView> (Resource.Id.txtReportRowViewFirstName);
			LastName = itemView.FindViewById<TextView> (Resource.Id.txtReportRowViewLastName);
			Gender = itemView.FindViewById<TextView>(Resource.Id.txtReportRowViewGender);
			DateOfBirth = itemView.FindViewById<TextView>(Resource.Id.txtReportRowViewDateOfBirth);
			//Mobile = itemView.FindViewById<TextView>(Resource.Id.reportrow);


			// Detect user clicks on the item view and report which item
			// was clicked (by position) to the listener:
			itemView.Click += delegate (object sender, EventArgs e) {

				listener (base.AdapterPosition);
			};


		}

	}
}

