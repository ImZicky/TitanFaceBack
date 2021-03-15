using Microsoft.EntityFrameworkCore;
using Model.Contexts;
using Model.DTO;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public interface ITitanRepository
    {
        Task<List<OriginalTitan>> GetOriginalTitans();
        Task<OriginalTitan> GetOriginalTitanById(int originalTitanId);
    }



    public class TitanRepository : ITitanRepository
    {

        private readonly TitanContext _ctx;

        public TitanRepository(TitanContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Get the original titans from database
        /// </summary>
        /// <returns>Original Titans list</returns>
        public async Task<List<OriginalTitan>> GetOriginalTitans()
        {
            return await _ctx.OriginalTitans.ToListAsync();
        }

        /// <summary>
        /// Get an especific original titan from database
        /// </summary>
        /// <param name="originalTitanId"></param>
        /// <returns>A original titan</returns>        
        public async Task<OriginalTitan> GetOriginalTitanById(int originalTitanId)
        {
            return await _ctx.OriginalTitans.Where(x => x.OriginalTitanId == originalTitanId).FirstOrDefaultAsync();
        }


    }
}
