using ApiTravelLib.Helpers;
using NUnit.Framework;

namespace ApiTravelLibTest
{
    public class LibrosControllerTest : IntegrationTestBuilder
    {

        [Test]
        public void GetLibros()
        {
            //Arrange
            Params libroParams = new Params();

            libroParams.PageIndex = 1;
            libroParams.PageSize = 10;
            libroParams.Search = null;

            //Act
            var c = this.TestClient.GetAsync($"api/Libros/{libroParams}").Result;
            var response = c.Content.ReadAsStringAsync().Result;
            //Asert
            Assert.NotNull(response);
        }
    }
}