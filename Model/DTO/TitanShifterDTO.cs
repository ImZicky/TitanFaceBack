using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTO
{
    public class TitanShifterDTO
    {
        public int ChosenTitanFaceId { get; set; }
        public IFormFile ShifterFace { get; set; }
    }
}
