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
    /// Description: DALTier -- the DAL class of ClassInfo.
    /// Datetime:2013/5/6 21:54:32
    /// </summary>
    public class ClassInfoDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ClassInfo set IsDel='" + isDel.ToString() + "' where CId in (" + ids + ")");
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
            strSql.Append("delete ClassInfo where CId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public ClassInfo GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CId,CName,MajorId,CNumber,IsDel from ClassInfo ");
            strSql.Append(" where CId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            ClassInfo model = new ClassInfo();
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

        public ClassInfo GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CId,CName,MajorId,CNumber,IsDel from ClassInfo ");
            strSql.Append(" where "+strWhere);
            ClassInfo model = new ClassInfo();
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
        public IList<ClassInfo> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CId,CName,MajorId,CNumber,IsDel ");
            strSql.Append(" FROM ClassInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<ClassInfo> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<ClassInfo>();
                ClassInfo model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new ClassInfo();
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
        public IList<ClassInfo> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<ClassInfo> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<ClassInfo>();
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
        public IList<ClassInfo> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<ClassInfo> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("ClassInfo", "CId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<ClassInfo>();
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
        private void LoadListData(ref IList<ClassInfo> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                ClassInfo model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new ClassInfo();
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
        private void LoadEntityData(ref ClassInfo model, DataRow dr)
        {
                        if (!dr.IsNull("CId")&&dr["CId"].ToString() != "")
            {
                model.CId = int.Parse(dr["CId"].ToString());
            }
            model.CName = dr["CName"].ToString();
            if (!dr.IsNull("MajorId")&&dr["MajorId"].ToString() != "")
            {
                int majorId=int.Parse(dr["MajorId"].ToString());
                model.Major = new MajorDAL().GetModel(majorId);
            }
            if (!dr.IsNull("CNumber")&&dr["CNumber"].ToString() != "")
            {
                model.CNumber = int.Parse(dr["CNumber"].ToString());
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
        public int Add(ClassInfo model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                 if (model.CId == 0)
                {
                    model.CId = DbHelperSQL.GetNextValidID("ClassInfo ", "CId");
                }
                
                strSql.Append("insert into ClassInfo(");
                strSql.Append("CId,CName,MajorId,CNumber,IsDel)");
                strSql.Append(" values (");
                strSql.Append(" @CId,@CName,@MajorId,@CNumber,@IsDel)");
                strSql.Append(";");
                SqlParameter[] parameters = {
                    new SqlParameter("@CId", SqlDbType.Int,4),
                    new SqlParameter("@CName", SqlDbType.VarChar,20),
                    new SqlParameter("@MajorId", SqlDbType.Int,4),
                    new SqlParameter("@CNumber", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};

				parameters[0].Value = model.CId;
                parameters[1].Value = model.CName;
                parameters[2].Value = model.Major.MId;
                parameters[3].Value = model.CNumber;
                parameters[4].Value = model.IsDel;
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
        public int Update(ClassInfo model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ClassInfo set ");
                        strSql.Append("CName=@CName,");
            strSql.Append("MajorId=@MajorId,");
            strSql.Append("CNumber=@CNumber,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where CId=@CId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@CId", SqlDbType.Int,4),
                    new SqlParameter("@CName", SqlDbType.VarChar,20),
                    new SqlParameter("@MajorId", SqlDbType.Int,4),
                    new SqlParameter("@CNumber", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			                parameters[0].Value = model.CId;
                parameters[1].Value = model.CName;
                parameters[2].Value = model.Major.MId;
                parameters[3].Value = model.CNumber;
                parameters[4].Value = model.IsDel;

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

        public int UpdateDelByMajorId(string mids)
        {
            DataTable dt = DbHelperSQL.GetTable("select CId from ClassInfo where MajorId in (" + mids + ")");
            StringBuilder sbCids = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sbCids.Append(dt.Rows[i][0] + ",");
            }
            if (sbCids.Length>0)
            {
                sbCids.Remove(sbCids.Length - 1, 1);
                //修改学生
                StudentDAL studentDAL = new StudentDAL();
                studentDAL.UpdateDelByClassId(sbCids.ToString()); 
            }

            return DbHelperSQL.ExcuteNonQuery("update ClassInfo set IsDel=1 where MajorId in ("+mids+")");
        }
    }
}
