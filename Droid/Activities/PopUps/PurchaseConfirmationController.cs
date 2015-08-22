
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
	public class OnPurchaseEvent : EventArgs{
		
		public OnPurchaseEvent(): base() {} }
	
	[Activity (Label = "Support_PopUp")]			
	public class PurchaseConfirmationController : DialogFragment
	{
		private Button _btnConfirmPurchase;
		public event EventHandler<OnPurchaseEvent> mPurchaseComplete;

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate (Resource.Layout.PurchaseConfirmationView, container, false);

			_btnConfirmPurchase = view.FindViewById<Button> (Resource.Id.popUpButton);
			_btnConfirmPurchase.Click += PurchaseCompletePopUpClick; 

			return view;
		}

		public override void OnActivityCreated(Bundle savedInstanceState){
			Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.popup_animation;
		}

		void PurchaseCompletePopUpClick(object sender, EventArgs e){

			//user has clicked on signup button
			mPurchaseComplete.Invoke(this, new OnPurchaseEvent());
			this.Dismiss ();



		}
	}
}


