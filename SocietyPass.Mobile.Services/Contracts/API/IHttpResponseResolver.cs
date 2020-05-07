using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SocietyPass.Mobile.Services.Contracts.API
{
    public interface IHttpResponseResolver
    {
        Task<TResult> ResolveHttpResponseAsync<TResult>(HttpResponseMessage responseMessage);
    }

}
