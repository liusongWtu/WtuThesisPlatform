using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using WtuThesisPlatform.MODEL;

namespace WtuThesisPlatform.DAL
{
    /// <summary>
    /// Author: LiuSong
    /// Description: DALTier -- the DAL class of SysFun.
    /// Datetime:2013/4/16 16:12:04
    /// </summary>
    public class SysFunDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysFun set IsDel='" + isDel.ToString() + "' where NodeId in (" + ids + ")");
            //SqlParameter parameter = new SqlParameter("@Ids", SqlDbType.VarChar, 100);
            //parameter.Value = ids;
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region DELETE PHYSICAL
        /// <summary>
        /// DELETE PHYSICAL
        /// </summary>
        public int Del(string ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SysFun where NodeId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public SysFun GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NodeId,DisplayName,NodeURL,ParentNodeId,DisplayOrder,IsDel from SysFun ");
            strSql.Append(" where NodeId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            SysFun model = new SysFun();
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                LoadEntityData(ref model, dt.Rows[0]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public SysFun GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NodeId,DisplayName,NodeURL,ParentNodeId,DisplayOrder,IsDel from SysFun ");
            strSql.Append(" where "+strWhere);
            SysFun model = new SysFun();
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                LoadEntityData(ref model, dt.Rows[0]);
                return model;
            }
            else
            {
                return null;
            }
        } 		
        #endregion
		
        #region GET DATA LIST bysqlwhere
        /// <summary>
        /// GET DATA LIST bysqlwhere
        /// </summary>
        public IList<SysFun> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NodeId,DisplayName,NodeURL,ParentNodeId,DisplayOrder,IsDel ");
            strSql.Append(" FROM SysFun ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<SysFun> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<SysFun>();
                SysFun model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new SysFun();
                    LoadEntityData(ref model, dr);
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion

        #region GetListByProc
        /// <summary>
        /// GetListByProc
        /// </summary>
        /// <param name="procName">procName</param>
        /// <param name="paras">paras</param>
        public IList<SysFun> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<SysFun> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<SysFun>();
            LoadListData(ref list, dt);
            if (list.Count > 0) return list;
            else return null;
        }
        #endregion

        #region GET PAGED DATA LIST,TOTAL ROWS,TOTAL PAGES
        /// <summary>
        /// GET PAGED DATA LIST,TOTAL ROWS,TOTAL PAGES
        /// </summary>
        /// <param name="pageIndex">PAGEINDEX</param>
        /// <param name="pageSize">PAGESIZE</param>
        /// <param name="where">QUERY</param>
        /// <param name="orderby">SORT</param>
        /// <param name="rowCount">out TOTAL ROWS</param>
        /// <param name="pageCount">out TOTAL PAGES</param>
        /// <returns></returns>
        public IList<SysFun> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<SysFun> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("SysFun", "NodeId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<SysFun>();
            LoadListData(ref list, dt);
            if (list.Count > 0) return list;
            else return null;
        }
        #endregion

        #region LoadTableToGenericList and renturn
        /// <summary>
        /// LoadTableToGenericList and renturn
        /// </summary>
        /// <param name="list">GenericList</param>
        /// <param name="dt">DataTable</param>
        private void LoadListData(ref IList<SysFun> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                SysFun model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new SysFun();
                    LoadEntityData(ref model, dr);
                    list.Add(model);
                }
            }
        }
        #endregion
		
        #region LoadEntityData
        /// <summary>
        /// LoadEntityData
        /// </summary>
        /// <param name="model">Entity</param>
        /// <param name="dr">DataRow</param>
        private void LoadEntityData(ref SysFun model, DataRow dr)
        {
                        if (!dr.IsNull("NodeId")&&dr["NodeId"].ToString() != "")
            {
                model.NodeId = int.Parse(dr["NodeId"].ToString());
            }
            model.DisplayName = dr["DisplayName"].ToString();
            model.NodeURL = dr["NodeURL"].ToString();
            if (!dr.IsNull("ParentNodeId")&&dr["ParentNodeId"].ToString() != "")
            {
                model.ParentNodeId = int.Parse(dr["ParentNodeId"].ToString());
            }
            if (!dr.IsNull("DisplayOrder")&&dr["DisplayOrder"].ToString() != "")
            {
                model.DisplayOrder = int.Parse(dr["DisplayOrder"].ToString());
            }
            if (!dr.IsNull("IsDel")&&dr["IsDel"].ToString() != "")
            {
                model.IsDel = bool.Parse(dr["IsDel"].ToString());
            }

        }
        #endregion
		
        #region Add a record
        /// <summary>
        /// Add a record
        /// </summary>
        public int Add(SysFun model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into SysFun(");
                strSql.Append("DisplayName,NodeURL,ParentNodeId,DisplayOrder,IsDel)");
                strSql.Append(" values (");
                strSql.Append("@DisplayName,@NodeURL,@ParentNodeId,@DisplayOrder,@IsDel)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@DisplayName", SqlDbType.VarChar,50),
                    new SqlParameter("@NodeURL", SqlDbType.VarChar,200),
                    new SqlParameter("@ParentNodeId", SqlDbType.Int,4),
                    new SqlParameter("@DisplayOrder", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
				                parameters[0].Value = model.DisplayName;
                parameters[1].Value = model.NodeURL;
                parameters[2].Value = model.ParentNodeId;
                parameters[3].Value = model.DisplayOrder;
                parameters[4].Value = model.IsDel;
                result = DbHelperSQL.ExcuteScalar(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion
		
        #region Update
        /// <summary>
        /// Update a data
        /// </summary>
        public int Update(SysFun model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysFun set ");
                        strSql.Append("DisplayName=@DisplayName,");
            strSql.Append("NodeURL=@NodeURL,");
            strSql.Append("ParentNodeId=@ParentNodeId,");
            strSql.Append("DisplayOrder=@DisplayOrder,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where NodeId=@NodeId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@NodeId", SqlDbType.Int,4),
                    new SqlParameter("@DisplayName", SqlDbType.VarChar,50),
                    new SqlParameter("@NodeURL", SqlDbType.VarChar,200),
                    new SqlParameter("@ParentNodeId", SqlDbType.Int,4),
                    new SqlParameter("@DisplayOrder", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			                parameters[0].Value = model.NodeId;
                parameters[1].Value = model.DisplayName;
                parameters[2].Value = model.NodeURL;
                parameters[3].Value = model.ParentNodeId;
                parameters[4].Value = model.DisplayOrder;
                parameters[5].Value = model.IsDel;

            try
            {
                res = DbHelperSQL.ExcuteNonQuery(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally { DbHelperSQL.CloseDB(); }
            return res;
        }
        #endregion
    }
}
