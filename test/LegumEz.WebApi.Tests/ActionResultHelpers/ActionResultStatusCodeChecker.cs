using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LegumEz.WebApi.Tests.ActionResultHelpers
{
    internal static class ActionResultStatusCodeChecker
    {
        internal static void CheckIsOk200(this OkObjectResult result)
        {
            result?.Should().NotBeNull();
            result?.StatusCode.Should().Be(200);
        }
    }
}
