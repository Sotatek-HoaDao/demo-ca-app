﻿using NUnit.Framework;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Tests
{
    using static Testing;

    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}
