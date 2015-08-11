using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace TCheck.Droid
{
	//The ViewHolder Pattern is built into the RecyclerView,
	//So we must create a view holder as this will act as a cache
	//for our View references.
	public class BackgroundCheckRowHolder : RecyclerView.ViewHolder
	{
		public BackgroundCheckRowHolder(View itemView, Action<int> listener)
			: base(itemView)
		{
			//Creates and caches our views defined in our layout
			ProfileRowPhotoView = itemView.FindViewById<ImageView>(Resource.Id.profilePhotoView);
			ProfileRowName = itemView.FindViewById<TextView>(Resource.Id.profileName);
			ProfileRowBiography = itemView.FindViewById<TextView>(Resource.Id.profileBiography);
			ProfileRowtextfield2 = itemView.FindViewById<TextView>(Resource.Id.profileTextField2);
			ProfileRowtextfield3 = itemView.FindViewById<TextView>(Resource.Id.profileTextField3);
			ProfileRowtextfield4 = itemView.FindViewById<TextView>(Resource.Id.profileTextField4);
			// Detect user clicks on the item view and report which item
			// was clicked (by position) to the listener:
			itemView.Click += (sender, e) => listener(AdapterPosition);
		}
		// profile binding for view holder
		public ImageView ProfileRowPhotoView { get; set; }
		public TextView ProfileRowName { get; set; }
		public TextView ProfileRowBiography { get; set; }
		public TextView ProfileRowtextfield2 { get; set; }
		public TextView ProfileRowtextfield3 { get; set; }
		public TextView ProfileRowtextfield4 { get; set; }
	}
}