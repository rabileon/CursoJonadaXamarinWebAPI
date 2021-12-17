using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace JornadaXamarin.MobileApp.AppBase.Storage.Interfaces
{
    public interface IKeyObject
    {
        [PrimaryKey]
        public string Id { get; set; }
    }
}
