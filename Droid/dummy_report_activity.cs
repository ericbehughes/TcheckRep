
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
	[Activity (Label = "dummy_report_activity")]			
	public class dummy_report_activity : Activity
	{
		private Button mButtonHome;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.dummy_report);
			mButtonHome = FindViewById<Button>(Resource.Id.buttonHome);
			mButtonHome.Click += mButtonHome_Click;

			// Create your application here
		}

		void mButtonHome_Click (object sender, EventArgs args)
		{
			Intent intent = new Intent (this, typeof(main_menu_activity));
			this.StartActivity (intent);

		}
	}
}

