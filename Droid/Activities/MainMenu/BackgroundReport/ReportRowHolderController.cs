using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace TCheck.Droid
{
	//The ViewHolder Pattern is built into the RecyclerView,
	//So we must create a view holder as this will act as a cache
	//for our View references.
	public class ReportRowHolder : RecyclerView.ViewHolder
	{
		public ImageView ReportProfilePhoto { get; set; }
		public TextView ReportProfileFirstName; 


		public ReportRowHolder(View itemView, Action<int> listener) 
			: base (itemView)
		{
			//Creates and caches our views defined in our layout
			ReportProfilePhoto = itemView.FindViewById<ImageView>(Resource.Id.imgReportRowViewPicture);
			ReportProfileFirstName = itemView.FindViewById<TextView>(Resource.Id.txtReportRowViewFirstName);


			// Detect user clicks on the item view and report which item
			// was clicked (by position) to the listener:
			itemView.Click += (sender, e) => listener (base.AdapterPosition);
		}
	}
}

