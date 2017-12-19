using System;
using System.Collections.Generic;
using Android.OS;
using Android.Support.V4.App;
using Java.Lang;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;

namespace a
{
    public class ViewPagerAdapter: FragmentPagerAdapter
    {
        public List<SupportFragment> Fragments { get; set; }
        public List<string> FragmentsNames { get; set; }

        public ViewPagerAdapter(SupportFragmentManager sfm): base(sfm)
        {
            Fragments = new List<SupportFragment>();
            FragmentsNames = new List<string>();

        }
        public void AddFragment(SupportFragment fragment, string name)
        {
            Fragments.Add(fragment);
            FragmentsNames.Add(name);
        }

        public override int Count 
        {
            get
            {
                return Fragments.Count;  
            }
             
        }

        public override SupportFragment GetItem(int position)
        {
            return Fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(FragmentsNames[position]);
        }


    }

}
