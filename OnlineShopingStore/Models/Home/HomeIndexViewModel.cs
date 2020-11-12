using OnlineShopingStore.DAL;
using OnlineShopingStore.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace OnlineShopingStore.Models.Home
{
    public class HomeIndexViewModel
    {
        //objet  GenericUnitOfWork
        public GenericUnitOfWork  _unitOfWork = new GenericUnitOfWork();

        //objet context
        public DB_MyOnlineIphoneStoreEntities context = new DB_MyOnlineIphoneStoreEntities();

        public IPagedList<Tbl_Product> ListOfProducts { get; set; }
        public string FirstName { get; set; }

        public  HomeIndexViewModel createModel(string search,int pageSize,int? page)
        {
            //usage de la procedure stokée
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
            IPagedList<Tbl_Product> data = context.Database.SqlQuery<Tbl_Product>("GetBySearch @search", param).ToList().ToPagedList(page??1, pageSize);
            return new HomeIndexViewModel
            {
                //_unitOfWork.GetRepositoryInstance<Tbl_Product>().GetAllRecords()
                //entity framework do not support left  join
                ListOfProducts = data
            };
        }
    }
}