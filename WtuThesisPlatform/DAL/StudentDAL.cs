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
    /// Description: DALTier -- the DAL class of Student.
    /// Datetime:2013/4/21 14:10:07
    /// </summary>
    public class StudentDAL
    {
        RoleInfoDAL roleInfoDal = new RoleInfoDAL();

        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Student set IsDel='" + isDel.ToString() + "' where SId in (" + ids + ")");
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
            strSql.Append("delete Student where SId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion

        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public Student GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SId,SNo,SName,DId,MId,SSex,CId,SPhone,SQQ,SEmail,SPassword,SFlag,SYear,RoleId,SCheckCode,IsDel from Student ");
            strSql.Append(" where SId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            Student model = new Student();
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

        public Student GetModelBySno(string currentSno)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SId,SNo,SName,DId,MId,SSex,CId,SPhone,SQQ,SEmail,SPassword,SFlag,SYear,SCheckCode,RoleId,IsDel from Student ");
            strSql.Append(" where SNo=@currentSno ");
            SqlParameter[] parameters = {
                    new SqlParameter("@currentSno", SqlDbType.VarChar,20)};
            parameters[0].Value = currentSno;
            Student model = new Student();
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

        public Student GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SId,SNo,SName,DId,MId,SSex,CId,SPhone,SQQ,SEmail,SPassword,SFlag,SYear,RoleId,SCheckCode,IsDel from Student ");
            strSql.Append(" where " + strWhere);
            Student model = new Student();
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
        public IList<Student> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SId,SNo,SName,DId,MId,SSex,CId,SPhone,SQQ,SEmail,SPassword,SFlag,SYear,RoleId,SCheckCode,IsDel ");
            strSql.Append(" FROM Student ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<Student> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Student>();
                Student model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Student();
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
        public IList<Student> GetListByProc(string procName, SqlParameter[] paras)
        {
            IList<Student> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<Student>();
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
        public IList<Student> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<Student> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("Student", "SId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<Student>();
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
        private void LoadListData(ref IList<Student> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Student model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Student();
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
        private void LoadEntityData(ref Student model, DataRow dr)
        {
            if (!dr.IsNull("SId") && dr["SId"].ToString() != "")
            {
                model.SId = int.Parse(dr["SId"].ToString());
            }
            model.SNo = dr["SNo"].ToString();
            model.SName = dr["SName"].ToString();
            if (!dr.IsNull("DId") && dr["DId"].ToString() != "")
            {
                model.Department.DId = int.Parse(dr["DId"].ToString());
                model.Department = new DepartmentDAL().GetModel(model.Department.DId);
            }
            if (!dr.IsNull("MId") && dr["MId"].ToString() != "")
            {
                model.Major.MId = int.Parse(dr["MId"].ToString());
                model.Major = new MajorDAL().GetModel(model.Major.MId);
            }
            model.SSex = dr["SSex"].ToString();
            if (!dr.IsNull("CId") && dr["CId"].ToString() != "")
            {
                model.ClassInfo.CId = int.Parse(dr["CId"].ToString());
                model.ClassInfo = new ClassInfoDAL().GetModel(model.ClassInfo.CId);
            }
            model.SPhone = dr["SPhone"].ToString();
            model.SQQ = dr["SQQ"].ToString();
            model.SEmail = dr["SEmail"].ToString();
            model.SPassword = dr["SPassword"].ToString();
            if (!dr.IsNull("SFlag") && dr["SFlag"].ToString() != "")
            {
                model.SFlag = bool.Parse(dr["SFlag"].ToString());
            }
            model.SYear = dr["SYear"].ToString();
            if (!dr.IsNull("RoleId") && dr["RoleId"].ToString() != "")
            {
                int roleId = int.Parse(dr["RoleId"].ToString());
                model.RoleInfo = roleInfoDal.GetModel(roleId);
            }
            model.SCheckCode = dr["SCheckCode"].ToString();
            if (!dr.IsNull("IsDel") && dr["IsDel"].ToString() != "")
            {
                model.IsDel = bool.Parse(dr["IsDel"].ToString());
            }

        }
        #endregion

        #region Add a record
        /// <summary>
        /// Add a record
        /// </summary>
        public int Add(Student model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                if (model.SId == 0)
                {
                    model.SId = DbHelperSQL.GetNextValidID("Student ", "SId");
                }

                strSql.Append("insert into Student(");
                strSql.Append("SId,SNo,SName,DId,MId,SSex,CId,SPhone,SQQ,SEmail,SPassword,SFlag,SYear,RoleId,SCheckCode,IsDel)");
                strSql.Append(" values (");
                strSql.Append(" @SId,@SNo,@SName,@DId,@MId,@SSex,@CId,@SPhone,@SQQ,@SEmail,@SPassword,@SFlag,@SYear,@RoleId,@SCheckCode,@IsDel)");
                strSql.Append(";");
                SqlParameter[] parameters = {
                    new SqlParameter("@SId", SqlDbType.Int,4),
                    new SqlParameter("@SNo", SqlDbType.VarChar,20),
                    new SqlParameter("@SName", SqlDbType.VarChar,20),
                    new SqlParameter("@DId", SqlDbType.Int,4),
                    new SqlParameter("@MId", SqlDbType.Int,4),
                    new SqlParameter("@SSex", SqlDbType.VarChar,2),
                    new SqlParameter("@CId", SqlDbType.VarChar,20),
                    new SqlParameter("@SPhone", SqlDbType.VarChar,15),
                    new SqlParameter("@SQQ", SqlDbType.VarChar,20),
                    new SqlParameter("@SEmail", SqlDbType.VarChar,30),
                    new SqlParameter("@SPassword", SqlDbType.VarChar,20),
                    new SqlParameter("@SFlag", SqlDbType.Bit,1),
                    new SqlParameter("@SYear", SqlDbType.VarChar,4),
                    new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@SCheckCode", SqlDbType.VarChar,8),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};

                parameters[0].Value = model.SId;
                parameters[1].Value = model.SNo;
                parameters[2].Value = model.SName;
                parameters[3].Value = model.Department.DId;
                parameters[4].Value = model.Major.MId;
                parameters[5].Value = model.SSex;
                parameters[7].Value = model.ClassInfo.CId;
                parameters[8].Value = model.SPhone;
                parameters[9].Value = model.SQQ;
                parameters[10].Value = model.SEmail;
                parameters[11].Value = model.SPassword;
                parameters[12].Value = model.SFlag;
                parameters[13].Value = model.SYear;
                parameters[14].Value = model.RoleInfo.RoleId;
                parameters[15].Value = model.SCheckCode;
                parameters[16].Value = model.IsDel;
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
        public int Update(Student model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Student set ");
            strSql.Append("SNo=@SNo,");
            strSql.Append("SName=@SName,");
            strSql.Append("DId=@DId,");
            strSql.Append("MId=@MId,");
            strSql.Append("SSex=@SSex,");
            strSql.Append("CId=@CId,");
            strSql.Append("SPhone=@SPhone,");
            strSql.Append("SQQ=@SQQ,");
            strSql.Append("SEmail=@SEmail,");
            strSql.Append("SPassword=@SPassword,");
            strSql.Append("SFlag=@SFlag,");
            strSql.Append("SYear=@SYear,");
            strSql.Append("RoleId=@RoleId,");
            strSql.Append("SCheckCode=@SCheckCode,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where SId=@SId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SId", SqlDbType.Int,4),
                    new SqlParameter("@SNo", SqlDbType.VarChar,20),
                    new SqlParameter("@SName", SqlDbType.VarChar,20),
                    new SqlParameter("@DId", SqlDbType.Int,4),
                    new SqlParameter("@MId", SqlDbType.Int,4),
                    new SqlParameter("@SSex", SqlDbType.VarChar,2),
                    new SqlParameter("@CId", SqlDbType.VarChar,20),
                    new SqlParameter("@SPhone", SqlDbType.VarChar,15),
                    new SqlParameter("@SQQ", SqlDbType.VarChar,20),
                    new SqlParameter("@SEmail", SqlDbType.VarChar,30),
                    new SqlParameter("@SPassword", SqlDbType.VarChar,32),
                    new SqlParameter("@SFlag", SqlDbType.Bit,1),
                    new SqlParameter("@SYear", SqlDbType.VarChar,4),
                    new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@SCheckCode", SqlDbType.VarChar,8),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
            parameters[0].Value = model.SId;
            parameters[1].Value = model.SNo;
            parameters[2].Value = model.SName;
            parameters[3].Value = model.Department.DId;
            parameters[4].Value = model.Major.MId;
            parameters[5].Value = model.SSex;
            parameters[6].Value = model.ClassInfo.CId;
            parameters[7].Value = model.SPhone;
            parameters[8].Value = model.SQQ;
            parameters[9].Value = model.SEmail;
            parameters[10].Value = model.SPassword;
            parameters[11].Value = model.SFlag;
            parameters[12].Value = model.SYear;
            parameters[13].Value = model.RoleInfo.RoleId;
            parameters[14].Value = model.SCheckCode;
            parameters[15].Value = model.IsDel;

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
