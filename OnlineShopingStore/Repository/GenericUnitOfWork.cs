using OnlineShopingStore.DAL;
using OnlineShopingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopingStore.Repository
{
    public class GenericUnitOfWork :IDisposable
    {
        private DB_MyOnlineIphoneStoreEntities DBEntity = new DB_MyOnlineIphoneStoreEntities();

        public IRepository<Tbl_EntityType> GetRepositoryInstance<Tbl_EntityType>() where Tbl_EntityType : class
        {
            return new GenericRepository<Tbl_EntityType>(DBEntity);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DBEntity.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
    }
}