
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
		private EditText _Mobile;
		private EditText _Country;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.ApplicantInfoInputView);
			// Create your application here
			_FirstName = FindViewById<EditText>(Resource.Id.txtScrollInfoInputFirstName);
			_LastName = FindViewById<EditText>(Resource.Id.txtScrollInfoInputLastName);
			_Gender = FindViewById<EditText>(Resource.Id.txtScrollInfoInputGender);
			_DateOfBirth = FindViewById<EditText>(Resource.Id.txtScrollInfoInputDateOfBirth);

			//_Country = FindViewById<EditText>(Resource.Id.txtScrollInfoInputDateOfBirth);
			_SubmitQueryInfo = FindViewById<Button>(Resource.Id.btnScrollInfoInputSubmit);
			_SubmitQueryInfo.Click += async (sender, e) => {

				var model = new Applicant {

					//FirstName = Guid.NewGuid().ToString(),


					FirstName = _FirstName.Text,
					LastName = _LastName.Text,
					Gender = _Gender.Text,
					DateOfBirth = _DateOfBirth.Text,
					Mobile = "1324356475",
					Country = "can"
	
					//LastName = Guid.NewGuid().ToString()
				};

				try {
					// authenticate

					// create new applicant (applicant is returned with ID)

					var applicant = await OnFido.API.OnFidoService.CreateApplicant(model);
					applicant = await OnFido.API.OnFidoService.GetApplicantById(applicant.Id);

					var applicantIntentInfo = new Intent(this, typeof (ReportMainController));

					applicantIntentInfo.PutExtra("Applicant",JsonConvert.SerializeObject(applicant));
					//_reportList.Add(applicant);
					this.StartActivity(applicantIntentInfo);
				

				} catch (Exception) {
					throw;
				}
			};



		}


	}
}
