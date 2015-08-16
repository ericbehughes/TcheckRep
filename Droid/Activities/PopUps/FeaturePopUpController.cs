
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
	public class OnIncludeFeaturePopUp : EventArgs{
		public OnIncludeFeaturePopUp(): base() {} }

	[Activity (Label = "Support_PopUp")]			
	public class FeaturePopUpController : DialogFragment
	{
		private Button mPopUpButton;
		public event EventHandler<OnIncludeFeaturePopUp> mFeatureSurveyComplete;

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate (Resource.Layout.IncludeFeatureView, container, false);

			mPopUpButton = view.FindViewById<Button> (Resource.Id.popUpButton);

			mPopUpButton.Click += mFeatureSurveyPopUp_Click; 

			return view;
		}

		public override void OnActivityCreated(Bundle savedInstanceState){
			Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.popup_animation;
		}

		void mFeatureSurveyPopUp_Click(object sender, EventArgs e){

			//user has clicked on signup button
			mFeatureSurveyComplete.Invoke(this, new OnIncludeFeaturePopUp());
			this.Dismiss ();



		}
	}
}


