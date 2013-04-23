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
    /// Description: DALTier -- the DAL class of Notice.
    /// Datetime:2013/4/22 16:14:30
    /// </summary>
    public class NoticeDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Notice set IsDel='" + isDel.ToString() + "' where NId in (" + ids + ")");
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
            strSql.Append("delete Notice where NId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public Notice GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NId,NLevel,NName,NPublisherId,NPublishUnits,NContent,NPublishTime,NDeadTime,IsDel from Notice ");
            strSql.Append(" where NId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            Notice model = new Notice();
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

        public Notice GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NId,NLevel,NName,NPublisherId,NPublishUnits,NContent,NPublishTime,NDeadTime,IsDel from Notice ");
            strSql.Append(" where "+strWhere);
            Notice model = new Notice();
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
        public IList<Notice> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NId,NLevel,NName,NPublisherId,NPublishUnits,NContent,NPublishTime,NDeadTime,IsDel ");
            strSql.Append(" FROM Notice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<Notice> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Notice>();
                Notice model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Notice();
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
        public IList<Notice> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<Notice> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<Notice>();
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
        public IList<Notice> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<Notice> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("Notice", "NId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<Notice>();
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
        private void LoadListData(ref IList<Notice> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Notice model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Notice();
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
        private void LoadEntityData(ref Notice model, DataRow dr)
        {
                        if (!dr.IsNull("NId")&&dr["NId"].ToString() != "")
            {
                model.NId = int.Parse(dr["NId"].ToString());
            }
            if (!dr.IsNull("NLevel")&&dr["NLevel"].ToString() != "")
            {
                model.NLevel = int.Parse(dr["NLevel"].ToString());
            }
            model.NName = dr["NName"].ToString();
            if (!dr.IsNull("NPublisherId")&&dr["NPublisherId"].ToString() != "")
            {
                model.NPublisherId = int.Parse(dr["NPublisherId"].ToString());
            }
            model.NPublishUnits = dr["NPublishUnits"].ToString();
            model.NContent = dr["NContent"].ToString();
            if (!dr.IsNull("NPublishTime")&&dr["NPublishTime"].ToString() != "")
            {
                model.NPublishTime = DateTime.Parse(dr["NPublishTime"].ToString());
            }
            if (!dr.IsNull("NDeadTime")&&dr["NDeadTime"].ToString() != "")
            {
                model.NDeadTime = DateTime.Parse(dr["NDeadTime"].ToString());
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
        public int Add(Notice model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                 if (model.NId == 0)
                {
                    model.NId = DbHelperSQL.GetNextValidID("Notice ", "NId");
                }
                
                strSql.Append("insert into Notice(");
                strSql.Append("NId,NLevel,NName,NPublisherId,NPublishUnits,NContent,NPublishTime,NDeadTime,IsDel)");
                strSql.Append(" values (");
                strSql.Append(" @NId,@NLevel,@NName,@NPublisherId,@NPublishUnits,@NContent,@NPublishTime,@NDeadTime,@IsDel)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@NId", SqlDbType.Int,4),
                    new SqlParameter("@NLevel", SqlDbType.Int,4),
                    new SqlParameter("@NName", SqlDbType.VarChar,20),
                    new SqlParameter("@NPublisherId", SqlDbType.Int,4),
                    new SqlParameter("@NPublishUnits", SqlDbType.VarChar,50),
                    new SqlParameter("@NContent", SqlDbType.VarChar,16),
                    new SqlParameter("@NPublishTime", SqlDbType.DateTime,8),
                    new SqlParameter("@NDeadTime", SqlDbType.DateTime,8),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};

				parameters[0].Value = model.NId;
                parameters[1].Value = model.NLevel;
                parameters[2].Value = model.NName;
                parameters[3].Value = model.NPublisherId;
                parameters[4].Value = model.NPublishUnits;
                parameters[5].Value = model.NContent;
                parameters[6].Value = model.NPublishTime;
                parameters[7].Value = model.NDeadTime;
                parameters[8].Value = model.IsDel;
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
        public int Update(Notice model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Notice set ");
                        strSql.Append("NLevel=@NLevel,");
            strSql.Append("NName=@NName,");
            strSql.Append("NPublisherId=@NPublisherId,");
            strSql.Append("NPublishUnits=@NPublishUnits,");
            strSql.Append("NContent=@NContent,");
            strSql.Append("NPublishTime=@NPublishTime,");
            strSql.Append("NDeadTime=@NDeadTime,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where NId=@NId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@NId", SqlDbType.Int,4),
                    new SqlParameter("@NLevel", SqlDbType.Int,4),
                    new SqlParameter("@NName", SqlDbType.VarChar,20),
                    new SqlParameter("@NPublisherId", SqlDbType.Int,4),
                    new SqlParameter("@NPublishUnits", SqlDbType.VarChar,50),
                    new SqlParameter("@NContent", SqlDbType.VarChar,16),
                    new SqlParameter("@NPublishTime", SqlDbType.DateTime,8),
                    new SqlParameter("@NDeadTime", SqlDbType.DateTime,8),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			                parameters[0].Value = model.NId;
                parameters[1].Value = model.NLevel;
                parameters[2].Value = model.NName;
                parameters[3].Value = model.NPublisherId;
                parameters[4].Value = model.NPublishUnits;
                parameters[5].Value = model.NContent;
                parameters[6].Value = model.NPublishTime;
                parameters[7].Value = model.NDeadTime;
                parameters[8].Value = model.IsDel;

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
