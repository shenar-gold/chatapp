using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;

//using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Firebase.Storage;
using Java.IO;
using Java.Lang;
using Java.Net;
using Refractored.Controls;

namespace a
{
    public class ContactsAdapter: RecyclerView.Adapter, View.IOnClickListener
    {
        //private ContactsFragment contactsFragment;
        public List<Contact> listOfContacts;
        public List<DataWithPhoto> ListOfAccounts;
        Context context;

        //public ContactsAdapter(List<Contact> listOfContacts)
        public ContactsAdapter(List<DataWithPhoto> ListOfAccounts, Context context)
        {
           // this.contactsFragment = contactsFragment;
            //this.listOfContacts = listOfContacts;
            this.ListOfAccounts = ListOfAccounts;
            this.context = context;
        }

        //public override int ItemCount => listOfContacts.Count;

        public override int ItemCount => ListOfAccounts.Count;

        public class MyContactsView : RecyclerView.ViewHolder
        {

            public View mView { set; get; }
            public TextView vContactName {set; get;}
          //  public TextView vLastMsg { set; get; }
           // public TextView vDate_Time { set; get; }
            public TextView vPhoto { set; get; }
            public TextView vContactMail {set; get;}

            public Refractored.Controls.CircleImageView vImage { set; get; }

            public MyContactsView(View v):base(v)
            {
                mView = v;
            }
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyContactsView my_contacts_view = (a.ContactsAdapter.MyContactsView)holder;

            //my_contacts_view.vContactName.Text = listOfContacts[position].mRecipientName;
            //my_contacts_view.vContactMail.Text = listOfContacts[position].mRecipientMail;
            //my_contacts_view.vPhoto.Text = listOfContacts[position].mRecipientPhoto.ToString();

            my_contacts_view.vContactName.Text = ListOfAccounts[position].mName;
            my_contacts_view.vContactMail.Text = ListOfAccounts[position].mEmail;

            //my_contacts_view.vPhoto.Text = ListOfAccounts[position].mPhotoPath.ToString();

            var storage = FirebaseStorage.Instance;
            var storageRef = storage.GetReferenceFromUrl("gs://auth-50655.appspot.com");

            //string stringURL = "https://firebasestorage.googleapis.com/v0/b/auth-50655.appspot.com/o/images%2F1bdb096a-1b51-4d60-88bb-58e814440377?alt=media&token=9b81b5f7-4efd-401d-ac77-bfec55624d5a";

            var stringURL = ListOfAccounts[position].mPhotoPath;

            System.Threading.Tasks.Task.Factory.StartNew(() => LoadImage(stringURL, my_contacts_view.vImage)).ContinueWith(t => my_contacts_view.vImage.SetImageBitmap(t.Result), TaskScheduler.FromCurrentSynchronizationContext());


            my_contacts_view.mView.SetOnClickListener(this); 

        }

        private Bitmap LoadImage(string stringURL, Refractored.Controls.CircleImageView vImage)
        {
            
            try{
                URL w = new URL(stringURL);
                Bitmap image2 = BitmapFactory.DecodeStream(w.OpenConnection().InputStream);
               // vImage.SetImageBitmap(image2); 
                return image2;
            } catch(System.IO.IOException e)
            {
                var chto = e.ToString();   
                return null;
            }


        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Contact_ItemLayout, null, false);

            var row_view = new MyContactsView(row);

            row_view.vContactName = row.FindViewById<TextView>(Resource.Id.contact_name);
            row_view.vContactMail = row.FindViewById<TextView>(Resource.Id.contact_last_msg);
            //row_view.vDate_Time = row.FindViewById<TextView>(Resource.Id.contact_last_msg_DateTime);
            row_view.vImage = row.FindViewById<Refractored.Controls.CircleImageView>(Resource.Id.circleImageView1);
            return row_view;
        }

        public void OnClick(View v)
        {
            Intent intent = new Intent(v.Context, typeof(DashBoard));
            Bundle mBundle = new Bundle();
            mBundle.PutString("Contact", v.FindViewById<TextView>(Resource.Id.contact_last_msg).Text);

            intent.PutExtras(mBundle);

            v.Context.StartActivity(intent);
        }
    }


}