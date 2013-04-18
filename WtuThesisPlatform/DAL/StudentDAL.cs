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
    /// Datetime:2013/4/16 16:11:59
    /// </summary>
    public class StudentDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Student set IsDel='" + isDel.ToString() + "' where SNo in (" + ids + ")");
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
            strSql.Append("delete Student where SNo in (" + ids + ")");
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
            strSql.Append("select SNo,SName,DId,MId,SSex,SGrade,SClass,SPhone,SQQ,SEmail,SPassword,SFlag,SYear,SCheckCode,IsDel from Student ");
            strSql.Append(" where SNo=@intId ");
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

        public Student GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SNo,SName,DId,MId,SSex,SGrade,SClass,SPhone,SQQ,SEmail,SPassword,SFlag,SYear,SCheckCode,IsDel from Student ");
            strSql.Append(" where "+strWhere);
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
            strSql.Append("select SNo,SName,DId,MId,SSex,SGrade,SClass,SPhone,SQQ,SEmail,SPassword,SFlag,SYear,SCheckCode,IsDel ");
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
        public IList<Student> GetListByProc(string procName,SqlParameter[] paras)
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
            DataTable dt = DbHelperSQL.ExecProPageList("Student", "SNo", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
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
                        model.SNo = dr["SNo"].ToString();
            model.SName = dr["SName"].ToString();
            if (!dr.IsNull("DId")&&dr["DId"].ToString() != "")
            {
                model.DId = int.Parse(dr["DId"].ToString());
            }
            if (!dr.IsNull("MId")&&dr["MId"].ToString() != "")
            {
                model.MId = int.Parse(dr["MId"].ToString());
            }
            model.SSex = dr["SSex"].ToString();
            model.SGrade = dr["SGrade"].ToString();
            model.SClass = dr["SClass"].ToString();
            model.SPhone = dr["SPhone"].ToString();
            model.SQQ = dr["SQQ"].ToString();
            model.SEmail = dr["SEmail"].ToString();
            model.SPassword = dr["SPassword"].ToString();
            if (!dr.IsNull("SFlag")&&dr["SFlag"].ToString() != "")
            {
                model.SFlag = bool.Parse(dr["SFlag"].ToString());
            }
            model.SYear = dr["SYear"].ToString();
            model.SCheckCode = dr["SCheckCode"].ToString();
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
        public int Add(Student model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Student(");
                strSql.Append("SName,DId,MId,SSex,SGrade,SClass,SPhone,SQQ,SEmail,SPassword,SFlag,SYear,SCheckCode,IsDel)");
                strSql.Append(" values (");
                strSql.Append("@SName,@DId,@MId,@SSex,@SGrade,@SClass,@SPhone,@SQQ,@SEmail,@SPassword,@SFlag,@SYear,@SCheckCode,@IsDel)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@SName", SqlDbType.VarChar,20),
                    new SqlParameter("@DId", SqlDbType.Int,4),
                    new SqlParameter("@MId", SqlDbType.Int,4),
                    new SqlParameter("@SSex", SqlDbType.VarChar,2),
                    new SqlParameter("@SGrade", SqlDbType.VarChar,20),
                    new SqlParameter("@SClass", SqlDbType.VarChar,20),
                    new SqlParameter("@SPhone", SqlDbType.VarChar,15),
                    new SqlParameter("@SQQ", SqlDbType.VarChar,20),
                    new SqlParameter("@SEmail", SqlDbType.VarChar,30),
                    new SqlParameter("@SPassword", SqlDbType.VarChar,20),
                    new SqlParameter("@SFlag", SqlDbType.Bit,1),
                    new SqlParameter("@SYear", SqlDbType.VarChar,4),
                    new SqlParameter("@SCheckCode", SqlDbType.VarChar,8),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
				                parameters[0].Value = model.SName;
                parameters[1].Value = model.DId;
                parameters[2].Value = model.MId;
                parameters[3].Value = model.SSex;
                parameters[4].Value = model.SGrade;
                parameters[5].Value = model.SClass;
                parameters[6].Value = model.SPhone;
                parameters[7].Value = model.SQQ;
                parameters[8].Value = model.SEmail;
                parameters[9].Value = model.SPassword;
                parameters[10].Value = model.SFlag;
                parameters[11].Value = model.SYear;
                parameters[12].Value = model.SCheckCode;
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
        public int Update(Student model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Student set ");
                        strSql.Append("SName=@SName,");
            strSql.Append("DId=@DId,");
            strSql.Append("MId=@MId,");
            strSql.Append("SSex=@SSex,");
            strSql.Append("SGrade=@SGrade,");
            strSql.Append("SClass=@SClass,");
            strSql.Append("SPhone=@SPhone,");
            strSql.Append("SQQ=@SQQ,");
            strSql.Append("SEmail=@SEmail,");
            strSql.Append("SPassword=@SPassword,");
            strSql.Append("SFlag=@SFlag,");
            strSql.Append("SYear=@SYear,");
            strSql.Append("SCheckCode=@SCheckCode,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where SNo=@SNo ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SNo", SqlDbType.VarChar,20),
                    new SqlParameter("@SName", SqlDbType.VarChar,20),
                    new SqlParameter("@DId", SqlDbType.Int,4),
                    new SqlParameter("@MId", SqlDbType.Int,4),
                    new SqlParameter("@SSex", SqlDbType.VarChar,2),
                    new SqlParameter("@SGrade", SqlDbType.VarChar,20),
                    new SqlParameter("@SClass", SqlDbType.VarChar,20),
                    new SqlParameter("@SPhone", SqlDbType.VarChar,15),
                    new SqlParameter("@SQQ", SqlDbType.VarChar,20),
                    new SqlParameter("@SEmail", SqlDbType.VarChar,30),
                    new SqlParameter("@SPassword", SqlDbType.VarChar,20),
                    new SqlParameter("@SFlag", SqlDbType.Bit,1),
                    new SqlParameter("@SYear", SqlDbType.VarChar,4),
                    new SqlParameter("@SCheckCode", SqlDbType.VarChar,8),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			                parameters[0].Value = model.SNo;
                parameters[1].Value = model.SName;
                parameters[2].Value = model.DId;
                parameters[3].Value = model.MId;
                parameters[4].Value = model.SSex;
                parameters[5].Value = model.SGrade;
                parameters[6].Value = model.SClass;
                parameters[7].Value = model.SPhone;
                parameters[8].Value = model.SQQ;
                parameters[9].Value = model.SEmail;
                parameters[10].Value = model.SPassword;
                parameters[11].Value = model.SFlag;
                parameters[12].Value = model.SYear;
                parameters[13].Value = model.SCheckCode;
                parameters[14].Value = model.IsDel;

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
