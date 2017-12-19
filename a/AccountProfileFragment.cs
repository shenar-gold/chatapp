
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.Graphics;
using Android.Net;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Storage;
using Firebase.Xamarin.Database;
using Java.Lang;
using Java.Util;
using static Android.Views.View;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace a

{  // [Activity(Label = "a", MainLauncher = true, Theme = "@android:style/Theme.Material.NoActionBar")]
    [Activity(Label = "MyApp", MainLauncher = false, NoHistory = false)]
    public class AccountProfileFragment : SupportFragment, ActivityResultDispatcher
    //, IOnClickListener

    {
        private const int PICK_IMAGE_REQUEST = -1;
        private TextView txtView;
        private ImageButton btn_edit_photo;
        ImageView imgView;

        public Android.Net.Uri filePath;
        StorageReference storageRef;
        FirebaseStorage storage;



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View frgView = inflater.Inflate(Resource.Layout.AccountProfileLayout, container, false);

            txtView = frgView.FindViewById<TextView>(Resource.Id.txt);
            imgView = frgView.FindViewById<ImageView>(Resource.Id.user_image);

            btn_edit_photo = frgView.FindViewById<ImageButton>(Resource.Id.edit_image);
            //btn_edit_photo.SetOnClickListener(new myViewListener(this));

            btn_edit_photo.Click += pic_Click;
            storage = FirebaseStorage.Instance;
            storageRef = storage.GetReferenceFromUrl("gs://auth-50655.appspot.com");


            return frgView;

        }

        private void pic_Click(object sender, EventArgs e)
        {
            ChoosePhoto();
        }

        public void ChoosePhoto()
        {

            Intent intent = new Intent(Intent.ActionPick, Android.Provider.MediaStore.Images.Media.ExternalContentUri);
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(intent,1);

        }



        public void DispatchResultData(Intent data, int requestCode)
        {
            if (data!=null) 
            {
                Android.Net.Uri imageUri = data.Data;
                Stream streamForFirebase = ResizePhoto(imageUri);
                UpLoadPhoto(imageUri);
            }

        }

        private void UpLoadPhoto(Android.Net.Uri imageUri)
        {

            if (imageUri != null)
            {
                var guid = Guid.NewGuid().ToString();
                var images = storageRef.Child("images/" + guid);
                var fullPath = images.ToString();

                images.PutFile(imageUri)  
                      .AddOnSuccessListener(new MyOnSuccessListener(fullPath))
                      .AddOnFailureListener(new MyOnFailureListener());
             }
        }

        private Stream ResizePhoto(Android.Net.Uri imageUri)
        {
          
            var options1 = new BitmapFactory.Options();
            options1.InJustDecodeBounds = true;
            Stream inStream1 = Context.ContentResolver.OpenInputStream(imageUri);
            Bitmap userImage = BitmapFactory.DecodeStream(inStream1, null, options1);
            inStream1.Close();
            Stream inStream2 =  Context.ContentResolver.OpenInputStream(imageUri);
            var options2 = new BitmapFactory.Options();

            options2.InJustDecodeBounds = false;


            if (options1.OutWidth > imgView.Width)
            {
                options2.InSampleSize = System.Math.Max(options1.OutWidth / imgView.Width, options1.OutHeight / imgView.Height);
            }
            try
            {
                Bitmap bmp = BitmapFactory.DecodeStream(inStream2, null, options2); 
                imgView.SetImageBitmap(bmp);

            } catch(IOException e) {
                var txt = e.ToString();
            }


            imgView.SetScaleType(ImageView.ScaleType.FitXy);
            return inStream2;
        }


    }

    internal class MyOnFailureListener : Java.Lang.Object, IOnFailureListener
    {
        public void OnFailure(Java.Lang.Exception e)
        {
           var excep = e.ToString();
        }
    }

    internal class MyOnSuccessListener : Java.Lang.Object, IOnSuccessListener
    {
        private string fullPath;
        //public FirebaseClient firebase;
        DatabaseReference refdb;
        FirebaseAuth auth;

        public MyOnSuccessListener(string fullPath)
        {
            this.fullPath = fullPath;
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            auth = FirebaseAuth.GetInstance(MainActivity.app);
            refdb = FirebaseDatabase.GetInstance(MainActivity.app)
                                    .GetReference("accounts");

            var chtoref = refdb.OrderByChild("mEmail").EqualTo(auth.CurrentUser.Email);
            chtoref.AddListenerForSingleValueEvent(new ValueEventListener(this.fullPath));

        }
    }


    internal class ValueEventListener: Java.Lang.Object, IValueEventListener
    {
        private string fullPath;

        public ValueEventListener(string fullPath)
        {
            this.fullPath = fullPath;
            //this.fullPath = "test";
        }

        public void OnCancelled(DatabaseError error)
        {
            var e = error.ToString();
        }

        public void OnDataChange(DataSnapshot snapshot)
        {

            var eto = snapshot.Ref;
            var chto = snapshot.Children;
            foreach(DataSnapshot item in snapshot.Children.ToEnumerable())
            {
                item.Ref.Child("mPhotoPath").SetValue(this.fullPath);

            }
        }
    }

    public class myViewListener : Java.Lang.Object, View.IOnClickListener
    {
        private const int PICK_IMAGE_REQUEST = 7;
        private AccountProfileFragment fr;

        public myViewListener(AccountProfileFragment frag)
        {
            this.fr = frag;
        }
        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.edit_image)
            {
                fr.ChoosePhoto();

            }
        }

    }



}


