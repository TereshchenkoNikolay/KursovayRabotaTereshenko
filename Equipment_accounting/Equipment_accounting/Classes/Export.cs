using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Equipment_accounting.Classes
{
    class Export
    {
        public static void ExportPdf(DataGrid MainGrid)
        {

            //Объект документа пдф
            Document doc = new Document();
            //Создаем объект записи пдф-документа в файл
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            int headersCount = 7; //Количество столбцов с данными
            PdfWriter.GetInstance(doc, new FileStream(folderPath + "Оборудование ГУПа.pdf", FileMode.Create));
            //Открываем документ
            doc.Open();
            //Определение шрифта 
            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\times.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);
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
        public static void ExportExcel(DataGrid MainGrid)
        { }
    }

}
