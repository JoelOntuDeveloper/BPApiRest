using DataTransferObject;
using DBContext.DBRepository;
using DBContext.DBRepository.Models;

namespace DataAccessLayer {
    public class PersonaDAL : IMantenimientoPKInt<Persona> {

        BancoDbContext db;

        public PersonaDAL(BancoDbContext db) {

            this.db = db;
        }

        #region Get Methods
        public SingleResponse<Persona> Get(int id) {

            SingleResponse<Persona> singleResponse = new SingleResponse<Persona> {
                Success = false,
                Message = "No se ha encontrado a la persona",
            };

            Persona result = db.Personas.Find(id);

            if (result != null) {

                singleResponse.Success = true;
                singleResponse.Message = "Búsqueda Exitosa";
                singleResponse.Result = result;
            }

            return singleResponse;
        }

        public MultipleResponse<Persona> GetAll() {

            List<Persona> personas = db.Personas.ToList();

            MultipleResponse<Persona> multipleResponse = new MultipleResponse<Persona> {
                Success = true,
                Message = "Búsqueda Exitosa",
                MultipleResult = personas
            };

            return multipleResponse;
        }
        #endregion

        #region Maintenance Methods
        public SingleResponse<Persona> Create(Persona entity) {
            throw new NotImplementedException();
        }

        public SingleResponse<Persona> Delete(Persona entity) {
            throw new NotImplementedException();
        }

        public SingleResponse<Persona> Update(Persona entity) {
            throw new NotImplementedException();
        }
        #endregion
    }
}
