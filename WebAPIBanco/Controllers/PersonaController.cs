using DataAccessLayer;
using DataTransferObject;
using DBContext.DBRepository;
using DBContext.DBRepository.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIBanco.Controllers {
    [Route("Persona")]
    [ApiController]
    public class PersonaController : ControllerBase {

        BancoDbContext db;
        PersonaDAL personaDAL;

        public PersonaController() {
            db = new BancoDbContext();

            personaDAL = new PersonaDAL(this.db);
        }


        [HttpGet]
        [Route("GetAll")]
        public MultipleResponse<PersonaDTO> GetAll() {

            MultipleResponse<PersonaDTO> response = personaDAL.GetAll();

            return response;
        }

        [HttpGet]
        [Route("Get")]
        public SingleResponse<PersonaDTO> Get(string identificacion) {

            SingleResponse<PersonaDTO> response = personaDAL.GetBy(identificacion);

            return response;
        }

        [HttpPost]
        [Route("Create")]
        public SingleResponse<PersonaDTO> Create(Persona persona) {

            SingleResponse<PersonaDTO> response = personaDAL.Create(persona);

            return response;
        }

        [HttpDelete]
        [Route("Delete")]
        public SingleResponse<PersonaDTO> Delete(Persona persona) {

            SingleResponse<PersonaDTO> response = personaDAL.Delete(persona);

            return response;
        }

    }
}
