
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Xamarin.Database;
using static Android.Views.View;
using Android.Provider;
using Java.IO;
using Firebase.Storage;
using Android.Gms.Tasks;
using Java.Lang;

namespace a
{
    [Activity(Label = "CreateContactActivity")]
    public class CreateContactActivity : Activity, IOnClickListener
    {
        EditText ReName;
        EditText ReEmail;
        EditText SeName;
        EditText PhoneNumber;
        Button btn_generate_contact;
        Button btn_choose;
        ImageView imgView;


        FirebaseAuth auth;
        FirebaseClient firebase;
        FirebaseStorage storage;
        StorageReference storageRef;

        private Android.Net.Uri filePath;

        private const int PICK_IMAGE_REQUEST = 7;

        public void OnClick(View v)
        {
            var fullPath = "";
            add_acount(fullPath, ReName.Text, ReEmail.Text, PhoneNumber.Text);

            //if (filePath != null)
            //{
            //   var guid =  Guid.NewGuid().ToString();
            //    var images = storageRef.Child("images/" + guid);
            //    var fullPath = images.ToString();
            //    fullPath = "";
            //    images.PutFile(filePath).AddOnSuccessListener(
            //        new MyTestOnSuccessListener(fullPath, ReName.Text, ReEmail.Text, PhoneNumber.Text));
            //}
        }

        private void add_acount(string path, string name, string email, string phone)
        {
            firebase = new FirebaseClient("https://auth-50655.firebaseio.com");

            DataWithPhoto dWph = new DataWithPhoto();
            dWph.mName = name;
            dWph.mEmail = email;
            dWph.mPhotoPath = path;
            dWph.mPhone = phone;

            var item = firebase.Child("accounts").PostAsync(dWph);

        }

        public class MyTestOnSuccessListener : Java.Lang.Object, IOnSuccessListener
        {
            string mName;
            string mEmail;
            string mPath;
            string mPhone;
            FirebaseClient firebase;

            public MyTestOnSuccessListener(string path, string str, string str2, string phone){

                this.mName = str;
                this.mEmail = str2;
                this.mPath = path;
                this.mPhone = phone;
            }
            public void OnSuccess(Java.Lang.Object result)
            {

                firebase = new FirebaseClient("https://auth-50655.firebaseio.com");

                DataWithPhoto dWph = new DataWithPhoto();
                dWph.mName = mName;
                dWph.mEmail = mEmail;
                dWph.mPhotoPath = mPath;

                var item =  firebase.Child("accounts").PostAsync(dWph);


            }

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateContactLayout);

            ReName = FindViewById<EditText>(Resource.Id.recipient_name);
            ReEmail = FindViewById<EditText>(Resource.Id.recipient_mail);
            SeName = FindViewById<EditText>(Resource.Id.sender_name);
           // img = (byte)FindViewById<ImageView>(Resource.Id.imageView1);
            imgView = FindViewById<ImageView>(Resource.Id.imageView1);
            PhoneNumber = FindViewById<EditText>(Resource.Id.phone_number);


            btn_generate_contact = FindViewById<Button>(Resource.Id.btn_generate_contact);
            btn_generate_contact.SetOnClickListener(this);

            btn_choose = FindViewById<Button>(Resource.Id.btn_choose);
            btn_choose.Click += Btn_Choose_Click;

            firebase = new FirebaseClient(GetString(Resource.String.database_name));
            auth = FirebaseAuth.GetInstance(MainActivity.app);
            storage = FirebaseStorage.Instance;
            storageRef = storage.GetReferenceFromUrl("gs://auth-50655.appspot.com");

        }

        private void Btn_Choose_Click(object sender, EventArgs e)
        {
            // 
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            this.StartActivityForResult(Intent.CreateChooser(intent, "Select picture"), PICK_IMAGE_REQUEST);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == PICK_IMAGE_REQUEST && resultCode == Result.Ok &&
                data != null && data.Data!=null) 
            {
                filePath = data.Data;

                try
                {
                    Bitmap bitmap = MediaStore.Images.Media.GetBitmap(ContentResolver, filePath);
                    imgView.SetImageBitmap(bitmap);
                    
                } catch (IOException e) {
                    e.PrintStackTrace();
                }
            }

        }

    }
}
