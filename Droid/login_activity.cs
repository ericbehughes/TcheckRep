
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
	[Activity (Label = "login_activity")]			
	public class login_activity : Activity
	{
		private Button mButtonLogin;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.login_screen);
			mButtonLogin = FindViewById<Button>(Resource.Id.buttonLogIn);
			mButtonLogin.Click += mButtonLogin_Click;


		}

		void mButtonLogin_Click (object sender, EventArgs args)
		{
			Intent intent = new Intent (this, typeof(main_menu_activity));
			this.StartActivity (intent);
			Finish ();


		}
	}
}

