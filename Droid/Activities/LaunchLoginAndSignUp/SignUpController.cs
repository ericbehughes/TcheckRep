
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
using RentProof.API.Models;


namespace TCheck.Droid
{
	[Activity (Label = "SignUpController")]			
	public class SignUpController : Activity
	{
		
		private EditText _name;
		private EditText _email;
		private EditText _SSN;
		private EditText _Password;

		protected override void OnCreate (Bundle bundle){

			base.OnCreate (bundle);
			SetContentView (Resource.Layout.SignUpView);
			_name = FindViewById<EditText>(Resource.Id.txtSignUpFirstName);
			_email = FindViewById<EditText>(Resource.Id.txtSignUpEmail);
			_SSN = FindViewById<EditText>(Resource.Id.txtSignUpSSN);
			_Password = FindViewById<EditText>(Resource.Id.txtSignUpPassword);

			var BtnSignUp = FindViewById<Button>(Resource.Id.btnSignUpViewButton);

			BtnSignUp.Click += BtnSignUp_Click; 

			}

		private async void BtnSignUp_Click(object sender, EventArgs args)
		{
			

//			// build models
//			var registerModel = new RegisterBindingModel
//			{
//				Name = _name.Text,
//				Email = _email.Text,
//				SIN = Int32.Parse(_SSN.Text),
//				Password = _Password.Text
//			};
//
//			var loginModel = new LoginBindingModel
//			{
//				Email = _email.Text,
//				Password = _Password.Text
//			};
//
//			 //register user
//			await RentProof.API.Service.Register(registerModel);
//			await  RentProof.API.Service.Register (registerModel);
//
//			// auto-authenticate
//			await RentProof.API.Service.Login (loginModel);

				// user has clicked on signup button
			var intent = new Intent(this, typeof (MainMenuController));
			this.StartActivity (intent);
			}
			


			}
		}
	


