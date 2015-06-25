
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
	[Activity (Label = "query_payment_activity")]			
	public class query_payment_activity : Activity
	{
		private Button mButtonPaymentMade;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.query_payment_screen);
			mButtonPaymentMade = FindViewById<Button>(Resource.Id.buttonPay);
			mButtonPaymentMade.Click += mButtonPaymentMade_Click;




		}
		void mButtonPaymentMade_Click (object sender, EventArgs args)
		{
			Intent intent = new Intent (this, typeof(dummy_report_activity));
			this.StartActivity (intent);

		}

		void mButtonCancelPayment_Click (object sender, EventArgs args)
		{
			Intent intent = new Intent (this, typeof(cancel_activity));
			this.StartActivity (intent);

		}
	}
}





