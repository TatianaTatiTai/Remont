using LAMS.Logic.Common.SMTPClient;
using LAMS.Logic.SMTPClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.Logic.Tests.SMTP
{
    [TestFixture]
    public class SMTPClientTest
    {
        [Test]
        public void SendEmail()
        {
            ISMTPservice client = new SMTPservice();

            Assert.DoesNotThrow(() => client.SendNew("Вид акта", "Указ", 34));
        }
    }
}
