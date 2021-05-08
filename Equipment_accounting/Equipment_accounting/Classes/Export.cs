using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
namespace Equipment_accounting.Classes
{
    class Export
    {
        public static string dateToday = DateTime.Now.ToString("dd MMMM yyyy");
        public static void ExportPdf(DataGrid MainGrid)
        {

            //Объект документа пдф
            Document doc = new Document();
            //Создаем объект записи пдф-документа в файл
            string folderPath = "C:\\ExportData\\Pdfs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fileName = "Оборудование ГУПа на " + dateToday + ".pdf";
            int headersCount = 7; //Количество столбцов с данными
            PdfWriter.GetInstance(doc, new FileStream(folderPath + fileName, FileMode.Create));
            //Открываем документ
            doc.Open();
            //Определение шрифта 
            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\times.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
            //Создаем объект таблицы и передаем в нее число столбцов таблицы
            PdfPTable table = new PdfPTable(headersCount + 1);
            table.WidthPercentage = 100;
            // table.LockedWidth = true;
            float[] widths = new float[] { 17f, 60f, 60f, 55f, 50f, 50f, 45f, 45f };
            table.SetWidths(widths);
            //Добавим в таблицу общий заголовок
            PdfPCell cell = new PdfPCell(new Phrase("Оборудование СПБ ГУП Пассажиравтотранс \n\n", font));
            cell.Colspan = MainGrid.Columns.Count;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //Убираем границу первой ячейки
            cell.Border = 0;
            //  float width = 20f;
            table.AddCell(cell);
            //Добавляем стоблец с номерами
            cell = new PdfPCell(new Phrase("№", font));
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(cell);
            for (int j = 1; j <= headersCount; j++)
            {
                cell = new PdfPCell(new Phrase(MainGrid.Columns[j].Header.ToString(), font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
            }

            //Добавляем все остальные ячейки
            for (int j = 0; j < MainGrid.Items.Count; j++)
            {
                cell = new PdfPCell(new Phrase((j + 1).ToString(), font));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                for (int k = 1; k <= headersCount; k++)
                {
                    table.AddCell(new Phrase((MainGrid.Columns[k].GetCellContent(MainGrid.Items[j]) as TextBlock)?.Text ?? "", font));
                }
            }
            //Добавляем таблицу в документ
            doc.Add(table);
            //Закрываем документ
            doc.Close();
            MessageBox.Show("Pdf-документ сохранен");
        }
        //TODO:Сделать экспорт в пдф в фоновом режиме
        public static void ExportExcel(DataGrid MainGrid)
        {

            int headersCount = 7; //Количество столбцов с данными
            //string folderPath = "C:\\ExportData\\Excels\\";
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            sheet1.Name = "Отчет за " + dateToday;

            //Заполение заголовками
            for (int j = 1; j <= headersCount; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j];

                sheet1.Cells[1, j].Font.Bold = true;
                sheet1.Columns.AutoFit();
                // sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = MainGrid.Columns[j].Header;
            }

            //Заполнение данными
            for (int i = 1; i <= headersCount; i++)
            {
                for (int j = 0; j < MainGrid.Items.Count; j++)
                {

                    TextBlock b = MainGrid.Columns[i].GetCellContent(MainGrid.Items[j]) as TextBlock;
                    sheet1.Columns.AutoFit();
                    Range myRange = (Range)sheet1.Cells[j + 2, i];
                    myRange.Value2 = b.Text;
                }
            }
            // MessageBox.Show("Excel-документ сохранен");
        }
    }

}
