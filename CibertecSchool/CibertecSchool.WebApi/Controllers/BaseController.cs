using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CibertecSchool.UnitOfWork;

namespace CibertecSchool.WebApi.Controllers
{
    [Produces("application/json")]    
    public class BaseController : Controller
    {
        protected IUnitOfWork _unit;

        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
        }
    }
}