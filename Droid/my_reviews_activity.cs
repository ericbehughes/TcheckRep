
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
	[Activity (Label = "my_reviews_activity")]			
	public class my_reviews_activity : Activity
	{
		private Button mButtonReviewPerson;
		private Button mButtonNewReview;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.my_reviews_screen);

			mButtonReviewPerson = FindViewById<Button>(Resource.Id.buttonList1);
			mButtonReviewPerson.Click += mButtonReviewPerson_Click;

			mButtonNewReview = FindViewById<Button>(Resource.Id.buttonNewReview);
			mButtonNewReview.Click += mButtonNewReview_Click;

		}
		void mButtonReviewPerson_Click (object sender, EventArgs args)
		{	
			Intent intent = new Intent (this, typeof(review_activity));
			this.StartActivity (intent);
			Finish ();
		}

		void mButtonNewReview_Click (object sender, EventArgs args)
		{	
			Intent intent = new Intent (this, typeof(review_activity));
			this.StartActivity (intent);
			Finish ();
		}
	}
}








