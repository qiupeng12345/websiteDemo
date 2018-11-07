/*******************************************************************************
 * 使用NPOI操作Excel
 * 
 * author：qp
 *
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.Data;
using System.IO;
using NPOI.XSSF.UserModel;

namespace ACA.Code
{
    /// <summary>
    /// 用NPOI操作Excel
    /// </summary>
    public class NPOIExcel
    {
        private string title;
        private string sheetName;
        private string filePath;
        /// <summary>
        /// 将dataTable的数据到处到excel
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool ToExcel(DataTable dt)
        {
            try
            {
                //新建一个文件流
                FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                IWorkbook workBook = new XSSFWorkbook(); //创建一个excel文件
                this.sheetName = string.IsNullOrWhiteSpace(this.sheetName) ? "sheet1" : this.sheetName;
                ISheet sheet = workBook.CreateSheet(this.sheetName); //创建一个sheet
                                                                     //处理表格标题
                IRow row = sheet.CreateRow(0);
                row.CreateCell(0).SetCellValue(this.title);
                //合并单元格
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dt.Columns.Count - 1));
                row.Height = 500;
                //单元样式
                ICellStyle cellStyle = workBook.CreateCellStyle();
                //字体
                IFont font = workBook.CreateFont();
                font.FontName = "微软雅黑";
                font.FontHeightInPoints = 17;
                cellStyle.SetFont(font);
                //水平垂直居中
                cellStyle.VerticalAlignment = VerticalAlignment.Center;
                cellStyle.Alignment = HorizontalAlignment.Center;
                row.Cells[0].CellStyle = cellStyle;
                //处理表哥列头
                row = sheet.CreateRow(1);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    row.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                    row.Height = 350;
                    sheet.AutoSizeColumn(i);
                }
                //处理数据内容
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = sheet.CreateRow(2 + i);
                    row.Height = 250;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        row.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString().Trim());
                        sheet.SetColumnWidth(j, 256 * 15);
                    }
                }
                //写入数据流
                workBook.Write(fs);
                fs.Flush();
                fs.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
        /// <summary>
        /// 将DataTable里的数据导出excel
        /// </summary>
        /// <param name="dt">datatable</param>
        /// <param name="title">标题</param>
        /// <param name="sheetName">工作表</param>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        public bool ToExcel(DataTable dt,string title,string sheetName,string filePath)
        {
            this.title = title;
            this.sheetName = sheetName;
            this.filePath = filePath;
            return ToExcel(dt);
        }
        /// <summary>
        /// 导入Excel的数据到DataTable
        /// </summary>
        /// <param name="isFirstRowColumn"></param>
        /// <returns></returns>
        private DataTable ExcelToDataTable(bool isFirstRowColumn)
        {
            try
            {
                ISheet sheet = null;
                DataTable dt = new DataTable();
                int startRow = 0;
                FileStream fs = new FileStream(this.filePath, FileMode.Open, FileAccess.Read);
                //根据filePath/sheetName获取worksheet
                IWorkbook workbook = new XSSFWorkbook(fs);
                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null)
                    {
                        sheet.Workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet.Workbook.GetSheetAt(0);
                }
                //将worksheet的值赋值给DataTable
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum;//一行最后一个cell的编号。总的列数
                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    dt.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i < rowCount; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        DataRow dataRow = dt.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null)
                            {
                                dataRow[j] = row.GetCell(j).ToString().Trim();
                            }
                        }
                        dt.Rows.Add(dataRow);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 导入Excel的数据到DataTable
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="sheetName">工作表名</param>
        /// <param name="isFirstRowColumn">第一行是否是字符串的列名</param>
        /// <returns></returns>
        public DataTable ExcelToDataTable(string filePath,string sheetName,bool isFirstRowColumn)
        {
            this.filePath = filePath;
            this.sheetName = sheetName;
            return ExcelToDataTable(isFirstRowColumn);
        }
    }
}
