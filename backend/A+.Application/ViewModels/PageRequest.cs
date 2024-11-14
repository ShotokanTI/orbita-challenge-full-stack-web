using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PageRequest
    {
        [DefaultValue(1)]
        public int PageNumber { get; set; }
        [DefaultValue(25)]
        public int PageSize { get; set; }
    }

}
