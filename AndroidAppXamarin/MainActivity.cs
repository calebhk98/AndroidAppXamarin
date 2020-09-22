using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Xamarin.Essentials;
using Android.Net;
using System;
using Java.Net;
using System.Collections.Generic;
using Android.Content;

namespace AndroidAppXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
             List<string> phoneNumbers = new List<string>();
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Get our UI controls from the loaded layout
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            Button UpdateButton = FindViewById<Button>(Resource.Id.updateButton);
            Button JapaneseBtn = FindViewById<Button>(Resource.Id.DownloadJapaneseAppBtn);
            Button translationHistoryButton = FindViewById<Button>(Resource.Id.TranslationHistoryButton);


            translationHistoryButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(TranslationHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };


            // Add code to translate number
            string translatedNumber = string.Empty;
            translateButton.Click += (sender, e) =>
            {
                // Translate user's alphanumeric phone number to numeric
                translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    translatedPhoneWord.Text = string.Empty;
                }
                else
                {
                    translatedPhoneWord.Text = translatedNumber;
                    phoneNumbers.Add(translatedNumber);
                    translationHistoryButton.Enabled = true;
                }
            };



            UpdateButton.Click += (sender, e) =>
            {
                Launcher.OpenAsync(new System.Uri("https://github.com/calebhk98/AndroidAppXamarin/raw/master/AndroidAppXamarin.AndroidAp.apk"));
            };

            JapaneseBtn.Click += (sender, e) =>
            {
                Launcher.OpenAsync(new System.Uri("https://github.com/calebhk98/JapaneseLearningApp/blob/master/com.companyname.japanese_learning.apk"));
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    
        
    
    
    
    }
}