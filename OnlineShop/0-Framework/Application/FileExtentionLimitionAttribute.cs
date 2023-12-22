using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Framework.Application
{
    public class FileExtentionLimitionAttribute : ValidationAttribute, IClientModelValidator
    {

        private readonly string[] _validExtentions;

        public FileExtentionLimitionAttribute(string[] validExtentions)
        {
            _validExtentions = validExtentions;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null) { return true; };
            var fileExtention = Path.GetExtension(file.FileName);
            return _validExtentions.Contains(fileExtention);
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            //context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-FileExtentionLimit", ErrorMessage);
        }
    }
}
