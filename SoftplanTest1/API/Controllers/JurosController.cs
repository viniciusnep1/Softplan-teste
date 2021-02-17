﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JurosController : ControllerBase
    {
        public JurosController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(0.01);
        }
    }
}
