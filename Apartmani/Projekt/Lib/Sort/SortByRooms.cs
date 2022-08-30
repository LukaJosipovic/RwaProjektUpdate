using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Sort
{
    public class SortByRooms
    {
        public static DataTable SortByRoomsAsc(DataTable table)
        {
            DataView dv = table.DefaultView;
            dv.Sort = "TotalRooms asc";
            DataTable sortTable = dv.ToTable();

            return sortTable;
        }
        public static DataTable SortByRoomsDesc(DataTable table)
        {
            DataView dv = table.DefaultView;
            dv.Sort = "TotalRooms desc";
            DataTable sortTable = dv.ToTable();

            return sortTable;
        }
    }
}
