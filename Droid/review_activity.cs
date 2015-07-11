
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

namespace TCheck.Droid{
	[Activity (Label = "review_activity")]			
	public class review_activity : Activity{
		private Button mButtonSurvey; // id -> buttonSurvey
		private Button mButtonHome; //id-> buttonHome

		protected override void OnCreate (Bundle bundle){
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.review_screen);

			mButtonSurvey = FindViewById<Button>(Resource.Id.buttonSurvey);
			mButtonSurvey.Click += mButtonSurvey_Click;

			mButtonHome = FindViewById<Button>(Resource.Id.buttonHome);
			mButtonHome.Click += mButtonHome_Click;

		}

		void mButtonMenuButton_Click (object sender, EventArgs args){
			Intent intent = new Intent (this, typeof(main_menu_activity));
			this.StartActivity (intent);
			Finish ();

		}

		void mButtonSurvey_Click (object sender, EventArgs e){
			Intent intent = new Intent (this, typeof(survey_activity));
			this.StartActivity (intent);
		}

		void mButtonHome_Click (object sender, EventArgs e){
			Intent intent = new Intent (this, typeof(main_menu_activity));
			this.StartActivity (intent);
			Finish ();
		}
	}
}


