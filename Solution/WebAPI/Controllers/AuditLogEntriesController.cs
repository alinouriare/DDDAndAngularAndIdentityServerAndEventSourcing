using Application;
using Application.AuditLogEntries.DTOs;
using Application.AuditLogEntries.Queries;
using Application.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogEntriesController : ControllerBase
    {
        private readonly Dispatcher _dispatcher;

        public AuditLogEntriesController(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuditLogEntryDTO>> Get()
        {
            var logs = _dispatcher.Dispatch(new GetAuditEntriesQuery { });
            return Ok(logs);
        }
    }
}