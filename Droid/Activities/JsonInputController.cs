
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
		


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.ApplicantInfoInputView);
			_SubmitQueryInfo = FindViewById<Button>(Resource.Id.btnScrollInfoInputSubmit);
			_SubmitQueryInfo.Click += async (sender, e) => {

				var model = new Applicant {

					FirstName = FindViewById<EditText>(Resource.Id.txtScrollInfoInputFirstName).Text,
					LastName = FindViewById<EditText>(Resource.Id.txtScrollInfoInputLastName).Text,
					Gender = FindViewById<EditText>(Resource.Id.txtScrollInfoInputGender).Text,
					DateOfBirth = FindViewById<EditText>(Resource.Id.txtScrollInfoInputDateOfBirth).Text,
					Mobile = FindViewById<EditText>(Resource.Id.txtScrollInfoInputMobile).Text,
					Country = FindViewById<EditText>(Resource.Id.txtScrollInfoInputCountry).Text
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
