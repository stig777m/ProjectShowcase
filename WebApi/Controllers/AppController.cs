using DataAccessLayer.Models;
using BussinessLogicLayer.DTOs;
using BussinessLogicLayer.Services;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    public class AppController : Controller
    {
        private readonly ITicketServices ticketServices;
        private readonly IProjectServices projectServices;

        public AppController(ITicketRepositories ticketRepositories, IProjectRepositories projectRepositories)
        {
            this.ticketServices = ticketServices;
            this.projectServices = projectServices;
        }

        [HttpPost("createProject")]
        [Consumes("application/json")]
        public IActionResult CreateProject([FromBody] ProjectDTO projectdto)
        {
            var res = projectServices.CreateProject(projectdto);
            if (res == null)
            {
                return StatusCode(500);
            }
            return Ok(res);
        }

        [HttpPost("createTicket")]
        [Consumes("application/json")]
        public IActionResult CreateTicket([FromBody] TicketDTO ticketdto)
        {
            var res = ticketServices.CreateTicket(ticketdto);
            if (res == null)
            {
                return StatusCode(500);
            }
            return Ok(res);
        }

        [HttpPut]
        [Route("TicketStatusUpdate/{Id}")]
        public IActionResult UpdateStatus(string Id, string status)
        {
            var res = ticketServices.UpdateStatus(Id,status);
            if (res == null)
            {
                return StatusCode(500);
            }
            return Ok(res);
        }

        [HttpGet]
        [Route("GetProjectById/{ProjectId}")]
        public IActionResult SearchProject(string ProjectId) 
        {
            var prj = projectServices.GetProjectById(ProjectId);
            if (prj==null)
            {
                return StatusCode(500);
            }
            return Ok(prj);
        }

    }
}
