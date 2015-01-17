using Concrety.Core.Interfaces.Entities;
using System.Web.Http;

namespace Concrety.API.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected IHttpActionResult GetErrorResult(IEntityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Sucesso)
            {
                if (result.Erros != null)
                {
                    foreach (string erro in result.Erros)
                    {
                        ModelState.AddModelError("", erro);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
