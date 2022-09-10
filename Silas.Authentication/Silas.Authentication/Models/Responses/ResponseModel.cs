using System;
using System.Collections.Generic;
using System.Text;

namespace Silas.Authentication.Models.Responses
{
    public class ResponseModel<T>
    {

        public ResponseModel()
        {
            this.Errors = new List<string>();
        }

        public ResponseModel(T data)
        {
            this.Data = data;
        }

        public ResponseModel<T> AddError(string errorMessage)
        {
            if (this.Errors == null)
                this.Errors = new List<string>();

            this.Errors.Add(errorMessage);

            return this;
        }

        public ResponseModel<T> AddError(List<string> errors)
        {
            if (this.Errors == null)
                this.Errors = new List<string>();

            this.Errors.AddRange(errors);

            return this;
        }

        public void AddData(T data)
        {
            if (this.Data == null || Data.Equals(Guid.Parse("00000000-0000-0000-0000-000000000000")))
                this.Data = data;
        }

        public T Data { get; private set; }

        public List<string> Errors { get; private set; }

        public bool HasError => this.Errors == null || this.Errors.Count > 0;

        public string AccessToken { get; set; }

    }
}
