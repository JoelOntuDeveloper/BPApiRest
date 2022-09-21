using DataTransferObject;
using DBContext.DBRepository;
using DBContext.DBRepository.Models;

namespace DataAccessLayer {
    public class PersonaDAL : IMantenimientoPKString<Persona, PersonaDTO> {

        BancoDbContext db;

        public PersonaDAL(BancoDbContext db) {

            this.db = db;
        }

        #region Get Methods
        public SingleResponse<PersonaDTO> Get(string id) {

            SingleResponse<PersonaDTO> singleResponse = new SingleResponse<PersonaDTO> {
                Success = false,
                Message = "No se ha encontrado a la persona",
            };

            Persona result = db.Personas.Find(id);

            if (result != null) {

                singleResponse.Success = true;
                singleResponse.Message = "Búsqueda Exitosa";
                singleResponse.Result = new PersonaDTO {
                    Identificacion = result.Identificacion,
                    Direccion = result.Direccion,
                    Edad = result.Edad,
                    Genero = result.Genero,
                    Nombre = result.Nombre,
                    Telefono = result.Telefono,
                };
            }

            return singleResponse;
        }

        public MultipleResponse<PersonaDTO> GetAll() {

            List<PersonaDTO> personas = db.Personas.Select(p => new PersonaDTO {
                Identificacion = p.Identificacion,
                Direccion = p.Direccion,
                Edad = p.Edad,
                Genero = p.Genero,
                Nombre = p.Nombre,
                Telefono = p.Telefono,
            }).ToList();

            MultipleResponse<PersonaDTO> multipleResponse = new MultipleResponse<PersonaDTO> {
                Success = true,
                Message = "Búsqueda Exitosa",
                MultipleResult = personas
            };

            return multipleResponse;
        }
        #endregion

        #region Maintenance Methods
        public SingleResponse<PersonaDTO> Create(Persona entity) {

            db.Add(entity);

            SingleResponse<PersonaDTO> response = new SingleResponse<PersonaDTO> {
                Success = false,
                Message = "No se pudo registrar a esta persona",
            };

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Registro exitoso";
                response.Result = new PersonaDTO {
                    Identificacion = entity.Identificacion,
                    Direccion = entity.Direccion,
                    Edad = entity.Edad,
                    Genero = entity.Genero,
                    Nombre = entity.Nombre,
                    Telefono = entity.Telefono,
                };

                return response;

            } catch (Exception) {

                return response;
            }

        }

        public SingleResponse<PersonaDTO> Delete(Persona entity) {

            Persona entityToRemove = db.Personas.Find(entity.Identificacion);

            db.Remove(entityToRemove);

            SingleResponse<PersonaDTO> response = new SingleResponse<PersonaDTO> {
                Success = false,
                Message = "No se pudo eliminar a esta persona",
            };

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Registro actualizado";
                response.Result = new PersonaDTO {
                    Identificacion = entity.Identificacion,
                    Direccion = entity.Direccion,
                    Edad = entity.Edad,
                    Genero = entity.Genero,
                    Nombre = entity.Nombre,
                    Telefono = entity.Telefono,
                };

                return response;

            } catch (Exception) {

                return response;
            }


        }

        public SingleResponse<PersonaDTO> Update(Persona entity) {

            db.Update(entity);

            SingleResponse<PersonaDTO> response = new SingleResponse<PersonaDTO> {
                Success = false,
                Message = "No se pudo actualizar los datos de esta persona",
            };

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Registro actualizado";
                response.Result = new PersonaDTO {
                    Identificacion = entity.Identificacion,
                    Direccion = entity.Direccion,
                    Edad = entity.Edad,
                    Genero = entity.Genero,
                    Nombre = entity.Nombre,
                    Telefono = entity.Telefono,
                };

                return response;

            } catch (Exception) {

                return response;
            }
        }
        #endregion
    }
}
