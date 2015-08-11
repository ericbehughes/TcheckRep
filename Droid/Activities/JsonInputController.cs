
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




namespace TCheck.Droid
{
	[Activity (Label = "JsonInputController")]			
	public class JsonInputController : Activity
	{
		private Button _submitQueryInfo;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.InfoInputView);
			// Create your application here
			_submitQueryInfo = FindViewById<Button>(Resource.Id.btnSubmit);
			_submitQueryInfo.Click += async (sender, e) => {
				//var firstName = FindViewById<EditText> (Resource.Id.txtFirstName).Text;
				//var lastName = FindViewById<EditText> (Resource.Id.txtLastName).Text;
				//var gender = FindViewById<EditText> (Resource.Id.txtGender).Text;
				//var dateOfBirth = FindViewById<EditText> (Resource.Id.txtDateOfBirth).Text;


				var model = new AccountBindingModel {

					FirstName = "eric",
					LastName = "hughes",
					//Gender = "male",
					//DateOfBirth = "1992-08-21",
				};

				try {
					// authenticate

					await OnFido.API.OnFidoService.Query (model);


				} catch (Exception) {
					throw;
				}
			};


		}

		private void ParseAndDisplay (AccountBindingModel model)
		{
			// Get the weather reporting fields from the layout resource: 
			TextView FirstName = FindViewById<TextView>(Resource.Id.textView1);
			TextView LastName = FindViewById<TextView>(Resource.Id.textView2);
			TextView Gender = FindViewById<TextView>(Resource.Id.textView3);
			TextView DateOfBirth = FindViewById<TextView>(Resource.Id.textView4);

			FirstName.Text = model.FirstName;
			LastName.Text = model.LastName;
			//Gender.Text = model.Gender;
			//DateOfBirth.Text = model.DateOfBirth;
		}
	}
}
