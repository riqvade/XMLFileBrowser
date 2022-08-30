using ClosedXML.Excel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XMLFileBrowser.XMLViewer;

namespace XMLFileBrowser.Components
{
    /// <summary>
    /// Менеджер по экспорту
    /// </summary>
    public static class ExportManager
    {
        /// <summary>
        /// Экспортирует данные в excel файл
        /// </summary>
        public static void ExportDataToExcel(string filePath)
        {
            string mergeRow = "A1:Z1";
            int currentRow = 1;
            int currentColumn = 1;
            FileContentService fileContentService = App.Current.Services.GetService<FileContentService>();
            

            IXLWorkbook workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add("Sheet1");

            ObservableCollection<ChapterModel> chapterModels = fileContentService.GetChapters();

            worksheet.Column(currentColumn).Width = 3;
            currentColumn += 1;
            worksheet.Column(currentColumn).Width = 7;
            worksheet.Column(currentColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Column(currentColumn).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Column(currentColumn).Style.Alignment.WrapText = true;
            currentColumn += 1;
            worksheet.Column(currentColumn).Width = 22;
            worksheet.Column(currentColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Column(currentColumn).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            currentColumn += 1;
            worksheet.Column(currentColumn).Width = 90;
            worksheet.Column(currentColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            worksheet.Column(currentColumn).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Column(currentColumn).Style.Alignment.WrapText = true;
            currentColumn += 1;
            worksheet.Column(currentColumn).Width = 18;
            worksheet.Column(currentColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Column(currentColumn).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Column(currentColumn).Style.Alignment.WrapText = true;
            currentColumn += 1;
            worksheet.Column(currentColumn).Width = 12;
            worksheet.Column(currentColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Column(currentColumn).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            currentColumn = 1;

            foreach (ChapterModel chapter in chapterModels)
            {
                if(chapter != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = chapter.Caption;
                    worksheet.Row(currentRow).Style.Font.Bold = true;
                    worksheet.Range(mergeRow).Row(currentRow).Merge();
                    currentRow += 1;

                    foreach (Position position in chapter.Positions)
                    {
                        currentColumn += 1;
                        worksheet.Cell(currentRow, currentColumn).Value = position.Number;
                        currentColumn += 1;
                        worksheet.Cell(currentRow, currentColumn).Value = position.Code;
                        currentColumn += 1;
                        worksheet.Cell(currentRow, currentColumn).Value = position.Caption;
                        currentColumn += 1;
                        worksheet.Cell(currentRow, currentColumn).Value = position.Units;
                        currentColumn += 1;
                        worksheet.Cell(currentRow, currentColumn).Value = position.Quantity;
                        currentColumn = 1;
                        currentRow += 1;

                        foreach (Resource resource in position.Resources)
                        {
                            currentColumn += 2;
                            worksheet.Cell(currentRow, currentColumn).Value = resource.Code;
                            currentColumn += 1;
                            worksheet.Cell(currentRow, currentColumn).Value = resource.Caption;
                            currentColumn += 2;
                            worksheet.Cell(currentRow, currentColumn).Value = resource.Quantity;

                            currentColumn = 1;
                            currentRow += 1;
                        }
                    }
                }
            }
            workbook.SaveAs(filePath);
            MessageBox.Show("Файл создан");
        }
    }
}
