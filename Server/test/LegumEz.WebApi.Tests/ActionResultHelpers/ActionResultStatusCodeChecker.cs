using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace LegumEz.WebApi.Tests.ActionResultHelpers
{
    internal static class ActionResultStatusCodeChecker
    {
        internal static void CheckIsOk200(this ObjectResult result)
        {
            result?.Should().NotBeNull();
            result?.StatusCode.Should().Be(200);
        }
        
        internal static void CheckIsBadRequest400(this ObjectResult result)
        {
            result?.Should().NotBeNull();
            result?.StatusCode.Should().Be(400);
        }
    }
}
