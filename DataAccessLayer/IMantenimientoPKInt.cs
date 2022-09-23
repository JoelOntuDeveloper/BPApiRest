using DataTransferObject;

namespace DataAccessLayer {

    /// <summary>
    /// Interfaz de mantenimiento para poder hacer Operaciones de CRUD
    /// </summary>
    /// <typeparam name="T">Entidad que hace referencia a la Tabla de la Base de datos</typeparam>
    /// <typeparam name="K">Objeto que se retornará</typeparam>
    public interface IMantenimientoPKInt<T, K>
        where T : class
        where K : class {

        #region Read Methods
        MultipleResponse<K> GetAll();
        SingleResponse<K> Get(int id);
        T GetEntity(int id);
        #endregion

        #region Maintenance Methods
        SingleResponse<K> Create(T entity);
        SingleResponse<K> Update(T entity);
        SingleResponse<K> Delete(int id);
        #endregion
    }


}
