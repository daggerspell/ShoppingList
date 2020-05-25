using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace CommonLib
{
    // Should only have to be used once as once the data is in. The database takes care of all the data in the program
    public class ExcelDataImporter
    {
        public string pathToFile;

        public ExcelDataImporter(string filePath)
        {
            pathToFile = filePath;
        }
        
        public List<Item> ImportData()
        {
            Excel.Application excelApp;
            Excel.Workbook excelWorkBook;
            Excel.Worksheet excelWorkSheet;
            Excel.Range excelRange;

            excelApp = new Excel.Application();
            excelWorkBook = excelApp.Workbooks.Open(pathToFile, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);

            excelRange = excelWorkSheet.UsedRange;
            int rowCount = excelRange.Rows.Count;
            int columnCount = excelRange.Columns.Count;

            List<Item> insertItems = new List<Item>();
            //loop through and see what data is there
            bool taxable = false;
            for(int row = 1; row <= rowCount; row++)
            {
                Item newItem = new Item();
                for(int col = 1; col <= columnCount; col++)
                {
                    //Just write to the console at first will work on converting to the correct types and inputing in the database
                    string temp = (string)(excelRange.Cells[row, col] as Excel.Range).Text;
                    System.Console.WriteLine(temp);
                    if (!string.IsNullOrEmpty(temp))
                    {
                        if (col == 1)
                        {
                            newItem.Name = temp;
                        }
                        else if (col == 2)
                        {
                            newItem.Price = double.Parse(temp);
                        }
                        else if (col == 3)
                        {
                            if(temp == "0")
                            {
                                newItem.Taxable = false;
                            }
                            else
                            {
                                newItem.Taxable = true;
                            }
                        }
                    }
                }
                insertItems.Add(newItem);
            }

            //need to close all the above opened stuff
            excelWorkBook.Close(true, null, null);
            excelApp.Quit();

            Marshal.ReleaseComObject(excelWorkSheet);
            Marshal.ReleaseComObject(excelWorkBook);
            Marshal.ReleaseComObject(excelApp);

            return insertItems;
        }

    }
}
