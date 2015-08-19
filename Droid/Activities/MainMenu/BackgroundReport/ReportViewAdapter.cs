﻿using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Content.Res;
using OnFido.API.Models;
using Newtonsoft.Json;
using Android.Content;

namespace TCheck.Droid
{
	public class ReportViewAdapter : RecyclerView.Adapter
	{
		//Create an Event so that our our clients can act when a user clicks
		//on each individual item.
		public event EventHandler<int> ItemClick;
		private List<Applicant> _reportList;

		private Applicant ApplicantReport;
		private readonly ImageManager _imageManager;



		public ReportViewAdapter(List<Applicant> applicantReport, Resources resources)
		{
			_reportList = applicantReport;
			_imageManager = new ImageManager(resources);
		}

		//Must override, just like regular Adapters
		public override int ItemCount
		{
			get
			{
				return _reportList.Count;
			}
		}

		//Must override, this inflates our Layout and instantiates and assigns
		//it to the ViewHolder.
		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			//Inflate our CrewMemberItem Layout
			View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ReportRowContainerView, parent, false);

			//Create our ViewHolder to cache the layout view references and register
			//the OnClick event.
			var viewHolder = new ReportRowHolder(itemView, OnClick);

			return viewHolder;
		}

		//Must override, this is the important one.  This method is used to
		//bind our current data to your view holder.  Think of this as the equivalent
		//of GetView for regular Adapters.
		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			var viewHolder = holder as ReportRowHolder;

			ApplicantReport = _reportList[position];

			//Bind our data from our data source to our View References
			viewHolder.ID.Text = ApplicantReport.Id.ToString();
			viewHolder.FirstName.Text = ApplicantReport.FirstName;
			viewHolder.LastName.Text = ApplicantReport.LastName;
			viewHolder.Gender.Text = ApplicantReport.Gender;
			viewHolder.DateOfBirth.Text = ApplicantReport.DateOfBirth;


			//var photoBitmap = await _imageManager.GetScaledDownBitmapFromResourceAsync(currentReport.ProfileReportPhoto, 120, 120);
			//viewHolder.ReportProfilePhoto.SetImageBitmap(photoBitmap);
		}

		//This will fire any event handlers that are registered with our ItemClick
		//event.
		private void OnClick(int position)
		{
			if(ItemClick != null)
			{
				
				ItemClick(this, position);
			}
		}

		//Since this example uses a lot of Bitmaps, we want to do some house cleaning
		//and make them available for garbage collecting as soon as possible.
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if(_imageManager != null)
			{
				_imageManager.Dispose();
			}

		}
	}
}

