using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;

namespace TCheck.Droid{
	[Activity (Label = "main_menu_activity",Theme="@style/MyTheme")]
	public class main_menu_activity : ActionBarActivity{

		private Button mButtonBackgroundCheck; 
		private Button mButtonMyReview;
		private Button mButtonMyQueries;
		private Button mButtonMyProfile;

		private SupportToolbar mToolbar;
		private MyActionBarDrawerToggle mDrawerToggle;
		private DrawerLayout mDrawerLayout;
		private ListView mLeftDrawer;
		private ListView mRightDrawer;
		private ArrayAdapter mLeftAdapter;
		private ArrayAdapter mRightAdapter;
		private List<string> mLeftDataSet;
		private List<string> mRightDataSet;


		protected override void OnCreate (Bundle bundle){
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.main_menu);

			mButtonBackgroundCheck = FindViewById<Button>(Resource.Id.buttonQuery);
			mButtonBackgroundCheck.Click += mButtonBackgroundCheck_Click;

			mButtonMyReview = FindViewById<Button>(Resource.Id.buttonReview);
			mButtonMyReview.Click += mButtonMyReview_Click;

			mButtonMyQueries = FindViewById<Button>(Resource.Id.buttonMyQueries);
			mButtonMyQueries.Click += mButtonMyQueries_Click;

			mButtonMyProfile = FindViewById<Button>(Resource.Id.buttonMyProfile);
			mButtonMyProfile.Click += mButtonMyProfile_Click;

			mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
			mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
			mRightDrawer = FindViewById<ListView>(Resource.Id.right_drawer);

			mLeftDrawer.Tag = 0;
			mRightDrawer.Tag = 1;

			SetSupportActionBar(mToolbar);
			//SupportActionBar.SetHomeButtonEnabled(true);
			//SupportActionBar.SetDisplayShowHomeEnabled(true);
			//SupportActionBar.SetDisplayShowTitleEnabled(true);

			mLeftDataSet = new List<string>();
			mLeftDataSet.Add ("My Profile");
			mLeftDataSet.Add ("Logout");
			mLeftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mLeftDataSet);
			mLeftDrawer.Adapter = mLeftAdapter;

			mRightDataSet = new List<string>();
			mRightDataSet.Add ("FAQ");
			mRightDataSet.Add ("Support");
			mRightAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mRightDataSet);
			mRightDrawer.Adapter = mRightAdapter;

			mDrawerToggle = new MyActionBarDrawerToggle(
				this,							//Host Activity
				mDrawerLayout,					//DrawerLayout
				Resource.String.openDrawer,		//Opened Message
				Resource.String.closeDrawer		//Closed Message
			);

			mDrawerLayout.SetDrawerListener(mDrawerToggle);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			SupportActionBar.SetDisplayShowTitleEnabled(true);
			mDrawerToggle.SyncState();

			if (bundle != null){
				if (bundle.GetString("DrawerState") == "Opened"){
					SupportActionBar.SetTitle(Resource.String.openDrawer);
				}

				else{
					SupportActionBar.SetTitle(Resource.String.closeDrawer);
				}
			}

			else{
				//This is the first the time the activity is ran
				SupportActionBar.SetTitle(Resource.String.closeDrawer);
			}
		}

		public override bool OnOptionsItemSelected (IMenuItem item){		
			switch (item.ItemId){

			case Android.Resource.Id.Home:
				//The hamburger icon was clicked which means the drawer toggle will handle the event
				//all we need to do is ensure the right drawer is closed so the don't overlap
				mDrawerLayout.CloseDrawer (mRightDrawer);
				mDrawerToggle.OnOptionsItemSelected(item);
				return true;

			case Resource.Id.toolbar:
				//Refresh
				return true;

			case Resource.Id.action_help:
				if (mDrawerLayout.IsDrawerOpen (mRightDrawer)) {
					//Right Drawer is already open, close it
					mDrawerLayout.CloseDrawer (mRightDrawer);
				} else {
					//Right Drawer is closed, open it and just in case close left drawer
					mDrawerLayout.OpenDrawer (mRightDrawer);
					mDrawerLayout.CloseDrawer (mLeftDrawer);
				}
				return true;

			default:
				return base.OnOptionsItemSelected (item);
			}
		}

		public override bool OnCreateOptionsMenu (IMenu menu){
			MenuInflater.Inflate (Resource.Menu.main_action_bar, menu);
			return base.OnCreateOptionsMenu (menu);
		}

		protected override void OnSaveInstanceState (Bundle outState){
			if (mDrawerLayout.IsDrawerOpen((int)GravityFlags.Left)){
				outState.PutString("DrawerState", "Opened");
			}

			else{
				outState.PutString("DrawerState", "Closed");
			}

			base.OnSaveInstanceState (outState);
		}

		protected override void OnPostCreate (Bundle savedInstanceState){
			base.OnPostCreate (savedInstanceState);
			mDrawerToggle.SyncState();
		}

		public override void OnConfigurationChanged (Android.Content.Res.Configuration newConfig){
			base.OnConfigurationChanged (newConfig);
			mDrawerToggle.OnConfigurationChanged(newConfig);
		}


		void mButtonBackgroundCheck_Click (object sender, EventArgs args){
			Intent intent = new Intent (this, typeof(query_activity));
			this.StartActivity (intent);
		}

		void mButtonMyReview_Click (object sender, EventArgs e){
			Intent intent = new Intent (this, typeof(my_reviews_activity));
			this.StartActivity (intent);
		}

		void mButtonMyQueries_Click (object sender, EventArgs args){
			Intent intent = new Intent (this, typeof(my_reports_activity));
			this.StartActivity (intent);
		}

		void mButtonMyProfile_Click (object sender, EventArgs args){
			Intent intent = new Intent (this, typeof(swipe_activity));
			this.StartActivity (intent);
		}
	
	}
}






