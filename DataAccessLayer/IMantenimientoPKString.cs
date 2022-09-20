using DataTransferObject;

namespace DataAccessLayer {
    public interface IMantenimientoPKString<T> where T : class {
        List<T> GetAll();
        SingleResponse<T> Get(int id);
        SingleResponse<T> Create(T entity);
        SingleResponse<T> Update(T entity);
        SingleResponse<T> Delete(T entity);

    }
}
