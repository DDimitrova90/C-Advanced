namespace _14_Export_To_Excel
{
    using ExcelLibrary.SpreadSheet;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExportToExcel
    {
        public static void Main()
        {
            string file = "../../try1.xls";
            Workbook wb = new Workbook();
            Worksheet wsh = new Worksheet("shf");
            wsh.Cells[3, 1] = new Cell("ID");
            wsh.Cells[3, 2] = new Cell("First name");
            wb.Worksheets.Add(wsh);
            wb.Save(file);
        }
    }
}
