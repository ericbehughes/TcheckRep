using System;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TCheck.Droid
{
	
	class cancel_activity : DialogFragment
	{
		
		private Button mYesCancelButton;
		private Button mNoCancelButton;

		public event EventHandler<OnSignUpEventArgs> mOnSignUpComplete;

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate (Resource.Layout.cancel_screen, container, false);

			mYesCancelButton = view.FindViewById<Button> (Resource.Id.buttonYesCancel);
			mYesCancelButton.Click += mYesCancelButton_Click; 

			mNoCancelButton = view.FindViewById<Button> (Resource.Id.buttonNoCancel);
			mNoCancelButton.Click += mNoCancelButton_Click; 

			return view;
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
			base.OnActivityCreated (savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.popup_animation;
		}

		void mYesCancelButton_Click(object sender, EventArgs e){

			//user has clicked on signup button
			//mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs());
			this.Dismiss();


		}

		void mNoCancelButton_Click(object sender, EventArgs e){

			//user has clicked on signup button
			//mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs());
			this.Dismiss();

		}
	}
}

