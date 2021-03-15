using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.DTO;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AttackOnTitanBackend.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TitanController : Controller
    {

        private readonly ITitanService _serv;
        private readonly ILogger<TitanController> _logger;

        public TitanController(ITitanService serv, ILogger<TitanController> logger)
        {
            _serv = serv;
            _logger = logger;
        }



        /// <summary>
        /// Method to get original titans from database
        /// </summary>
        /// <see cref="OriginalTitanDTO"/>>
        /// <response code="200">All right with the request</response>
        /// <returns>List of OriginalTitanDTO</returns>
        [HttpGet]
        [Route("GetOriginalTitans")]
        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<OriginalTitanDTO>> GetOriginalTitans()                 
        {
            try
            {
                _logger.LogInformation($"Getting original titans - {DateTime.Now:F}");
                return await _serv.GetOriginalTitans();
            }
            catch (Exception e) 
            {
                _logger.LogError($"Something went wrong - {e.Message}");
                return null;
            }
        }

        [HttpPost]
        public async Task<Stream> StartTitanTransformation([FromBody] TitanShifterDTO dto) 
        {
            try
            {
                _logger.LogInformation($"Transforming person into the chosen titan - {DateTime.Now:F}");

                using (var ms = new MemoryStream())
                {
                    dto.ShifterFace.CopyTo(ms);
                    var fileBytes = ms.ToArray();

                    return await _serv.StartTitanTransformation(fileBytes, dto.ChosenTitanFaceId);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong - {e.Message}");
                return null;
            }

        }




    }
}
