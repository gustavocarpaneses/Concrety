using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Entities.Enumerators;
using Concrety.Core.Extensions;
using Concrety.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Concrety.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Anexos")]
    public class AnexosController : ApiControllerBase
    {

        private IAnexoService _anexoService;

        public AnexosController(IAnexoService anexoService)
        {
            _anexoService = anexoService;
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Criar(int idObra)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            try
            {

                var anexo = new Anexo
                {
                    IdObra = idObra
                };

                var provider = new MultipartFormDataStreamProvider(Path.GetTempPath());
                            
                await Request.Content.ReadAsMultipartAsync(provider).ConfigureAwait(false);

                foreach (MultipartFileData file in provider.FileData)
                {
                    anexo.NomeArquivoUpload = file.LocalFileName;
                    anexo.Tipo = file.Headers.ContentType.MediaType;
                    await _anexoService.CriarAsync(anexo).ConfigureAwait(false);
                    File.Delete(file.LocalFileName);
                }

                var anexoViewModel = Mapper.Map<Anexo, AnexoViewModel>(anexo);

                return Ok(anexoViewModel);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        
    }
}
