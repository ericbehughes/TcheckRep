
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
	public class OnHelpEvent : EventArgs{
		public OnHelpEvent(): base() {} }
	
	[Activity (Label = "Help_PopUp")]			
	public class HelpPopUpController : DialogFragment
	{
		private Button _btnHelp;
		public event EventHandler<OnHelpEvent> mHelpPopUpEvent;

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate (Resource.Layout.SupportPopUpView, container, false);

			_btnHelp = view.FindViewById<Button> (Resource.Id.popUpButton);

			_btnHelp.Click += HelpPopUpClick; 

			return view;
		}

		public override void OnActivityCreated(Bundle savedInstanceState){
			Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.popup_animation;
		}

		void HelpPopUpClick(object sender, EventArgs e){

			//user has clicked on signup button
			this.Dismiss ();
		}
	}
}


