using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Controllers.API
{
    public class AuthenticationApicontroller : Controller
    {
        private readonly IMapper _mapper;
        public AuthenticationApicontroller(IMapper mapper)
        {
            this._mapper = mapper;
        }
    }
}