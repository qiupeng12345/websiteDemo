/*******************************************************************************
 * 分页
 * 
 * author：qp
 *
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ACA.Code
{
    /// <summary>
    /// 分页类
    /// </summary>
    public class TableToPage
    {
        /// <summary>
        /// 获取表中某页的数据
        /// </summary>
        /// <param name="data">表数据</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="allPage">返回总页数</param>
        /// <returns>返回当页表数据</returns>
        public static DataTable GetPage(DataTable data,int pageIndex,int pageSize,out int allPage)
        {
            //计算出总页数
            allPage = data.Rows.Count / pageSize;
            allPage += data.Rows.Count % pageSize==0 ? 1 : 0;
            DataTable pageTable = data.Clone();
            //根据pageIndex和pageSize提取出这一页的内容到table
            if (pageIndex<=allPage)
            {
                int startIndex = pageIndex * pageSize;
                int endIndex = startIndex + pageSize > data.Rows.Count ? data.Rows.Count : startIndex + pageSize;
                if (startIndex<endIndex)
                {
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        pageTable.ImportRow(data.Rows[i]);
                    }
                }
            }
            return pageTable;
        }
        /// <summary>
        /// 根据字段过滤表中的内容
        /// </summary>
        /// <param name="data">数据表</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static DataTable GetDataFilter(DataTable data,string condition)
        {
            if (data != null && data.Rows.Count > 0)
            {
                if (condition.Trim() == "")
                {
                    return data;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = data.Clone();
                    DataRow[] dr = data.Select(condition);
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dt.ImportRow(dr[i]);
                    }
                    return dt;
                }
            }
            else return null;
        }
    }
}
