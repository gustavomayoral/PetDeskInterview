using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetDeskInterview.Models;

namespace PetDeskInterview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Appointments()
        {
            var client = _clientFactory.CreateClient("PetDesk Api");
            var result = await client.GetAsync("/api/appointments");
            var appointments = new List<Appointment>();

            if (result.IsSuccessStatusCode)
            {
                var appointmentsJson = await result.Content.ReadAsStringAsync();
                appointments = JsonConvert.DeserializeObject<List<Appointment>>(appointmentsJson);
            }

            return PartialView("_Appointments", appointments);
        }

        public IActionResult Change(ChangeDto change)
        {
            if (change.changeId < 10000)
                return BadRequest(change);
            else
                return Ok(change);
        }

        public IActionResult Confirm(int id)
        {
            if (id < 10000)
                return BadRequest(id);
            else
                return Ok(id);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
