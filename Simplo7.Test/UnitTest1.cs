using System;
using Xunit;
using Simplo7;

namespace Simplo7.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
           // Assert.Equal("ople", new Simplo7.API("","").call(Endpoints.Categorias, Methods.GET));
            Assert.Equal("ople", (new Simplo7.API("","").call(Endpoints.Categorias, Methods.POST, new { nome = "ata" }))["Wscategoria"]["id"]);
        }
    }
}
