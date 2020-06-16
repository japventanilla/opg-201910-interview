using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using opg_201910_interview.Classes;
using opg_201910_interview.Models;

namespace opg_201910_interview.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<ClientSettings> _clientSettings;

        public HomeController(IOptions<ClientSettings> clientSettings)
        {
            _clientSettings = clientSettings;
        }

        public IActionResult Index()
        {
            ViewData["ClientId"] = _clientSettings.Value.ClientId;
            ViewData["Path"] = _clientSettings.Value.FileDirectoryPath;

            ClientLogic clientLogic = new ClientLogic();
            List<Client> clients = clientLogic.GetClients(
                _clientSettings.Value.ClientId, 
                _clientSettings.Value.FileDirectoryPath);
            
            return View(clients);
        }

        public OkObjectResult Get()
        {
            throw new NotImplementedException();
        }

        public IActionResult Privacy()
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
