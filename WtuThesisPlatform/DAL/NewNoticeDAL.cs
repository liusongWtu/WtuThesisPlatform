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
    /// Description: DALTier -- the DAL class of NewNotice.
    /// Datetime:2013/4/22 16:14:22
    /// </summary>
    public class NewNoticeDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NewNotice set noDelKey='" + isDel.ToString() + "' where NId in (" + ids + ")");
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
            strSql.Append("delete NewNotice where NId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public NewNotice GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NId,NoticeId,NUserType,NUserId from NewNotice ");
            strSql.Append(" where NId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            NewNotice model = new NewNotice();
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

        public NewNotice GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NId,NoticeId,NUserType,NUserId from NewNotice ");
            strSql.Append(" where "+strWhere);
            NewNotice model = new NewNotice();
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
        public IList<NewNotice> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NId,NoticeId,NUserType,NUserId ");
            strSql.Append(" FROM NewNotice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<NewNotice> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<NewNotice>();
                NewNotice model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new NewNotice();
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
        public IList<NewNotice> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<NewNotice> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<NewNotice>();
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
        public IList<NewNotice> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<NewNotice> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("NewNotice", "NId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<NewNotice>();
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
        private void LoadListData(ref IList<NewNotice> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                NewNotice model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new NewNotice();
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
        private void LoadEntityData(ref NewNotice model, DataRow dr)
        {
                        if (!dr.IsNull("NId")&&dr["NId"].ToString() != "")
            {
                model.NId = int.Parse(dr["NId"].ToString());
            }
            if (!dr.IsNull("NoticeId")&&dr["NoticeId"].ToString() != "")
            {
                model.NoticeId = int.Parse(dr["NoticeId"].ToString());
            }
            if (!dr.IsNull("NUserType")&&dr["NUserType"].ToString() != "")
            {
                model.NUserType = int.Parse(dr["NUserType"].ToString());
            }
            if (!dr.IsNull("NUserId")&&dr["NUserId"].ToString() != "")
            {
                model.NUserId = int.Parse(dr["NUserId"].ToString());
            }

        }
        #endregion
		
        #region Add a record
        /// <summary>
        /// Add a record
        /// </summary>
        public int Add(NewNotice model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                 if (model.NId == 0)
                {
                    model.NId = DbHelperSQL.GetNextValidID("NewNotice ", "NId");
                }
                
                strSql.Append("insert into NewNotice(");
                strSql.Append("NId,NoticeId,NUserType,NUserId)");
                strSql.Append(" values (");
                strSql.Append(" @NId,@NoticeId,@NUserType,@NUserId)");
                strSql.Append(";");
                SqlParameter[] parameters = {
                    new SqlParameter("@NId", SqlDbType.Int,4),
                    new SqlParameter("@NoticeId", SqlDbType.Int,4),
                    new SqlParameter("@NUserType", SqlDbType.Int,2),
                    new SqlParameter("@NUserId", SqlDbType.Int,4)};

				parameters[0].Value = model.NId;
                parameters[1].Value = model.NoticeId;
                parameters[2].Value = model.NUserType;
                parameters[3].Value = model.NUserId;
                result = DbHelperSQL.ExcuteNonQuery(strSql.ToString(), parameters);
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
        public int Update(NewNotice model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NewNotice set ");
                        strSql.Append("NoticeId=@NoticeId,");
            strSql.Append("NUserType=@NUserType,");
            strSql.Append("NUserId=@NUserId");
            strSql.Append(" where NId=@NId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@NId", SqlDbType.Int,4),
                    new SqlParameter("@NoticeId", SqlDbType.Int,4),
                    new SqlParameter("@NUserType", SqlDbType.Int,2),
                    new SqlParameter("@NUserId", SqlDbType.Int,4)};
			                parameters[0].Value = model.NId;
                parameters[1].Value = model.NoticeId;
                parameters[2].Value = model.NUserType;
                parameters[3].Value = model.NUserId;

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

        public int Del(int noticeId, int userId, int userType)
        {
            string sql = "delete from NewNotice where NoticeId="+noticeId+" and NUserType="+userType+" and NUserId="+userId;
            return DbHelperSQL.ExcuteNonQuery(sql);
        }

        public int GetNewNumByTid(int teacherId)
        {
            string sql = "select count(*) from NewNotice where NUserType=2 and NUserId="+teacherId;
            return DbHelperSQL.ExcuteScalar(sql);
        }

        public int GetNewNumBySId(int studentId)
        {
            string sql = "select count(*) from NewNotice where NUserType=1 and NUserId="+studentId;
            return DbHelperSQL.ExcuteScalar(sql);
        }
    }
}
