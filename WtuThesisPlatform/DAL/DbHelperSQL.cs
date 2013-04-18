using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 数据库操作帮助类
    /// </summary>
    public class DbHelperSQL
    {
        //从配置文件读取了 连接字符串
        static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        #region 01.执行查询语句 返回数据表 +DataTable GetTable(string sqlStr, params SqlParameter[] paras)
        /// <summary>
        /// 执行查询语句 返回数据表
        /// </summary>
        /// <param name="sqlStr">查询语句</param>
        /// <param name="paras">参数集合</param>
        /// <returns></returns>
        public static DataTable GetTable(string sqlStr, params SqlParameter[] paras)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
                da.SelectCommand.Parameters.AddRange(paras);
                da.Fill(dt);
            }
            return dt;
        }
        #endregion

        #region 02.执行增删改操作，返回受影响行数+ int ExcuteNonQuery(string sql, params SqlParameter[] paras)
        /// <summary>
        /// 执行增删改操作，返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static int ExcuteNonQuery(string sql, params SqlParameter[] paras)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(paras);
                conn.Open();
                res = cmd.ExecuteNonQuery();
            }
            return res;
        }
        #endregion

        #region 03.执行查询单个值操作，返回受结果集的第一行第一列+ int ExcuteScalar(string sql, params SqlParameter[] paras)
        /// <summary>
        /// 执行查询单个值操作，返回受结果集的第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static int ExcuteScalar(string sql, params SqlParameter[] paras)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(paras);
                conn.Open();
                object o = cmd.ExecuteScalar();
                res = Convert.ToInt32(o);
            }
            return res;
        }
        #endregion

        #region 04.执行存储过程查询语句，返回数据表+DataTable ExecProDataTable(string procName, params SqlParameter[] paras)
        /// <summary>
        /// 执行存储过程查询语句，返回数据表
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static DataTable ExecProDataTable(string procName, params SqlParameter[] paras)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(procName, conn);
                da.SelectCommand.Parameters.AddRange(paras);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            return dt;
        }
        #endregion

        #region 05. 执行查询分页数据  ，返回分页数据表 +DataTable ExecProPageList(...)

        /// <summary>
        /// 执行查询分页数据  ，返回分页数据表
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="key">表主键名</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="rowCount">总行数（传出参数）</param>
        /// <param name="pageCount">总页数（传出参数）</param>
        /// <returns></returns>
        public static DataTable ExecProPageList(string table, string key, int pageIndex, int pageSize,
            string where, string orderby, out int rowCount, out int pageCount)
        {
            DataTable dt = new DataTable();
            rowCount = 0;
            pageCount = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("up_GetPageDataOut", conn);
                SqlParameter[] paras ={
                                          new SqlParameter("@tn",table),
                                          new SqlParameter ("@idn",key),
                                          new SqlParameter ("@pi",pageIndex),
                                          new SqlParameter ("@ps",pageSize),
                                          new SqlParameter ("@wh",where ),
                                          new SqlParameter ("@oby",orderby ),
                                          new SqlParameter ("@rc",rowCount),
                                          new SqlParameter ("@pc",pageCount)
                                     };
                //指定输出参数的输出方向
                paras[6].Direction = ParameterDirection.Output;
                paras[7].Direction = ParameterDirection.Output;
                //将参数集合加入到查询命令对象中
                da.SelectCommand.Parameters.AddRange(paras);
                //设置查询命令类型为存储过程
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //执行存储过程
                da.Fill(dt);
                //执行完后，将存储过程 获得的 两个输出参数值 赋给 此方法的两个输出参数
                rowCount = Convert.ToInt32(paras[6].Value);
                pageCount = Convert.ToInt32(paras[7].Value);
            }
            return dt;
        }

        #endregion
    }
}
