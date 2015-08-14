using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices.Sync;


namespace TCheck.Droid{
	[Activity (Label = "RentProof", MainLauncher = true, Icon = "@drawable/rent_proof_icon" )]
	public class MainActivity : Activity{

		private Button _BtnSignUp; 
		private Button _BtnSignIn;

		protected override void OnCreate (Bundle bundle){
			//no action bar
			RequestWindowFeature(WindowFeatures.NoTitle);
			base.OnCreate (bundle);
			// sets screen to Launch.axml
			SetContentView (Resource.Layout.AppLaunchView);
			//sign in button find view with event handler underneath
			_BtnSignIn = FindViewById<Button>(Resource.Id.buttonSignIn);
			_BtnSignIn.Click += SignInComplete_Click;
			//sign up button find view with event handler underneath
			_BtnSignUp = FindViewById<Button>(Resource.Id.buttonSignUp);
			_BtnSignUp.Click += SignUpComplete_Click;
		}

		void SignInComplete_Click (object sender, EventArgs e){
			Intent intent = new Intent (this, typeof(LoginController));
			this.StartActivity (intent);
			Finish (); 
		}

		void SignUpComplete_Click (object sender, EventArgs e){
			Intent intent = new Intent (this, typeof(SignUpController));
			this.StartActivity (intent);
			Finish (); 
		}

	}
}


