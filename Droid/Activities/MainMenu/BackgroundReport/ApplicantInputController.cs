
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
using System;

namespace TCheck.Droid
{
	[Activity (Label = "JsonInputController")]			
	public class ApplicantInputController : AppCompatActivity
	{
		private Button _SubmitQueryInfo;

		private SupportToolbar _toolbar;
		private NavigationBar _drawerToggle;
		private DrawerLayout _drawerLayout;
		private ListView _leftDrawer;
		private ListView _rightDrawer;
		private ArrayAdapter _leftAdapter;
		private ArrayAdapter _rightAdapter;
		private List<string> _leftDataSet;
		private List<string> _rightDataSet;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.ApplicantInfoInputView);
			_SubmitQueryInfo = FindViewById<Button>(Resource.Id.btnScrollInfoInputSubmit);
			_SubmitQueryInfo.Click += async (sender, e) => {

				var model = new Applicant {

					FirstName = FindViewById<EditText>(Resource.Id.txtScrollInfoInputFirstName).Text,
					LastName = FindViewById<EditText>(Resource.Id.txtScrollInfoInputLastName).Text,
					Gender = FindViewById<EditText>(Resource.Id.txtScrollInfoInputGender).Text,
					DateOfBirth = FindViewById<EditText>(Resource.Id.txtScrollInfoInputDateOfBirth).Text,
					Mobile = FindViewById<EditText>(Resource.Id.txtScrollInfoInputMobile).Text,
					Country = FindViewById<EditText>(Resource.Id.txtScrollInfoInputCountry).Text
				};

				try {
					// create new applicant (applicant is returned with ID)
					var applicant = await OnFido.API.OnFidoService.CreateApplicant(model);
					applicant = await OnFido.API.OnFidoService.GetApplicantById(applicant.Id);
					// pass applicant info to recycler view 
					var applicanInfo = new Intent(this, typeof (ReportMainController));
					applicanInfo.PutExtra("Applicant",JsonConvert.SerializeObject(applicant));
					this.StartActivity(applicanInfo);
					//finish activity
					Finish();

				} catch (Exception) {
					throw;
				}
			};

			/************TOOLBAR******************************************************/
			_toolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
			_drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			_leftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
			_rightDrawer = FindViewById<ListView>(Resource.Id.right_drawer);

			//tag left and right drawer for case statment when clicked 
			_leftDrawer.Tag = 0;
			_rightDrawer.Tag = 1;
			//Set action support toolbar with private class variable
			SetSupportActionBar(_toolbar);


			//***********LEFT DATA SET******************************/
			//Left data set, these are the buttons you see when you click on the drawers 
			_leftDataSet = new List<string>();
			//my_profile has a string in the string xml file in values directory
			_leftDataSet.Add(GetString(Resource.String.main_menu));
			//log_out has a string in the string xml file in values directory
			_leftDataSet.Add(GetString(Resource.String.log_out));
			_leftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, _leftDataSet);
			_leftDrawer.Adapter = _leftAdapter;
			//click event for the left drawer 
			this._leftDrawer.ItemClick += LeftDrawerRowClick;

			//***********RIGHT DATA SET******************************/
			_rightDataSet = new List<string>();
			//support has a string in the string xml file in values directory
			_rightDataSet.Add(GetString (Resource.String.help_popup));
			//rentproof has a string in the string xml file in values directory
			_rightDataSet.Add(GetString(Resource.String.support));
			_rightAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, _rightDataSet);
			_rightDrawer.Adapter = _rightAdapter;
			this._rightDrawer.ItemClick += RightDrawerRowClick;

			//constructor for navigation bar
			_drawerToggle = new NavigationBar(
				this,							//Host Activity
				_drawerLayout,					//DrawerLayout
				Resource.String.openDrawer,		//Opened Message
				Resource.String.closeDrawer		//Closed Message
			);
			//set drawerlistener
			_drawerLayout.SetDrawerListener(_drawerToggle);
			//set home button
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			SupportActionBar.SetDisplayShowTitleEnabled(true);
			_drawerToggle.SyncState();

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
			//*****************END OF ONCREATE TOO
		}

		void LeftDrawerRowClick (object sender, AdapterView.ItemClickEventArgs e)
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

		void RightDrawerRowClick (object sender, AdapterView.ItemClickEventArgs e)
		{

			switch (e.Position) {

			case 0:
				FragmentTransaction transaction1 = FragmentManager.BeginTransaction();
				HelpPopUpController helpPopUp = new HelpPopUpController();
				helpPopUp.Show(transaction1, "help fragment");
				helpPopUp.mHelpPopUpEvent += HelpPopUpButtonClick;
				break;

			case 1:
				FragmentTransaction transaction2 = FragmentManager.BeginTransaction();
				SupportPopUpController supportPopUp = new SupportPopUpController();
				supportPopUp.Show(transaction2, "support fragment");
				supportPopUp.mSupportPopUpEvent += SupportPopUpButtonClick;
				break;
			}
		}

		public override bool OnOptionsItemSelected (IMenuItem item){		
			switch (item.ItemId){

			case Android.Resource.Id.Home:
				//The hamburger icon was clicked which means the drawer toggle will handle the event
				//all we need to do is ensure the right drawer is closed so the don't overlap
				_drawerLayout.CloseDrawer (_rightDrawer);
				_drawerToggle.OnOptionsItemSelected(item);
				return true;
			case Resource.Id.toolbar:
				//Refresh
				return true;
			case Resource.Id.action_help:
				if (_drawerLayout.IsDrawerOpen (_rightDrawer)) {
					//Right Drawer is already open, close it
					_drawerLayout.CloseDrawer (_rightDrawer);
				} else {
					//Right Drawer is closed, open it and just in case close left drawer
					_drawerLayout.OpenDrawer (_rightDrawer);
					_drawerLayout.CloseDrawer (_leftDrawer);
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
			if (_drawerLayout.IsDrawerOpen((int)GravityFlags.Left))
			{
				outState.PutString("DrawerState", "Opened");
			}
			else
			{
				outState.PutString("DrawerState", "Closed");
			}
			base.OnSaveInstanceState (outState);
		}

		public override void OnConfigurationChanged (Android.Content.Res.Configuration newConfig){
			base.OnConfigurationChanged (newConfig);
			_drawerToggle.OnConfigurationChanged(newConfig);
		}

		/*protected override void OnPostCreate (Bundle savedInstanceState){
			base.OnPostCreate (savedInstanceState);
			mDrawerToggle.SyncState();
		}
*/		
		void HelpPopUpButtonClick (object sender, OnHelpEvent e){
			Intent intent = new Intent (this, typeof(HelpPopUpController));
			this.StartActivity (intent);
			Finish (); 
		}

		void SupportPopUpButtonClick (object sender, OnSupportEvent e){
			Intent intent = new Intent (this, typeof(SupportPopUpController));
			this.StartActivity (intent);
			Finish (); 
		}
	}
}
