﻿using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace RentProof.Droid
{
    public class OnPurchaseEvent : EventArgs
    {
    }

    [Activity(Label = "Support_PopUp")]
    public class Purchase_Confirmation : DialogFragment
    {
        private Button mPopUpButton;
        public event EventHandler<OnPurchaseEvent> mPurchaseComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Purchase_Confirmation, container, false);

            mPopUpButton = view.FindViewById<Button>(Resource.Id.popUpButton);

            mPopUpButton.Click += mPurchaseCompletePopUp_Click;

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.popup_animation;
        }

        private void mPurchaseCompletePopUp_Click(object sender, EventArgs e)
        {
            //user has clicked on signup button
            mPurchaseComplete.Invoke(this, new OnPurchaseEvent());
            Dismiss();
        }
    }
}