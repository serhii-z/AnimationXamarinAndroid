using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Com.Airbnb.Lottie;
using Android.Animation;
using System;
using Android.Content;

namespace AnimationAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, Animator.IAnimatorListener
    {
        private Button _nextButton;
        private Android.Views.Animations.AlphaAnimation _alphaAnimation;
        public void OnAnimationCancel(Animator animation)
        {
 
        }

        public void OnAnimationEnd(Animator animation)
        {
            _alphaAnimation = new Android.Views.Animations.AlphaAnimation(0.0f, 1.0f);
            _alphaAnimation.Duration = 5000;
            _nextButton.StartAnimation(_alphaAnimation);
            _nextButton.Visibility = Android.Views.ViewStates.Visible;
        }

        public void OnAnimationRepeat(Animator animation)
        {
            
        }

        public void OnAnimationStart(Animator animation)
        {

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            SetUpControls();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _nextButton.Click -= nextButtonClick;
        }

        private void nextButtonClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SecondActivity));
            StartActivity(intent);
            OverridePendingTransition(Resource.Drawable.right_anim, Resource.Drawable.left_anim);
        }

        private void SetUpControls()
        {
            var animationView = FindViewById<LottieAnimationView>(Resource.Id.animation_view);
            animationView.AddAnimatorListener(this);
            _nextButton = FindViewById<Button>(Resource.Id.next);       
            _nextButton.Click += nextButtonClick;
        }
    }
}