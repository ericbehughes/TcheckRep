using System;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TCheck.Droid{
	[Activity (Label = "cancel_activity")]
	public class OnCancelEvent : EventArgs{
		public OnCancelEvent(){}
	}
	
	class CancelController : DialogFragment{
		private Button _btnYesCancel;
		private Button _btnNoCancel;

		public event EventHandler<OnCancelEvent> mOnCancel ;

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
			
			base.OnCreateView (inflater, container, savedInstanceState);
			var view = inflater.Inflate (Resource.Layout.CancelPopUpView, container, false);

			_btnYesCancel = view.FindViewById<Button> (Resource.Id.btnYesCancel);
			_btnYesCancel.Click += YesCancelButtonClick; 

			_btnNoCancel = view.FindViewById<Button> (Resource.Id.btnNoCancel);
			_btnNoCancel.Click += NoCancelButtonClick; 
			return view;
		}

		public override void OnActivityCreated(Bundle savedInstanceState){
			Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.popup_animation;
		}

		void YesCancelButtonClick(object sender, EventArgs e){
			//user has clicked on signup button
			mOnCancel.Invoke(this, new OnCancelEvent());
			this.Dismiss();
		}
		void NoCancelButtonClick(object sender, EventArgs e){
			//user has clicked on signup button
			//mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(mTxtFirstName.Text, mTxtEmail.Text,mTxtSecurityNumber.Text, mTxtPassword.Text ));
			this.Dismiss();
		}
	}
}

