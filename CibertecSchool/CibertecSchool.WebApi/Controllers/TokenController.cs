﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CibertecSchool.WebApi.Authentication;
using CibertecSchool.UnitOfWork;
using CibertecSchool.Models;

namespace CibertecSchool.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private ITokenProvider _tokenprovider;
        private IUnitOfWork _unit;

        public TokenController(ITokenProvider tokenprovider, IUnitOfWork unit)
        {
            _tokenprovider = tokenprovider;
            _unit = unit;
        }

        [HttpPost]
        public JsonWebToken Post([FromBody] User userLogin)
        {
            var user = GetUserByCredentials(userLogin.Email, userLogin.Password);

            if (user == null) throw new UnauthorizedAccessException("No!");

            var lifeInHours = 8;

            var token = new JsonWebToken
            {
                Access_Token = _tokenprovider.CreateToken(user,
                DateTime.UtcNow.AddHours(lifeInHours)),
                Expires_In = lifeInHours * 60
            };

            return token;
        }

        private User GetUserByCredentials(string email, string password)
        {
            return _unit.Users.ValidaterUser(email, password);
        }

    }
}