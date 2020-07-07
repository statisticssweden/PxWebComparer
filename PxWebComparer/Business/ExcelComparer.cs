using System;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections;
using System.Text.RegularExpressions;

namespace PxWebComparer.Business
{
    public class ExcelComparer : IExcelComparer
    {
        public ArrayList ReadExcelFile(string fileName)
        {

            try
            {

            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
            {
                WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                ArrayList data = new ArrayList();
                
                foreach (Row r in sheetData.Elements<Row>())
                {
                    foreach (Cell c in r.Elements<Cell>())
                    {
                       
                        if (c.DataType != null && c.DataType == CellValues.SharedString && c.InnerText != string.Empty)
                        {
                            var stringId = Convert.ToInt32(Regex.Unescape(c.InnerText));
                            data.Add(Regex.Unescape(workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>()
                                .ElementAt(stringId).InnerText));
                        }
                        else if (c.InnerText != null || c.InnerText != string.Empty)
                        {
                            data.Add(Regex.Unescape(c.InnerText));
                        }
                    }
                }
                return data;
            }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
