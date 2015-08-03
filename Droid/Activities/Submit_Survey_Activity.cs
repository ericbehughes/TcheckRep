using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace RentProof.Droid
{
    [Activity(Label = "survey_activity")]
    public class survey_activity : Activity
    {
        private Button mButtonSurveySubmit;
        //private Button mButtonMenuButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Submit_Survey);

            mButtonSurveySubmit = FindViewById<Button>(Resource.Id.buttonSurveySubmit);
            mButtonSurveySubmit.Click += mButtonSurveySubmit_Click;
        }

        private void mButtonSurveySubmit_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof (Main_Menu_Activity));
            StartActivity(intent);
            Finish();
        }
    }
}