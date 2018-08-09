using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperationMars.Responses
{
    public abstract class ResponseBase
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }

        public ResponseBase ReturnWithSuccess() {
            this.Success = true;
            return this;
        }

        public ResponseBase ReturnWithErrors(params string[] messages) {
            this.Success = false;
            Errors = messages;
            return this;
        }

    }
}