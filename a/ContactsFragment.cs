
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using static Android.Views.View;
using SupportFragment = Android.Support.V4.App.Fragment;

using Firebase.Xamarin.Database;

using System.Diagnostics.Contracts;
using Firebase.Database;

namespace a
{
    public class ContactsFragment : SupportFragment

    {
        FirebaseClient firebase;
        //public List<MessageContent> contacts = new List<MessageContent>();
        FirebaseAuth auth;
        public RecyclerView recView;
        public Android.Widget.SearchView searchContacts;
        public List<Contact> listOfContacts = new List<Contact>();
        public List<DataWithPhoto> listOfAccounts = new List<DataWithPhoto>();
        private ContactsAdapter adapterOfContactsRecView;
        RecyclerView.LayoutManager mLayoutManager;
        public Refractored.Controls.CircleImageView btnAddContact;

        //public override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);
        //}

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Contract.Ensures(Contract.Result<View>() != null);
            View rootView = inflater.Inflate(Resource.Layout.ContactsLayout, container, false);

            recView = rootView.FindViewById<RecyclerView>(Resource.Id.rec_view_of_contacts);
            searchContacts = rootView.FindViewById<Android.Widget.SearchView>(Resource.Id.contact_search_view);

            btnAddContact = rootView.FindViewById<Refractored.Controls.CircleImageView>(Resource.Id.circleImageView1);


            mLayoutManager = new LinearLayoutManager(this.Context);
            // recView.AddOnItemTouchListener(new MyListenre());


            auth = FirebaseAuth.GetInstance(MainActivity.app);
            firebase = new FirebaseClient(GetString(Resource.String.database_name));

            if (auth.CurrentUser == null)
                StartActivity(new Android.Content.Intent(this.Context, typeof(MainActivity)));
            else
            {
                var CurrentUser = FirebaseAuth.Instance.CurrentUser.Email;
                Toast.MakeText(this.Context, "Welcome " + CurrentUser, ToastLength.Short).Show();
                DisplayContactsAsync();


                searchContacts.QueryTextChange += SearchContacts_QueryTextChange;
                btnAddContact.Click += AddContact; 

            }

            return rootView;


        }

        private void AddContact(object sender, EventArgs e)
        {
            //create fragment
            //create recview
            //change fragment
            //search searchview in database
            //click on the item
            //goto chat and him in contact (change the table with just a key)


            Toast.MakeText(Context, "test", ToastLength.Short).Show();
        }


        private void SearchContacts_QueryTextChange(object sender, Android.Widget.SearchView.QueryTextChangeEventArgs e)
        {
           
        }

        private async void DisplayContactsAsync()
        {
            listOfContacts.Clear();

            var firebaseContacts = await firebase.Child("contacts")
                                                 .OnceAsync<Contact>();
            

            List<string> keys = new List<string>();


            var query = from fc in firebaseContacts
                        where fc.Object.mSenderMail.Equals(auth.CurrentUser.Email)
                        select fc;
            foreach (var item in query)

                keys.Add(item.Object.mRecipientPhoto);


            var refdb = await firebase.Child("accounts")
                                      .OnceAsync<DataWithPhoto>();
                
                //FirebaseDatabase.GetInstance(MainActivity.app)
                                        //.GetReference("accounts");

            foreach (var id in keys)
            {
                var qr = from acc in refdb
                     where acc.Key.Equals(id)
                     select acc;  
                
                foreach (var it in qr)

                    listOfAccounts.Add(it.Object);
                
            }
               // refdb.OrderByKey().EqualTo(id).AddListenerForSingleValueEvent(new MyValueEventListener());
            
                     //EqualTo(em).AddListenerForSingleValueEvent(new MyValueEventListener());
              
            
                recView.SetLayoutManager(mLayoutManager);
          //  adapterOfContactsRecView = new ContactsAdapter(listOfContacts);
            adapterOfContactsRecView = new ContactsAdapter(listOfAccounts, Activity);
            recView.SetAdapter(adapterOfContactsRecView);

        }



    }

    //internal class MyValueEventListener : Java.Lang.Object, IValueEventListener
    //{

    //    public void OnCancelled(DatabaseError error)
    //    {
    //        var e = error.ToString();
    //    }

    //    public void OnDataChange(DataSnapshot snapshot)
    //    {

    //        snapshot.GetValue(DataWithPhoto);      

    //        foreach (DataSnapshot item in )
    //        {
    //            //item.Ref.Child("mPhotoPath").SetValue(this.fullPath);

    //        }
    //    }
    //}
}
 