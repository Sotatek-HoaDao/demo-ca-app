using demo_ca_app.Application.Common.Interfaces;
using System;

namespace demo_ca_app.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
