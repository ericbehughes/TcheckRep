using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using SupportActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;

namespace RentProof.Droid
{
    public class MyActionBarDrawerToggle : SupportActionBarDrawerToggle
    {
        private readonly int mClosedResource;
        private readonly AppCompatActivity mHostActivity;
        private readonly int mOpenedResource;

        public MyActionBarDrawerToggle(AppCompatActivity host, DrawerLayout drawerLayout, int openedResource,
            int closedResource)
            : base(host, drawerLayout, openedResource, closedResource)
        {
            mHostActivity = host;
            mOpenedResource = openedResource;
            mClosedResource = closedResource;
        }

        public override void OnDrawerOpened(View drawerView)
        {
            var drawerType = (int) drawerView.Tag;

            if (drawerType == 0)
            {
                base.OnDrawerOpened(drawerView);
                mHostActivity.SupportActionBar.SetTitle(mOpenedResource);
            }
        }

        public override void OnDrawerClosed(View drawerView)
        {
            var drawerType = (int) drawerView.Tag;

            if (drawerType == 0)
            {
                base.OnDrawerClosed(drawerView);
                mHostActivity.SupportActionBar.SetTitle(mClosedResource);
            }
        }

        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            var drawerType = (int) drawerView.Tag;

            if (drawerType == 0)
            {
                base.OnDrawerSlide(drawerView, slideOffset);
            }
        }
    }
}