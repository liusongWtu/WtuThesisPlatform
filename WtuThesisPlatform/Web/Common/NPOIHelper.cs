using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using System.Data;

namespace StarTech.NPOI
{
    /// <summary>
    /// Excel���ɲ�����
    /// </summary>
    public class NPOIHelper
    {
        /// <summary>
        /// ��������
        /// </summary>
        public static System.Collections.SortedList ListColumnsName;
        /// <summary>
        /// ����Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public static void ExportExcel(DataTable dtSource, string filePath)
        {
            if (ListColumnsName == null || ListColumnsName.Count == 0)
                throw (new Exception("���ListColumnsName����Ҫ������������"));

            HSSFWorkbook excelWorkbook = CreateExcelFile();
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, filePath);
        }
        /// <summary>
        /// ����Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public static void ExportExcel(DataTable dtSource, Stream excelStream)
        {
            if (ListColumnsName == null || ListColumnsName.Count == 0)
                throw (new Exception("���ListColumnsName����Ҫ������������"));

            HSSFWorkbook excelWorkbook = CreateExcelFile();
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, excelStream);
        }
        /// <summary>
        /// ����Excel�ļ�
        /// </summary>
        /// <param name="excelWorkBook"></param>
        /// <param name="filePath"></param>
        protected static void SaveExcelFile(HSSFWorkbook excelWorkBook, string filePath)
        {
            FileStream file = null;
            try
            {
                file = new FileStream(filePath, FileMode.Create);
                excelWorkBook.Write(file);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        /// <summary>
        /// ����Excel�ļ�
        /// </summary>
        /// <param name="excelWorkBook"></param>
        /// <param name="filePath"></param>
        protected static void SaveExcelFile(HSSFWorkbook excelWorkBook, Stream excelStream)
        {
            try
            {
                excelWorkBook.Write(excelStream);
            }
            finally
            {

            }
        }
        /// <summary>
        /// ����Excel�ļ�
        /// </summary>
        /// <param name="filePath"></param>
        protected static HSSFWorkbook CreateExcelFile()
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            return hssfworkbook;
        }
        /// <summary>
        /// ����excel��ͷ
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="excelSheet"></param>
        protected static void CreateHeader(HSSFSheet excelSheet)
        {
            int cellIndex = 0;
            //ѭ��������
            foreach (System.Collections.DictionaryEntry de in ListColumnsName)
            {
                HSSFRow newRow = excelSheet.CreateRow(0);
                HSSFCell newCell = newRow.CreateCell(cellIndex);
                newCell.SetCellValue(de.Value.ToString());
                cellIndex++;
            }
        }
        /// <summary>
        /// ����������
        /// </summary>
        protected static void InsertRow(DataTable dtSource, HSSFWorkbook excelWorkbook)
        {
            int rowCount = 0;
            int sheetCount = 1;
            HSSFSheet newsheet = null;

            //ѭ������Դ�������ݼ�
            newsheet = excelWorkbook.CreateSheet("Sheet" + sheetCount);
            CreateHeader(newsheet);
            foreach (DataRow dr in dtSource.Rows)
            {
                rowCount++;
                //����10000������ �����µĹ�����
                if (rowCount == 10000)
                {
                    rowCount = 1;
                    sheetCount++;
                    newsheet = excelWorkbook.CreateSheet("Sheet" + sheetCount);
                    CreateHeader(newsheet);
                }

                HSSFRow newRow = newsheet.CreateRow(rowCount);
                InsertCell(dtSource, dr, newRow, newsheet, excelWorkbook);
            }
        }
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="drSource"></param>
        /// <param name="currentExcelRow"></param>
        /// <param name="excelSheet"></param>
        /// <param name="excelWorkBook"></param>
        protected static void InsertCell(DataTable dtSource, DataRow drSource, HSSFRow currentExcelRow, HSSFSheet excelSheet, HSSFWorkbook excelWorkBook)
        {
            for (int cellIndex = 0; cellIndex < ListColumnsName.Count; cellIndex++)
            {
                //������
                string columnsName = ListColumnsName.GetKey(cellIndex).ToString();
                HSSFCell newCell = null;
                System.Type rowType = drSource[columnsName].GetType();
                string drValue = drSource[columnsName].ToString().Trim();
                switch (rowType.ToString())
                {
                    case "System.String"://�ַ�������
                        drValue = drValue.Replace("&", "&");
                        drValue = drValue.Replace(">", ">");
                        drValue = drValue.Replace("<", "<");
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(drValue);
                        break;
                    case "System.DateTime"://��������
                        DateTime dateV;
                        DateTime.TryParse(drValue, out dateV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(dateV);

                        //��ʽ����ʾ
                        HSSFCellStyle cellStyle = excelWorkBook.CreateCellStyle();
                        HSSFDataFormat format = excelWorkBook.CreateDataFormat();
                        cellStyle.DataFormat = format.GetFormat("yyyy-mm-dd hh:mm:ss");
                        newCell.CellStyle = cellStyle;

                        break;
                    case "System.Boolean"://������
                        bool boolV = false;
                        bool.TryParse(drValue, out boolV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(boolV);
                        break;
                    case "System.Int16"://����
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Byte":
                        int intV = 0;
                        int.TryParse(drValue, out intV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(intV.ToString());
                        break;
                    case "System.Decimal"://������
                    case "System.Double":
                        double doubV = 0;
                        double.TryParse(drValue, out doubV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(doubV);
                        break;
                    case "System.DBNull"://��ֵ����
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue("");
                        break;
                    default:
                        throw (new Exception(rowType.ToString() + "�����������޷�����!"));
                }
            }
        }
    }
    //����ʵ�ֽӿ� ���������� �������˳�򵼳�
    public class NoSort : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            return -1;
        }
    }
}
