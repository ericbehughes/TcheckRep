using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace TCheck.Droid
{
	[Activity(Label = "MyReports_Activity")]
	public class MyReports_Activity: Activity
	{
		private RecyclerView mRecyclerView;
		private RecyclerView.LayoutManager mLayoutManager;
		private RecyclerView.Adapter mAdapter;
		private MyReports<MyReports> mMyReportsLists;


		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.recycler_report_screen);
			mRecyclerView = FindViewById<RecyclerView>(Resource.Id.re);

			mMyReportsLists = new MyReports<MyReports>();
			mMyReportsLists.Add(new MyReports() { Name = "tom", Subject = "Wanna hang out?", Message = "I'll be around tomorrow!!" });
			mMyReportsLists.Add(new MyReports() { Name = "tom", Subject = "Wanna hang out?", Message = "I'll be around tomorrow!!" });
			mMyReportsLists.Add(new MyReports() { Name = "tom", Subject = "Wanna hang out?", Message = "I'll be around tomorrow!!" });
			mMyReportsLists.Add(new MyReports() { Name = "tom", Subject = "Wanna hang out?", Message = "I'll be around tomorrow!!" });


			//Create our layout manager
			mLayoutManager = new LinearLayoutManager(this);
			mRecyclerView.SetLayoutManager(mLayoutManager);
			mAdapter = new RecyclerAdapter(mMyReportsLists, mRecyclerView);
			mMyReportsLists.Adapter = mAdapter;
			mRecyclerView.SetAdapter(mAdapter);


		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.add_and_remove_bar, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch(item.ItemId)
			{
			case Resource.Id.add:
				//Add button clicked
				mMyReportsLists.Add(new MyReports() { Name = "New Name", Subject = "New Subject", Message = "New Message" });
				return true;

			case Resource.Id.discard:
				//Discard button clicked
				mMyReportsLists.Remove(mMyReportsLists.Count - 1);
				return true;
			}
			return base.OnOptionsItemSelected(item);
		}
	}

	public class MyReports<T>
	{
		private List<T> mItems;
		private RecyclerView.Adapter mAdapter;

		public MyReports()
		{
			mItems = new List<T>();
		}

		public RecyclerView.Adapter Adapter
		{
			get { return mAdapter; }
			set { mAdapter = value; }
		}

		public void Add(T item)
		{
			mItems.Add(item);

			if (Adapter != null)
			{
				Adapter.NotifyItemInserted(0);
			}

		}

		public void Remove (int position)
		{
			mItems.RemoveAt(position);

			if (Adapter != null)
			{
				Adapter.NotifyItemRemoved(0);
			}
		}

		public T this[int index]
		{
			get { return mItems[index]; }
			set { mItems[index] = value; }
		}

		public int Count
		{
			get { return mItems.Count; }
		}

	}

	public class RecyclerAdapter : RecyclerView.Adapter
	{
		private MyReports<MyReports> mMyReportsLists;
		private RecyclerView mRecyclerView;

		public RecyclerAdapter(MyReports<MyReports> MyReportss, RecyclerView recyclerView)
		{
			mMyReportsLists = MyReportss;
			mRecyclerView = recyclerView;
		}

		public class MyView : RecyclerView.ViewHolder
		{
			public View mMainView { get; set; }
			public TextView mName { get; set; }
			public TextView mSubject { get; set; }
			public TextView mMessage { get; set; }

			public MyView (View view) : base(view)
			{
				mMainView = view;
			}
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row_report, parent, false);

			TextView txtName = row.FindViewById<TextView>(Resource.Id.txtName);
			TextView txtSubject = row.FindViewById<TextView>(Resource.Id.txtSubject);
			TextView txtMessage = row.FindViewById<TextView>(Resource.Id.txtMessage);

			MyView view = new MyView(row) { mName = txtName, mSubject = txtSubject, mMessage = txtMessage };
			return view;
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			MyView myHolder = holder as MyView;
			int indexPosition = (mMyReportsLists.Count - 1) - position;
			myHolder.mMainView.Click += mMainView_Click;
			myHolder.mName.Text = mMyReportsLists[indexPosition].Name;
			myHolder.mSubject.Text = mMyReportsLists[indexPosition].Subject;
			myHolder.mMessage.Text = mMyReportsLists[indexPosition].Message;
		}

		void mMainView_Click(object sender, EventArgs e)
		{
			int position = mRecyclerView.GetChildPosition((View)sender);
			int indexPosition = (mMyReportsLists.Count - 1) - position;
			Console.WriteLine(mMyReportsLists[indexPosition].Name);
		}

		public override int ItemCount
		{
			get { return mMyReportsLists.Count; }
		}
	}
}

