using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace RealStateSolution.API.Test
{
    public class ExceptionMiddleWare
    {
        [Fact]
        public async Task Test_Exception_MiddleWare_LogCalled()
        {
            HttpContext httpContext = new DefaultHttpContext();

            var logger = new Mock<ILogger<ErrorHandlingMiddleware>>();
            logger.Setup(x => x.Log(It.IsAny<LogLevel>(), It.IsAny<EventId>(), It.Is<It.IsAnyType>((v, t) => true), It.IsAny<Exception>(), It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true))).Verifiable();

            RequestDelegate request = (httpContext) => throw new Exception();

            var errorHandlingMiddleware = new ErrorHandlingMiddleware(request);

            await errorHandlingMiddleware.Invoke(httpContext, logger.Object);

            Assert.NotNull(httpContext.Response);
            logger.Verify();
        }
    }
}
