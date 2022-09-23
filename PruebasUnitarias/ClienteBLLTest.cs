using BusinessLogicLayer;
using DataTransferObject;
using DBContext.DBRepository;

namespace PruebasUnitarias {
    public class Tests {

        BancoDbContext db;
        ClienteBLL clienteBLL;

        [SetUp]
        public void Setup() {

            db = new BancoDbContext();

            clienteBLL = new ClienteBLL(db);
        }

        [Test, Description("EL método hace la búsqueda de un cliente por su identificación, el cliente existe y por lo tanto debe retornar true")]
        public void Get_SuccesReturn() {

            //Arrange
            string identifiacion = "1724366654";

            //Act
            SingleResponse<ClienteDTO> response = clienteBLL.GetBy(identifiacion);

            //Assert
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Result);
        }

        [Test, Description("EL método hace la búsqueda de un cliente por su identificación, el cliente no existe y por lo tanto debe retornar false")]
        public void GetBy_NotSuccesReturn() {

            //Arrange
            string identifiacion = "00000000000";

            //Act
            SingleResponse<ClienteDTO> response = clienteBLL.GetBy(identifiacion);

            //Assert
            Assert.IsFalse(response.Success);
            Assert.IsNull(response.Result);
        }
    }
}