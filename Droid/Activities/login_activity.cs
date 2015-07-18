using System;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using TCheck.Droid.Models;

namespace TCheck.Droid
{
    [Activity(Label = "login_activity")]
    public class login_activity : Activity
    {
        // Mobile Service info
        private const string applicationURL = @"https://rentproof.azure-mobile.net/";
        private const string applicationKey = @"lckYYGaMXIVGQDaRxgShndenFhSYRf78";

        protected override void OnCreate(Bundle bundle)
        {
            // initialize
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);

            // set view
            SetContentView(Resource.Layout.login_screen);

            // bind login button
            var mButtonLogin = FindViewById<Button>(Resource.Id.buttonLogIn);
            mButtonLogin.Click += mButtonLogin_Click;
        }

        private async void mButtonLogin_Click(object sender, EventArgs args)
        {
            // get email
            var txtLoginEmail = FindViewById<EditText>(Resource.Id.txtLoginEmail);
            var email = txtLoginEmail.Text;

            // try to retrieve user by email from DB
            var isAuthenticated = await IsUserAuthenticated(email);

            // grant/deny access
            if (isAuthenticated)
            {
                // move onto main menu
                Intent intent = new Intent(this, typeof (main_menu_activity));
                StartActivity(intent);
                Finish();
            }
            else
            {
                // advise of access denied
                txtLoginEmail.Text = "Access denied";
            }
        }

        private async Task<bool> IsUserAuthenticated(string email)
        {
            // create the Mobile Service Client instance, using the provided URL and key
            var client = new MobileServiceClient(applicationURL, applicationKey);

            // try to retrieve users by email from DB
            var users = client.GetTable<User>();
            var results = await users.Where(o => o.Email == email).ToListAsync();

            return results.Any();
        }
    }
}