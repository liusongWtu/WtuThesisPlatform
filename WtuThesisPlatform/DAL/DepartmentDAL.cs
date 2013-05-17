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
    /// Description: DALTier -- the DAL class of Department.
    /// Datetime:2013/5/6 21:54:40
    /// </summary>
    public class DepartmentDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Department set IsDel='" + isDel.ToString() + "' where DId in (" + ids + ")");
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
            strSql.Append("delete Department where DId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion
		
        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public Department GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DId,DName,DTelPhone,DNumber,IsDel from Department ");
            strSql.Append(" where DId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            Department model = new Department();
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

        public Department GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DId,DName,DTelPhone,DNumber,IsDel from Department ");
            strSql.Append(" where "+strWhere);
            Department model = new Department();
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
        public IList<Department> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DId,DName,DTelPhone,DNumber,IsDel ");
            strSql.Append(" FROM Department ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<Department> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Department>();
                Department model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Department();
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
        public IList<Department> GetListByProc(string procName,SqlParameter[] paras)
        {
            IList<Department> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<Department>();
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
        public IList<Department> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<Department> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("Department", "DId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<Department>();
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
        private void LoadListData(ref IList<Department> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Department model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Department();
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
        private void LoadEntityData(ref Department model, DataRow dr)
        {
                        if (!dr.IsNull("DId")&&dr["DId"].ToString() != "")
            {
                model.DId = int.Parse(dr["DId"].ToString());
            }
            model.DName = dr["DName"].ToString();
            model.DTelPhone = dr["DTelPhone"].ToString();
            if (!dr.IsNull("DNumber")&&dr["DNumber"].ToString() != "")
            {
                model.DNumber = int.Parse(dr["DNumber"].ToString());
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
        public int Add(Department model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                 if (model.DId == 0)
                {
                    model.DId = DbHelperSQL.GetNextValidID("Department ", "DId");
                }
                
                strSql.Append("insert into Department(");
                strSql.Append("DId,DName,DTelPhone,DNumber,IsDel)");
                strSql.Append(" values (");
                strSql.Append(" @DId,@DName,@DTelPhone,@DNumber,@IsDel)");
                strSql.Append(";");
                SqlParameter[] parameters = {
                    new SqlParameter("@DId", SqlDbType.Int,4),
                    new SqlParameter("@DName", SqlDbType.VarChar,50),
                    new SqlParameter("@DTelPhone", SqlDbType.VarChar,50),
                    new SqlParameter("@DNumber", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};

				parameters[0].Value = model.DId;
                parameters[1].Value = model.DName;
                parameters[2].Value = model.DTelPhone;
                parameters[3].Value = model.DNumber;
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
        public int Update(Department model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Department set ");
                        strSql.Append("DName=@DName,");
            strSql.Append("DTelPhone=@DTelPhone,");
            strSql.Append("DNumber=@DNumber,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where DId=@DId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@DId", SqlDbType.Int,4),
                    new SqlParameter("@DName", SqlDbType.VarChar,50),
                    new SqlParameter("@DTelPhone", SqlDbType.VarChar,50),
                    new SqlParameter("@DNumber", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			                parameters[0].Value = model.DId;
                parameters[1].Value = model.DName;
                parameters[2].Value = model.DTelPhone;
                parameters[3].Value = model.DNumber;
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

        public object GetModelByDName(string name)
        {
            return GetModel(" DName='"+name+"' and IsDel=0");
        }
    }
}
