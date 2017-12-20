using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Firebase;
using Firebase.Auth;
using System;
using static Android.Views.View;
using Android.Views;
using Android.Gms.Tasks;
//using FragmentManager = Android.Support.V4.App.FragmentManager;
using Fragment = Android.Support.V4.App.Fragment;
using Android.Content;
using Android.Graphics;
using System.IO;

namespace a
{
    [Activity(Label = "a", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@android:style/Theme.Material.NoActionBar")]
    public class MainActivity : Activity, IOnClickListener, IOnCompleteListener
    {
        Button btn_create_contact;

        public Button btnSignUp;
        LinearLayout activity_main;
        public static FirebaseApp app;
        FirebaseAuth auth;


        public Button btnLogIn;
        EditText input_email, input_password;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            InitFirebaseAuth();

            btnSignUp = FindViewById<Button>(Resource.Id.login_btn_sign_up);
            btnSignUp.SetOnClickListener(this);
            activity_main = FindViewById<LinearLayout>(Resource.Id.activity_main);


            input_email = FindViewById<EditText>(Resource.Id.login_email);
            input_password = FindViewById<EditText>(Resource.Id.login_password);
            btnLogIn = FindViewById<Button>(Resource.Id.login_btn_login);
            btnLogIn.SetOnClickListener(this);

            btn_create_contact = FindViewById<Button>(Resource.Id.btn_create_contact);
            btn_create_contact.SetOnClickListener(this);

        }


        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
                                             .SetApplicationId("1:715252781463:android:3681a575e998e063")
                                             .SetApiKey("AIzaSyAhXehU8TNLv9VhbNHCGDVXSOseeHajTu0")
                                             .SetDatabaseUrl("https://auth-50655.firebaseio.com")
                                             .Build();
            if (app == null)
                app = FirebaseApp.InitializeApp(this, options);
            auth = FirebaseAuth.GetInstance(app);

        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.login_btn_sign_up)
            {
                StartActivity(new Android.Content.Intent(this,typeof(SignUp)));

                Finish();
            }

            if (v.Id == Resource.Id.login_btn_login)
            {
                LoginUser(input_email.Text, input_password.Text);


               // Finish();
            }

            if (v.Id == Resource.Id.btn_create_contact) 
            { 
                LoginUser(input_email.Text, input_password.Text);
                StartActivity(new Android.Content.Intent(this, typeof(CreateContactActivity)));
                Finish();
            }
        }

        private void LoginUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Toast.MakeText(this, "Error: email or password cannot be empty", ToastLength.Short).Show();
                return;
            }
            auth.SignInWithEmailAndPassword(email,password)
                .AddOnCompleteListener(this,this);
//            FirebaseAuth.Instance.SignInWithEmailAndPassword(email,password).AddOnCompleteListener(this,this);
        }

        public void OnComplete(Task task)
        {
            if(task.IsSuccessful){

               
                //StartActivity(new Android.Content.Intent(this, typeof(ViewPagerActivity)));


                var intentVP = new Android.Content.Intent(this, typeof(ViewPagerActivity));
                StartActivity(intentVP);
                Finish();

            }
            else
            {
                Console.Write("Login Failed");
                Toast.MakeText(this, "Error: email or password cannot be empty", ToastLength.Short).Show();
            }
        }



    }

     
}

