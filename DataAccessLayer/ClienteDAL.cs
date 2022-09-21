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
                                     join per in db.Personas on cli.Identificacion equals per.Identificacion
                                     where cli.ClienteId == id
                                     select new ClienteDTO {
                                         Identificacion = cli.Identificacion,
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

        public SingleResponse<ClienteDTO> GetBy(string identificacion) {

            SingleResponse<ClienteDTO> singleResponse = new SingleResponse<ClienteDTO> {
                Success = false,
                Message = "No se pudo encontrar este registro",
            };

            ClienteDTO clienteDTO = (from cli in db.Clientes
                                     join per in db.Personas on cli.Identificacion equals per.Identificacion
                                     where cli.Identificacion == identificacion
                                     select new ClienteDTO {
                                         Identificacion = cli.Identificacion,
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

            MultipleResponse<ClienteDTO> response = new MultipleResponse<ClienteDTO> {
                Success = false,
                Message = "No se pudo encontrar este registro",
            };

            List<ClienteDTO> clienteDTO = (from cli in db.Clientes
                                           join per in db.Personas on cli.Identificacion equals per.Identificacion
                                           select new ClienteDTO {
                                               Identificacion = cli.Identificacion,
                                               Direccion = per.Direccion,
                                               Edad = per.Edad,
                                               Estado = cli.Estado,
                                               Genero = per.Genero,
                                               NombrePersona = per.Nombre,
                                               Telefono = per.Telefono
                                           }).ToList();

            if (clienteDTO != null) {

                response.Success = true;
                response.Message = "Búsqueda Exitosa";
                response.MultipleResult = clienteDTO;
            }

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
                    Identificacion = entity.Identificacion,
                    Estado = "True",
                };

                return response;

            } catch (Exception) {

                return response;
            }

        }

        public SingleResponse<ClienteDTO> Delete(Cliente entity) {
            SingleResponse<ClienteDTO> response = new SingleResponse<ClienteDTO> {
                Success = false,
                Message = "No se pudo eliminar el registro",
            };

            Persona entityToRemove = db.Personas.Find(entity.Identificacion);

            db.Remove(entityToRemove);

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Eliminación exitosa";
                response.Result = new ClienteDTO {
                    Identificacion = entity.Identificacion,
                    Estado = "True",
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
                    Identificacion = entity.Identificacion,
                    Estado = "True",
                };

                return response;

            } catch (Exception) {

                return response;
            }
        }
        #endregion
    }
}
