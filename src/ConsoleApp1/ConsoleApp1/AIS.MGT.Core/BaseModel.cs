using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIS.MGT.Core
{
    public class BaseModel
    {
        private List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;
        public List<Exception> _exceptions;
        public IReadOnlyCollection<Exception> Exceptions => _exceptions;
        public bool IsValid => !Errors.Any();
        public BaseModel()
        {
            this._errors = new List<string>();
            this._exceptions = new List<Exception>();
        }
        public void AddError(string error)
        {
            _errors.Add(error);
            _exceptions.Add(new Exception(error));
        }

        public void AddError(Exception ex)
        {
            _errors.Add(ex.Message);
            _exceptions.Add(ex);
        }
    }


}
