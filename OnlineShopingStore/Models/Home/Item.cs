using OnlineShopingStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopingStore.Models.Home
{
    public  class Item
    {
        public Tbl_Product product { get; set; }
        public int quantity { get; set; }
        public Tbl_Members member { get; set; }
        public string FirstName { get; set; }
    }
    
}