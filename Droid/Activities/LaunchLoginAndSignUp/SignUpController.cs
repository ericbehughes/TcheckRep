
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
using RentProof.API;

namespace TCheck.Droid
{
	[Activity (Label = "SignUpController")]			
	public class SignUpController : Activity
	{
			private Button _BtnSignUp;

			protected override void OnCreate (Bundle bundle){
				base.OnCreate (bundle);
			SetContentView (Resource.Layout.SignUpView);
			_BtnSignUp = FindViewById<Button>(Resource.Id.btnAppLaunchSignUp);
			_BtnSignUp.Click += BtnSignUp_Click; 
			}

		private async void BtnSignUp_Click(object sender, EventArgs e)
		{
			
				// grab user info
			var name = FindViewById<EditText>(Resource.Id.txtSignUpFirstName).Text;
			var email = FindViewById<EditText>(Resource.Id.txtSignUpEmail).Text;
			var sin = FindViewById<EditText>(Resource.Id.txtSignUpSSN).Text;
			var password = FindViewById<EditText>(Resource.Id.txtSignUpPassword).Text;

			// build models
			var registerModel = new RegisterBindingModel
			{
				Name = name,
				Email = email,
				SIN = Int32.Parse(sin),
				Password = password
			};

			var loginModel = new LoginBindingModel
			{
				Email = email,
				Password = password
			};

			// register user
			//await API.Service.Register(registerModel);
			await RentProof.API.Service.Register (registerModel);

			// auto-authenticate
			await RentProof.API.Service.Login (loginModel);

			// user has clicked on signup button
			var intent = new Intent(this, typeof (MainMenuController));
			this.StartActivity (intent);

			}
		}
	}


