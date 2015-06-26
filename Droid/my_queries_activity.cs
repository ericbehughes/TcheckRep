
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TCheck.Droid
{
	[Activity (Label = "my_queries_activity")]			
	public class my_queries_activity : ListActivity
	{
		string[] items;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			items = new string[] { "Larry Johnson","Eric Hughes","Denis Ouspenski","Michael Jordan","Barrack Obama","Stephen Harper" };
			ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSelectableListItem, items);

		}
		protected override void OnListItemClick(ListView l, View v, int position, long id){
			var t = items[position];
			Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();
		}
	}


}
