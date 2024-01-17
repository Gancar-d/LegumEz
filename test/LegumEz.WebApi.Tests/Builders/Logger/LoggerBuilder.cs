using Microsoft.Extensions.Logging;
using Moq;

namespace LegumEz.WebApi.Tests.Builders.Logger
{
    internal class LoggerBuilder<T>
    {
        private readonly Mock<ILogger<T>> _logger;

        public LoggerBuilder()
        {
            _logger = new Mock<ILogger<T>>();
        }

        public ILogger<T> Build()
        {
            return _logger.Object;
        }
    }
}
