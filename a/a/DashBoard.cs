
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Xamarin.Database;
using static Android.Views.View;


namespace a
{
    [Activity(Label = "DashBoard", Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class DashBoard : Activity, IOnClickListener, IValueEventListener
    {
        String cntct;
        FirebaseAuth auth;
        FirebaseClient firebase;

        TextView logOut;


        RecyclerView list_view;
        RecyclerView.LayoutManager mLayoutManager;


        List<MessageContent> list_msg_content = new List<MessageContent>();
        EditText edtText;
        Button btnSend;

        public int MyResultCode =1;

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DashBoardLayout);

            auth = FirebaseAuth.GetInstance(MainActivity.app);
            cntct = this.Intent.GetStringExtra("Contact");


                firebase = new FirebaseClient(GetString(Resource.String.database_name));

                FirebaseDatabase.Instance.GetReference("chats").AddValueEventListener(this);


            logOut = FindViewById<TextView>(Resource.Id.txtLogOut);
            logOut.SetOnClickListener(this);
           

            list_view = FindViewById<RecyclerView>(Resource.Id.list_of_message);
            edtText = FindViewById<EditText>(Resource.Id.edtText);
            btnSend = FindViewById<Button>(Resource.Id.btn_send);
            btnSend.SetOnClickListener(this);



            mLayoutManager = new LinearLayoutManager(this);

            list_view.SetLayoutManager(mLayoutManager);
            MsgContentAdapter adapter = new MsgContentAdapter(list_msg_content);
            list_view.SetAdapter(adapter);

            if (auth.CurrentUser == null)
                StartActivityForResult(new Android.Content.Intent(this, typeof(MainActivity)), MyResultCode);
            else
            {

                DisplayChatMessages(cntct);

            }


        }

        public void OnClick(View v)
        {
            if(v.Id == Resource.Id.txtLogOut){
                auth.SignOut();
                if(auth.CurrentUser == null)
                {
                    StartActivity(new Intent(this, typeof(MainActivity)));
                    Finish();
                }
            }

            if(v.Id == Resource.Id.btn_send){

                PostMessage();
            } 
        }

        private async void PostMessage()
        {
            var items = await firebase.Child("chats").PostAsync(new MessageContent(auth.CurrentUser.Email, edtText.Text));
            edtText.Text = "";
        }

        public void OnCancelled(DatabaseError error)
        {
            
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
                
            DisplayChatMessages(cntct);
        }


        private async void DisplayChatMessages(String str)
        {
            list_msg_content.Clear();

            var items = await firebase.Child("chats")
                                      .OnceAsync<MessageContent>();
            var userStr = auth.CurrentUser.Email;
            var query = from subItems in items
                    where subItems.Object.recipient_mail.Equals(str) & subItems.Object.user_email.Equals(userStr)
                                  || subItems.Object.recipient_mail.Equals(userStr) & subItems.Object.user_email.Equals(str)
                                      select subItems;

            foreach (var item in query)
                list_msg_content.Add(item.Object);

        }


    }
}
