using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Application.Utilities.Common
{
    public class PaginatedDTO<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalAmountOfRecords { get; set; }
    }
}
