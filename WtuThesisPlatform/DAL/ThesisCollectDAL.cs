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
    /// Description: DALTier -- the DAL class of ThesisCollect.
    /// Datetime:2013/5/2 22:39:41
    /// </summary>
    public class ThesisCollectDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ThesisCollect set noDelKey='" + isDel.ToString() + "' where CId in (" + ids + ")");
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
            strSql.Append("delete ThesisCollect where CId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public ThesisCollect GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CId,StudentId,ThesisTitleId from ThesisCollect ");
            strSql.Append(" where CId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            ThesisCollect model = new ThesisCollect();
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

        public ThesisCollect GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CId,StudentId,ThesisTitleId from ThesisCollect ");
            strSql.Append(" where "+strWhere);
            ThesisCollect model = new ThesisCollect();
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
        public IList<ThesisCollect> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CId,StudentId,ThesisTitleId ");
            strSql.Append(" FROM ThesisCollect ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<ThesisCollect> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<ThesisCollect>();
                ThesisCollect model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new ThesisCollect();
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
        public IList<ThesisCollect> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<ThesisCollect> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<ThesisCollect>();
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
        public IList<ThesisCollect> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<ThesisCollect> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("ThesisCollect", "CId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<ThesisCollect>();
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
        private void LoadListData(ref IList<ThesisCollect> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                ThesisCollect model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new ThesisCollect();
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
        private void LoadEntityData(ref ThesisCollect model, DataRow dr)
        {
            if (!dr.IsNull("CId")&&dr["CId"].ToString() != "")
            {
                model.CId = int.Parse(dr["CId"].ToString());
            }
            if (!dr.IsNull("StudentId")&&dr["StudentId"].ToString() != "")
            {
                int studentId=int.Parse(dr["StudentId"].ToString());
                model.Student = new StudentDAL().GetModel(studentId);
            }
            if (!dr.IsNull("ThesisTitleId")&&dr["ThesisTitleId"].ToString() != "")
            {
                int thesisTitleId=int.Parse(dr["ThesisTitleId"].ToString());
                model.ThesisTitle = new ThesisTitleDAL().GetModel(thesisTitleId);
            }

        }
        #endregion
		
        #region Add a record
        /// <summary>
        /// Add a record
        /// </summary>
        public int Add(ThesisCollect model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                 if (model.CId == 0)
                {
                    model.CId = DbHelperSQL.GetNextValidID("ThesisCollect ", "CId");
                }
                
                strSql.Append("insert into ThesisCollect(");
                strSql.Append("CId,StudentId,ThesisTitleId)");
                strSql.Append(" values (");
                strSql.Append(" @CId,@StudentId,@ThesisTitleId)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@CId", SqlDbType.Int,4),
                    new SqlParameter("@StudentId", SqlDbType.Int,4),
                    new SqlParameter("@ThesisTitleId", SqlDbType.Int,4)};

				parameters[0].Value = model.CId;
                parameters[1].Value = model.Student.SId;
                parameters[2].Value = model.ThesisTitle.TId;
                result = DbHelperSQL.ExcuteScalar(strSql.ToString(), parameters);

                //更新选题中选择人数信息
                string sql = "update ThesisTitle set TSelectedNum=TSelectedNum+1 where TId= "+model.ThesisTitle.TId;
                DbHelperSQL.ExcuteScalar(sql);
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
        public int Update(ThesisCollect model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ThesisCollect set ");
                        strSql.Append("StudentId=@StudentId,");
            strSql.Append("ThesisTitleId=@ThesisTitleId");
            strSql.Append(" where CId=@CId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@CId", SqlDbType.Int,4),
                    new SqlParameter("@StudentId", SqlDbType.Int,4),
                    new SqlParameter("@ThesisTitleId", SqlDbType.Int,4)};
			                parameters[0].Value = model.CId;
                parameters[1].Value = model.Student.SId;
                parameters[2].Value = model.ThesisTitle.TId;

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
