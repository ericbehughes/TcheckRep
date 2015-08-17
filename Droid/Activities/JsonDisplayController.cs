
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using OnFido.API.Models;

namespace TCheck.Droid
{
	[Activity (Label = "JsonDisplayController")]			
	public class JsonDisplayController : Activity
	{
		
		private TextView _DisplayCreatedAt;
		private TextView _DisplayFirstName;
		private TextView _DisplayLastName;
		private TextView _DisplayGender;
		private TextView _DisplayDateOfBirth;
		private TextView _DisplayTelephone;
		private TextView _DisplayMobile;
		private TextView _DisplayCountry;
		private TextView _DisplayHref;
		//private Applicant _ApplicantReport;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.JsonDisplayView);
			// Create your application here

			_DisplayCreatedAt = FindViewById<TextView>(Resource.Id.JsonDisplayCreatedAt);
			_DisplayFirstName = FindViewById<TextView> (Resource.Id.JsonDisplayFirstName);
			_DisplayLastName = FindViewById<TextView> (Resource.Id.JsonDisplayLastName);
			_DisplayGender = FindViewById<TextView> (Resource.Id.JsonDisplayGender);
			_DisplayDateOfBirth = FindViewById<TextView> (Resource.Id.JsonDisplayDateOfBirth);
			_DisplayTelephone = FindViewById<TextView> (Resource.Id.JsonDisplayTelephone);
			_DisplayMobile = FindViewById<TextView> (Resource.Id.JsonDisplayTelephone);
			_DisplayCountry = FindViewById<TextView> (Resource.Id.JsonDisplayCountry);
			//_DisplayHref = FindViewById<TextView> (Resource.Id.JsonDisplayHref);

			//_ApplicantReport = JsonConvert.DeserializeObject<Applicant> (Intent.GetStringExtra ("Applicant"));
			/*
			_DisplayCreatedAt.Text = _ApplicantReport.CreatedAt;
			_DisplayFirstName.Text = _ApplicantReport.FirstName;
			_DisplayLastName.Text = _ApplicantReport.LastName;
			_DisplayGender.Text = _ApplicantReport.Gender;
			_DisplayDateOfBirth.Text = _ApplicantReport.DateOfBirth;
			_DisplayTelephone.Text = _ApplicantReport.Telephone;
			_DisplayMobile.Text = _ApplicantReport.Mobile;
			_DisplayCountry.Text = _ApplicantReport.Country;
			//_DisplayHref.Text = _ApplicantReport.;
*/
		}
	}
}

