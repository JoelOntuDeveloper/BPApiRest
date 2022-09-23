using DataTransferObject;
using DBContext.DBRepository;
using DBContext.DBRepository.Models;

namespace DataAccessLayer {
    public class MovimientoDAL : IMantenimientoPKInt<Movimiento, MovimientoDTO> {

        BancoDbContext db;
        public MovimientoDAL(BancoDbContext db) {
            this.db = db;
        }

        #region Read Methods
        public SingleResponse<MovimientoDTO> Get(int id) {

            SingleResponse<MovimientoDTO> singleResponse = new SingleResponse<MovimientoDTO> {
                Success = false,
                Message = "No se ha encontrado a la persona",
            };

            Movimiento result = db.Movimientos.Find(id);

            if (result != null) {

                singleResponse.Success = true;
                singleResponse.Message = "Búsqueda Exitosa";
                singleResponse.Result = new MovimientoDTO {
                    Fecha = result.Fecha,
                    MovimientoId = result.MovimientoId,
                    NumeroCuenta = result.NumeroCuenta,
                    Saldo = result.Saldo,
                    TipoMovimiento = result.TipoMovimiento,
                    Valor = result.Valor,
                };
            }

            return singleResponse;
        }

        public MultipleResponse<MovimientoDTO> GetAll() {

            List<MovimientoDTO> movimientos = db.Movimientos.Select(mov => new MovimientoDTO {
                MovimientoId = mov.MovimientoId,
                Valor = mov.Valor,
                TipoMovimiento = mov.TipoMovimiento,
                Saldo = mov.Saldo,
                Fecha = mov.Fecha,
                NumeroCuenta = mov.NumeroCuenta
            }).ToList();

            MultipleResponse<MovimientoDTO> response = new MultipleResponse<MovimientoDTO> {
                Success = true,
                Message = "Búsqueda Exitosa",
                MultipleResult = movimientos
            };

            return response;
        }

        public Movimiento GetEntity(int id) {
            return db.Movimientos.FirstOrDefault(mov => mov.MovimientoId == id);
        }
        #endregion

        public SingleResponse<MovimientoDTO> Create(Movimiento entity) {

            db.Add(entity);

            SingleResponse<MovimientoDTO> response = new SingleResponse<MovimientoDTO> {
                Success = false,
                Message = "No se pudo registrar este movimiento",
            };

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Transacción exitosa";
                response.Result = new MovimientoDTO {
                    NumeroCuenta = entity.NumeroCuenta,
                    MovimientoId = entity.MovimientoId,
                    Fecha = entity.Fecha,
                    Saldo = entity.Saldo,
                    TipoMovimiento = entity.TipoMovimiento,
                    Valor = entity.Valor,
                };

                return response;

            } catch (Exception) {

                return response;
            }
        }

        public SingleResponse<MovimientoDTO> Delete(int id) {

            Movimiento entity = GetEntity(id);
            db.Add(entity);

            SingleResponse<MovimientoDTO> response = new SingleResponse<MovimientoDTO> {
                Success = false,
                Message = "No se pudo eliminar este movimiento",
            };

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Cuenta eliminada";
                response.Result = new MovimientoDTO {
                    NumeroCuenta = entity.NumeroCuenta,
                    MovimientoId = entity.MovimientoId,
                    Fecha = entity.Fecha,
                    Saldo = entity.Saldo,
                    TipoMovimiento = entity.TipoMovimiento,
                    Valor = entity.Valor,
                };

                return response;

            } catch (Exception) {

                return response;
            }
        }

        public SingleResponse<MovimientoDTO> Update(Movimiento entity) {

            db.Update(entity);

            SingleResponse<MovimientoDTO> response = new SingleResponse<MovimientoDTO> {
                Success = false,
                Message = "No se pudo actualizar este movimiento",
            };

            try {

                db.SaveChanges();

                response.Success = true;
                response.Message = "Transacción actualizada";
                response.Result = new MovimientoDTO {
                    NumeroCuenta = entity.NumeroCuenta,
                    MovimientoId = entity.MovimientoId,
                    Fecha = entity.Fecha,
                    Saldo = entity.Saldo,
                    TipoMovimiento = entity.TipoMovimiento,
                    Valor = entity.Valor,
                };

                return response;

            } catch (Exception) {

                return response;
            }
        }
    }
}
