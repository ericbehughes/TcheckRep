using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TCheck.Droid
{
	[Activity (Label = "TCheck.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		
		private Button mButtonSignUp;
		private Button mButtonSignIn;
	
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.launch_screen);

			mButtonSignUp = FindViewById<Button>(Resource.Id.buttonSignUp);
			mButtonSignUp.Click += (object sender, EventArgs args) =>
				{
				//pull up dialog
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				dialog_SignUp signUpDialog = new dialog_SignUp();
				signUpDialog.Show(transaction, "dialog fragment");
				signUpDialog.mOnSignUpComplete += signUpDialog_mOnSignUpComplete;
				};


			mButtonSignIn = FindViewById<Button>(Resource.Id.buttonSignIn);
			mButtonSignIn.Click += mButtonSignIn_Click;

		}


		void signUpDialog_mOnSignUpComplete (object sender, OnSignUpEventArgs e)
		{
			Intent intent = new Intent (this, typeof(main_menu_activity));
			this.StartActivity (intent);
			this.FinishActivity(0);


		}

		void mButtonSignIn_Click (object sender, EventArgs args)
		{	
			Intent intent = new Intent (this, typeof(login_activity));
			this.StartActivity (intent);
			this.FinishActivity(0);
		}



			
		
	}
}


