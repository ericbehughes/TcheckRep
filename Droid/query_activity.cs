
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

	public class OnCancel : EventArgs{}

	[Activity (Label = "query_activity")]			
	public class query_activity : Activity
	{
		private Button mPayButtonQS;
		private Button mButtonCancelQuery;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.query_screen);
			mPayButtonQS = FindViewById<Button>(Resource.Id.buttonGO);
			mPayButtonQS.Click += mQueryButtonQueryScreen_Click;

			mButtonCancelQuery = FindViewById<Button>(Resource.Id.buttonQueryCancel);
			mButtonCancelQuery.Click += (object sender, EventArgs args) =>
			{
				//pull up dialog
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				cancel_activity cancelScreen = new cancel_activity();
				cancelScreen.Show(transaction, "cancel fragment");
				cancelScreen.mOnSignUpComplete += cancelScreen_mOnCancel;
			};
		}


		void mQueryButtonQueryScreen_Click (object sender, EventArgs args)
		{
			Intent intent = new Intent (this, typeof(query_payment_activity));
			this.StartActivity (intent);

		}
			

		void cancelScreen_mOnCancel (object sender, EventArgs e)
		{
			Intent intent = new Intent (this, typeof(main_menu_activity));
			this.StartActivity (intent);

		}
	}
}

