using DataTransferObject;

namespace DataAccessLayer {
    public interface IMantenimientoPKString<T, K>
        where T : class
        where K : class {

        #region Read Methods
        MultipleResponse<K> GetAll();
        SingleResponse<K> Get(string id);
        #endregion

        #region Maintenance Methods
        SingleResponse<K> Create(T entity);
        SingleResponse<K> Update(T entity);
        SingleResponse<K> Delete(T entity);
        #endregion

    }
}
