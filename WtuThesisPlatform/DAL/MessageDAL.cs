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
    /// Description: DALTier -- the DAL class of Message.
    /// Datetime:2013/4/22 16:14:14
    /// </summary>
    public class MessageDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Message set IsDel='" + isDel.ToString() + "' where MId in (" + ids + ")");
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
            strSql.Append("delete Message where MId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public Message GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MId,ThesisTitleSelectedId,MContent,MTime,MName,SrcId,MType,IsRead,IsDel from Message ");
            strSql.Append(" where MId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            Message model = new Message();
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

        public Message GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MId,ThesisTitleSelectedId,MContent,MTime,MName,SrcId,MType,IsRead,IsDel from Message ");
            strSql.Append(" where "+strWhere);
            Message model = new Message();
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
        public IList<Message> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MId,ThesisTitleSelectedId,MContent,MTime,MName,SrcId,MType,IsRead,IsDel ");
            strSql.Append(" FROM Message ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<Message> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Message>();
                Message model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Message();
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
        public IList<Message> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<Message> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<Message>();
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
        public IList<Message> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<Message> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("Message", "MId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<Message>();
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
        private void LoadListData(ref IList<Message> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Message model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Message();
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
        private void LoadEntityData(ref Message model, DataRow dr)
        {
                        if (!dr.IsNull("MId")&&dr["MId"].ToString() != "")
            {
                model.MId = int.Parse(dr["MId"].ToString());
            }
            if (!dr.IsNull("ThesisTitleSelectedId")&&dr["ThesisTitleSelectedId"].ToString() != "")
            {
                model.ThesisTitleSelectedId = int.Parse(dr["ThesisTitleSelectedId"].ToString());
            }
            model.MContent = dr["MContent"].ToString();
            if (!dr.IsNull("MTime")&&dr["MTime"].ToString() != "")
            {
                model.MTime = DateTime.Parse(dr["MTime"].ToString());
            }
            model.MName = dr["MName"].ToString();
            if (!dr.IsNull("SrcId")&&dr["SrcId"].ToString() != "")
            {
                model.SrcId = int.Parse(dr["SrcId"].ToString());
            }
            if (!dr.IsNull("MType")&&dr["MType"].ToString() != "")
            {
                model.MType = int.Parse(dr["MType"].ToString());
            }
            if (!dr.IsNull("IsRead")&&dr["IsRead"].ToString() != "")
            {
                model.IsRead = bool.Parse(dr["IsRead"].ToString());
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
        public int Add(Message model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                 if (model.MId == 0)
                {
                    model.MId = DbHelperSQL.GetNextValidID("Message ", "MId");
                }
                
                strSql.Append("insert into Message(");
                strSql.Append("MId,ThesisTitleSelectedId,MContent,MTime,MName,SrcId,MType,IsRead,IsDel)");
                strSql.Append(" values (");
                strSql.Append(" @MId,@ThesisTitleSelectedId,@MContent,@MTime,@MName,@SrcId,@MType,@IsRead,@IsDel)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@MId", SqlDbType.Int,4),
                    new SqlParameter("@ThesisTitleSelectedId", SqlDbType.Int,4),
                    new SqlParameter("@MContent", SqlDbType.VarChar,16),
                    new SqlParameter("@MTime", SqlDbType.DateTime,8),
                    new SqlParameter("@MName", SqlDbType.VarChar,20),
                    new SqlParameter("@SrcId", SqlDbType.Int,4),
                    new SqlParameter("@MType", SqlDbType.Int,2),
                    new SqlParameter("@IsRead", SqlDbType.Bit,1),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};

				parameters[0].Value = model.MId;
                parameters[1].Value = model.ThesisTitleSelectedId;
                parameters[2].Value = model.MContent;
                parameters[3].Value = model.MTime;
                parameters[4].Value = model.MName;
                parameters[5].Value = model.SrcId;
                parameters[6].Value = model.MType;
                parameters[7].Value = model.IsRead;
                parameters[8].Value = model.IsDel;
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
        public int Update(Message model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Message set ");
                        strSql.Append("ThesisTitleSelectedId=@ThesisTitleSelectedId,");
            strSql.Append("MContent=@MContent,");
            strSql.Append("MTime=@MTime,");
            strSql.Append("MName=@MName,");
            strSql.Append("SrcId=@SrcId,");
            strSql.Append("MType=@MType,");
            strSql.Append("IsRead=@IsRead,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where MId=@MId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MId", SqlDbType.Int,4),
                    new SqlParameter("@ThesisTitleSelectedId", SqlDbType.Int,4),
                    new SqlParameter("@MContent", SqlDbType.VarChar,16),
                    new SqlParameter("@MTime", SqlDbType.DateTime,8),
                    new SqlParameter("@MName", SqlDbType.VarChar,20),
                    new SqlParameter("@SrcId", SqlDbType.Int,4),
                    new SqlParameter("@MType", SqlDbType.Int,2),
                    new SqlParameter("@IsRead", SqlDbType.Bit,1),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			                parameters[0].Value = model.MId;
                parameters[1].Value = model.ThesisTitleSelectedId;
                parameters[2].Value = model.MContent;
                parameters[3].Value = model.MTime;
                parameters[4].Value = model.MName;
                parameters[5].Value = model.SrcId;
                parameters[6].Value = model.MType;
                parameters[7].Value = model.IsRead;
                parameters[8].Value = model.IsDel;

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
