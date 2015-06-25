
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
	[Activity (Label = "main_menu_activity")]			
	public class main_menu_activity : Activity
	{
		private Button mButtonQueryMM;
		private Button mButtonReviewMM;
		//private Button mCopyButtonMM;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.main_menu);
			mButtonQueryMM = FindViewById<Button>(Resource.Id.buttonQuery);
			mButtonQueryMM.Click += mButtonQueryMM_Click;

			mButtonReviewMM = FindViewById<Button>(Resource.Id.buttonReview);
			mButtonReviewMM.Click += mButtonReviewMM_Click;




		}
		void mButtonQueryMM_Click (object sender, EventArgs args)
		{
			Intent intent = new Intent (this, typeof(query_activity));
			this.StartActivity (intent);

		}

		void mButtonReviewMM_Click (object sender, EventArgs e)
		{
			Intent intent = new Intent (this, typeof(review_activity));
			this.StartActivity (intent);

		}
	}


}

