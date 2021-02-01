using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarDto:IEntity
    {
        public int CarId { get; set; }
        public String ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }

        // public string BrandName { get; set; }

    }
}
