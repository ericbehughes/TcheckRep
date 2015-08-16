
using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;

using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OnFido.API.Models;
using Newtonsoft.Json;




namespace TCheck.Droid
{
	[Activity (Label = "JsonInputController")]			
	public class JsonInputController : Activity
	{
		private Button _SubmitQueryInfo;
		private EditText _FirstName;
		private EditText _LastName;
		private EditText _Gender;
		private EditText _DateOfBirth;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.InfoInputView);
			// Create your application here
			_FirstName = FindViewById<EditText>(Resource.Id.txtFirstName);
			_LastName = FindViewById<EditText>(Resource.Id.txtLastName);
			_Gender = FindViewById<EditText>(Resource.Id.txtGender);
			_DateOfBirth = FindViewById<EditText>(Resource.Id.txtDateOfBirth);
			_SubmitQueryInfo = FindViewById<Button>(Resource.Id.btnSubmit);
			_SubmitQueryInfo.Click += async (sender, e) => {

				var model = new Applicant {

					//FirstName = Guid.NewGuid().ToString(),
					FirstName = _FirstName.Text,
					LastName = _LastName.Text,
					Gender = _Gender.Text,
					DateOfBirth = _DateOfBirth.Text,
					//LastName = Guid.NewGuid().ToString()
				};

				try {
					// authenticate

					// create new applicant (applicant is returned with ID)

					var applicant = await OnFido.API.OnFidoService.CreateApplicant(model);
					applicant = await OnFido.API.OnFidoService.GetApplicantById(applicant.Id);
					FindViewById<TextView>(Resource.Id.textView1).Text = applicant.FirstName;
					FindViewById<TextView>(Resource.Id.textView2).Text = applicant.LastName;
					FindViewById<TextView>(Resource.Id.textView3).Text = applicant.Gender;
					FindViewById<TextView>(Resource.Id.textView4).Text = applicant.DateOfBirth;

					var applicantIntentInfo = new Intent(this, typeof (ReportMainController));
					this.StartActivity(applicantIntentInfo);

					// get applicant info
				} catch (Exception) {
					throw;
				}
			};



		}

		private void ParseAndDisplay (Applicant model)
		{
			// Get the weather reporting fields from the layout resource: 
	
			//Gender.Text = model.Gender;
			//DateOfBirth.Text = model.DateOfBirth;
		}
	}
}
