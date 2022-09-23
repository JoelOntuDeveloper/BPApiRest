using BusinessLogicLayer;
using DataTransferObject;
using DBContext.DBRepository.Models;
using DBContext.DBRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using General.Validations;

namespace WebAPIBanco.Controllers {

    [Route("Cuenta")]
    [ApiController]
    public class CuentaController : ControllerBase {

        BancoDbContext db;
        CuentaBLL cuentaBLL;

        public CuentaController() {
            db = new BancoDbContext();
            cuentaBLL = new CuentaBLL(this.db);
        }

        [HttpGet]
        [Route("GetCuentasByCliente")]
        public MultipleResponse<CuentaDTO> GetCuentasByCliente(int clienteID) {

            return cuentaBLL.GetCuentasByCliente(clienteID);
        }

        [HttpPost]
        [Route("Create")]
        public SingleResponse<CuentaDTO> Create(CuentaDTO modelo) {

            return cuentaBLL.Create(modelo);
        }

        [HttpPut]
        [Route("Update")]
        public SingleResponse<CuentaDTO> Update(CuentaDTO modelo) {

            return cuentaBLL.Update(modelo);
        }

        [HttpDelete]
        [Route("Delete")]
        public SingleResponse<CuentaDTO> Delete(CuentaDTO modelo) {

            return cuentaBLL.Delete(modelo);
        }

    }
}
