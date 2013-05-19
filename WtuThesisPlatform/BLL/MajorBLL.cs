using System;
using System.Collections.Generic;
using System.Text;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.DAL;

namespace WtuThesisPlatform.BLL
{
    /// <summary>
    /// Author: LiuSong
    /// Description: BLLTier -- the BLL class of Major.
    /// Datetime:2013/5/6 21:54:53
    /// </summary>
    public class MajorBLL
    {
        private readonly MajorDAL dal = new MajorDAL();
        
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
            return dal.GetList(pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
        }
        #endregion
        
        #region GetListByProc
        /// <summary>
        /// GetListByProc
        /// </summary>
        /// <param name="procName">procName</param>
        /// <param name="paras">paras</param>
        public IList<Major> GetListByProc(string procName,System.Data.SqlClient.SqlParameter[] paras)
        {
            return dal.GetListByProc(procName,paras);
        }
        #endregion
        
        #region GET A Model byId
        /// <summary>
        /// GET A Model byId
        /// </summary>
        public Major GetModel(int intId)
        {
            return dal.GetModel(intId);
        }
		#endregion
        
        #region GET DATA LIST
        /// <summary>
        /// GET DATA LIST
        /// </summary>
        public IList<Major> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        #endregion
		
        #region RESTORE
        /// <summary>
        /// RESTORE
        /// </summary>
        public int UpdateRe(string ids)
        {
            return dal.UpdateDel(ids, false);
        }
        #endregion
		
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids)
        {
            return dal.UpdateDel(ids, true);
        }

        public int UpdateDelByDepartmentId(string ids)
        {
            return dal.UpdateDelByDepartmentId(ids);
        }
        #endregion
		
        #region DELETE SOFTLY
        /// <summary>
        /// DELETE SOFTLY
        /// </summary>
        public int UpdateDel(string ids, bool isDel)
        {
            return dal.UpdateDel(ids, isDel);
        }
        #endregion
		
        #region DELETE PHYSICAL
        /// <summary>
        /// DELETE PHYSICAL
        /// </summary>
        public int Del(string ids)
        {
            return dal.Del(ids);
        }
        #endregion
		
        #region ADD A RECORD
        /// <summary>
        /// ADD A RECORD
        /// </summary>
        public int Add(Major model)
        {
            return dal.Add(model);
        }
        #endregion
		
		#region Update
        /// <summary>
        /// Update a data
        /// </summary>
        public int Update(Major model)
        {
            return dal.Update(model);
		}
        #endregion

        #region Get list by departmentId
        public IList<Major> GetListByDId(string departmentId)
        {
            return dal.GetList("DId=" + departmentId + " and IsDel=0");
        }
        #endregion

        #region Get all list
        public IList<Major> GetAll()
        {
            return dal.GetList("IsDel =0");
        }
        #endregion

        public object GetModel(string name)
        {
            return dal.GetModelByMName(name);
        }

        public string GetMIdsByName(string filter)
        {
            StringBuilder sbMids = new StringBuilder();
            IList<int> lstDids = dal.GetMidsByName(filter);
            if (lstDids != null)
            {
                foreach (int item in lstDids)
                {
                    sbMids.Append(item.ToString() + ",");
                }
                if (sbMids.Length > 1)
                {
                    sbMids.Remove(sbMids.Length - 1, 1);
                }
            }
            return sbMids.ToString();
        }

        public int GetMIdByName(string majorName)
        {
            return dal.GetDIdByName(majorName);
        }

        public int GetInsertMId(string majorName,int did)
        {
            int mid = GetMIdByName(majorName);
            if (mid <= 0)
            {
                Major major = new Major();
                major.MName = majorName;
                major.Department = new Department();
                major.Department.DId = did;
                Add(major);
                return major.MId;
            }
            else
            {
                return mid;
            }
        }
    }
}
