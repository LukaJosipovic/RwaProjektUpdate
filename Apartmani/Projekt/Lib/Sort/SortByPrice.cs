using Lib.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Sort
{
    public class SortByPrice
    {
        public static DataTable SortByPriceAsc(DataTable table)
        {
            DataView dv = table.DefaultView;
            dv.Sort = "Price asc";
            DataTable sortTable = dv.ToTable();

            return sortTable;
        }
        public static DataTable SortByPriceDesc(DataTable table)
        {
            DataView dv = table.DefaultView;
            dv.Sort = "Price desc";
            DataTable sortTable = dv.ToTable();

            return sortTable;
        }
    }
}
