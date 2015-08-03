using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace RentProof.Droid
{
    [Activity(Label = "review_activity")]
    public class Submit_Review_Activity : Activity
    {
        private Button mButtonHome; //id-> buttonHome
        private Button mButtonSurvey; // id -> buttonSurvey

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Submit_Survey);

            mButtonSurvey = FindViewById<Button>(Resource.Id.buttonSurvey);
            mButtonSurvey.Click += mButtonSurvey_Click;

            mButtonHome = FindViewById<Button>(Resource.Id.buttonHome);
            mButtonHome.Click += mButtonHome_Click;
        }

        private void mButtonMenuButton_Click(object sender, EventArgs args)
        {
            var intent = new Intent(this, typeof (Main_Menu_Activity));
            StartActivity(intent);
            Finish();
        }

        private void mButtonSurvey_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof (survey_activity));
            StartActivity(intent);
        }

        private void mButtonHome_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof (Main_Menu_Activity));
            StartActivity(intent);
            Finish();
        }
    }
}