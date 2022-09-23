using BusinessLogicLayer;
using DataTransferObject;
using DBContext.DBRepository;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIBanco.Controllers {

    [Route("cliente")]
    [ApiController]
    public class ClienteController : ControllerBase {

        BancoDbContext db;
        ClienteBLL clienteBLL;

        public ClienteController() {
            db = new BancoDbContext();
            clienteBLL = new ClienteBLL(this.db);
        }

        [HttpGet]
        [Route("GetAll")]
        public MultipleResponse<ClienteDTO> GetAll() {

            return clienteBLL.GetAll();
        }

        [HttpGet]
        [Route("GetByIdentificacion")]
        public SingleResponse<ClienteDTO> GetBy(string identificacion) {

            return clienteBLL.GetBy(identificacion);
        }

        [HttpPost]
        [Route("Create")]
        public SingleResponse<ClienteDTO> Create(ClienteDTO modelo) {

            return clienteBLL.Create(modelo);
        }

        [HttpPut]
        [Route("Update")]
        public SingleResponse<ClienteDTO> Update(ClienteDTO modelo) {

            return clienteBLL.Update(modelo);
        }

        [HttpDelete]
        [Route("Delete")]
        public SingleResponse<ClienteDTO> Delete(ClienteDTO modelo) {

            return clienteBLL.Delete(modelo);
        }

    }
}
