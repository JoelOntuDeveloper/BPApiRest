using DataTransferObject;
using DBContext.DBRepository;
using DBContext.DBRepository.Models;

namespace DataAccessLayer {
    public class CuentaDAL : IMantenimientoPKString<Cuentum, CuentaDTO> {

        BancoDbContext db;

        public CuentaDAL(BancoDbContext db) {

            this.db = db;
        }

        #region Read Methods
        public SingleResponse<CuentaDTO> Get(string id) {

            SingleResponse<CuentaDTO> singleResponse = new SingleResponse<CuentaDTO> {
                Success = false,
                Message = "No se ha encontrado a la persona",
            };

            Cuentum result = db.Cuenta.Find(id);

            if (result != null) {

                singleResponse.Success = true;
                singleResponse.Message = "Búsqueda Exitosa";
                singleResponse.Result = new CuentaDTO {
                    NumeroCuenta = result.NumeroCuenta,
                    TipoCuenta = result.TipoCuenta,
                    Estado = result.Estado,
                    ClienteId = result.ClienteId,
                    SaldoInicial = result.SaldoInicial
                };
            }

            return singleResponse;
        }

        public MultipleResponse<CuentaDTO> GetAll() {

            List<CuentaDTO> cuentas = db.Cuenta.Select(cuenta => new CuentaDTO {
                NumeroCuenta = cuenta.NumeroCuenta,
                TipoCuenta = cuenta.TipoCuenta,
                Estado = cuenta.Estado,
                ClienteId = cuenta.ClienteId,
                SaldoInicial = cuenta.SaldoInicial
            }).ToList();

            MultipleResponse<CuentaDTO> response = new MultipleResponse<CuentaDTO> {
                Success = true,
                Message = "Búsqueda Exitosa",
                MultipleResult = cuentas
            };

            return response;
        }

        public Cuentum GetEntity(string id) {
            return db.Cuenta.FirstOrDefault(cuenta => cuenta.NumeroCuenta == id);
        }

        public List<Cuentum> GetCuentasByCliente(int clienteID) {
            return db.Cuenta.Where(cue => cue.ClienteId == clienteID).ToList();
        }

        #endregion

        #region Maintenance Methods
        public SingleResponse<CuentaDTO> Create(Cuentum entity) {

            db.Add(entity);

            SingleResponse<CuentaDTO> response = new SingleResponse<CuentaDTO> {
                Success = false,
                Message = "No se pudo registrar a esta cuenta",
            };

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Registro exitoso";
                response.Result = new CuentaDTO {
                    NumeroCuenta = entity.NumeroCuenta,
                    TipoCuenta = entity.TipoCuenta,
                    Estado = entity.Estado,
                    ClienteId = entity.ClienteId,
                    SaldoInicial = entity.SaldoInicial
                };

                return response;

            } catch (Exception) {

                return response;
            }
        }

        public SingleResponse<CuentaDTO> Delete(string id) {

            Cuentum entity = GetEntity(id);
            db.Add(entity);

            SingleResponse<CuentaDTO> response = new SingleResponse<CuentaDTO> {
                Success = false,
                Message = "No se pudo eliminar esta cuenta",
            };

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Cuenta eliminada";
                response.Result = new CuentaDTO {
                    NumeroCuenta = entity.NumeroCuenta,
                    TipoCuenta = entity.TipoCuenta,
                    Estado = entity.Estado,
                    ClienteId = entity.ClienteId,
                    SaldoInicial = entity.SaldoInicial
                };

                return response;

            } catch (Exception) {

                return response;
            }

        }

        public SingleResponse<CuentaDTO> Update(Cuentum entity) {

            db.Update(entity);

            SingleResponse<CuentaDTO> response = new SingleResponse<CuentaDTO> {
                Success = false,
                Message = "No se pudo actualizar esta cuenta",
            };

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Registro actualizado";
                response.Result = new CuentaDTO {
                    NumeroCuenta = entity.NumeroCuenta,
                    TipoCuenta = entity.TipoCuenta,
                    Estado = entity.Estado,
                    ClienteId = entity.ClienteId,
                    SaldoInicial = entity.SaldoInicial
                };

                return response;

            } catch (Exception) {

                return response;
            }
        }
        #endregion
    }
}
