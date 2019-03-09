using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using FragmentTest.Fragments;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Views;
using System.Collections.Generic;
using Android.Support.Design.Widget;

namespace FragmentTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private SupportFragment mCurrentFragment;
        private Fragment1 mFragment1;
        private Fragment2 mFragment2;
        private Fragment3 mFragment3;
        private Stack<SupportFragment> mStackFragment;
        BottomNavigationView bottomNavigation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            bottomNavigation.NavigationItemSelected += (s, e) =>
            {
                Android.Support.V4.App.Fragment fragment = null;
                switch (e.Item.ItemId)
                {
                    case Resource.Id.Food:
                        fragment = new Fragment1();
                        break;
                    case Resource.Id.Tourist:
                        fragment = new Fragment2();
                        break;
                    case Resource.Id.History:
                        fragment = new Fragment3();
                        break;
                }
                SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.fragmentContainer, fragment)
                .Commit();

                return;
            };

            mFragment1 = new Fragment1();
            mFragment2 = new Fragment2();
            mFragment3 = new Fragment3();

            mStackFragment = new Stack<SupportFragment>();

            var trans = SupportFragmentManager.BeginTransaction();
            trans.Add(Resource.Id.fragmentContainer, mFragment3, "Fragment3");//NOT bottom_navigation, it must be the container
            trans.Hide(mFragment3);
            trans.Add(Resource.Id.fragmentContainer, mFragment2, "Fragment2");
            trans.Hide(mFragment2);
            trans.Add(Resource.Id.fragmentContainer, mFragment1, "Fragment1");
            trans.Commit();

            mCurrentFragment = mFragment1;
           
        }

        //private void ShowFragment(SupportFragment fragment)
        //{
        //    var trans = SupportFragmentManager.BeginTransaction();
        //    trans.Hide(mCurrentFragment);
        //    trans.Show(fragment);
        //    trans.AddToBackStack(null);
        //    trans.Commit();

        //    mStackFragment.Push(mCurrentFragment);
        //    mCurrentFragment = fragment;
        //}

        //public override void OnBackPressed()
        //{
        //    if(SupportFragmentManager.BackStackEntryCount > 0)
        //    {
        //        SupportFragmentManager.PopBackStack();
        //        mCurrentFragment = mStackFragment.Pop();

        //    }
        //    else
        //    {
        //        base.OnBackPressed();
        //    }
           
        //}

    }
}