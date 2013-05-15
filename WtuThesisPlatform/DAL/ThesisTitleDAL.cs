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
    /// Description: DALTier -- the DAL class of ThesisTitle.
    /// Datetime:2013/5/3 17:24:34
    /// </summary>
    public class ThesisTitleDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ThesisTitle set IsDel='" + isDel.ToString() + "' where TId in (" + ids + ")");
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
            strSql.Append("delete ThesisTitle where TId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public ThesisTitle GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TId,TTeacherId,TName,TLevel,TNumber,TPlatform,TIntroduct,TRequire,TSelectedNum,TAcceptNum,TState,TYear,TDepartmentId,IsDel from ThesisTitle ");
            strSql.Append(" where TId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            ThesisTitle model = new ThesisTitle();
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

        public ThesisTitle GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TId,TTeacherId,TName,TLevel,TNumber,TPlatform,TIntroduct,TRequire,TSelectedNum,TAcceptNum,TState,TYear,TDepartmentId,IsDel from ThesisTitle ");
            strSql.Append(" where "+strWhere);
            ThesisTitle model = new ThesisTitle();
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
        public IList<ThesisTitle> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TId,TTeacherId,TName,TLevel,TNumber,TPlatform,TIntroduct,TRequire,TSelectedNum,TAcceptNum,TState,TYear,TDepartmentId,IsDel ");
            strSql.Append(" FROM ThesisTitle ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<ThesisTitle> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<ThesisTitle>();
                ThesisTitle model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new ThesisTitle();
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
        public IList<ThesisTitle> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<ThesisTitle> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<ThesisTitle>();
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
        public IList<ThesisTitle> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<ThesisTitle> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("ThesisTitle", "TId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<ThesisTitle>();
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
        private void LoadListData(ref IList<ThesisTitle> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                ThesisTitle model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new ThesisTitle();
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
        private void LoadEntityData(ref ThesisTitle model, DataRow dr)
        {
                        if (!dr.IsNull("TId")&&dr["TId"].ToString() != "")
            {
                model.TId = int.Parse(dr["TId"].ToString());
            }
            if (!dr.IsNull("TTeacherId")&&dr["TTeacherId"].ToString() != "")
            {
                int teacherId=int.Parse(dr["TTeacherId"].ToString());
                model.Teacher = new TeacherDAL().GetModel(teacherId);
            }
            model.TName = dr["TName"].ToString();
            model.TLevel = dr["TLevel"].ToString();
            if (!dr.IsNull("TNumber")&&dr["TNumber"].ToString() != "")
            {
                model.TNumber = int.Parse(dr["TNumber"].ToString());
            }
            model.TPlatform = dr["TPlatform"].ToString();
            model.TIntroduct = dr["TIntroduct"].ToString();
            model.TRequire = dr["TRequire"].ToString();
            if (!dr.IsNull("TSelectedNum")&&dr["TSelectedNum"].ToString() != "")
            {
                model.TSelectedNum = int.Parse(dr["TSelectedNum"].ToString());
            }
            if (!dr.IsNull("TAcceptNum")&&dr["TAcceptNum"].ToString() != "")
            {
                model.TAcceptNum = int.Parse(dr["TAcceptNum"].ToString());
            }
            if (!dr.IsNull("TState")&&dr["TState"].ToString() != "")
            {
                model.TState = int.Parse(dr["TState"].ToString());
            }
            model.TYear = dr["TYear"].ToString();
            if (!dr.IsNull("TDepartmentId")&&dr["TDepartmentId"].ToString() != "")
            {
                model.TDepartmentId = int.Parse(dr["TDepartmentId"].ToString());
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
        public int Add(ThesisTitle model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                 if (model.TId == 0)
                {
                    model.TId = DbHelperSQL.GetNextValidID("ThesisTitle ", "TId");
                }
                
                strSql.Append("insert into ThesisTitle(");
                strSql.Append("TId,TTeacherId,TName,TLevel,TNumber,TPlatform,TIntroduct,TRequire,TSelectedNum,TAcceptNum,TState,TYear,TDepartmentId,IsDel)");
                strSql.Append(" values (");
                strSql.Append(" @TId,@TTeacherId,@TName,@TLevel,@TNumber,@TPlatform,@TIntroduct,@TRequire,@TSelectedNum,@TAcceptNum,@TState,@TYear,@TDepartmentId,@IsDel)");
                strSql.Append(";");
                SqlParameter[] parameters = {
                    new SqlParameter("@TId", SqlDbType.Int,4),
                    new SqlParameter("@TTeacherId", SqlDbType.Int,4),
                    new SqlParameter("@TName", SqlDbType.VarChar,80),
                    new SqlParameter("@TLevel", SqlDbType.VarChar,20),
                    new SqlParameter("@TNumber", SqlDbType.Int,4),
                    new SqlParameter("@TPlatform", SqlDbType.VarChar,200),
                    new SqlParameter("@TIntroduct", SqlDbType.VarChar,1000),
                    new SqlParameter("@TRequire", SqlDbType.VarChar,1000),
                    new SqlParameter("@TSelectedNum", SqlDbType.Int,4),
                    new SqlParameter("@TAcceptNum", SqlDbType.Int,4),
                    new SqlParameter("@TState", SqlDbType.Int,4),
                    new SqlParameter("@TYear", SqlDbType.VarChar,4),
                    new SqlParameter("@TDepartmentId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};

				parameters[0].Value = model.TId;
                parameters[1].Value = model.Teacher.TId;
                parameters[2].Value = model.TName;
                parameters[3].Value = model.TLevel;
                parameters[4].Value = model.TNumber;
                parameters[5].Value = model.TPlatform;
                parameters[6].Value = model.TIntroduct;
                parameters[7].Value = model.TRequire;
                parameters[8].Value = model.TSelectedNum;
                parameters[9].Value = model.TAcceptNum;
                parameters[10].Value = model.TState;
                parameters[11].Value = model.TYear;
                parameters[12].Value = model.TDepartmentId;
                parameters[13].Value = model.IsDel;
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
        public int Update(ThesisTitle model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ThesisTitle set ");
                        strSql.Append("TTeacherId=@TTeacherId,");
            strSql.Append("TName=@TName,");
            strSql.Append("TLevel=@TLevel,");
            strSql.Append("TNumber=@TNumber,");
            strSql.Append("TPlatform=@TPlatform,");
            strSql.Append("TIntroduct=@TIntroduct,");
            strSql.Append("TRequire=@TRequire,");
            strSql.Append("TSelectedNum=@TSelectedNum,");
            strSql.Append("TAcceptNum=@TAcceptNum,");
            strSql.Append("TState=@TState,");
            strSql.Append("TYear=@TYear,");
            strSql.Append("TDepartmentId=@TDepartmentId,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where TId=@TId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@TId", SqlDbType.Int,4),
                    new SqlParameter("@TTeacherId", SqlDbType.Int,4),
                    new SqlParameter("@TName", SqlDbType.VarChar,80),
                    new SqlParameter("@TLevel", SqlDbType.VarChar,20),
                    new SqlParameter("@TNumber", SqlDbType.Int,4),
                    new SqlParameter("@TPlatform", SqlDbType.VarChar,200),
                    new SqlParameter("@TIntroduct", SqlDbType.VarChar,1000),
                    new SqlParameter("@TRequire", SqlDbType.VarChar,1000),
                    new SqlParameter("@TSelectedNum", SqlDbType.Int,4),
                    new SqlParameter("@TAcceptNum", SqlDbType.Int,4),
                    new SqlParameter("@TState", SqlDbType.Int,4),
                    new SqlParameter("@TYear", SqlDbType.VarChar,4),
                    new SqlParameter("@TDepartmentId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			                parameters[0].Value = model.TId;
                parameters[1].Value = model.Teacher.TId;
                parameters[2].Value = model.TName;
                parameters[3].Value = model.TLevel;
                parameters[4].Value = model.TNumber;
                parameters[5].Value = model.TPlatform;
                parameters[6].Value = model.TIntroduct;
                parameters[7].Value = model.TRequire;
                parameters[8].Value = model.TSelectedNum;
                parameters[9].Value = model.TAcceptNum;
                parameters[10].Value = model.TState;
                parameters[11].Value = model.TYear;
                parameters[12].Value = model.TDepartmentId;
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
