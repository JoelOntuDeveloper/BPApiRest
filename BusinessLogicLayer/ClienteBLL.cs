using DataAccessLayer;
using DataTransferObject;
using DBContext.DBRepository;
using DBContext.DBRepository.Models;
using General.Validations;

namespace BusinessLogicLayer {
    public class ClienteBLL {

        BancoDbContext db;
        ClienteDAL clienteDAL;
        PersonaDAL personaDAL;

        public ClienteBLL(BancoDbContext db) {
            this.db = db;
            clienteDAL = new ClienteDAL(this.db);
            personaDAL = new PersonaDAL(this.db);
        }

        public SingleResponse<ClienteDTO> GetBy(string identificacion) {

            SingleResponse<ClienteDTO> response = clienteDAL.GetBy(identificacion);

            return response;
        }

        public MultipleResponse<ClienteDTO> GetAll() {

            MultipleResponse<ClienteDTO> response = clienteDAL.GetAll();

            return response;
        }

        public SingleResponse<ClienteDTO> Create(ClienteDTO cliente) {

            SingleResponse<ClienteDTO> response = new SingleResponse<ClienteDTO> {
                Success = false,
                Result = cliente,
            };

            Validate(response);

            if (response.HasValidationExcepcion) {
                return response;
            } else {

                RegistroClienteYPersona(response);

                return response;
            }

        }

        #region Validations
        private void Validate(SingleResponse<ClienteDTO> response) {

            Validation<ClienteDTO> validation = new Validation<ClienteDTO>(response);
            validation.IsRequired(response.Result.Identificacion, "Identificación");
            validation.IsRequired(response.Result.NombrePersona, "Nombre");
            validation.IsRequired(response.Result.Genero, "Género");

            ValidarIdentificacionDuplicada(response.Result, validation);

        }
        #endregion

        #region Private Methods
        private void RegistroClienteYPersona(SingleResponse<ClienteDTO> response) {

            Persona persona = new Persona() {
                Identificacion = response.Result.Identificacion,
                Direccion = response.Result.Direccion,
                Telefono = response.Result.Telefono,
                Edad = response.Result.Edad,
                Genero = response.Result.Genero,
                Nombre = response.Result.NombrePersona,
            };

            Cliente cliente = new Cliente() {
                Contrasenia = response.Result.Contrasenia,
                Estado = response.Result.Estado,
            };

            using (db.Database.BeginTransaction()) {

                try {

                    SingleResponse<PersonaDTO> resultadoRegistroPersona = personaDAL.Create(persona);

                    cliente.PersonaId = persona.PersonaId;
                    SingleResponse<ClienteDTO> resultadoRegistroCliente = clienteDAL.Create(cliente);

                    if (resultadoRegistroPersona.Success && resultadoRegistroCliente.Success) {

                        db.Database.CommitTransaction();

                        response.Success = true;
                        response.Message = "Registro exitoso";

                    } else {

                        db.Database.RollbackTransaction();

                        response.Success = false;
                        response.Message = "Error al realizar el registro";
                    }

                } catch (Exception) {

                    db.Database.RollbackTransaction();

                    response.Success = false;
                    response.Message = "Error al realizar el registro";
                }
            }
        }

        private void ValidarIdentificacionDuplicada(ClienteDTO clienteDTO, Validation<ClienteDTO> validation) {

            if (personaDAL.ExistePersonaIdentificacion(Convert.ToInt32(clienteDTO.PersonaID), clienteDTO.Identificacion)) {
                validation.NewRule("Ya existe un cliente con esta Identificación");
            }
        }

        #endregion
    }
}
