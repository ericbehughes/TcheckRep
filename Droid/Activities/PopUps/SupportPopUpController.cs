
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
	public class OnSupportEvent : EventArgs{
		
		public OnSupportEvent(): base() {} }
	[Activity (Label = "SupportPopUp")]			
	public class SupportPopUpController : DialogFragment
	{
		private Button _btnSupport;
		public event EventHandler<OnSupportEvent> mSupportPopUpEvent;

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate (Resource.Layout.SupportPopUpView, container, false);
			_btnSupport = view.FindViewById<Button> (Resource.Id.popUpButton);
			_btnSupport.Click += mSupportPopUpClick; 
			return view;
		}

		public override void OnActivityCreated(Bundle savedInstanceState){
			Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.popup_animation;
		}

		void mSupportPopUpClick(object sender, EventArgs e){
			this.Dismiss ();
		}
	}
}


