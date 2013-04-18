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
    /// Description: DALTier -- the DAL class of UserInfo.
    /// Datetime:2013/4/16 16:12:28
    /// </summary>
    public class UserInfoDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set IsDel='" + isDel.ToString() + "' where UId in (" + ids + ")");
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
            strSql.Append("delete UserInfo where UId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public UserInfo GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UId,UUserName,UPassword,UName,DepartmentId,UCheckId,IsDel from UserInfo ");
            strSql.Append(" where UId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            UserInfo model = new UserInfo();
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

        public UserInfo GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UId,UUserName,UPassword,UName,DepartmentId,UCheckId,IsDel from UserInfo ");
            strSql.Append(" where "+strWhere);
            UserInfo model = new UserInfo();
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
        public IList<UserInfo> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UId,UUserName,UPassword,UName,DepartmentId,UCheckId,IsDel ");
            strSql.Append(" FROM UserInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<UserInfo> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<UserInfo>();
                UserInfo model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new UserInfo();
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
        public IList<UserInfo> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<UserInfo> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<UserInfo>();
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
        public IList<UserInfo> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<UserInfo> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("UserInfo", "UId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<UserInfo>();
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
        private void LoadListData(ref IList<UserInfo> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                UserInfo model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new UserInfo();
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
        private void LoadEntityData(ref UserInfo model, DataRow dr)
        {
                        if (!dr.IsNull("UId")&&dr["UId"].ToString() != "")
            {
                model.UId = int.Parse(dr["UId"].ToString());
            }
            model.UUserName = dr["UUserName"].ToString();
            model.UPassword = dr["UPassword"].ToString();
            model.UName = dr["UName"].ToString();
            if (!dr.IsNull("DepartmentId")&&dr["DepartmentId"].ToString() != "")
            {
                model.DepartmentId = int.Parse(dr["DepartmentId"].ToString());
            }
            if (!dr.IsNull("UCheckId")&&dr["UCheckId"].ToString() != "")
            {
                model.UCheckId = int.Parse(dr["UCheckId"].ToString());
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
        public int Add(UserInfo model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into UserInfo(");
                strSql.Append("UUserName,UPassword,UName,DepartmentId,UCheckId,IsDel)");
                strSql.Append(" values (");
                strSql.Append("@UUserName,@UPassword,@UName,@DepartmentId,@UCheckId,@IsDel)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@UUserName", SqlDbType.VarChar,20),
                    new SqlParameter("@UPassword", SqlDbType.VarChar,20),
                    new SqlParameter("@UName", SqlDbType.VarChar,20),
                    new SqlParameter("@DepartmentId", SqlDbType.Int,4),
                    new SqlParameter("@UCheckId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
				                parameters[0].Value = model.UUserName;
                parameters[1].Value = model.UPassword;
                parameters[2].Value = model.UName;
                parameters[3].Value = model.DepartmentId;
                parameters[4].Value = model.UCheckId;
                parameters[5].Value = model.IsDel;
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
        public int Update(UserInfo model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ");
                        strSql.Append("UUserName=@UUserName,");
            strSql.Append("UPassword=@UPassword,");
            strSql.Append("UName=@UName,");
            strSql.Append("DepartmentId=@DepartmentId,");
            strSql.Append("UCheckId=@UCheckId,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where UId=@UId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UId", SqlDbType.Int,4),
                    new SqlParameter("@UUserName", SqlDbType.VarChar,20),
                    new SqlParameter("@UPassword", SqlDbType.VarChar,20),
                    new SqlParameter("@UName", SqlDbType.VarChar,20),
                    new SqlParameter("@DepartmentId", SqlDbType.Int,4),
                    new SqlParameter("@UCheckId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			                parameters[0].Value = model.UId;
                parameters[1].Value = model.UUserName;
                parameters[2].Value = model.UPassword;
                parameters[3].Value = model.UName;
                parameters[4].Value = model.DepartmentId;
                parameters[5].Value = model.UCheckId;
                parameters[6].Value = model.IsDel;

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
