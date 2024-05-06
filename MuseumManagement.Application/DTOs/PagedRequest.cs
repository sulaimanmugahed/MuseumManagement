using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumManagement.Application.DTOs
{
    public class PagedRequest
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string SearchValue { get; set; }
        public string SortColumn { get; set; }
        public string SortColumnDirection { get; set; }
    }
}
