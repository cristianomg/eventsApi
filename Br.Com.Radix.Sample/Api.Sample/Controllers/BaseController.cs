using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Sample.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;
        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
