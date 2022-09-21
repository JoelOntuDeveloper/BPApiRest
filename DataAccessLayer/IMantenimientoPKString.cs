using DataTransferObject;

namespace DataAccessLayer {
    public interface IMantenimientoPKString<T> where T : class {
        MultipleResponse<T> GetAll();
        SingleResponse<T> Get(string id);
        SingleResponse<T> Create(T entity);
        SingleResponse<T> Update(T entity);
        SingleResponse<T> Delete(T entity);

    }
}
