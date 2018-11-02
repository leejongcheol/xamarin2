using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;

namespace Android_Hello
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", 
        MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            Button callButton = FindViewById<Button>(Resource.Id.CallButton);

            callButton.Enabled = false;

            phoneNumberText.TextChanged += (s, e) =>
            {
                callButton.Enabled = !string.IsNullOrWhiteSpace(phoneNumberText.Text) ? true : false;
            };

            callButton.Click += (o, e) =>
            {
                var callDialog = new Android.App.AlertDialog.Builder(this);
                callDialog.SetMessage("전화거시겠어요? " + phoneNumberText.Text);

                callDialog.SetNeutralButton("Call", delegate
                {
                    var callIntent = new Intent(Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse("tel:" + phoneNumberText.Text));
                     StartActivity(callIntent);                    
                });
                callDialog.SetNegativeButton("Cancel", delegate { });

                callDialog.Show();
            };

        }
    }
}