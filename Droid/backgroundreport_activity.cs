using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Support.V7;
using Android.Support.V4.Widget;
using System.Collections.Generic;

namespace TCheck.Droid{
	[Activity (Label = "backgroundreport_activity")]
	public class backgroundreport_activity : Activity{
		private RecyclerView mRecyclerView;
		private RecyclerView.LayoutManager mLayoutManager;
		private RecyclerView.Adapter mAdapter;
		private MyList<BackgroundReport> mBackgroundReport;

		protected override void OnCreate(Bundle bundle){
			base.OnCreate(bundle);
			//var toolbar = FindViewById<Toolbar> (Resource.Id.reportToolbar);
			//Toolbar will now take on default Action Bar characteristics

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.recycler_report_screen);
			mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recycleReportScreen);
			mBackgroundReport = new MyList<BackgroundReport>();
			mBackgroundReport.Add(new BackgroundReport() { Name = "Person", Status = "Status Complete", Message = "Query Report" });
			mBackgroundReport.Add(new BackgroundReport() { Name = "Person", Status = "Status Complete", Message = "Query Report" });
			mBackgroundReport.Add(new BackgroundReport() { Name = "Person", Status = "Status Complete", Message = "Query Report" });
			mBackgroundReport.Add(new BackgroundReport() { Name = "Person", Status = "Staus Complete", Message = "Query Report" });

			//Create our layout manager
			mLayoutManager = new LinearLayoutManager(this);
			mRecyclerView.SetLayoutManager(mLayoutManager);
			mAdapter = new RecyclerAdapter(mBackgroundReport, mRecyclerView);
			mBackgroundReport.Adapter = mAdapter;
			mRecyclerView.SetAdapter(mAdapter);
			//SupportActionBar.SetHomeButtonEnabled(true);
			//SupportActionBar.SetDisplayShowTitleEnabled(true);
		}

		public override bool OnCreateOptionsMenu(IMenu menu){
			MenuInflater.Inflate(Resource.Menu.add_and_remove_bar, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item){
			switch(item.ItemId){
			case Resource.Id.add:
				//Add button clicked
				mBackgroundReport.Add(new BackgroundReport() { Name = "Another Person", Status = "Status Pending", Message = "Query Report" });
				return true;

			case Resource.Id.discard:
				//Discard button clicked
				mBackgroundReport.Remove(mBackgroundReport.Count - 1);
				return true;
			}
			return base.OnOptionsItemSelected(item);
		}
	}

	public class MyList<T>{
		private List<T> mItems;
		private RecyclerView.Adapter mAdapter;

		public MyList(){
			mItems = new List<T>();
		}

		public RecyclerView.Adapter Adapter{
			get { return mAdapter; }
			set { mAdapter = value; }
		}

		public void Add(T item){
			mItems.Add(item);

			if (Adapter != null){
				Adapter.NotifyItemInserted(0);
			}

		}

		public void Remove (int position){
			mItems.RemoveAt(position);

			if (Adapter != null){
				Adapter.NotifyItemRemoved(0);
			}
		}

		public T this[int index]{
			get { return mItems[index]; }
			set { mItems[index] = value; }
		}

		public int Count{
			get { return mItems.Count; }
		}

	}

	public class RecyclerAdapter : RecyclerView.Adapter{
		private MyList<BackgroundReport> mBackgroundReport;
		private RecyclerView mRecyclerView;

		public RecyclerAdapter(MyList<BackgroundReport> emails, RecyclerView recyclerView){
			mBackgroundReport = emails;
			mRecyclerView = recyclerView;
		}

		public class MyView : RecyclerView.ViewHolder{
			public View mMainView { get; set; }
			public TextView mName { get; set; }
			public TextView mStatus { get; set; }
			public TextView mMessage { get; set; }

			public MyView (View view) : base(view){
				mMainView = view;
			}
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType){
			View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row_contact, parent, false);

			TextView txtName = row.FindViewById<TextView>(Resource.Id.txtName);
			TextView txtStatus = row.FindViewById<TextView>(Resource.Id.txtStatus);
			TextView txtMessage = row.FindViewById<TextView>(Resource.Id.txtMessage);

			MyView view = new MyView(row) { mName = txtName, mStatus = txtStatus, mMessage = txtMessage };
			return view;
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position){
			MyView myHolder = holder as MyView;
			int indexPosition = (mBackgroundReport.Count - 1) - position;
			myHolder.mMainView.Click += mMainView_Click;
			myHolder.mName.Text = mBackgroundReport[indexPosition].Name;
			myHolder.mStatus.Text = mBackgroundReport[indexPosition].Status;
			myHolder.mMessage.Text = mBackgroundReport[indexPosition].Message;
		}

		void mMainView_Click(object sender, EventArgs e){
			int position = mRecyclerView.GetChildPosition((View)sender);
			int indexPosition = (mBackgroundReport.Count - 1) - position;
			Console.WriteLine(mBackgroundReport[indexPosition].Name);
		}

		public override int ItemCount{
			get { return mBackgroundReport.Count; }
		}
	}
}

