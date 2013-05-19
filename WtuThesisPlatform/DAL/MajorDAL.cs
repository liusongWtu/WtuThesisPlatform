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
    /// Description: DALTier -- the DAL class of Major.
    /// Datetime:2013/5/6 21:54:53
    /// </summary>
    public class MajorDAL
    {
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            //删除学生
            ClassInfoDAL classInfoDal = new ClassInfoDAL();
            classInfoDal.UpdateDelByMajorId(ids);

            //删除教师
            TeacherDAL teacherDal = new TeacherDAL();
            teacherDal.UpdateDelByMajorId(ids);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Major set IsDel='" + isDel.ToString() + "' where MId in (" + ids + ")");
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
            strSql.Append("delete Major where MId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());
        }
        #endregion

        #region GET A ENTITY
        /// <summary>
        /// GET A ENTITY GetAllKeysNameString
        /// </summary>
        public Major GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MId,DId,MName,Mnumber,IsDel from Major ");
            strSql.Append(" where MId=@intId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;
            Major model = new Major();
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

        public Major GetModel(String strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MId,DId,MName,Mnumber,IsDel from Major ");
            strSql.Append(" where " + strWhere);
            Major model = new Major();
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
        public IList<Major> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MId,DId,MName,Mnumber,IsDel ");
            strSql.Append(" FROM Major ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = DbHelperSQL.GetTable(strSql.ToString());
            List<Major> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Major>();
                Major model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Major();
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
        public IList<Major> GetListByProc(string procName, SqlParameter[] paras)
        {
            IList<Major> list = null;
            DataTable dt = DbHelperSQL.ExecProDataTable(procName, paras);
            list = new List<Major>();
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
        public IList<Major> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
        {
            IList<Major> list = null;
            DataTable dt = DbHelperSQL.ExecProPageList("Major", "MId", pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
            list = new List<Major>();
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
        private void LoadListData(ref IList<Major> list, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Major model;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Major();
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
        private void LoadEntityData(ref Major model, DataRow dr)
        {
            if (!dr.IsNull("MId") && dr["MId"].ToString() != "")
            {
                model.MId = int.Parse(dr["MId"].ToString());
            }
            if (!dr.IsNull("DId") && dr["DId"].ToString() != "")
            {
                int departmentId = int.Parse(dr["DId"].ToString());
                model.Department = new DepartmentDAL().GetModel(departmentId);
            }
            model.MName = dr["MName"].ToString();
            if (!dr.IsNull("Mnumber") && dr["Mnumber"].ToString() != "")
            {
                model.Mnumber = int.Parse(dr["Mnumber"].ToString());
            }
            if (!dr.IsNull("IsDel") && dr["IsDel"].ToString() != "")
            {
                model.IsDel = bool.Parse(dr["IsDel"].ToString());
            }

        }
        #endregion

        #region Add a record
        /// <summary>
        /// Add a record
        /// </summary>
        public int Add(Major model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                if (model.MId == 0)
                {
                    model.MId = DbHelperSQL.GetNextValidID("Major ", "MId");
                }

                strSql.Append("insert into Major(");
                strSql.Append("MId,DId,MName,Mnumber,IsDel)");
                strSql.Append(" values (");
                strSql.Append(" @MId,@DId,@MName,@Mnumber,@IsDel)");
                strSql.Append(";");
                SqlParameter[] parameters = {
                    new SqlParameter("@MId", SqlDbType.Int,4),
                    new SqlParameter("@DId", SqlDbType.Int,4),
                    new SqlParameter("@MName", SqlDbType.VarChar,50),
                    new SqlParameter("@Mnumber", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};

                parameters[0].Value = model.MId;
                parameters[1].Value = model.Department.DId;
                parameters[2].Value = model.MName;
                parameters[3].Value = model.Mnumber;
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
        public int Update(Major model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Major set ");
            strSql.Append("DId=@DId,");
            strSql.Append("MName=@MName,");
            strSql.Append("Mnumber=@Mnumber,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where MId=@MId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MId", SqlDbType.Int,4),
                    new SqlParameter("@DId", SqlDbType.Int,4),
                    new SqlParameter("@MName", SqlDbType.VarChar,50),
                    new SqlParameter("@Mnumber", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Bit,1)};
            parameters[0].Value = model.MId;
            parameters[1].Value = model.Department.DId;
            parameters[2].Value = model.MName;
            parameters[3].Value = model.Mnumber;
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

        public int UpdateDelByDepartmentId(string ids)
        {
            DataTable dt = DbHelperSQL.GetTable("select MId from Major where DId in (" + ids + ")");
            StringBuilder sbMids = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sbMids.Append(dt.Rows[i][0] + ",");
            }
            if (sbMids.Length > 0)
            {
                sbMids.Remove(sbMids.Length - 1, 1);
                //删除学生
                ClassInfoDAL classInfoDal = new ClassInfoDAL();
                classInfoDal.UpdateDelByMajorId(sbMids.ToString());

                //删除教师
                TeacherDAL teacherDal = new TeacherDAL();
                teacherDal.UpdateDelByMajorId(sbMids.ToString());
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Major set IsDel=1 where DId in (" + ids + ")");
            return DbHelperSQL.ExcuteNonQuery(strSql.ToString());

        }

        public object GetModelByMName(string name)
        {
            return GetModel(" MName='" + name + "' and IsDel=0");
        }

        public IList<int> GetMidsByName(string filter)
        {
            string sql = "select MId from Major where IsDel=0 and MName like '%" + filter + "%'";
            DataTable dt = DbHelperSQL.GetTable(sql);
            IList<int> mids = new List<int>();
            foreach (DataRow row in dt.Rows)
            {
                mids.Add(Convert.ToInt32(row[0]));
            }
            return mids;
        }

        public int GetDIdByName(string majorName)
        {
            string sql = "select MId from Major where IsDel=0 and MName='"+majorName+"'";
            return DbHelperSQL.ExcuteScalar(sql);
        }
    }
}
