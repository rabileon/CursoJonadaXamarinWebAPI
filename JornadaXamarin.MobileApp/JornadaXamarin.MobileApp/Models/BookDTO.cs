using JornadaXamarin.MobileApp.AppBase.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace JornadaXamarin.MobileApp.Models
{
    public class BookDTO : SQLiteObject
    {
        public string Title { get; set; }
        public string Editorial { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
    }
}
