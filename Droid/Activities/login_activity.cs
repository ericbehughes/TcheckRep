using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using RentProof.API.Models;

namespace RentProof.Droid
{
    [Activity(Label = "login_activity")]
    public class Login_Activity : Activity
    {
        private Button mButtonLogin;

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Login);

            mButtonLogin = FindViewById<Button>(Resource.Id.buttonLogIn);
            mButtonLogin.Click += mButtonLogin_Click;
        }

        private async void mButtonLogin_Click(object sender, EventArgs args)
        {
            // grab user info
            var email = FindViewById<EditText>(Resource.Id.txtLoginEmail).Text;
            var password = FindViewById<EditText>(Resource.Id.txtPassword).Text;

            // build model
            var model = new LoginBindingModel
            {
                Email = email,
                Password = password
            };

            try
            {
                // authenticate
                await API.Service.Login(model);

                // proceed to main menu
                var intent = new Intent(this, typeof (Main_Menu_Activity));
                StartActivity(intent);
                Finish();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}