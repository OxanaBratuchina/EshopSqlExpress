using Eshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Tests.Infrastructure.Helpers
{
    internal class TestClient
    {
        public static Client CreateTestClient(int clientTestId) 
        {
            var varPhonePart = (clientTestId % 100).ToString().PadLeft(3, '0');
            return Client.Create($"Client{clientTestId}", $"Client{clientTestId}@seznam.cz", $"+420776452{varPhonePart}").Value;
        }
    }
}
