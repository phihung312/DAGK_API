using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_SprintRetrospective.Controllers
{

    public class BaseController : ControllerBase
    {
        public static User _User;
    }
}