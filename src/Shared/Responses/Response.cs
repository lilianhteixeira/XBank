using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBank.Domain.Shared.Responses
{
    public abstract class Response
    {
        public List<string> Errors { get; set; }

        public Response()
        {
            Errors = new List<string>();
        }


        public void SetErrorList(List<ValidationFailure> errorList)
        {
            errorList.ForEach(x => Errors.Add(x.ErrorMessage));
        }

    }
}
