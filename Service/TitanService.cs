using AutoMapper;
using Model.DTO;
using Model.EntityFramework;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Service
{

    public interface ITitanService
    {
        Task<List<OriginalTitanDTO>> GetOriginalTitans();
        Task<Stream> StartTitanTransformation(byte[] shifterFace, int chosenTitanFaceId);
    }

    public class TitanService : ITitanService
    {

        private readonly ITitanRepository _rep;

        public TitanService(ITitanRepository rep)
        {
            _rep = rep;
        }

        /// <summary>
        /// Get the dto list of original titans on database
        /// </summary>
        /// <returns>The dto list of original titans</returns>
        public async Task<List<OriginalTitanDTO>> GetOriginalTitans()
        {
            var lstEtt = await _rep.GetOriginalTitans();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OriginalTitan, OriginalTitanDTO>();
            });

            IMapper mapper = config.CreateMapper();

            var lstDTO = new List<OriginalTitanDTO>();
            foreach (var e in lstEtt)
            {
                var dto = mapper.Map<OriginalTitan, OriginalTitanDTO>(e);
                lstDTO.Add(dto);
            }

            return lstDTO;
        }


        /// <summary>
        /// Mix two images into one (titan shifter and a original titan)
        /// </summary>
        /// <param name="shifterFace"></param>
        /// <param name="chosenTitanFaceId"></param>
        /// <returns>A new image</returns>
        public async Task<Stream> StartTitanTransformation(byte[] shifterFace, int chosenTitanFaceId)
        {

            throw new NotImplementedException();
        }




    }
}
