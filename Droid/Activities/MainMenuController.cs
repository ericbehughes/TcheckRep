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
	[Activity (Label = "Main_Menu_activity",Theme="@style/MyTheme")]
	public class MainMenuController : AppCompatActivity{

		private Button mButtonBackgroundCheck; 
		private Button mButtonMyReview;
		private Button mButtonMyReports;
		private Button mButtonTenantSearch;

		private SupportToolbar mToolbar;
		private NavigationBar mDrawerToggle;
		private DrawerLayout mDrawerLayout;
		private ListView mLeftDrawer;
		private ListView mRightDrawer;
		private ArrayAdapter mLeftAdapter;
		private ArrayAdapter mRightAdapter;
		private List<string> mLeftDataSet;
		private List<string> mRightDataSet;


		protected override void OnCreate (Bundle bundle){
			base.OnCreate (bundle);
			//set main_menu xml file in layout directory
			SetContentView(Resource.Layout.MainMenuView);

			//backgroundcheck button
			mButtonBackgroundCheck = FindViewById<Button>(Resource.Id.buttonQuery);
			mButtonBackgroundCheck.Click += mButtonBackgroundCheck_Click;

			mButtonMyReview = FindViewById<Button>(Resource.Id.buttonMyReviews);
			mButtonMyReview.Click += mButtonMyReview_Click;

			mButtonMyReports = FindViewById<Button>(Resource.Id.buttonMyReports);
			mButtonMyReports.Click += mButtonMyReports_Click;

			mButtonTenantSearch = FindViewById<Button>(Resource.Id.buttonTenantSearch);
			mButtonTenantSearch.Click += mButtonTenantSearch_Click;
			/************TOOLBAR******************************************************/
			mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
			mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
			mRightDrawer = FindViewById<ListView>(Resource.Id.right_drawer);

			//tag left and right drawer for case statment when clicked 
			mLeftDrawer.Tag = 0;
			mRightDrawer.Tag = 1;
			//Set action support toolbar with private class variable
			SetSupportActionBar(mToolbar);


			//***********LEFT DATA SET******************************/
			//Left data set, these are the buttons you see when you click on the drawers 
			mLeftDataSet = new List<string>();
			//my_profile has a string in the string xml file in values directory
			mLeftDataSet.Add(GetString(Resource.String.main_menu));
			//log_out has a string in the string xml file in values directory
			mLeftDataSet.Add(GetString(Resource.String.log_out));
			mLeftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mLeftDataSet);
			mLeftDrawer.Adapter = mLeftAdapter;
			//click event for the left drawer 
			this.mLeftDrawer.ItemClick += mLeftDrawer_ItemClick;

			//***********RIGHT DATA SET******************************/
			mRightDataSet = new List<string>();
			//drawer_faq has a string in the string xml file in values directory


			//support has a string in the string xml file in values directory
			mRightDataSet.Add(GetString (Resource.String.help_popup));
			//rentproof has a string in the string xml file in values directory
			mRightDataSet.Add(GetString(Resource.String.support));
			mRightAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mRightDataSet);
			mRightDrawer.Adapter = mRightAdapter;
			this.mRightDrawer.ItemClick += mRightDrawer_ItemClick;

			mDrawerToggle = new NavigationBar(
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


		void mLeftDrawer_ItemClick (object sender, AdapterView.ItemClickEventArgs e)
		{
			
			switch (e.Position) {

			case 0:
				Intent mDrawerButtonMainMenu = new Intent (this, typeof(MainMenuController));
				this.StartActivity (mDrawerButtonMainMenu);
				break;
		
			case 1:
				Intent mLogout = new Intent (this, typeof(MainActivity));
				this.StartActivity (mLogout);
			break;
			}
		}

		void mRightDrawer_ItemClick (object sender, AdapterView.ItemClickEventArgs e)
		{

			switch (e.Position) {

			case 0:
				FragmentTransaction transaction1 = FragmentManager.BeginTransaction();
				HelpPopUpController helpPopUp = new HelpPopUpController();
				helpPopUp.Show(transaction1, "help fragment");
				helpPopUp.mHelpPopUpEvent += mHelpPopUpButton_Click;
				break;

			case 1:
				FragmentTransaction transaction2 = FragmentManager.BeginTransaction();
				SupportPopUpController supportPopUp = new SupportPopUpController();
				supportPopUp.Show(transaction2, "support fragment");
				supportPopUp.mSupportPopUpEvent += mSupportPopUpButton_Click;
				break;
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
			Intent intent = new Intent (this, typeof(JsonInputController));
			this.StartActivity (intent);
		}

		void mButtonMyReports_Click (object sender, EventArgs args){
			Intent intent = new Intent (this, typeof(BackgroundReportController));
			this.StartActivity (intent);
		}

		void mButtonMyReview_Click (object sender, EventArgs e){
			Intent intent = new Intent (this, typeof(MainMenuController));
			this.StartActivity (intent);
		}

		void mHelpPopUpButton_Click (object sender, OnHelpEvent e){
			Intent intent = new Intent (this, typeof(HelpPopUpController));
			this.StartActivity (intent);
			Finish (); 
		}

		void mSupportPopUpButton_Click (object sender, OnSupportEvent e){
			Intent intent = new Intent (this, typeof(SupportPopUpController));
			this.StartActivity (intent);
			Finish (); 
		}

		void mButtonTenantSearch_Click (object sender, EventArgs args){
			Intent intent = new Intent (this, typeof(TenantSearchController1));
			this.StartActivity (intent);
		}
	
	}
}






