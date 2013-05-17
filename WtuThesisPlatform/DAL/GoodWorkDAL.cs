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
    /// Description: DALTier -- the DAL class of GoodWork.
    /// Datetime:2013/5/16 23:53:43
    /// </summary>
    public class GoodWorkDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GoodWork set noDelKey='" + isDel.ToString() + "' where GId in (" + ids + ")");
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
            strSql.Append("delete GoodWork where GId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public GoodWork GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GId,GTitle,GStudentId,GTime,GContent,GCoverPic from GoodWork ");
            strSql.Append(" where GId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            GoodWork model = new GoodWork();
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

        public GoodWork GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GId,GTitle,GStudentId,GTime,GContent,GCoverPic from GoodWork ");
            strSql.Append(" where "+strWhere);
            GoodWork model = new GoodWork();
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
        public IList<GoodWork> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GId,GTitle,GStudentId,GTime,GContent,GCoverPic ");
            strSql.Append(" FROM GoodWork ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<GoodWork> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<GoodWork>();
                GoodWork model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new GoodWork();
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
        public IList<GoodWork> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<GoodWork> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<GoodWork>();
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
        public IList<GoodWork> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<GoodWork> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("GoodWork", "GId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<GoodWork>();
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
        private void LoadListData(ref IList<GoodWork> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                GoodWork model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new GoodWork();
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
        private void LoadEntityData(ref GoodWork model, DataRow dr)
        {
                        if (!dr.IsNull("GId")&&dr["GId"].ToString() != "")
            {
                model.GId = int.Parse(dr["GId"].ToString());
            }
            model.GTitle = dr["GTitle"].ToString();
            if (!dr.IsNull("GStudentId")&&dr["GStudentId"].ToString() != "")
            {
                model.GStudentId = int.Parse(dr["GStudentId"].ToString());
            }
            if (!dr.IsNull("GTime")&&dr["GTime"].ToString() != "")
            {
                model.GTime = DateTime.Parse(dr["GTime"].ToString());
            }
            model.GContent = dr["GContent"].ToString();
            model.GCoverPic = dr["GCoverPic"].ToString();

        }
        #endregion
		
        #region Add a record
        /// <summary>
        /// Add a record
        /// </summary>
        public int Add(GoodWork model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                 if (model.GId == 0)
                {
                    model.GId = DbHelperSQL.GetNextValidID("GoodWork ", "GId");
                }
                
                strSql.Append("insert into GoodWork(");
                strSql.Append("GId,GTitle,GStudentId,GTime,GContent,GCoverPic)");
                strSql.Append(" values (");
                strSql.Append(" @GId,@GTitle,@GStudentId,@GTime,@GContent,@GCoverPic)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@GId", SqlDbType.Int,4),
                    new SqlParameter("@GTitle", SqlDbType.VarChar,200),
                    new SqlParameter("@GStudentId", SqlDbType.Int,4),
                    new SqlParameter("@GTime", SqlDbType.DateTime,3),
                    new SqlParameter("@GContent", SqlDbType.Text),
                    new SqlParameter("@GCoverPic", SqlDbType.VarChar,200)};

				parameters[0].Value = model.GId;
                parameters[1].Value = model.GTitle;
                parameters[2].Value = model.GStudentId;
                parameters[3].Value = model.GTime;
                parameters[4].Value = model.GContent;
                parameters[5].Value = model.GCoverPic;
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
        public int Update(GoodWork model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GoodWork set ");
                        strSql.Append("GTitle=@GTitle,");
            strSql.Append("GStudentId=@GStudentId,");
            strSql.Append("GTime=@GTime,");
            strSql.Append("GContent=@GContent,");
            strSql.Append("GCoverPic=@GCoverPic");
            strSql.Append(" where GId=@GId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@GId", SqlDbType.Int,4),
                    new SqlParameter("@GTitle", SqlDbType.VarChar,200),
                    new SqlParameter("@GStudentId", SqlDbType.Int,4),
                    new SqlParameter("@GTime", SqlDbType.DateTime,3),
                    new SqlParameter("@GContent", SqlDbType.VarChar,16),
                    new SqlParameter("@GCoverPic", SqlDbType.VarChar,200)};
			                parameters[0].Value = model.GId;
                parameters[1].Value = model.GTitle;
                parameters[2].Value = model.GStudentId;
                parameters[3].Value = model.GTime;
                parameters[4].Value = model.GContent;
                parameters[5].Value = model.GCoverPic;

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
