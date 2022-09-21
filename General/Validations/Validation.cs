using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Validations {

    public class Validation<T> where T : class {

        SingleResponse<T> response;

        public Validation(SingleResponse<T> response) {

            this.response = response;
        }

        /// <summary>
        /// Valida que un valor requerido no retorne como nulo
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        public void IsRequired(object obj, string name) {
            if (obj == null) {
                response.ValidationExcepcion.Add($"El parámetro {name} es requerido");
                response.HasValidationExcepcion = true;
            }
        }

        public void NewRule(string message) {

            response.HasValidationExcepcion = true;
            response.ValidationExcepcion.Add(message);
        }

    }
}
