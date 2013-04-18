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
    /// Description: DALTier -- the DAL class of ThesisSelected.
    /// Datetime:2013/4/16 16:12:19
    /// </summary>
    public class ThesisSelectedDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ThesisSelected set IsDel='" + isDel.ToString() + "' where TId in (" + ids + ")");
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
            strSql.Append("delete ThesisSelected where TId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public ThesisSelected GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TId,ThesisTitleId,TearchId,StudentId,TPassed,TYear,MessageId,IsDel from ThesisSelected ");
            strSql.Append(" where TId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            ThesisSelected model = new ThesisSelected();
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

        public ThesisSelected GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TId,ThesisTitleId,TearchId,StudentId,TPassed,TYear,MessageId,IsDel from ThesisSelected ");
            strSql.Append(" where "+strWhere);
            ThesisSelected model = new ThesisSelected();
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
        public IList<ThesisSelected> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TId,ThesisTitleId,TearchId,StudentId,TPassed,TYear,MessageId,IsDel ");
            strSql.Append(" FROM ThesisSelected ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<ThesisSelected> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<ThesisSelected>();
                ThesisSelected model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new ThesisSelected();
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
        public IList<ThesisSelected> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<ThesisSelected> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<ThesisSelected>();
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
        public IList<ThesisSelected> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<ThesisSelected> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("ThesisSelected", "TId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<ThesisSelected>();
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
        private void LoadListData(ref IList<ThesisSelected> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                ThesisSelected model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new ThesisSelected();
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
        private void LoadEntityData(ref ThesisSelected model, DataRow dr)
        {
                        if (!dr.IsNull("TId")&&dr["TId"].ToString() != "")
            {
                model.TId = int.Parse(dr["TId"].ToString());
            }
            if (!dr.IsNull("ThesisTitleId")&&dr["ThesisTitleId"].ToString() != "")
            {
                model.ThesisTitleId = int.Parse(dr["ThesisTitleId"].ToString());
            }
            if (!dr.IsNull("TearchId")&&dr["TearchId"].ToString() != "")
            {
                model.TearchId = int.Parse(dr["TearchId"].ToString());
            }
            model.StudentId = dr["StudentId"].ToString();
            if (!dr.IsNull("TPassed")&&dr["TPassed"].ToString() != "")
            {
                model.TPassed = bool.Parse(dr["TPassed"].ToString());
            }
            model.TYear = dr["TYear"].ToString();
            if (!dr.IsNull("MessageId")&&dr["MessageId"].ToString() != "")
            {
                model.MessageId = int.Parse(dr["MessageId"].ToString());
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
        public int Add(ThesisSelected model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into ThesisSelected(");
                strSql.Append("ThesisTitleId,TearchId,StudentId,TPassed,TYear,MessageId,IsDel)");
                strSql.Append(" values (");
                strSql.Append("@ThesisTitleId,@TearchId,@StudentId,@TPassed,@TYear,@MessageId,@IsDel)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@ThesisTitleId", SqlDbType.Int,4),
                    new SqlParameter("@TearchId", SqlDbType.Int,4),
                    new SqlParameter("@StudentId", SqlDbType.VarChar,20),
                    new SqlParameter("@TPassed", SqlDbType.Bit,1),
                    new SqlParameter("@TYear", SqlDbType.VarChar,4),
                    new SqlParameter("@MessageId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
				                parameters[0].Value = model.ThesisTitleId;
                parameters[1].Value = model.TearchId;
                parameters[2].Value = model.StudentId;
                parameters[3].Value = model.TPassed;
                parameters[4].Value = model.TYear;
                parameters[5].Value = model.MessageId;
                parameters[6].Value = model.IsDel;
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
        public int Update(ThesisSelected model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ThesisSelected set ");
                        strSql.Append("ThesisTitleId=@ThesisTitleId,");
            strSql.Append("TearchId=@TearchId,");
            strSql.Append("StudentId=@StudentId,");
            strSql.Append("TPassed=@TPassed,");
            strSql.Append("TYear=@TYear,");
            strSql.Append("MessageId=@MessageId,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where TId=@TId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@TId", SqlDbType.Int,4),
                    new SqlParameter("@ThesisTitleId", SqlDbType.Int,4),
                    new SqlParameter("@TearchId", SqlDbType.Int,4),
                    new SqlParameter("@StudentId", SqlDbType.VarChar,20),
                    new SqlParameter("@TPassed", SqlDbType.Bit,1),
                    new SqlParameter("@TYear", SqlDbType.VarChar,4),
                    new SqlParameter("@MessageId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			                parameters[0].Value = model.TId;
                parameters[1].Value = model.ThesisTitleId;
                parameters[2].Value = model.TearchId;
                parameters[3].Value = model.StudentId;
                parameters[4].Value = model.TPassed;
                parameters[5].Value = model.TYear;
                parameters[6].Value = model.MessageId;
                parameters[7].Value = model.IsDel;

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
