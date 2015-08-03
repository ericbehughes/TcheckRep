using System;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace RentProof.Droid
{
    [Activity(Label = "Profile", Theme = "@style/MyTheme")]
    public class BackgroundCheckProfileActivity : Activity
    {
        private TextView _biogaphy;
        private TextView _name;
        private ImageView _photo;
        private TextView _position;
        private TextView _posting;
        private TextView _rank;
        private TextView _tenantScore;
        // Adapter that accesses the data set (a photo album):
        private PhotoAlbumAdapter mAdapter;
        // Layout manager that lays out each card in the RecyclerView:
        private RecyclerView.LayoutManager mLayoutManager;
        // Photo album that is managed by the adapter:
        private PhotoAlbum mPhotoAlbum;
        private RecyclerView mRecyclerView;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.BackgroundCheck_Profile);

            _rank = FindViewById<TextView>(Resource.Id.crewMemberRankTextView);
            _name = FindViewById<TextView>(Resource.Id.crewMemberNameTextView);
            _position = FindViewById<TextView>(Resource.Id.crewMemberPositionTextView);
            _posting = FindViewById<TextView>(Resource.Id.crewMemberPostingTextView);
            _tenantScore = FindViewById<TextView>(Resource.Id.crewMemberTenantScoreTextView);
            _biogaphy = FindViewById<TextView>(Resource.Id.crewMemberBioTextView);
            _photo = FindViewById<ImageView>(Resource.Id.crewMemberImageView);


            var index = Intent.GetIntExtra("index", -1);
            if (index < 0)
            {
                return;
            }

            var imageResourceId = Intent.GetIntExtra("imageResourceId", -1);

            var crewMember = SharedData.CrewManifest[index];

            _rank.Text = crewMember.Rank;
            _name.Text = crewMember.Name;
            _position.Text = crewMember.Position;
            _posting.Text = crewMember.Posting;
            _tenantScore.Text = String.Format("Species: {0}", crewMember.TenantScore);
            _biogaphy.Text = crewMember.Biography;

            var imageManager = new ImageManager(Resources);
            var bitmap = await imageManager.GetScaledDownBitmapFromResourceAsync(imageResourceId, 150, 150);

            _photo.SetImageBitmap(bitmap);

            mPhotoAlbum = new PhotoAlbum();

            // Set our view from the "main" layout resource:
            //SetContentView (Resource.Layout.Main);

            // Get our RecyclerView layout:
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            //............................................................
            // Layout Manager Setup:

            // Use the built-in linear layout manager:
            mLayoutManager = new LinearLayoutManager(this);

            // Or use the built-in grid layout manager (two horizontal rows):
            // mLayoutManager = new GridLayoutManager
            //        (this, 2, GridLayoutManager.Horizontal, false);

            // Plug the layout manager into the RecyclerView:
            mRecyclerView.SetLayoutManager(mLayoutManager);

            //............................................................
            // Adapter Setup:

            // Create an adapter for the RecyclerView, and pass it the
            // data set (the photo album) to manage:
            mAdapter = new PhotoAlbumAdapter(mPhotoAlbum);

            // Register the item click handler (below) with the adapter:
            //mAdapter.ItemClick += OnItemClick;

            // Plug the adapter into the RecyclerView:
            mRecyclerView.SetAdapter(mAdapter);

            //............................................................
            // Random Pick Button:

            // Get the button for randomly swapping a photo:
            //Button randomPickBtn = FindViewById<Button>(Resource.Id.randPickButton);

            // Handler for the Random Pick Button:
            //randomPickBtn.Click += delegate
            {
                if (mPhotoAlbum != null)
                {
                    // Randomly swap a photo with the top:
                    var idx = mPhotoAlbum.RandomSwap();

                    // Update the RecyclerView by notifying the adapter:
                    // Notify that the top and a randomly-chosen photo has changed (swapped):
                    mAdapter.NotifyItemChanged(0);
                    mAdapter.NotifyItemChanged(idx);
                }
            }
            ;
        }

        // VIEW HOLDER

        // Implement the ViewHolder pattern: each ViewHolder holds references
        // to the UI components (ImageView and TextView) within the CardView 
        // that is displayed in a row of the RecyclerView:
        public class PhotoViewHolder : RecyclerView.ViewHolder
        {
            // Get references to the views defined in the CardView layout.
            public PhotoViewHolder(View itemView, Action<int> listener)
                : base(itemView)
            {
                // Locate and cache view references:
                Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
                Caption = itemView.FindViewById<TextView>(Resource.Id.textView);

                // Detect user clicks on the item view and report which item
                // was clicked (by position) to the listener:
                itemView.Click += (sender, e) => listener(AdapterPosition);
            }

            public ImageView Image { get; }
            public TextView Caption { get; }
        }

        //----------------------------------------------------------------------
        // ADAPTER

        // Adapter to connect the data set (photo album) to the RecyclerView: 
        public class PhotoAlbumAdapter : RecyclerView.Adapter
        {
            // Underlying data set (a photo album):
            public PhotoAlbum mPhotoAlbum;
            // Load the adapter with the data set (photo album) at construction time:
            public PhotoAlbumAdapter(PhotoAlbum photoAlbum)
            {
                mPhotoAlbum = photoAlbum;
            }

            // Return the number of photos available in the photo album:
            public override int ItemCount
            {
                get { return mPhotoAlbum.NumPhotos; }
            }

            // Event handler for item clicks:
            public event EventHandler<int> ItemClick;
            // Create a new photo CardView (invoked by the layout manager): 
            public override RecyclerView.ViewHolder
                OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                // Inflate the CardView for the photo:
                var itemView = LayoutInflater.From(parent.Context).
                    Inflate(Resource.Layout.BackgroundCheck_ProfileCard, parent, false);

                // Create a ViewHolder to find and hold these view references, and 
                // register OnClick with the view holder:
                var vh = new PhotoViewHolder(itemView, OnClick);
                return vh;
            }

            // Fill in the contents of the photo card (invoked by the layout manager):
            public override void
                OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                var vh = holder as PhotoViewHolder;

                // Set the ImageView and TextView in this ViewHolder's CardView 
                // from this position in the photo album:
                vh.Image.SetImageResource(mPhotoAlbum[position].PhotoID);
                vh.Caption.Text = mPhotoAlbum[position].Caption;
            }

            // Raise an event when the item-click takes place:
            private void OnClick(int position)
            {
                if (ItemClick != null)
                    ItemClick(this, position);
            }
        }
    }
}