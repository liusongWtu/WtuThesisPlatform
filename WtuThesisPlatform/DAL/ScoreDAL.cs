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
    /// Description: DALTier -- the DAL class of Score.
    /// Datetime:2013/4/16 16:11:54
    /// </summary>
    public class ScoreDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Score set IsDel='" + isDel.ToString() + "' where SId in (" + ids + ")");
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
            strSql.Append("delete Score where SId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public Score GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SId,SNo,STearcherScore,SAppraiserScore,SRejoinScore,IsDel from Score ");
            strSql.Append(" where SId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            Score model = new Score();
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

        public Score GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SId,SNo,STearcherScore,SAppraiserScore,SRejoinScore,IsDel from Score ");
            strSql.Append(" where "+strWhere);
            Score model = new Score();
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
        public IList<Score> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SId,SNo,STearcherScore,SAppraiserScore,SRejoinScore,IsDel ");
            strSql.Append(" FROM Score ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<Score> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Score>();
                Score model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Score();
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
        public IList<Score> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<Score> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<Score>();
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
        public IList<Score> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<Score> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("Score", "SId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<Score>();
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
        private void LoadListData(ref IList<Score> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Score model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Score();
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
        private void LoadEntityData(ref Score model, DataRow dr)
        {
                        if (!dr.IsNull("SId")&&dr["SId"].ToString() != "")
            {
                model.SId = int.Parse(dr["SId"].ToString());
            }
            model.SNo = dr["SNo"].ToString();
            if (!dr.IsNull("STearcherScore")&&dr["STearcherScore"].ToString() != "")
            {
                model.STearcherScore = int.Parse(dr["STearcherScore"].ToString());
            }
            if (!dr.IsNull("SAppraiserScore")&&dr["SAppraiserScore"].ToString() != "")
            {
                model.SAppraiserScore = int.Parse(dr["SAppraiserScore"].ToString());
            }
            if (!dr.IsNull("SRejoinScore")&&dr["SRejoinScore"].ToString() != "")
            {
                model.SRejoinScore = int.Parse(dr["SRejoinScore"].ToString());
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
        public int Add(Score model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Score(");
                strSql.Append("SNo,STearcherScore,SAppraiserScore,SRejoinScore,IsDel)");
                strSql.Append(" values (");
                strSql.Append("@SNo,@STearcherScore,@SAppraiserScore,@SRejoinScore,@IsDel)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@SNo", SqlDbType.VarChar,20),
                    new SqlParameter("@STearcherScore", SqlDbType.Int,4),
                    new SqlParameter("@SAppraiserScore", SqlDbType.Int,4),
                    new SqlParameter("@SRejoinScore", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
				                parameters[0].Value = model.SNo;
                parameters[1].Value = model.STearcherScore;
                parameters[2].Value = model.SAppraiserScore;
                parameters[3].Value = model.SRejoinScore;
                parameters[4].Value = model.IsDel;
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
        public int Update(Score model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Score set ");
                        strSql.Append("SNo=@SNo,");
            strSql.Append("STearcherScore=@STearcherScore,");
            strSql.Append("SAppraiserScore=@SAppraiserScore,");
            strSql.Append("SRejoinScore=@SRejoinScore,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where SId=@SId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SId", SqlDbType.Int,4),
                    new SqlParameter("@SNo", SqlDbType.VarChar,20),
                    new SqlParameter("@STearcherScore", SqlDbType.Int,4),
                    new SqlParameter("@SAppraiserScore", SqlDbType.Int,4),
                    new SqlParameter("@SRejoinScore", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			                parameters[0].Value = model.SId;
                parameters[1].Value = model.SNo;
                parameters[2].Value = model.STearcherScore;
                parameters[3].Value = model.SAppraiserScore;
                parameters[4].Value = model.SRejoinScore;
                parameters[5].Value = model.IsDel;

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
