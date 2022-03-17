using IdentityServer.API2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IdentityServer.API2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PictureController : ControllerBase
    {

        [Authorize]
        public IActionResult GetPictures()
        {
            var pictures = new List<Picture>
            {
                new Picture { Name = "Doğa resmi", Url = "dogaresmi.jpg"},
                new Picture { Name = "Köpek resmi", Url = "dogaresmi.jpg"},
                new Picture { Name = "Fil resmi", Url = "dogaresmi.jpg"},
                new Picture { Name = "Zürafa resmi", Url = "dogaresmi.jpg"},
                new Picture { Name = "Linux resmi", Url = "dogaresmi.jpg"},
            };

            return Ok(pictures);
        }

    }
}
