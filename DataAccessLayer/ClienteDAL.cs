using DataTransferObject;
using DBContext.DBRepository.Models;
using DBContext.DBRepository;

namespace DataAccessLayer {
    public class ClienteDAL : IMantenimientoPKInt<Cliente, ClienteDTO> {

        BancoDbContext db;

        public ClienteDAL(BancoDbContext db) {
            this.db = db;
        }

        #region Read Methods
        public SingleResponse<ClienteDTO> Get(int id) {

            SingleResponse<ClienteDTO> singleResponse = new SingleResponse<ClienteDTO> {
                Success = false,
                Message = "No se pudo encontrar este registro",
            };

            ClienteDTO clienteDTO = (from cli in db.Clientes
                                     join per in db.Personas on cli.PersonaId equals per.PersonaId
                                     where cli.ClienteId == id
                                     select new ClienteDTO {
                                         PersonaID = cli.PersonaId,
                                         Identificacion = per.Identificacion,
                                         Direccion = per.Direccion,
                                         Edad = per.Edad,
                                         Estado = cli.Estado,
                                         Genero = per.Genero,
                                         NombrePersona = per.Nombre,
                                         Telefono = per.Telefono
                                     }).FirstOrDefault();

            if (clienteDTO != null) {

                singleResponse.Success = true;
                singleResponse.Message = "Búsqueda Exitosa";
                singleResponse.Result = clienteDTO;
            }

            return singleResponse;
        }

        public Cliente GetEntity(int id) {
            return db.Clientes.Find(id);
        }

        public Cliente GetEntityBy(int personaID) {
            return db.Clientes.FirstOrDefault(cli => cli.PersonaId == personaID);
        }

        public SingleResponse<ClienteDTO> GetBy(string identificacion) {

            SingleResponse<ClienteDTO> singleResponse = new SingleResponse<ClienteDTO> {
                Success = false,
                Message = "No se pudo encontrar este registro",
            };

            ClienteDTO clienteDTO = (from cli in db.Clientes
                                     join per in db.Personas on cli.PersonaId equals per.PersonaId
                                     where per.Identificacion == identificacion
                                     select new ClienteDTO {
                                         PersonaID = cli.PersonaId,
                                         Identificacion = per.Identificacion,
                                         Direccion = per.Direccion,
                                         Edad = per.Edad,
                                         Estado = cli.Estado,
                                         Genero = per.Genero,
                                         NombrePersona = per.Nombre,
                                         Telefono = per.Telefono
                                     }).FirstOrDefault();

            if (clienteDTO != null) {

                singleResponse.Success = true;
                singleResponse.Message = "Búsqueda Exitosa";
                singleResponse.Result = clienteDTO;
            }

            return singleResponse;
        }

        public MultipleResponse<ClienteDTO> GetAll() {


            List<ClienteDTO> clienteDTO = (from cli in db.Clientes
                                           join per in db.Personas on cli.PersonaId equals per.PersonaId
                                           select new ClienteDTO {
                                               PersonaID = cli.PersonaId,
                                               Identificacion = per.Identificacion,
                                               Direccion = per.Direccion,
                                               Edad = per.Edad,
                                               Estado = cli.Estado,
                                               Genero = per.Genero,
                                               NombrePersona = per.Nombre,
                                               Telefono = per.Telefono
                                           }).ToList();

            MultipleResponse<ClienteDTO> response = new MultipleResponse<ClienteDTO> {
                Success = false,
                Message = "Búsqueda exitosa",
                MultipleResult = clienteDTO
            };

            return response;
        }
        #endregion

        #region Maintenance Methods
        public SingleResponse<ClienteDTO> Create(Cliente entity) {

            SingleResponse<ClienteDTO> response = new SingleResponse<ClienteDTO> {
                Success = false,
                Message = "No se pudo realizar el registro",
            };

            db.Add(entity);

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Registro exitoso";
                response.Result = new ClienteDTO {
                    Estado = true,
                };

                return response;

            } catch (Exception) {

                return response;
            }

        }

        public SingleResponse<ClienteDTO> Delete(int id) {
            SingleResponse<ClienteDTO> response = new SingleResponse<ClienteDTO> {
                Success = false,
                Message = "No se pudo eliminar el registro",
            };

            Cliente entityToRemove = db.Clientes.Find(id);

            db.Remove(entityToRemove);

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Eliminación exitosa";
                response.Result = new ClienteDTO {
                    Estado = true,
                };

                return response;

            } catch (Exception) {

                return response;
            }
        }

        public SingleResponse<ClienteDTO> Update(Cliente entity) {

            SingleResponse<ClienteDTO> response = new SingleResponse<ClienteDTO> {
                Success = false,
                Message = "No se pudo realizar el registro",
            };

            db.Update(entity);

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Registro actualizado";
                response.Result = new ClienteDTO {
                    Estado = true,
                };

                return response;

            } catch (Exception) {

                return response;
            }
        }

        #endregion
    }
}
