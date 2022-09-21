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
        public MultipleResponse<Persona> GetAll() {

            MultipleResponse<Persona> response = personaDAL.GetAll();

            return response;
        }
        
        [HttpGet]
        [Route("Get")]
        public SingleResponse<Persona> Get(string identificacion) {

            SingleResponse<Persona> response = personaDAL.Get(identificacion);

            return response;
        }

        [HttpPost]
        [Route("Create")]
        public SingleResponse<Persona> Create(Persona persona) {

            SingleResponse<Persona> response = personaDAL.Create(persona);

            return response;
        }

    }
}
