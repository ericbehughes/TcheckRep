
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

namespace TCheck.Droid
{
	[Activity (Label = "SignUpController")]			
	public class SignUpController : Activity
	{
			private EditText _FirstNameSignUp;
			private EditText _EmailSignUp;
			private EditText _SecurityNumberSignUp;
			private EditText _PasswordSignUp;
			private Button _BtnSignUp;

			protected override void OnCreate (Bundle bundle){
				base.OnCreate (bundle);
			SetContentView (Resource.Layout.SignUpView);
				_FirstNameSignUp = FindViewById<EditText> (Resource.Id.txtFirstName);
				_EmailSignUp = FindViewById<EditText> (Resource.Id.txtEmail);
				_SecurityNumberSignUp = FindViewById<EditText> (Resource.Id.txtSecurityNumber);
				_PasswordSignUp = FindViewById<EditText> (Resource.Id.txtPassword);
				_BtnSignUp = FindViewById<Button> (Resource.Id.popUpButton);

				_BtnSignUp.Click += BtnSignUp_Click; 
			}

			void BtnSignUp_Click(object sender, EventArgs e){

				//user has clicked on signup button
			Intent intent = new Intent (this, typeof(MainMenuController));
				this.StartActivity (intent);
				Finish ();
			}
		}
	}


