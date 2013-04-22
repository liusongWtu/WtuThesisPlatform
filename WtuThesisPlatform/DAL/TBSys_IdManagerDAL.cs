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
    /// Description: DALTier -- the DAL class of TBSys_IdManager.
    /// Datetime:2013/4/21 14:10:19
    /// </summary>
    public class TBSys_IdManagerDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TBSys_IdManager set noDelKey='" + isDel.ToString() + "' where Id in (" + ids + ")");
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
            strSql.Append("delete TBSys_IdManager where Id in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public TBSys_IdManager GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,TableName,FieldName,CurrentValue,Start,Step from TBSys_IdManager ");
            strSql.Append(" where Id=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            TBSys_IdManager model = new TBSys_IdManager();
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

        public TBSys_IdManager GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,TableName,FieldName,CurrentValue,Start,Step from TBSys_IdManager ");
            strSql.Append(" where "+strWhere);
            TBSys_IdManager model = new TBSys_IdManager();
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
        public IList<TBSys_IdManager> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,TableName,FieldName,CurrentValue,Start,Step ");
            strSql.Append(" FROM TBSys_IdManager ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<TBSys_IdManager> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<TBSys_IdManager>();
                TBSys_IdManager model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new TBSys_IdManager();
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
        public IList<TBSys_IdManager> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<TBSys_IdManager> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<TBSys_IdManager>();
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
        public IList<TBSys_IdManager> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<TBSys_IdManager> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("TBSys_IdManager", "Id", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<TBSys_IdManager>();
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
        private void LoadListData(ref IList<TBSys_IdManager> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                TBSys_IdManager model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new TBSys_IdManager();
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
        private void LoadEntityData(ref TBSys_IdManager model, DataRow dr)
        {
                        if (!dr.IsNull("Id")&&dr["Id"].ToString() != "")
            {
                model.Id = int.Parse(dr["Id"].ToString());
            }
            model.TableName = dr["TableName"].ToString();
            model.FieldName = dr["FieldName"].ToString();
            if (!dr.IsNull("CurrentValue")&&dr["CurrentValue"].ToString() != "")
            {
                model.CurrentValue = int.Parse(dr["CurrentValue"].ToString());
            }
            if (!dr.IsNull("Start")&&dr["Start"].ToString() != "")
            {
                model.Start = int.Parse(dr["Start"].ToString());
            }
            if (!dr.IsNull("Step")&&dr["Step"].ToString() != "")
            {
                model.Step = int.Parse(dr["Step"].ToString());
            }

        }
        #endregion
		
        #region Add a record
        /// <summary>
        /// Add a record
        /// </summary>
        public int Add(TBSys_IdManager model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                 if (model.Id == 0)
                {
                    model.Id = DbHelperSQL.GetNextValidID("TBSys_IdManager ", "Id");
                }
                
                strSql.Append("insert into TBSys_IdManager(");
                strSql.Append("Id,TableName,FieldName,CurrentValue,Start,Step)");
                strSql.Append(" values (");
                strSql.Append(" @Id,@TableName,@FieldName,@CurrentValue,@Start,@Step)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@TableName", SqlDbType.VarChar,100),
                    new SqlParameter("@FieldName", SqlDbType.VarChar,100),
                    new SqlParameter("@CurrentValue", SqlDbType.Int,4),
                    new SqlParameter("@Start", SqlDbType.Int,4),
                    new SqlParameter("@Step", SqlDbType.Int,4)};

				parameters[0].Value = model.Id;
                parameters[1].Value = model.TableName;
                parameters[2].Value = model.FieldName;
                parameters[3].Value = model.CurrentValue;
                parameters[4].Value = model.Start;
                parameters[5].Value = model.Step;
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
        public int Update(TBSys_IdManager model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TBSys_IdManager set ");
                        strSql.Append("TableName=@TableName,");
            strSql.Append("FieldName=@FieldName,");
            strSql.Append("CurrentValue=@CurrentValue,");
            strSql.Append("Start=@Start,");
            strSql.Append("Step=@Step");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@TableName", SqlDbType.VarChar,100),
                    new SqlParameter("@FieldName", SqlDbType.VarChar,100),
                    new SqlParameter("@CurrentValue", SqlDbType.Int,4),
                    new SqlParameter("@Start", SqlDbType.Int,4),
                    new SqlParameter("@Step", SqlDbType.Int,4)};
			                parameters[0].Value = model.Id;
                parameters[1].Value = model.TableName;
                parameters[2].Value = model.FieldName;
                parameters[3].Value = model.CurrentValue;
                parameters[4].Value = model.Start;
                parameters[5].Value = model.Step;

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
