using System;
using Android.App;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.Animation;
using Android.Util;
using Android.Views.Animations;
using Android.Widget;

namespace AnimationAndroid
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        Button _startRotation;
        Button _stopRotation;
        Button _startScale;
        Button _stopScale;
        Button _startShake;
        Button _stopShake;
        Button _startColor;
        Button _stopColor;
        Button _startSprings;
        private ImageView _icon1;
        private ImageView _icon2;
        private ImageView _icon3;
        private ImageView _icon4;
        private ImageView _icon5;
        AnimationDrawable _animation;
        Animation _animationSkale;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_second);
            SetUpControls();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _startRotation.Click -= startRotationButtonClick;
            _stopRotation.Click -= stopRotationButtonsClick;
            _startScale.Click -= startScaleButtonClick;
            _stopScale.Click -= stopScaleButtonsClick;
            _startShake.Click -= startShakeButtonClick;
            _stopShake.Click -= stopShakeButtonsClick;
            _startColor.Click -= startColorButtonClick;
            _stopColor.Click -= stopColorButtonsClick;
            _startSprings.Click -= startSpringsButtonClick;
            _icon1.ClearAnimation();
            _icon2.ClearAnimation();
            _icon3.ClearAnimation();
        }

        private void startRotationButtonClick(object sender, EventArgs e)
        {
            var rotateAnimation = new RotateAnimation(0, 359, Dimension.RelativeToSelf, 0.5f, Dimension.RelativeToSelf, 0.5f);           
            rotateAnimation.Duration = 1000;
            rotateAnimation.FillAfter = true;
            rotateAnimation.RepeatCount = Animation.Infinite;
            rotateAnimation.Interpolator = new LinearInterpolator();
            _icon1.StartAnimation(rotateAnimation);
        }

        private void startScaleButtonClick(object sender, EventArgs e)
        {
            _animationSkale = AnimationUtils.LoadAnimation(this, Resource.Drawable.skale);
            _icon2.StartAnimation(_animationSkale);
        }

        private void startShakeButtonClick(object sender, EventArgs e)
        {
            var animationShake = AnimationUtils.LoadAnimation(this, Resource.Drawable.shake);           
            _icon3.StartAnimation(animationShake);
        }

        private void startColorButtonClick(object sender, EventArgs e)
        {
            _animation = (AnimationDrawable)_icon4.Background;
            _animation.SetEnterFadeDuration(1000);
            _animation.SetExitFadeDuration(2000);
            _animation.Start();          
        }

        private void startSpringsButtonClick(object sender, EventArgs e)
        {
            var springAnimation = new SpringAnimation(_icon5, DynamicAnimation.TranslationY, 0);
            springAnimation.Spring.SetStiffness(SpringForce.StiffnessLow);
            springAnimation.Spring.SetDampingRatio(SpringForce.DampingRatioHighBouncy);
            springAnimation.SetStartVelocity(2000);
            springAnimation.Start();
        }

        private void stopRotationButtonsClick(object sender, EventArgs e)
        {
            _icon1.ClearAnimation();
        }

        private void stopScaleButtonsClick(object sender, EventArgs e)
        {
            _icon2.ClearAnimation();
        }

        private void stopShakeButtonsClick(object sender, EventArgs e)
        {
            _icon3.ClearAnimation();
        }

        private void stopColorButtonsClick(object sender, EventArgs e)
        {          
            _animation?.Stop();                
        }

        private void SetUpControls()
        {      
            _startRotation = FindViewById<Button>(Resource.Id.startRotation);
            _stopRotation = FindViewById<Button>(Resource.Id.stopRotation);
            _startScale = FindViewById<Button>(Resource.Id.startScale);
            _stopScale = FindViewById<Button>(Resource.Id.stopScale);
            _startShake = FindViewById<Button>(Resource.Id.startShake);
            _stopShake = FindViewById<Button>(Resource.Id.stopShake);
            _startColor = FindViewById<Button>(Resource.Id.startColor);
            _stopColor = FindViewById<Button>(Resource.Id.stopColor);
            _startSprings = FindViewById<Button>(Resource.Id.startSprings);
            _icon1 = FindViewById<ImageView>(Resource.Id.icon1);
            _icon2 = FindViewById<ImageView>(Resource.Id.icon2);
            _icon3 = FindViewById<ImageView>(Resource.Id.icon3);
            _icon4 = FindViewById<ImageView>(Resource.Id.icon4);
            _icon5 = FindViewById<ImageView>(Resource.Id.icon5);
            _startRotation.Click += startRotationButtonClick;
            _stopRotation.Click += stopRotationButtonsClick;
            _startScale.Click += startScaleButtonClick;
            _stopScale.Click += stopScaleButtonsClick;
            _startShake.Click += startShakeButtonClick;
            _stopShake.Click += stopShakeButtonsClick;
            _startColor.Click += startColorButtonClick;
            _stopColor.Click += stopColorButtonsClick;
            _startSprings.Click += startSpringsButtonClick;
        }
    }
}