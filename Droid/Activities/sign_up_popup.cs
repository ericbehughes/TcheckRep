using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using RentProof.API.Models;

namespace RentProof.Droid
{
    internal class SignUpPopUp : DialogFragment
    {
        public event EventHandler<EventArgs> mOnSignUpComplete;
        private View view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            view = inflater.Inflate(Resource.Layout.SignUp_PopUp, container, false);
            var mPopUpButton = view.FindViewById<Button>(Resource.Id.popUpButton);
            mPopUpButton.Click += mPopUpButton_Click;

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.popup_animation;
        }

        private async void mPopUpButton_Click(object sender, EventArgs e)
        {
            // grab user info
            var name = view.FindViewById<EditText>(Resource.Id.txtFirstName).Text;
            var email = view.FindViewById<EditText>(Resource.Id.txtEmail).Text;
            var sin = view.FindViewById<EditText>(Resource.Id.txtSecurityNumber).Text;
            var password = view.FindViewById<EditText>(Resource.Id.txtPassword).Text;

            // build models
            var registerModel = new RegisterBindingModel
            {
                Name = name,
                Email = email,
                SIN = Int32.Parse(sin),
                Password = password
            };

            var loginModel = new LoginBindingModel
            {
                Email = email,
                Password = password
            };

            // register user
            await API.Service.Register(registerModel);

            // auto-authenticate
            await API.Service.Login(loginModel);

            // user has clicked on signup button
            mOnSignUpComplete.Invoke(this, new EventArgs());

            // close popup
            Dismiss();
        }
    }
}