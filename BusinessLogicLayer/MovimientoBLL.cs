using DataAccessLayer;
using DataTransferObject;
using DBContext.DBRepository;
using DBContext.DBRepository.Models;

namespace BusinessLogicLayer {
    public class MovimientoBLL {

        BancoDbContext db;
        MovimientoDAL movimientoDAL;

        public MovimientoBLL(BancoDbContext db) {
            this.db = db;

            movimientoDAL = new MovimientoDAL(this.db);
        }

        public SingleResponse<MovimientoDTO> GetBy(int movimientoID) {

            SingleResponse<MovimientoDTO> response = movimientoDAL.Get(movimientoID);

            return response;
        }

        public MultipleResponse<MovimientoDTO> GetAll() {

            MultipleResponse<MovimientoDTO> response = movimientoDAL.GetAll();

            return response;
        }

        public MultipleResponse<MovimientoDTO> GetByCuenta(string numeroCuenta) {

            MultipleResponse<MovimientoDTO> response = movimientoDAL.GetByCuenta(numeroCuenta);

            return response;
        }

        public SingleResponse<MovimientoDTO> Create(MovimientoDTO movimientoDTO) {

            Movimiento movimiento = new Movimiento {
                Fecha = movimientoDTO.Fecha,
                MovimientoId = movimientoDTO.MovimientoId,
                NumeroCuenta = movimientoDTO.NumeroCuenta,
                TipoMovimiento = movimientoDTO.TipoMovimiento,
                Saldo = movimientoDTO.Saldo,
                Valor = movimientoDTO.Valor
            };

            return movimientoDAL.Create(movimiento); ;

        }

        public SingleResponse<MovimientoDTO> Update(MovimientoDTO movimientoDTO) {

            Movimiento movimiento = new Movimiento {
                Fecha = movimientoDTO.Fecha,
                MovimientoId = movimientoDTO.MovimientoId,
                NumeroCuenta = movimientoDTO.NumeroCuenta,
                TipoMovimiento = movimientoDTO.TipoMovimiento,
                Saldo = movimientoDTO.Saldo,
                Valor = movimientoDTO.Valor
            };

            return movimientoDAL.Update(movimiento);
        }

        public SingleResponse<MovimientoDTO> Delete(MovimientoDTO movimientoDTO) {

            return movimientoDAL.Delete(movimientoDTO.MovimientoId);
        }



    }
}
