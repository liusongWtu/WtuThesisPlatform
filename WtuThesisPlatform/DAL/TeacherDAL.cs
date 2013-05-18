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
    /// Datetime:2013/5/4 11:06:34
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
            strSql.Append("select TId,TNo,TPassword,TName,TSex,TZhiCheng,TTeachNum,TPhone,TEmail,TQQ,DepartmentId,MajorId,TTeachCourse,TResearchFields,TCheckCode,RoleId,IsDel from Teacher ");
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

        public Teacher GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TId,TNo,TPassword,TName,TZhiCheng,TSex,TTeachNum,TPhone,TEmail,TQQ,DepartmentId,MajorId,TTeachCourse,TResearchFields,TCheckCode,RoleId,IsDel from Teacher ");
            strSql.Append(" where " + strWhere);
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

        public Teacher GetModelByUserName(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TId,TNo,TPassword,TName,TZhiCheng,TSex,TTeachNum,DepartmentId,TQQ,TPhone,TEmail,MajorId,TTeachCourse,TResearchFields,TCheckCode,RoleId,IsDel from Teacher ");
            strSql.Append(" where TNo=@userName ");
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
        #endregion

        #region GET DATA LIST bysqlwhere
        /// <summary>
        /// GET DATA LIST bysqlwhere
        /// </summary>
        public IList<Teacher> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TId,TNo,TPassword,TName,TZhiCheng,TSex,TTeachNum,TPhone,TEmail,TQQ,DepartmentId,MajorId,TTeachCourse,TResearchFields,TCheckCode,RoleId,IsDel ");
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
        public IList<Teacher> GetListByProc(string procName, SqlParameter[] paras)
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
            if (!dr.IsNull("TId") && dr["TId"].ToString() != "")
            {
                model.TId = int.Parse(dr["TId"].ToString());
            }
            model.TNo = dr["TNo"].ToString();
            model.TPassword = dr["TPassword"].ToString();
            model.TName = dr["TName"].ToString();
            model.TZhiCheng = dr["TZhiCheng"].ToString();
            model.TSex = dr["TSex"].ToString();
            if (!dr.IsNull("TTeachNum") && dr["TTeachNum"].ToString() != "")
            {
                model.TTeachNum = int.Parse(dr["TTeachNum"].ToString());
            }
            model.TPhone = dr["TPhone"].ToString();
            model.TEmail = dr["TEmail"].ToString();
            model.TQQ = dr["TQQ"].ToString();
            if (!dr.IsNull("DepartmentId") && dr["DepartmentId"].ToString() != "")
            {
                int departmentId = int.Parse(dr["DepartmentId"].ToString());
                model.Department = new DepartmentDAL().GetModel(departmentId);
            }
            if (!dr.IsNull("MajorId") && dr["MajorId"].ToString() != "")
            {
                int majorId = int.Parse(dr["MajorId"].ToString());
                model.Major = new MajorDAL().GetModel(majorId);
            }
            model.TTeachCourse = dr["TTeachCourse"].ToString();
            model.TResearchFields = dr["TResearchFields"].ToString();
            model.TCheckCode = dr["TCheckCode"].ToString();
            if (!dr.IsNull("RoleId") && dr["RoleId"].ToString() != "")
            {
                int roleId = int.Parse(dr["RoleId"].ToString());
                model.RoleInfo = new RoleInfoDAL().GetModel(roleId);
            }
            if (!dr.IsNull("IsDel") && dr["IsDel"].ToString() != "")
            {
                model.IsDel = bool.Parse(dr["IsDel"].ToString());
            }
            model.CurrNum= DbHelperSQL.ExcuteScalar("select COUNT(*) from View_TeacherTeach where TTeacherId="+model.TId+" and TPassed=1");
        }
        #endregion

        #region Add a record
        /// <summary>
        /// Add a record
        /// </summary>
        public int Add(Teacher model,out int tid)
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
                strSql.Append("TId,TNo,TPassword,TName,TZhiCheng,TTeachNum,TPhone,TEmail,TQQ,DepartmentId,MajorId,TTeachCourse,TResearchFields,TCheckCode,RoleId,IsDel,TSex)");
                strSql.Append(" values (");
                strSql.Append(" @TId,@TNo,@TPassword,@TName,@TZhiCheng,@TTeachNum,@TPhone,@TEmail,@TQQ,@DepartmentId,@MajorId,@TTeachCourse,@TResearchFields,@TCheckCode,@RoleId,@IsDel,@TSex)");
                strSql.Append(";");
                SqlParameter[] parameters = {
                    new SqlParameter("@TId", SqlDbType.Int,4),
                    new SqlParameter("@TNo", SqlDbType.VarChar,20),
                    new SqlParameter("@TPassword", SqlDbType.VarChar,32),
                    new SqlParameter("@TName", SqlDbType.VarChar,20),
                    new SqlParameter("@TZhiCheng", SqlDbType.VarChar,20),
                    new SqlParameter("@TTeachNum", SqlDbType.Int,4),
                    new SqlParameter("@TPhone", SqlDbType.VarChar,20),
                    new SqlParameter("@TEmail", SqlDbType.VarChar,20),
                    new SqlParameter("@TQQ", SqlDbType.VarChar,20),
                    new SqlParameter("@DepartmentId", SqlDbType.Int,4),
                    new SqlParameter("@MajorId", SqlDbType.Int,4),
                    new SqlParameter("@TTeachCourse", SqlDbType.VarChar,200),
                    new SqlParameter("@TResearchFields", SqlDbType.VarChar,16),
                    new SqlParameter("@TCheckCode", SqlDbType.VarChar,36),
                    new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1),
                    new SqlParameter("@TSex",SqlDbType.VarChar,2)};

                parameters[0].Value = model.TId;
                parameters[1].Value = model.TNo;
                parameters[2].Value = model.TPassword;
                parameters[3].Value = model.TName;
                parameters[4].Value = model.TZhiCheng;
                parameters[5].Value = model.TTeachNum;
                parameters[6].Value = model.TPhone;
                parameters[7].Value = model.TEmail;
                parameters[8].Value = model.TQQ;
                parameters[9].Value = model.Department.DId;
                parameters[10].Value = model.Major.MId;
                parameters[11].Value = model.TTeachCourse;
                parameters[12].Value = model.TResearchFields;
                parameters[13].Value = model.TCheckCode;
                parameters[14].Value = model.RoleInfo.RoleId;
                parameters[15].Value = model.IsDel;
                parameters[16].Value = model.TSex;
                result = DbHelperSQL.ExcuteNonQuery(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            tid = model.TId;
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
            strSql.Append("TNo=@TNo,");
            strSql.Append("TPassword=@TPassword,");
            strSql.Append("TName=@TName,");
            strSql.Append("TZhiCheng=@TZhiCheng,");
            strSql.Append("TTeachNum=@TTeachNum,");
            strSql.Append("TSex=@TSex,");
            strSql.Append("TPhone=@TPhone,");
            strSql.Append("TEmail=@TEmail,");
            strSql.Append("TQQ=@TQQ,");
            strSql.Append("DepartmentId=@DepartmentId,");
            strSql.Append("MajorId=@MajorId,");
            strSql.Append("TTeachCourse=@TTeachCourse,");
            strSql.Append("TResearchFields=@TResearchFields,");
            strSql.Append("TCheckCode=@TCheckCode,");
            strSql.Append("RoleId=@RoleId,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where TId=@TId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@TId", SqlDbType.Int,4),
                    new SqlParameter("@TNo", SqlDbType.VarChar,20),
                    new SqlParameter("@TPassword", SqlDbType.VarChar,32),
                    new SqlParameter("@TName", SqlDbType.VarChar,20),
                    new SqlParameter("@TZhiCheng", SqlDbType.VarChar,20),
                    new SqlParameter("@TTeachNum", SqlDbType.Int,4),
                    new SqlParameter("@TSex", SqlDbType.VarChar,2),
                    new SqlParameter("@TPhone", SqlDbType.VarChar,20),
                    new SqlParameter("@TEmail", SqlDbType.VarChar,20),
                    new SqlParameter("@TQQ", SqlDbType.VarChar,20),
                    new SqlParameter("@DepartmentId", SqlDbType.Int,4),
                    new SqlParameter("@MajorId", SqlDbType.Int,4),
                    new SqlParameter("@TTeachCourse", SqlDbType.VarChar,200),
                    new SqlParameter("@TResearchFields", SqlDbType.VarChar,500),
                    new SqlParameter("@TCheckCode", SqlDbType.VarChar,36),
                    new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
            parameters[0].Value = model.TId;
            parameters[1].Value = model.TNo;
            parameters[2].Value = model.TPassword;
            parameters[3].Value = model.TName;
            parameters[4].Value = model.TZhiCheng;
            parameters[5].Value = model.TTeachNum;
            parameters[6].Value = model.TSex;
            parameters[7].Value = model.TPhone;
            parameters[8].Value = model.TEmail;
            parameters[9].Value = model.TQQ;
            parameters[10].Value = model.Department.DId;
            parameters[11].Value = model.Major.MId;
            parameters[12].Value = model.TTeachCourse;
            parameters[13].Value = model.TResearchFields;
            parameters[14].Value = model.TCheckCode;
            parameters[15].Value = model.RoleInfo.RoleId;
            parameters[16].Value = model.IsDel;


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

        /// <summary>
        /// 选择一个学生
        /// </summary>
        public int SelectStudent(ThesisSelected thesisSelect)
        {
            string sql = "update ThesisSelected set TPassed=1 where TId=" + thesisSelect.TId +
                    ";update ThesisTitle set TAcceptNum=TAcceptNum+1 where TId= " + thesisSelect.ThesisTitle.TId +
                    ";update Student set SFlag=1 where SId=" + thesisSelect.Student.SId;
            return DbHelperSQL.ExecuteSqlTran(sql);
        }

        public DataTable GetAll()
        {
            string sql = "select * from Teacher where IsDel=0";
            DataTable dt = DbHelperSQL.GetTable(sql);
            return dt;
        }

        /// <summary>
        /// 退选学生
        /// </summary>
        /// <param name="thesisSelect"></param>
        /// <returns></returns>
        public int DelStudent(ThesisSelected thesisSelect)
        {
            string sql = "update ThesisSelected set TPassed=0 where TId=" + thesisSelect.TId +
                    ";update ThesisTitle set TAcceptNum=TAcceptNum-1 where TId= " + thesisSelect.ThesisTitle.TId +
                    ";update Student set SFlag=0 where SId=" + thesisSelect.Student.SId;
            return DbHelperSQL.ExecuteSqlTran(sql);
        }

        public IList<int> GetTeachStudent(int teacherId, string currYear)
        {
            IList<int> lstStudent = new List<int>();
            string sql = "select distinct StudentId from View_TeacherTeach where TTeacherId=" + teacherId + " and TYear=" + currYear;
            DataTable dt = DbHelperSQL.GetTable(sql);
            foreach (DataRow item in dt.Rows)
            {
                lstStudent.Add(Convert.ToInt32(item["StudentId"]));
            }
            return lstStudent;
        }

        public int UpdateDelByMajorId(string mids)
        {
            return DbHelperSQL.ExcuteNonQuery("update Teacher set IsDel=1 where MajorId in (" + mids + ")");
        }

        public IList<int> GetAllTId()
        {
            string sql = "select TId from Teacher where IsDel=0";
            DataTable dt = DbHelperSQL.GetTable(sql);
            List<int> lstTid = new List<int>();
            foreach (DataRow row in dt.Rows)
            {
                lstTid.Add(Convert.ToInt32(row[0]));
            }
            return lstTid;
        }
    }
}
