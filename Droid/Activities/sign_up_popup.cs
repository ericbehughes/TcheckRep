using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace RentProof.Droid
{
    public class OnSignUpEvent : EventArgs
    {
        public OnSignUpEvent(string firstName, string email, string securitynumber, string password)
        {
            FirstName = firstName;
            Email = email;
            SecurityNumber = securitynumber;
            Password = password;
        }

        public string FirstName { get; set; }
        public string Email { get; set; }
        public string SecurityNumber { get; set; }
        public string Password { get; set; }
    }

    internal class SignUpPopUp : DialogFragment
    {
        private Button mPopUpButton;
        private EditText mTxtEmail;
        private EditText mTxtFirstName;
        private EditText mTxtPassword;
        private EditText mTxtSecurityNumber;
        public event EventHandler<OnSignUpEvent> mOnSignUpComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.SignUp_PopUp, container, false);
            mTxtFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            mTxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mTxtSecurityNumber = view.FindViewById<EditText>(Resource.Id.txtSecurityNumber);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mPopUpButton = view.FindViewById<Button>(Resource.Id.popUpButton);

            mPopUpButton.Click += mPopUpButton_Click;

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.popup_animation;
        }

        private void mPopUpButton_Click(object sender, EventArgs e)
        {
            //user has clicked on signup button
            mOnSignUpComplete.Invoke(this,
                new OnSignUpEvent(mTxtFirstName.Text, mTxtEmail.Text, mTxtSecurityNumber.Text, mTxtPassword.Text));
            Dismiss();
        }
    }
}