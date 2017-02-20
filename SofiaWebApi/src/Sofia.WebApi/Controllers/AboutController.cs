using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Sofia.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("about")]
    public class AboutController : ControllerBase
    {
        [HttpGet, Route("servername")]
        public IActionResult GetServerName()
        {
            return Ok(Environment.MachineName);
        }

        [HttpGet, Route("version")]
        public IActionResult GetVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            return Ok(version);
        }
    }
}
