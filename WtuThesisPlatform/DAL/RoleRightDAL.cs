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
    /// Description: DALTier -- the DAL class of RoleRight.
    /// Datetime:2013/4/21 14:09:57
    /// </summary>
    public class RoleRightDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RoleRight set IsDel='" + isDel.ToString() + "' where RoleRightId in (" + ids + ")");
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
            strSql.Append("delete RoleRight where RoleRightId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public RoleRight GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleRightId,RoleId,NodeId,IsDel from RoleRight ");
            strSql.Append(" where RoleRightId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            RoleRight model = new RoleRight();
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

        public RoleRight GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleRightId,RoleId,NodeId,IsDel from RoleRight ");
            strSql.Append(" where "+strWhere);
            RoleRight model = new RoleRight();
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
        public IList<RoleRight> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleRightId,RoleId,NodeId,IsDel ");
            strSql.Append(" FROM RoleRight ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<RoleRight> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<RoleRight>();
                RoleRight model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new RoleRight();
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
        public IList<RoleRight> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<RoleRight> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<RoleRight>();
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
        public IList<RoleRight> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<RoleRight> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("RoleRight", "RoleRightId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<RoleRight>();
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
        private void LoadListData(ref IList<RoleRight> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                RoleRight model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new RoleRight();
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
        private void LoadEntityData(ref RoleRight model, DataRow dr)
        {
                        if (!dr.IsNull("RoleRightId")&&dr["RoleRightId"].ToString() != "")
            {
                model.RoleRightId = int.Parse(dr["RoleRightId"].ToString());
            }
            if (!dr.IsNull("RoleId")&&dr["RoleId"].ToString() != "")
            {
                model.RoleId = int.Parse(dr["RoleId"].ToString());
            }
            if (!dr.IsNull("NodeId")&&dr["NodeId"].ToString() != "")
            {
                int sysFunId = int.Parse(dr["NodeId"].ToString());
                model.SysFun = new SysFunDAL().GetModel(sysFunId);
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
        public int Add(RoleRight model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                 if (model.RoleRightId == 0)
                {
                    model.RoleRightId = DbHelperSQL.GetNextValidID("RoleRight ", "RoleRightId");
                }
                
                strSql.Append("insert into RoleRight(");
                strSql.Append("RoleRightId,RoleId,NodeId,IsDel)");
                strSql.Append(" values (");
                strSql.Append(" @RoleRightId,@RoleId,@NodeId,@IsDel)");
                strSql.Append(";");
                SqlParameter[] parameters = {
                    new SqlParameter("@RoleRightId", SqlDbType.Int,4),
                    new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@NodeId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};

				parameters[0].Value = model.RoleRightId;
                parameters[1].Value = model.RoleId;
                parameters[2].Value = model.SysFun.NodeId;
                parameters[3].Value = model.IsDel;
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
        public int Update(RoleRight model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RoleRight set ");
                        strSql.Append("RoleId=@RoleId,");
            strSql.Append("NodeId=@NodeId,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where RoleRightId=@RoleRightId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RoleRightId", SqlDbType.Int,4),
                    new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@NodeId", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			                parameters[0].Value = model.RoleRightId;
                parameters[1].Value = model.RoleId;
                parameters[2].Value = model.SysFun.NodeId;
                parameters[3].Value = model.IsDel;

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
