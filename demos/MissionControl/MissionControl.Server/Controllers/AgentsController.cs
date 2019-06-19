using MissionControl.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace MissionControl.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : Controller
    {
        [Authorize]
        [HttpGet]
        public IEnumerable<Agent> GetAgents()
        {
            return new List<Agent>
            {
                new Agent { Longitude = -74.0060, Latitude = 40.7126, Name = "George Smiley", Mission = "Place listening device in City Hall" },
                new Agent { Longitude = -73.9989, Latitude = 40.7077, Name = "Nancy Drew", Mission = "Control bridge access" },
                new Agent { Longitude = -74.0102, Latitude = 40.7068, Name = "Natalya Ivanova", Mission = "Trigger global banking crisis" },
                new Agent { Longitude = -74.0165, Latitude = 40.7034, Name = "Hans Kloss", Mission = "Infiltrate castle" },
                new Agent { Longitude = -74.0063, Latitude = 40.7033, Name = "Agent K", Mission = "Prepare SCUBA™ equipment" },
                new Agent { Longitude = -74.0152, Latitude = 40.7104, Name = "Jason Bourne", Mission = "Look out for suspicious characters" },
                new Agent { Longitude = -74.0107, Latitude = 40.7038, Name = "Johnny Fedora", Mission = "Awaiting orders" },
                new Agent { Longitude = -74.0073, Latitude = 40.7131, Name = "Emily Pollifax", Mission = "Block enemy agents from reaching Broadway" },
                new Agent { Longitude = -74.0079, Latitude = 40.7149, Name = "Work experience boy", Mission = "Check prices of Dell XPS laptops" },
                new Agent { Longitude = -74.0069, Latitude = 40.7134, Name = "Tim Donohue", Mission = "Get part in Broadway show" },
                new Agent { Longitude = -74.0058, Latitude = 40.7028, Name = "David Shirazi", Mission = "Intercept enemy shipment" },
                new Agent { Longitude = -74.0014, Latitude = 40.7054, Name = "Max Payne", Mission = "Prepare shipment" },
                new Agent { Longitude = -74.0140, Latitude = 40.7027, Name = "Evelyn Salt", Mission = "General surveillance rota" },
            };
        }
    }
}
