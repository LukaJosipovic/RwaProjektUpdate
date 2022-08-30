using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Sort
{
    public class SortById
    {
        public static DataTable SortByIdAsc(DataTable table)
        {
            DataView dv = table.DefaultView;
            dv.Sort = "Id asc";
            DataTable sortTable = dv.ToTable();

            return sortTable;
        }
    }
}
