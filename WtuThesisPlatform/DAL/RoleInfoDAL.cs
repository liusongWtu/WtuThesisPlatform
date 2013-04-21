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
    /// Description: DALTier -- the DAL class of RoleInfo.
    /// Datetime:2013/4/21 14:09:50
    /// </summary>
    public class RoleInfoDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RoleInfo set IsDel='" + isDel.ToString() + "' where RoleId in (" + ids + ")");
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
            strSql.Append("delete RoleInfo where RoleId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public RoleInfo GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleId,RoleName,RoleDesc,IsDel from RoleInfo ");
            strSql.Append(" where RoleId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            RoleInfo model = new RoleInfo();
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

        public RoleInfo GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleId,RoleName,RoleDesc,IsDel from RoleInfo ");
            strSql.Append(" where "+strWhere);
            RoleInfo model = new RoleInfo();
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
        public IList<RoleInfo> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleId,RoleName,RoleDesc,IsDel ");
            strSql.Append(" FROM RoleInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<RoleInfo> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<RoleInfo>();
                RoleInfo model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new RoleInfo();
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
        public IList<RoleInfo> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<RoleInfo> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<RoleInfo>();
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
        public IList<RoleInfo> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<RoleInfo> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("RoleInfo", "RoleId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<RoleInfo>();
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
        private void LoadListData(ref IList<RoleInfo> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                RoleInfo model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new RoleInfo();
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
        private void LoadEntityData(ref RoleInfo model, DataRow dr)
        {
                        if (!dr.IsNull("RoleId")&&dr["RoleId"].ToString() != "")
            {
                model.RoleId = int.Parse(dr["RoleId"].ToString());
            }
            model.RoleName = dr["RoleName"].ToString();
            model.RoleDesc = dr["RoleDesc"].ToString();
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
        public int Add(RoleInfo model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                 if (model.RoleId == 0)
                {
                    model.RoleId = DbHelperSQL.GetNextValidID("RoleInfo ", "RoleId");
                }
                
                strSql.Append("insert into RoleInfo(");
                strSql.Append("RoleId,RoleName,RoleDesc,IsDel)");
                strSql.Append(" values (");
                strSql.Append(" @RoleId,@RoleName,@RoleDesc,@IsDel)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@RoleName", SqlDbType.VarChar,50),
                    new SqlParameter("@RoleDesc", SqlDbType.VarChar,200),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};

				parameters[0].Value = model.RoleId;
                parameters[1].Value = model.RoleName;
                parameters[2].Value = model.RoleDesc;
                parameters[3].Value = model.IsDel;
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
        public int Update(RoleInfo model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RoleInfo set ");
                        strSql.Append("RoleName=@RoleName,");
            strSql.Append("RoleDesc=@RoleDesc,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where RoleId=@RoleId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@RoleName", SqlDbType.VarChar,50),
                    new SqlParameter("@RoleDesc", SqlDbType.VarChar,200),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			                parameters[0].Value = model.RoleId;
                parameters[1].Value = model.RoleName;
                parameters[2].Value = model.RoleDesc;
                parameters[3].Value = model.IsDel;

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
