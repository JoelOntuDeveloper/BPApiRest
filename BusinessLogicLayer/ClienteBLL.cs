using DBContext.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer {
    public class ClienteBLL {

        BancoDbContext db;

        public ClienteBLL(BancoDbContext db) {
            this.db = db;
        }


    }
}
