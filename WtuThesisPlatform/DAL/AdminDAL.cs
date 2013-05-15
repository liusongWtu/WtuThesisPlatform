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
    /// Description: DALTier -- the DAL class of Admin.
    /// Datetime:2013/4/21 14:32:10
    /// </summary>
    public class AdminDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Admin set IsDel='" + isDel.ToString() + "' where UId in (" + ids + ")");
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
            strSql.Append("delete Admin where UId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public Admin GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UId,UUserName,UPassword,UName,UPhone,UEmail,UQQ,DepartmentId,RoleId,UCheckId,IsDel from Admin "); 
            strSql.Append(" where UId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            Admin model = new Admin();
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

        public Admin GetModelByUserName(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UId,UUserName,UPassword,UName,UPhone,UEmail,UQQ,DepartmentId,RoleId,UCheckId,IsDel from Admin "); 
            strSql.Append(" where UUserName=@userName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@userName", SqlDbType.NVarChar,20)};
            parameters[0].Value = userName;
            Admin model = new Admin();
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

        public Admin GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UId,UUserName,UPassword,UName,UPhone,UEmail,UQQ,DepartmentId,RoleId,UCheckId,IsDel from Admin "); 
            strSql.Append(" where " + strWhere);
            Admin model = new Admin();
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
        public IList<Admin> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UId,UUserName,UPassword,UName,UPhone,UEmail,UQQ,DepartmentId,RoleId,UCheckId,IsDel "); 
            strSql.Append(" FROM Admin ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<Admin> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Admin>();
                Admin model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Admin();
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
        public IList<Admin> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<Admin> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<Admin>();
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
        public IList<Admin> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<Admin> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("Admin", "UId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<Admin>();
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
        private void LoadListData(ref IList<Admin> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Admin model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Admin();
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
        private void LoadEntityData(ref Admin model, DataRow dr)
        {
                        if (!dr.IsNull("UId")&&dr["UId"].ToString() != "")
            {
                model.UId = int.Parse(dr["UId"].ToString());
            }
            model.UUserName = dr["UUserName"].ToString();
            model.UPassword = dr["UPassword"].ToString();
            model.UName = dr["UName"].ToString();
            model.UPhone = dr["UPhone"].ToString();
            model.UEmail = dr["UEmail"].ToString();
            model.UQQ = dr["UQQ"].ToString();
            if (!dr.IsNull("DepartmentId")&&dr["DepartmentId"].ToString() != "")
            {
                model.DepartmentId = int.Parse(dr["DepartmentId"].ToString());
            }
            if (!dr.IsNull("RoleId")&&dr["RoleId"].ToString() != "")
            {
                int roleId = int.Parse(dr["RoleId"].ToString());
                model.RoleInfo = new RoleInfoDAL().GetModel(roleId);
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
        public int Add(Admin model,out int uid)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                 if (model.UId == 0)
                {
                    model.UId = DbHelperSQL.GetNextValidID("Admin ", "UId");
                }
                
                 strSql.Append("insert into Admin(");
                 strSql.Append("UId,UUserName,UPassword,UName,UPhone,UEmail,UQQ,DepartmentId,RoleId,UCheckId,IsDel)");
                 strSql.Append(" values (");
                 strSql.Append(" @UId,@UUserName,@UPassword,@UName,@UPhone,@UEmail,@UQQ,@DepartmentId,@RoleId,@UCheckId,@IsDel)");
                 strSql.Append(";");
                 SqlParameter[] parameters = {
                    new SqlParameter("@UId", SqlDbType.Int,4),
                    new SqlParameter("@UUserName", SqlDbType.VarChar,20),
                    new SqlParameter("@UPassword", SqlDbType.VarChar,32),
                    new SqlParameter("@UName", SqlDbType.VarChar,20),
                    new SqlParameter("@UPhone", SqlDbType.VarChar,50),
                    new SqlParameter("@UEmail", SqlDbType.VarChar,50),
                    new SqlParameter("@UQQ", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentId", SqlDbType.Int,4),
                    new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@UCheckId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};

                 parameters[0].Value = model.UId;
                 parameters[1].Value = model.UUserName;
                 parameters[2].Value = model.UPassword;
                 parameters[3].Value = model.UName;
                 parameters[4].Value = model.UPhone;
                 parameters[5].Value = model.UEmail;
                 parameters[6].Value = model.UQQ;
                 parameters[7].Value = model.DepartmentId;
                 parameters[8].Value = model.RoleInfo.RoleId;
                 parameters[9].Value = model.UCheckId;
                 parameters[10].Value = model.IsDel;
                 result = DbHelperSQL.ExcuteNonQuery(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            uid = model.UId;
            return result;
        }
        #endregion
		
        #region Update
        /// <summary>
        /// Update a data
        /// </summary>
        public int Update(Admin model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Admin set ");
            strSql.Append("UUserName=@UUserName,");
            strSql.Append("UPassword=@UPassword,");
            strSql.Append("UName=@UName,");
            strSql.Append("UPhone=@UPhone,");
            strSql.Append("UEmail=@UEmail,");
            strSql.Append("UQQ=@UQQ,");
            strSql.Append("DepartmentId=@DepartmentId,");
            strSql.Append("RoleId=@RoleId,");
            strSql.Append("UCheckId=@UCheckId,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where UId=@UId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UId", SqlDbType.Int,4),
                    new SqlParameter("@UUserName", SqlDbType.VarChar,20),
                    new SqlParameter("@UPassword", SqlDbType.VarChar,32),
                    new SqlParameter("@UName", SqlDbType.VarChar,20),
                    new SqlParameter("@UPhone", SqlDbType.VarChar,50),
                    new SqlParameter("@UEmail", SqlDbType.VarChar,50),
                    new SqlParameter("@UQQ", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentId", SqlDbType.Int,4),
                    new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@UCheckId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
            parameters[0].Value = model.UId;
            parameters[1].Value = model.UUserName;
            parameters[2].Value = model.UPassword;
            parameters[3].Value = model.UName;
            parameters[4].Value = model.UPhone;
            parameters[5].Value = model.UEmail;
            parameters[6].Value = model.UQQ;
            parameters[7].Value = model.DepartmentId;
            parameters[8].Value = model.RoleInfo.RoleId;
            parameters[9].Value = model.UCheckId;
            parameters[10].Value = model.IsDel;

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
