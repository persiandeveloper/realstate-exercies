using RealStateSolution.Services.Domain;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace RealStateSolution.Services.Test
{
    public class TestJsonConvert
    {
        [Fact]
        public void Test_If_DateTime_Convert_Works()
        {
            string json = string.Empty;

            using (StreamReader r = new StreamReader("data.json"))
            {
               json = r.ReadToEnd();
            }

            var result = JsonSerializer.Deserialize<RealstateResult>(json);

            Assert.NotNull(result.Objects.FirstOrDefault().AanmeldDatum);
        }
    }
}
