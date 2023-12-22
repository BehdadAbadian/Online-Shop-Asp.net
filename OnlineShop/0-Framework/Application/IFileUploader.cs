using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Framework.Application
{
    public interface IFileUploader
    {
        string Upload(IFormFile file, string path); 
    }
}
