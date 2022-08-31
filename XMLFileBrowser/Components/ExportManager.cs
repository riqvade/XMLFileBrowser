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
            string mergeRow = "A1:F1";
            int currentRow = 1;
            int currentColumn = 1;
            FileContentService fileContentService = App.Current.Services.GetService<FileContentService>();
            

            IXLWorkbook workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add("Sheet1");
            ObservableCollection<ChapterModel> chapterModels = fileContentService.GetChapters();

            FormatCells(worksheet, currentColumn);

            foreach (ChapterModel chapter in chapterModels)
            {
                if(chapter != null)
                {
                    worksheet.Range(mergeRow).Row(currentRow).Merge();
                    worksheet.Cell(currentRow, currentColumn).Value = chapter.Caption;
                    worksheet.Row(currentRow).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, currentColumn).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(currentRow, currentColumn).Style.Fill.BackgroundColor = XLColor.CoralRed;

                    currentRow += 1;

                    foreach (Position position in chapter.Positions)
                    {
                        currentColumn += 1;
                        worksheet.Cell(currentRow, currentColumn).Value = position.Number;
                        worksheet.Cell(currentRow, currentColumn).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(currentRow, currentColumn).Style.Fill.BackgroundColor = XLColor.LightBlue;
                        currentColumn += 1;
                        worksheet.Cell(currentRow, currentColumn).Value = position.Code;
                        worksheet.Cell(currentRow, currentColumn).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(currentRow, currentColumn).Style.Fill.BackgroundColor = XLColor.LightBlue;
                        currentColumn += 1;
                        worksheet.Cell(currentRow, currentColumn).Value = position.Caption;
                        worksheet.Cell(currentRow, currentColumn).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(currentRow, currentColumn).Style.Fill.BackgroundColor = XLColor.LightBlue;
                        currentColumn += 1;
                        worksheet.Cell(currentRow, currentColumn).Value = position.Units;
                        worksheet.Cell(currentRow, currentColumn).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(currentRow, currentColumn).Style.Fill.BackgroundColor = XLColor.LightBlue;
                        currentColumn += 1;
                        worksheet.Cell(currentRow, currentColumn).Value = position.Quantity + Convert.ToChar(130);
                        worksheet.Cell(currentRow, currentColumn).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(currentRow, currentColumn).Style.Fill.BackgroundColor = XLColor.LightBlue;
                        currentColumn = 1;
                        currentRow += 1;

                        foreach (Resource resource in position.Resources)
                        {
                            currentColumn += 2;
                            worksheet.Cell(currentRow, currentColumn).Value = resource.Code;
                            worksheet.Cell(currentRow, currentColumn).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            worksheet.Cell(currentRow, currentColumn).Style.Fill.BackgroundColor = XLColor.LightGreen;
                            currentColumn += 1;
                            worksheet.Cell(currentRow, currentColumn).Value = resource.Caption;
                            worksheet.Cell(currentRow, currentColumn).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            worksheet.Cell(currentRow, currentColumn).Style.Fill.BackgroundColor = XLColor.LightGreen;
                            currentColumn += 1;
                            worksheet.Cell(currentRow, currentColumn).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            worksheet.Cell(currentRow, currentColumn).Style.Fill.BackgroundColor = XLColor.LightGreen;
                            currentColumn += 1;
                            worksheet.Cell(currentRow, currentColumn).Value = resource.Quantity + Convert.ToChar(130);
                            worksheet.Cell(currentRow, currentColumn).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            worksheet.Cell(currentRow, currentColumn).Style.Fill.BackgroundColor = XLColor.LightGreen;

                            currentColumn = 1;
                            currentRow += 1;
                        }
                    }
                }
            }
            workbook.SaveAs(filePath);
            MessageBox.Show("Файл создан");
        }

        /// <summary>
        /// Форматирует ячейки
        /// </summary>
        private static void FormatCells(IXLWorksheet worksheet, int currentColumn)
        {
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
        }
    }
}
