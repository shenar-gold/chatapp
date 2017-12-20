using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Net;
using Android.OS;
using Android.Provider;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Widget;
using Firebase.Storage;
using SupportFragment = Android.Support.V4.App.Fragment;
//using SupportFragmentManager = Android.Support.V4.App.FragmentManager;

namespace a
{
    [Activity(Label = "a", Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    public class ViewPagerActivity : AppCompatActivity
    {

        AccountProfileFragment AccPro;

        protected override void OnCreate(Android.OS.Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewPagerLayout);

            TabLayout tbs = FindViewById<TabLayout>(Resource.Id.tabs);
            ViewPager vp = FindViewById<ViewPager>(Resource.Id.view_pager);

            SetUpViewPager(vp);
            tbs.SetupWithViewPager(vp);
        }

        private void SetUpViewPager(ViewPager vp)
        {
            ViewPagerAdapter adapter = new ViewPagerAdapter(SupportFragmentManager);

            AccPro = new AccountProfileFragment();

            adapter.AddFragment(AccPro, "Account");
            adapter.AddFragment(new ContactsFragment(), "Contacts");
   
            vp.Adapter = adapter;

        }

      protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);


            AccPro.DispatchResultData(data, 1);


        }

    }
}
