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
    /// Description: DALTier -- the DAL class of Teacher.
    /// Datetime:2013/4/21 14:10:24
    /// </summary>
    public class TeacherDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Teacher set IsDel='" + isDel.ToString() + "' where TId in (" + ids + ")");
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
            strSql.Append("delete Teacher where TId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public Teacher GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TId,TUserName,TPassword,TName,TZhiCheng,TTeachNum,TPhone,TEmail,MajorId,TTeachCourse,TResearchFields,TCheckCode,RoleId,IsDel from Teacher ");
            strSql.Append(" where TId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            Teacher model = new Teacher();
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

        public Teacher GetModelByUserName(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TId,TUserName,TPassword,TName,TZhiCheng,TTeachNum,TPhone,TEmail,MajorId,TTeachCourse,TResearchFields,TCheckCode,RoleId,IsDel from Teacher ");
            strSql.Append(" where TUserName=@userName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@userName", SqlDbType.NVarChar,20)};
            parameters[0].Value = userName;
            Teacher model = new Teacher();
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

        public Teacher GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TId,TUserName,TPassword,TName,TZhiCheng,TTeachNum,TPhone,TEmail,MajorId,TTeachCourse,TResearchFields,TCheckCode,RoleId,IsDel from Teacher ");
            strSql.Append(" where "+strWhere);
            Teacher model = new Teacher();
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
        public IList<Teacher> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TId,TUserName,TPassword,TName,TZhiCheng,TTeachNum,TPhone,TEmail,MajorId,TTeachCourse,TResearchFields,TCheckCode,RoleId,IsDel ");
            strSql.Append(" FROM Teacher ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<Teacher> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Teacher>();
                Teacher model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Teacher();
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
        public IList<Teacher> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<Teacher> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<Teacher>();
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
        public IList<Teacher> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<Teacher> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("Teacher", "TId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<Teacher>();
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
        private void LoadListData(ref IList<Teacher> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Teacher model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Teacher();
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
        private void LoadEntityData(ref Teacher model, DataRow dr)
        {
                        if (!dr.IsNull("TId")&&dr["TId"].ToString() != "")
            {
                model.TId = int.Parse(dr["TId"].ToString());
            }
            model.TUserName = dr["TUserName"].ToString();
            model.TPassword = dr["TPassword"].ToString();
            model.TName = dr["TName"].ToString();
            model.TZhiCheng = dr["TZhiCheng"].ToString();
            if (!dr.IsNull("TTeachNum")&&dr["TTeachNum"].ToString() != "")
            {
                model.TTeachNum = int.Parse(dr["TTeachNum"].ToString());
            }
            model.TPhone = dr["TPhone"].ToString();
            model.TEmail = dr["TEmail"].ToString();
            if (!dr.IsNull("MajorId")&&dr["MajorId"].ToString() != "")
            {
                model.MajorId = int.Parse(dr["MajorId"].ToString());
            }
            model.TTeachCourse = dr["TTeachCourse"].ToString();
            model.TResearchFields = dr["TResearchFields"].ToString();
            model.TCheckCode = dr["TCheckCode"].ToString();
            if (!dr.IsNull("RoleId")&&dr["RoleId"].ToString() != "")
            {
                int roleId = int.Parse(dr["RoleId"].ToString());
                model.RoleInfo = new RoleInfoDAL().GetModel(roleId);
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
        public int Add(Teacher model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                 if (model.TId == 0)
                {
                    model.TId = DbHelperSQL.GetNextValidID("Teacher ", "TId");
                }
                
                strSql.Append("insert into Teacher(");
                strSql.Append("TId,TUserName,TPassword,TName,TZhiCheng,TTeachNum,TPhone,TEmail,MajorId,TTeachCourse,TResearchFields,TCheckCode,RoleId,IsDel)");
                strSql.Append(" values (");
                strSql.Append(" @TId,@TUserName,@TPassword,@TName,@TZhiCheng,@TTeachNum,@TPhone,@TEmail,@MajorId,@TTeachCourse,@TResearchFields,@TCheckCode,@RoleId,@IsDel)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@TId", SqlDbType.Int,4),
                    new SqlParameter("@TUserName", SqlDbType.VarChar,20),
                    new SqlParameter("@TPassword", SqlDbType.VarChar,20),
                    new SqlParameter("@TName", SqlDbType.VarChar,20),
                    new SqlParameter("@TZhiCheng", SqlDbType.VarChar,20),
                    new SqlParameter("@TTeachNum", SqlDbType.Int,4),
                    new SqlParameter("@TPhone", SqlDbType.VarChar,20),
                    new SqlParameter("@TEmail", SqlDbType.VarChar,20),
                    new SqlParameter("@MajorId", SqlDbType.Int,4),
                    new SqlParameter("@TTeachCourse", SqlDbType.VarChar,200),
                    new SqlParameter("@TResearchFields", SqlDbType.VarChar,16),
                    new SqlParameter("@TCheckCode", SqlDbType.VarChar,36),
                    new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};

				parameters[0].Value = model.TId;
                parameters[1].Value = model.TUserName;
                parameters[2].Value = model.TPassword;
                parameters[3].Value = model.TName;
                parameters[4].Value = model.TZhiCheng;
                parameters[5].Value = model.TTeachNum;
                parameters[6].Value = model.TPhone;
                parameters[7].Value = model.TEmail;
                parameters[8].Value = model.MajorId;
                parameters[9].Value = model.TTeachCourse;
                parameters[10].Value = model.TResearchFields;
                parameters[11].Value = model.TCheckCode;
                parameters[12].Value = model.RoleInfo.RoleId;
                parameters[13].Value = model.IsDel;
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
        public int Update(Teacher model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Teacher set ");
                        strSql.Append("TUserName=@TUserName,");
            strSql.Append("TPassword=@TPassword,");
            strSql.Append("TName=@TName,");
            strSql.Append("TZhiCheng=@TZhiCheng,");
            strSql.Append("TTeachNum=@TTeachNum,");
            strSql.Append("TPhone=@TPhone,");
            strSql.Append("TEmail=@TEmail,");
            strSql.Append("MajorId=@MajorId,");
            strSql.Append("TTeachCourse=@TTeachCourse,");
            strSql.Append("TResearchFields=@TResearchFields,");
            strSql.Append("TCheckCode=@TCheckCode,");
            strSql.Append("RoleId=@RoleId,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where TId=@TId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@TId", SqlDbType.Int,4),
                    new SqlParameter("@TUserName", SqlDbType.VarChar,20),
                    new SqlParameter("@TPassword", SqlDbType.VarChar,20),
                    new SqlParameter("@TName", SqlDbType.VarChar,20),
                    new SqlParameter("@TZhiCheng", SqlDbType.VarChar,20),
                    new SqlParameter("@TTeachNum", SqlDbType.Int,4),
                    new SqlParameter("@TPhone", SqlDbType.VarChar,20),
                    new SqlParameter("@TEmail", SqlDbType.VarChar,20),
                    new SqlParameter("@MajorId", SqlDbType.Int,4),
                    new SqlParameter("@TTeachCourse", SqlDbType.VarChar,200),
                    new SqlParameter("@TResearchFields", SqlDbType.VarChar,16),
                    new SqlParameter("@TCheckCode", SqlDbType.VarChar,36),
                    new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			                parameters[0].Value = model.TId;
                parameters[1].Value = model.TUserName;
                parameters[2].Value = model.TPassword;
                parameters[3].Value = model.TName;
                parameters[4].Value = model.TZhiCheng;
                parameters[5].Value = model.TTeachNum;
                parameters[6].Value = model.TPhone;
                parameters[7].Value = model.TEmail;
                parameters[8].Value = model.MajorId;
                parameters[9].Value = model.TTeachCourse;
                parameters[10].Value = model.TResearchFields;
                parameters[11].Value = model.TCheckCode;
                parameters[12].Value = model.RoleInfo.RoleId;
                parameters[13].Value = model.IsDel;

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
