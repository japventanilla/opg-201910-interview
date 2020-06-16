using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opg_201910_interview;
using opg_201910_interview.Classes;
using opg_201910_interview.Controllers;
using opg_201910_interview.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace opg_201910_interview.UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Test_HomeController_Index()
        {
            ClientSettings cSetting = new ClientSettings();
            cSetting.ClientId = 1001;
            cSetting.FileDirectoryPath = "../../../../opg-201910-interview/UploadFiles/ClientA";

            IOptions<ClientSettings> _clientSettings = Options.Create(cSetting);

            HomeController home = new HomeController(_clientSettings);
            var result = home.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<Client>));
        }

        [TestMethod]
        public void Test_ClientLogic_ClientA()
        {
            int clientId = 1001;
            string path = "../../../../opg-201910-interview/UploadFiles/ClientA";

            ClientLogic client = new ClientLogic();
            List<Client> clients = client.GetClients(clientId, path);

            Assert.IsNotNull(clients);
            Assert.IsTrue(clients.Count > 0);
        }

        [TestMethod]
        public void Test_ClientLogic_ClientB()
        {
            int clientId = 2001;
            string path = "../../../../opg-201910-interview/UploadFiles/ClientB";

            ClientLogic client = new ClientLogic();
            List<Client> clients = client.GetClients(clientId, path);

            Assert.IsNotNull(clients);
            Assert.IsTrue(clients.Count > 0);
        }
    }
}
