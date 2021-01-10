using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.API.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> ModelStateInvalid(ModelStateDictionary modelStateDictionary)
        {
            List<string> errors = new List<string>();

            IEnumerable<ModelError> modelErrors = modelStateDictionary.Values.SelectMany(a => a.Errors);
            foreach(ModelError modelError in modelErrors)
            {
                errors.Add(modelError.Exception == null ? modelError.ErrorMessage : modelError.Exception.Message);
            }

            return errors;
        }
    }
}
