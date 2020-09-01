using System;
using System.Collections.Generic;

namespace S3_NVVM_Entities
{
    public partial class OrderSubtotals
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
