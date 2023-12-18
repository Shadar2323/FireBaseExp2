using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using static Android.Content.ClipData;

namespace FireBaseExp2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class MainActivity : AppCompatActivity
    {
        private FirebaseService _firebaseService;
        TextView t;
        string itemId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            t = FindViewById<TextView>(Resource.Id.textView1);
            //lst = databaseContext.GetAllItems();
            //ex = lst[0];
            _firebaseService = new FirebaseService();
            Item item = new Item("banana", 19, new Date { Year = 2023, Month = 11, Day = 11 }, new Date { Year = 2023, Month = 10, Day = 10 });
            SaveNewItem(item);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private async void SaveNewItem(Item item)
        {
            itemId = await _firebaseService.SaveItemAsync(item);
        }
    }
}