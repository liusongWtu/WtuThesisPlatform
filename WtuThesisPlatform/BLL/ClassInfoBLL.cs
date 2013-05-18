using System;
using System.Collections.Generic;
using System.Text;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.DAL;

namespace WtuThesisPlatform.BLL
{
    /// <summary>
    /// Author: LiuSong
    /// Description: BLLTier -- the BLL class of ClassInfo.
    /// Datetime:2013/5/6 21:54:32
    /// </summary>
    public class ClassInfoBLL
    {
        private readonly ClassInfoDAL dal = new ClassInfoDAL();

        #region Get all list
        public IList<ClassInfo> GetAll()
        {
            return dal.GetList("IsDel =0");
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
        public IList<ClassInfo> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
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
        public IList<ClassInfo> GetListByProc(string procName,System.Data.SqlClient.SqlParameter[] paras)
        {
            return dal.GetListByProc(procName,paras);
        }
        #endregion
        
        #region GET A Model byId
        /// <summary>
        /// GET A Model byId
        /// </summary>
        public ClassInfo GetModel(int intId)
        {
            return dal.GetModel(intId);
        }
		#endregion
        
        #region GET DATA LIST
        /// <summary>
        /// GET DATA LIST
        /// </summary>
        public IList<ClassInfo> GetList(string strWhere)
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
        public int Add(ClassInfo model)
        {
            return dal.Add(model);
        }
        #endregion
		
		#region Update
        /// <summary>
        /// Update a data
        /// </summary>
        public int Update(ClassInfo model)
        {
            return dal.Update(model);
		}
        #endregion

        #region Get list by MajorId
        public IList<ClassInfo> GetListByMId(string majorId)
        {
            return dal.GetList("MajorId=" + majorId + " and IsDel=0");
        }
        #endregion

        public object GetModel(string name)
        {
            return dal.GetModelByName(name);
        }

        public string GetCIdsByName(string filter)
        {
            StringBuilder sbCids = new StringBuilder();
            IList<int> lstDids = dal.GetCidsByName(filter);
            if (lstDids != null)
            {
                foreach (int item in lstDids)
                {
                    sbCids.Append(item.ToString() + ",");
                }
                if (sbCids.Length > 1)
                {
                    sbCids.Remove(sbCids.Length - 1, 1);
                }
            }
            return sbCids.ToString();
        }
    }
}
