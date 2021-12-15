using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using MKT.Entities.Models;

namespace MKT.Data.Services
{
    public class BaseDataService<T> : IDataService<T> where T : MKT.Entities.Models.IdentityBase, new()
    {
        protected MKTDbContext mktContext;

        public BaseDataService()
        {
            this.mktContext = new MKTDbContext();
        }

        public T Create(T entity)
        {
            mktContext.Set<T>().Add(entity);
            mktContext.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            mktContext.Set<T>().Attach(entity);
            mktContext.Set<T>().Remove(entity);
            mktContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            this.Delete(entity);
        }

        public List<T> Get(Expression<Func<T, bool>> whereExpression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunction = null, string includeModels = "")
        {
            IQueryable<T> query = mktContext.Set<T>();

            if (whereExpression != null)
                query = query.Where(whereExpression);

            var entity = includeModels.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            query = entity.Aggregate(query, (current, model) => current.Include(model));

            if (orderFunction != null)
                query = orderFunction(query);

            return query.ToList();
        }

        public T GetById(int id)
        {
            return mktContext.Set<T>().SingleOrDefault(o => o.Id == id);
        }

        public void Update(T entity)
        {
            mktContext.Entry(entity).State = EntityState.Modified;
            mktContext.SaveChanges();
        }

        public List<ValidationResult> ValidateModel(T model)
        {
            throw new NotImplementedException();
        }
    }
}