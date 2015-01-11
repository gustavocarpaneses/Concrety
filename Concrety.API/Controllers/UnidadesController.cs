﻿using AutoMapper;
using Concrety.API.ViewModels;
using Concrety.Core.Entities;
using Concrety.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Concrety.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Unidades")]
    public class UnidadesController : ApiController
    {

        private IUnidadeService _unidadeService;

        public UnidadesController(IUnidadeService unidadeService)
        {
            _unidadeService = unidadeService;
        }

        [Route("GetByIdNivel")]
        public async Task<IEnumerable<UnidadeViewModel>> GetByIdNivel(int idNivel)
        {
            var unidades = await _unidadeService.GetByIdNivel(idNivel);
            return Mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(unidades);
        }

    }
}