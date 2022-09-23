using BusinessLogicLayer;
using DataTransferObject;
using DBContext.DBRepository;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIBanco.Controllers {
    [Route("Movimiento")]
    [ApiController]
    public class MovimientoController : ControllerBase {

        BancoDbContext db;
        MovimientoBLL movimientoBLL;

        public MovimientoController() {
            db = new BancoDbContext();
            movimientoBLL = new MovimientoBLL(this.db);
        }

        [HttpGet]
        [Route("GetByCuenta")]
        public MultipleResponse<MovimientoDTO> GetByCuenta(string numeroCuenta) {

            return movimientoBLL.GetByCuenta(numeroCuenta);
        }

        [HttpPost]
        [Route("Create")]
        public SingleResponse<MovimientoDTO> Create(MovimientoDTO modelo) {

            return movimientoBLL.Create(modelo);
        }

        [HttpPut]
        [Route("Update")]
        public SingleResponse<MovimientoDTO> Update(MovimientoDTO modelo) {

            return movimientoBLL.Update(modelo);
        }

        [HttpDelete]
        [Route("Delete")]
        public SingleResponse<MovimientoDTO> Delete(MovimientoDTO modelo) {

            return movimientoBLL.Delete(modelo);
        }

    }
}
