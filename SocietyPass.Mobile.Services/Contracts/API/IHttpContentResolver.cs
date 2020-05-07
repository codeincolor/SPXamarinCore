using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SocietyPass.Mobile.Services.Contracts.API
{
    public interface IHttpContentResolver
    {
        HttpContent ResolveHttpContent<TContent>(TContent content);
    }
}
