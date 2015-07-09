
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V7.App;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.Widget;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TCheck.Droid
{
	[Activity (Label = "", Theme="@style/MyTheme")]			
	public class main_menu_activity : ActionBarActivity
	{
		private Button mButtonBackgroundCheck;
		private Button mButtonMyReview;
		private Button mButtonMyQueries;
		private Button mButtonMyProfile;
		private SupportToolbar mToolbar;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(Resource.Layout.main_menu);
			mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
			SetSupportActionBar(mToolbar);
			SupportActionBar.SetHomeButtonEnabled(true);
			SupportActionBar.SetDisplayShowTitleEnabled(true);
			SupportActionBar.SetTitle(Resource.String.app_name);

			mButtonBackgroundCheck = FindViewById<Button>(Resource.Id.buttonQuery);
			mButtonBackgroundCheck.Click += mButtonBackgroundCheck_Click;

			mButtonMyReview = FindViewById<Button>(Resource.Id.buttonReview);
			mButtonMyReview.Click += mButtonMyReview_Click;

			mButtonMyQueries = FindViewById<Button>(Resource.Id.buttonMyQueries);
			mButtonMyQueries.Click += mButtonMyQueries_Click;

			mButtonMyProfile = FindViewById<Button>(Resource.Id.buttonMyProfile);
			mButtonMyProfile.Click += mButtonMyProfile_Click;





		}
		void mButtonBackgroundCheck_Click (object sender, EventArgs args)
		{
			Intent intent = new Intent (this, typeof(query_activity));
			this.StartActivity (intent);

		}

		void mButtonMyReview_Click (object sender, EventArgs e)
		{
			Intent intent = new Intent (this, typeof(my_reviews_activity));
			this.StartActivity (intent);

		}

		void mButtonMyQueries_Click (object sender, EventArgs args)
		{
			Intent intent = new Intent (this, typeof(backgroundreport_activity));
			this.StartActivity (intent);

		}

		void mButtonMyProfile_Click (object sender, EventArgs args)
		{
			Intent intent = new Intent (this, typeof(swipe_activity));
			this.StartActivity (intent);

		}
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.main_action_bar, menu);
			return base.OnCreateOptionsMenu(menu);
		}

	}

	}




