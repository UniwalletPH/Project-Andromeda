using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andromeda.Models
{
    public class DTRReportVM
    {
        public int Selected { get; set; }

        public List<SelectListItem> Names { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
