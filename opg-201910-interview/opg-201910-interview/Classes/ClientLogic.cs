using Microsoft.Extensions.Options;
using opg_201910_interview.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace opg_201910_interview.Classes
{
    public class ClientLogic
    {

        public List<Client> GetClients(int clientId, string path)
        {
            List<Client> results = new List<Client>();

            foreach (string sFile in Directory.EnumerateFiles(path))
            {
                string fileName = Path.GetFileNameWithoutExtension(sFile);

                string fileFormat = clientId == 1001 ? "-" : "_";
                var firstSpaceIndex = fileName.IndexOf(fileFormat);

                if (firstSpaceIndex > -1)
                {
                    Client client = new Client();
                    client.Name = fileName.Substring(0, firstSpaceIndex);
                    client.Date = clientId == 1001 ? Convert.ToDateTime(fileName.Substring(firstSpaceIndex + 1)) :
                        DateTime.ParseExact(fileName.Substring(firstSpaceIndex + 1), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    results.Add(client);
                }
            }

            if(results.Count > 0)
            {
                results = results.OrderBy(x => x.Name).ThenBy(x => x.Date).ToList();
            }

            return results;
        }
    }
}
