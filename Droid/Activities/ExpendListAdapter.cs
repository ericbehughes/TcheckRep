using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace RentProof.Droid
{
    internal class ExpendListAdapter : BaseExpandableListAdapter
    {
        private readonly Activity _activity;
        private readonly Dictionary<string, List<string>> _dictGroup;
        private readonly List<string> _lstGroupID;

        public ExpendListAdapter(Activity activity,
            Dictionary<string, List<string>> dictGroup)
        {
            _dictGroup = dictGroup;
            _activity = activity;
            _lstGroupID = dictGroup.Keys.ToList();
        }

        #region implemented abstract members of BaseExpandableListAdapter

        public override Object GetChild(int groupPosition, int childPosition)
        {
            return _dictGroup[_lstGroupID[groupPosition]][childPosition];
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            return _dictGroup[_lstGroupID[groupPosition]].Count;
        }

        public override View GetChildView(int groupPosition,
            int childPosition,
            bool isLastChild,
            View convertView,
            ViewGroup parent)
        {
            var item = _dictGroup[_lstGroupID[groupPosition]][childPosition];

            if (convertView == null)
                convertView = _activity.LayoutInflater.Inflate(Resource.Layout.ListControl_ChildItem, null);

            var textBox = convertView.FindViewById<TextView>(Resource.Id.txtSmall);
            textBox.SetText(item, TextView.BufferType.Normal);

            return convertView;
        }

        public override Object GetGroup(int groupPosition)
        {
            return _lstGroupID[groupPosition];
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            var item = _lstGroupID[groupPosition];

            if (convertView == null)
                convertView = _activity.LayoutInflater.Inflate(Resource.Layout.ListControl_Group, null);

            var textBox = convertView.FindViewById<TextView>(Resource.Id.txtLarge);
            textBox.SetText(item, TextView.BufferType.Normal);

            return convertView;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        public override int GroupCount
        {
            get { return _dictGroup.Count; }
        }

        public override bool HasStableIds
        {
            get { return true; }
        }

        #endregion
    }
}