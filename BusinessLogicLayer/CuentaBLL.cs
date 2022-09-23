using DataAccessLayer;
using DataTransferObject;
using DBContext.DBRepository;
using DBContext.DBRepository.Models;

namespace BusinessLogicLayer {
    public class CuentaBLL {

        BancoDbContext db;
        CuentaDAL cuentaDAL;

        public CuentaBLL(BancoDbContext db) {
            this.db = db;
            cuentaDAL = new CuentaDAL(this.db);
        }

        public MultipleResponse<CuentaDTO> GetCuentasByCliente(int clienteID) {
            return cuentaDAL.GetCuentasByCliente(clienteID);
        }

        public SingleResponse<CuentaDTO> GetCuenta(string numeroCuenta) {
            return cuentaDAL.Get(numeroCuenta);
        }

        public SingleResponse<CuentaDTO> Create(CuentaDTO cuentaDTO) {

            Cuentum cuenta = new Cuentum {
                ClienteId = cuentaDTO.ClienteId,
                NumeroCuenta = cuentaDTO.NumeroCuenta,
                Estado = cuentaDTO.Estado,
                SaldoInicial = cuentaDTO.SaldoInicial,
                TipoCuenta = cuentaDTO.TipoCuenta
            };

            return cuentaDAL.Create(cuenta);

        }

        public SingleResponse<CuentaDTO> Update(CuentaDTO cuentaDTO) {

            Cuentum cuenta = new Cuentum {
                ClienteId = cuentaDTO.ClienteId,
                NumeroCuenta = cuentaDTO.NumeroCuenta,
                Estado = cuentaDTO.Estado,
                SaldoInicial = cuentaDTO.SaldoInicial,
                TipoCuenta = cuentaDTO.TipoCuenta
            };

            return cuentaDAL.Update(cuenta);
        }

        public SingleResponse<CuentaDTO> Delete(CuentaDTO cuentaDTO) {
            return cuentaDAL.Delete(cuentaDTO.NumeroCuenta);
        }

    }
}
