using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace Superhui.Api.Controllers
{
    [EnableCors("AllowSepecificOrigins")]
    public class NoteController : Controller
    {
        private readonly IFileProvider _fileProvider;
        public NoteController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<string> Note(string id)
        {
            string notePath = id.Replace('-', '/');
            IFileInfo file = _fileProvider.GetFileInfo(notePath);

            string res = "";
            using (var stream = file.CreateReadStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var output = await reader.ReadToEndAsync();
                    res = output;
                }
            }
            return res;
        }

    }
}