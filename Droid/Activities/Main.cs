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


		private Button mButtonSignUp; 
		private Button mButtonSignIn;

		//public static string clientId = "e78bf806-c33a-45e4-a7c3-82d63adffde9";
		//public static string commonAuthority = "https://login.windows.net/common";
		//public static Uri returnUri = new Uri("http://rentproof-azure-redirect");
	
		protected override void OnCreate (Bundle bundle){
			//no action bar
			RequestWindowFeature(WindowFeatures.NoTitle);
			base.OnCreate (bundle);
			// sets screen to Launch.axml
			SetContentView (Resource.Layout.Launch);
			//sign in button find view with event handler underneath
			mButtonSignIn = FindViewById<Button>(Resource.Id.buttonSignIn);
			mButtonSignIn.Click += mButtonSignIn_Click;
			//sign up button find view with event handler underneath
			mButtonSignUp = FindViewById<Button>(Resource.Id.buttonSignUp);
			mButtonSignUp.Click += (object sender, EventArgs args) =>{
				//sign up pop is a fragment with its own class SignUpPopUp
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				SignUpPopUp signUpPopUp = new SignUpPopUp();
				signUpPopUp.Show(transaction, "sign_up fragment");
				signUpPopUp.mOnSignUpComplete += mSignUpPopUp_mOnSignUpComplete;
				};
				

		}

		void mSignUpPopUp_mOnSignUpComplete (object sender, OnSignUpEvent e){
			Intent intent = new Intent (this, typeof(Main_Menu_Activity));
			this.StartActivity (intent);
			Finish (); 
		}

		void mButtonSignIn_Click (object sender, EventArgs e){
			Intent intent = new Intent (this, typeof(Login_Activity));
			this.StartActivity (intent);
			Finish (); 
		}


	}
}


