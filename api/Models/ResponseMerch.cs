using api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class ResponseMerch
    {
        public ResponseMerch(merch merch)
        {
            id = merch.id;
            name = merch.name;
            dexcription = merch.dexcription;
            manufacturer = merch.manufacturer;
            price = merch.price;
            photo = merch.photo;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string dexcription { get; set; }
        public string manufacturer { get; set; }
        public int price { get; set; }
        public byte[] photo { get; set; }
    }
}