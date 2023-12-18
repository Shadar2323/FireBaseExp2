using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireBaseExp2
{
    public class FirebaseService
    {
        private FirebaseClient _firebaseClient;

        public FirebaseService()
        {
            // Initialize Firebase client with your database URL
            _firebaseClient = new FirebaseClient("https://learning-435ae-default-rtdb.europe-west1.firebasedatabase.app/");
        }
        public async Task<string> SaveItemAsync(Item item)
        {
            var itemsNode = _firebaseClient.Child("items");

            // Serialize the item to JSON before posting to Firebase
            string itemJson = JsonConvert.SerializeObject(item);

            // Post the serialized JSON to Firebase
            var newItemNode = await itemsNode.PostAsync(itemJson);

            // Retrieve the generated key for the new item
            string newItemKey = newItemNode.Key;

            return newItemKey;
        }

        public async Task<Item> GetItemAsync(string itemId)
        {
            var itemsNode = _firebaseClient.Child("items").Child(itemId);

            // Retrieve the serialized JSON from Firebase
            string itemJson = await itemsNode.OnceSingleAsync<string>();

            // Deserialize the JSON back to the Item object
            Item retrievedItem = JsonConvert.DeserializeObject<Item>(itemJson);

            return retrievedItem;
        }
    }
}