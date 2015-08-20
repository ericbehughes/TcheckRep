using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using RentProof.API.Models;
using RentProof.API;

namespace TCheck.Droid
{
	[Activity(Label = "login_activity")]
	public class LoginController : Activity
	{
		private Button _ButtonLogin;

		protected override void OnCreate(Bundle bundle)
		{
			RequestWindowFeature(WindowFeatures.NoTitle);
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.LoginView);

			_ButtonLogin = FindViewById<Button>(Resource.Id.btnLogIn);
			_ButtonLogin.Click += mButtonLoginClick;
		}

		private async void mButtonLoginClick(object sender, EventArgs args)
		{
			//grab user info
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
			await RentProof.API.Service.Login(model);


				// proceed to main menu

			}
			catch (Exception)
			{
				throw;
			}
			var intent = new Intent(this, typeof (MainMenuController));
			StartActivity(intent);
			Finish();
		}
	}
}