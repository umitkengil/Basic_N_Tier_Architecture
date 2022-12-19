using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class,IEntity,new()
    {
        /// <summary>
        /// ID si seçili generic'i getirir
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T Get(Expression<Func<T,bool>> filter);

        /// <summary>
        /// Tüm generic'leri getirir
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IList<T> GetAll(Expression<Func<T,bool>> filter=null);

        /// <summary>
        /// Yeni entity ekle
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// eklenen entity günceller
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// entity siler
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// ID kontrol
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<bool> GetById(Expression<Func<T,bool>> filter);
    }
}
