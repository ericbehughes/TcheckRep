
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
	[Activity (Label = "")]			
	public class my_queries_activity : Activity
	{
	//	string[] items;
		private Button mButtonReviewPerson;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//items = new string[] { "Larry Johnson","Eric Hughes","Denis Ouspenski","Michael Jordan","Barrack Obama","Stephen Harper" };
			//ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSelectableListItem, items);
			SetContentView (Resource.Layout.my_queries_screen);
			mButtonReviewPerson = FindViewById<Button>(Resource.Id.buttonList1);
			mButtonReviewPerson.Click += mButtonReviewPerson_Click;




		}

		void mButtonReviewPerson_Click (object sender, EventArgs args)
		{	
			Intent intent = new Intent (this, typeof(dummy_report_activity));
			this.StartActivity (intent);
			Finish ();
		}



	}


}
