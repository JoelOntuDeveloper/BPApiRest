using DataTransferObject;
using DBContext.DBRepository;
using DBContext.DBRepository.Models;

namespace DataAccessLayer {
    public class PersonaDAL : IMantenimientoPKString<Persona> {

        BancoDbContext db;

        public PersonaDAL(BancoDbContext db) {

            this.db = db;
        }

        #region Get Methods
        public SingleResponse<Persona> Get(string id) {

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

            db.Add(entity);

            SingleResponse<Persona> response = new SingleResponse<Persona> {
                Success = false,
                Message = "No se pudo registrar a esta persona",
            };

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Registro exitoso";
                response.Result = entity;

                return response;

            } catch (Exception) {

                return response;
            }

        }

        public SingleResponse<Persona> Delete(Persona entity) {

            db.Remove(entity);

            SingleResponse<Persona> response = new SingleResponse<Persona> {
                Success = false,
                Message = "No se pudo eliminar a esta persona",
            };

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Registro actualizado";
                response.Result = entity;

                return response;

            } catch (Exception) {

                return response;
            }


        }

        public SingleResponse<Persona> Update(Persona entity) {

            db.Update(entity);

            SingleResponse<Persona> response = new SingleResponse<Persona> {
                Success = false,
                Message = "No se pudo actualizar los datos de esta persona",
            };

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Registro actualizado";
                response.Result = entity;

                return response;

            } catch (Exception) {

                return response;
            }
        }
        #endregion
    }
}
