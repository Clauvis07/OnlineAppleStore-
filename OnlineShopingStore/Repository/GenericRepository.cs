using OnlineShopingStore.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace OnlineShopingStore.Repository
{
    public class GenericRepository<Tbl_Entity> : IRepository<Tbl_Entity> where Tbl_Entity : class
    {
        DbSet<Tbl_Entity> _dbSet;
        //na copy in web.config
        private DB_MyOnlineIphoneStoreEntities _DBEntity;

        //constructor
        public GenericRepository(DB_MyOnlineIphoneStoreEntities DBEntity)
        {
            _DBEntity = DBEntity;
            _dbSet = DBEntity.Set<Tbl_Entity>();

        }

       public IEnumerable<Tbl_Entity> GetProduct()
        {
            return _dbSet.ToList();
        }

       public  IEnumerable<Tbl_Entity> GetCaegory()
        {
            return _dbSet.ToList();
        }
        public void Add(Tbl_Entity entity)
        {
            _dbSet.Add(entity);
            _DBEntity.SaveChanges();
        }

        public int GetAllRecordCount()
        {
            return _dbSet.Count();
        }

        public IEnumerable<Tbl_Entity> GetAllRecords()
        {
            return _dbSet.ToList();
        }

        public IQueryable<Tbl_Entity> GetAllRecordsIQueryable()
        {
            return _dbSet;
        }

        public Tbl_Entity GetFirstOrDefault(int recordId)
        {
            return _dbSet.Find(recordId);
        }

        public Tbl_Entity GetFirstOrDefaultByParameter(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            return _dbSet.Where(wherePredict).FirstOrDefault();
        }

        public IEnumerable<Tbl_Entity> GetListParameter(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            return _dbSet.Where(wherePredict).ToList();
        }

        public IEnumerable<Tbl_Entity> GetRecordsToShow(int pageNo, int pageSize, int currentPage, Expression<Func<Tbl_Entity, bool>> wherePredict, Expression<Func<Tbl_Entity, int>> orderByPredict)
        {
            if (wherePredict != null)
            {
                return _dbSet.OrderBy(orderByPredict).Where(wherePredict).ToList();
            }
            else
            {
                return _dbSet.OrderBy(orderByPredict).ToList();
            }
        }

        public IEnumerable<Tbl_Entity> GetResultBySqlProcedure(string query, params object[] parameters)
        {
            if (parameters != null)
            {
                return _DBEntity.Database.SqlQuery<Tbl_Entity>(query, parameters).ToList();
            }
            else
            {
                return _DBEntity.Database.SqlQuery<Tbl_Entity>(query).ToList();
            }
        }

        public void InactiveAndDeleteMarkByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPredict)
        {
            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        public void Remove(Tbl_Entity entity)
        {
            if (_DBEntity.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
                _DBEntity.SaveChanges();
            }
        }

        public void RemoveByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            Tbl_Entity entity = _dbSet.Where(wherePredict).FirstOrDefault();
            Remove(entity);
        }

        public void RemoveRangeByWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict)
        {
            List<Tbl_Entity> entity = _dbSet.Where(wherePredict).ToList();

            foreach(var ent in entity)
            {
                Remove(ent);
            }
        }

        public void Update(Tbl_Entity entity)
        {
            _dbSet.Attach(entity);
            _DBEntity.Entry(entity).State = EntityState.Modified;
            _DBEntity.SaveChanges();

        }

        public void UpdateWhereClause(Expression<Func<Tbl_Entity, bool>> wherePredict, Action<Tbl_Entity> ForEachPredict)
        {
            _dbSet.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }
    }
}