using OnlineShopingStore.DAL;
using OnlineShopingStore.Models.Home;
using OnlineShopingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopingStore.Controllers
{
    public class HomeController : Controller

    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public DB_MyOnlineIphoneStoreEntities context = new DB_MyOnlineIphoneStoreEntities();

        public ActionResult Index(string search, int? page)
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            return View(model.createModel(search, 4, page));
        }

        //Ajouter au panier
        public ActionResult AddToCart(int productId, string url)
        {
            if (Session["cart"] == null)
            {
                //create new list 
                List<Item> cart = new List<Item>();
                //find product by ID
                var product = context.Tbl_Product.Find(productId);
                //add product in the cart
                cart.Add(new Item
                {
                    product = product,
                    quantity = 1
                });
                //store in session

                Session["cart"] = cart;

            }
            else
            {
                //store in cart
                List<Item> cart = (List<Item>)Session["cart"];
                var count = cart.Count();
                var product = context.Tbl_Product.Find(productId);
                for (int i = 0; i < count; i++)
                {
                    if (cart[i].product.ProductId == productId)
                    {
                        int privQty = cart[i].quantity;
                        //move doublon
                        cart.Remove(cart[i]);
                        cart.Add(new Item
                        {
                            product = product,
                            quantity = privQty + 1
                        });
                        break;
                    }
                    else
                    {
                        var prd = cart.Where(x => x.product.ProductId == productId).SingleOrDefault();
                        if (prd == null)
                        {
                            cart.Add(new Item
                            {
                                product = product,
                                quantity = 1
                            });
                        }
                    }
                }

                Session["cart"] = cart;
            }
            return Redirect(url);
        }


        //remove to cart
        public ActionResult removeFormCart(int productId)
        {
            //store in cart
            List<Item> cart = (List<Item>)Session["cart"];

            foreach (var item in cart)
            {
                if (item.product.ProductId == productId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            //store in session

            Session["cart"] = cart;
            return Redirect("Index");
        }
        //view ChekOut
        public ActionResult CheckOut()
        {
            return View();
        }

        //view ChekOutDetail
        public ActionResult CheckOutDetails()
        {
            return View();
        }

        //rediuse quantity
        public ActionResult DecreaseQty(int productId)
        {
            if (Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var count = cart.Count();
                var product = context.Tbl_Product.Find(productId);
                for (int i = 0; i < count; i++)
                {
                    if (cart[i].product.ProductId == productId)
                    {
                        int privQty = cart[i].quantity;
                        if (privQty > 1)
                        {
                            cart.Remove(cart[i]);
                            cart.Add(new Item
                            {
                                product = product,
                                quantity = privQty - 1
                            });
                        }
                        break;
                    }
                }
                Session["cart"] = cart;
            }
                return Redirect("CheckOut");
            }

        public ActionResult Location()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddUser(Tbl_Members tbl)
        {
            tbl.CreateOn = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Tbl_Members>().Add(tbl);
            return RedirectToAction("Index");
        }


    }
}
