using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;


namespace RentProof.Droid
{
    [Activity(Label = "sample_report", Theme = "@style/MyTheme")]
    public class Sample_Report : Activity
    {
        private readonly Dictionary<string, List<string>> dictGroup = new Dictionary<string, List<string>>();
        private List<string> lstKeys = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Accordion_SampleReportNOTUSING);


            CreateExpendableListData();

            var ctlExListBox = FindViewById<ExpandableListView>(Resource.Id.ctlExListBox);
            ctlExListBox.SetAdapter(new ExpendListAdapter(this, dictGroup));

            ctlExListBox.ChildClick += delegate(object sender, ExpandableListView.ChildClickEventArgs e)
            {
                var itmGroup = lstKeys[e.GroupPosition];
                var itmChild = dictGroup[itmGroup][e.ChildPosition];

                Toast.MakeText(this, string.Format("You Click on Group {0} with child {1}", itmGroup, itmChild),
                    ToastLength.Long).Show();
            };
        }

        private void CreateExpendableListData()
        {
            for (var iGroup = 1; iGroup <= 4; iGroup++)
            {
                var lstChild = new List<string>();
                for (var iChild = 1; iChild <= 3; iChild++)
                {
                    lstChild.Add(string.Format("Criteria {0}", iGroup));
                }
                if (iGroup == 1)
                    dictGroup.Add(string.Format("RentScore"), lstChild);
                if (iGroup == 2)
                    dictGroup.Add(string.Format("CreditCheck"), lstChild);
                if (iGroup == 3)
                    dictGroup.Add(string.Format("BackgroundCheck"), lstChild);
                if (iGroup == 4)
                    dictGroup.Add(string.Format("SomethingCheck"), lstChild);
            }

            lstKeys = new List<string>(dictGroup.Keys);
        }
    }
}