using OnlineShopingStore.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopingStore.Models
{
    //ategoryDetail
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name required!!!")]
        [StringLength(100, ErrorMessage = "minimum 3 and maximum 100 characters ", MinimumLength = 3)]
        public string CategoryName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }

    //class productDetail
    public class ProductDetail
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product name resuired!!!")]
        [StringLength(100, ErrorMessage = "minimum 3 and maximum 100 characters ", MinimumLength = 3)]
        public string ProductName { get; set; }
        [Required]
        [Range(1, 50)]
        public Nullable<int> CategoryId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifierDate { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public Nullable<bool> Isfeatured { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(typeof(int), "1", "500", ErrorMessage = "Invalid Quantity!!!")]
        public Nullable<int> Quantity { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(typeof(decimal), "1", "2000000", ErrorMessage = "Ivalid price!!!")]
        public Nullable<decimal> Price { get; set; }
        public SelectList Categories { get; set; }

    }
    public class LoginDetail
    {
        public int LoginId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "minimum 3 and maximum 100 characters ", MinimumLength = 3)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> RoleId { get; set; }

        public virtual Tbl_role Tbl_role { get; set; }

    }
}