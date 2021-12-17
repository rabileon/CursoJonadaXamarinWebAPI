using System;
using System.Collections.Generic;
using System.Text;

namespace JornadaXamarin.MobileApp.AppBase.Storage
{
    public abstract class SQLiteObject : Interfaces.IKeyObject
    {
        public SQLiteObject()
        {

        }

        public string Id { get; set; }
    }
}
