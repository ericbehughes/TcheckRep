
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Content;
using Android.Support.V7.App;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using Android.Widget;
using Android.Views;
using OnFido.API.Models;
using Newtonsoft.Json;

namespace TCheck.Droid
{
	[Activity(Label = "ReportMainController",Theme="@style/MyTheme")]
	public class ReportMainController : AppCompatActivity
	{
		private RecyclerView _recyclerView;
		private RecyclerView.LayoutManager _layoutManager;
		private ReportViewAdapter _adapter;
		private ProgressDialog _progressDialog;
		private List<Applicant> _reportList = new List<Applicant>();


		private SupportToolbar mToolbar;
		private NavigationBar mDrawerToggle;
		private DrawerLayout mDrawerLayout;
		private ListView mLeftDrawer;
		private ListView mRightDrawer;
		private ArrayAdapter mLeftAdapter;
		private ArrayAdapter mRightAdapter;
		private List<string> mLeftDataSet;
		private List<string> mRightDataSet;
		private Applicant _ApplicantReport;


		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.ReportListView);

			_ApplicantReport = JsonConvert.DeserializeObject<Applicant> (Intent.GetStringExtra ("Applicant"));

			_progressDialog = new ProgressDialog(this);
			_progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
			_progressDialog.SetMessage("Loading  . . .");
			_progressDialog.Show();

			//If the device is portrait, then show the RecyclerView in a vertical list,
			//else show it in horizontal list.
			_layoutManager = Resources.Configuration.Orientation == Android.Content.Res.Orientation.Portrait 
				? new LinearLayoutManager(this, LinearLayoutManager.Vertical, false) 
				: new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false);

			//Experiement with a GridLayoutManger! You can create some cool looking UI!
			//This create a gridview with 2 rows that scrolls horizontally.
			//            _layoutManager = new GridLayoutManager(this, 2, GridLayoutManager.Horizontal, false);

			//Create a reference to our RecyclerView and set the layout manager;
			_recyclerView = FindViewById<RecyclerView>(Resource.Id.reportRecyclerListView);
			_recyclerView.SetLayoutManager(_layoutManager);

			//Get our crew member data. This could be a web service.


			_reportList.Add (_ApplicantReport);

			//Create the adapter for the RecyclerView with our crew data, and set
			//the adapter. Also, wire an event handler for when the user taps on each
			//individual item.
			_adapter = new ReportViewAdapter(_reportList, this.Resources);
			_adapter.ItemClick += OnItemClick;
			_recyclerView.SetAdapter(_adapter);


			_progressDialog.Dismiss();

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
			MenuInflater.Inflate (Resource.Menu.MainActionBar, menu);
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

		/*protected override void OnPostCreate (Bundle savedInstanceState){
			base.OnPostCreate (savedInstanceState);
			mDrawerToggle.SyncState();
		}
*/

		private void OnItemClick (object sender, int position)
		{
			Context con;
			var reportIntent = new Intent(this ,typeof(ReportController));
			//var reportIntent = new Intent(con, typeof(ReportController));
			_ApplicantReport = _reportList [position];
			reportIntent.PutExtra("Applicant",JsonConvert.SerializeObject(_ApplicantReport));
			StartActivity(reportIntent);
		}

		public override void OnConfigurationChanged (Android.Content.Res.Configuration newConfig){
			base.OnConfigurationChanged (newConfig);
			mDrawerToggle.OnConfigurationChanged(newConfig);
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


	}
		
}





