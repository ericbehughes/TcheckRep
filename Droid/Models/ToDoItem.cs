using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace TCheck.Droid.Models
{
    public class ToDoItem
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }

    public class ToDoItemWrapper : Java.Lang.Object
    {
        public ToDoItemWrapper(ToDoItem item)
        {
            ToDoItem = item;
        }

        public ToDoItem ToDoItem { get; private set; }
    }
}