using DataTransferObject;

namespace DataAccessLayer {
    public interface IMantenimientoPKInt<T> where T : class {

        MultipleResponse<T> GetAll();
        SingleResponse<T> Get(int id);
        SingleResponse<T> Create(T entity);
        SingleResponse<T> Update(T entity);
        SingleResponse<T> Delete(T entity);
    }


}
