using System;
using System.Collections.Generic;
using System.Text;

namespace whitewaterfinder.BusinessObjects.Rivers
{
    public static class RiverEntityExtensions
    {
        public static River ToRiver(this RiverEntity entity)
        {
            return new River()
            {
                Name = entity.Name,
                RiverId = entity.RiverId,
                State = entity.State,
                StateCode = entity.StateCode,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                Srs = entity.Srs
            };
        }
    }
}
