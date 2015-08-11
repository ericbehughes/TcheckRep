using System;
using System.Collections.Generic;
using Android.Content.Res;
using Android.Support.V7.Widget;
using Android.Views;

namespace TCheck.Droid
{
	public class BackgroundCheckRecyclerViewAdapter : RecyclerView.Adapter
	{
		private readonly List<BackgroundCheckBindingModel> _backgroundCheckProfiles;
		private readonly BackgroundCheckImageManager _imageManager;

		public BackgroundCheckRecyclerViewAdapter(List<BackgroundCheckBindingModel> backgroundCheckProfiles, Resources resources)
		{
			_backgroundCheckProfiles = backgroundCheckProfiles;
			_imageManager = new BackgroundCheckImageManager(resources);
		}

		//Must override, just like regular Adapters
		public override int ItemCount
		{
			get { return _backgroundCheckProfiles.Count; }
		}

		//Create an Event so that our our clients can act when a user clicks
		//on each individual item.
		public event EventHandler<int> ItemClick;
		//Must override, this inflates our Layout and instantiates and assigns
		//it to the ViewHolder.
		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			//Inflate our CrewMemberItem Layout
			var itemView = LayoutInflater.From(parent.Context)
				.Inflate(Resource.Layout.BackgroundCheckRowView, parent, false);

			//Create our ViewHolder to cache the layout view references and register
			//the OnClick event.
			var viewHolder = new BackgroundCheckRowHolder(itemView, OnClick);

			return viewHolder;
		}

		//Must override, this is the important one.  This method is used to
		//bind our current data to your view holder.  Think of this as the equivalent
		//of GetView for regular Adapters.
		public override async void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			var viewHolder = holder as BackgroundCheckRowHolder;

			var currentBackgroundCheck = _backgroundCheckProfiles[position];

			//Bind our data from our data source to our View References
			viewHolder.ProfileRowName.Text = currentBackgroundCheck.FirstName;
			viewHolder.ProfileRowBiography.Text = String.Format("{0}", currentBackgroundCheck.Biography);
			viewHolder.ProfileRowtextfield2.Text = currentBackgroundCheck.LastName;
			viewHolder.ProfileRowtextfield3.Text = currentBackgroundCheck.dob;
			viewHolder.ProfileRowtextfield4.Text = currentBackgroundCheck.id;
			var photoBitmap =
				await _imageManager.GetScaledDownBitmapFromResourceAsync(currentBackgroundCheck.PhotoResourceId, 120, 120);
			viewHolder.ProfileRowPhotoView.SetImageBitmap(photoBitmap);
		}

		//This will fire any event handlers that are registered with our ItemClick
		//event.
		private void OnClick(int position)
		{
			if (ItemClick != null)
			{
				ItemClick(this, position);
			}
		}

		//Since this example uses a lot of Bitmaps, we want to do some house cleaning
		//and make them available for garbage collecting as soon as possible.
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (_imageManager != null)
			{
				_imageManager.Dispose();
			}
		}
	}
}