using NUnit.Framework;
using wcfProyectPRS;
namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetPlayersTest()
        {
            ResponseJson response = null;
            try
            {
                InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
                var task = client.GetPlayersGameAsync();
                task.Wait();
                if (task.IsCompletedSuccessfully)
                    response = task.Result;

                Assert.IsNotNull(response);
            }
            catch
            {
                throw;
            }
        }

        [Test]
        public void GetMovesTest()
        {
            ResponseJson response = null;
            try
            {
                InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
                var task = client.GetMovesAsync();
                task.Wait();
                if (task.IsCompletedSuccessfully)
                    response = task.Result;

                Assert.IsNotNull(response);
            }
            catch
            {
                throw;
            }
        }

        [Test]
        public void NewGameTest()
        {
            ResponseJson response = null;
            try
            {
                InitializeClient client = new InitializeClient(new InitializeClient.EndpointConfiguration());
                var task = client.NewGameAsync();
                task.Wait();
                if (task.IsCompletedSuccessfully)
                    response = task.Result;

                Assert.IsNotNull(response);
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}