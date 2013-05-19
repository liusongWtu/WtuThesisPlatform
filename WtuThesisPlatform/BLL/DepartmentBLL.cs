using System;
using System.Collections.Generic;
using System.Text;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.DAL;

namespace WtuThesisPlatform.BLL
{
    /// <summary>
    /// Author: LiuSong
    /// Description: BLLTier -- the BLL class of Department.
    /// Datetime:2013/5/6 21:54:40
    /// </summary>
    public class DepartmentBLL
    {
        private readonly DepartmentDAL dal = new DepartmentDAL();

        #region Get All list
        public IList<Department> GetAll()
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
        public IList<Department> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
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
        public IList<Department> GetListByProc(string procName,System.Data.SqlClient.SqlParameter[] paras)
        {
            return dal.GetListByProc(procName,paras);
        }
        #endregion
        
        #region GET A Model byId
        /// <summary>
        /// GET A Model byId
        /// </summary>
        public Department GetModel(int intId)
        {
            return dal.GetModel(intId);
        }
		#endregion
        
        #region GET DATA LIST
        /// <summary>
        /// GET DATA LIST
        /// </summary>
        public IList<Department> GetList(string strWhere)
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

        public int UpdateDelByDId(string ids)
        {
            MajorDAL majorDal = new MajorDAL();
            majorDal.UpdateDelByDepartmentId(ids);
            return dal.UpdateDel(ids,true);
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
        public int Add(Department model)
        {
            return dal.Add(model);
        }
        #endregion
		
		#region Update
        /// <summary>
        /// Update a data
        /// </summary>
        public int Update(Department model)
        {
            return dal.Update(model);
		}
        #endregion

        public object GetModel(string name)
        {
            return dal.GetModelByDName(name);
        }

        public string GetDidsByName(string filter)
        {
            StringBuilder sbDids = new StringBuilder ();
            IList<int> lstDids = dal.GetDidsByName(filter);
            if (lstDids != null)
            {
                foreach (int item in lstDids)
                {
                    sbDids.Append(item.ToString ()+",");
                }
                if (sbDids.Length > 1)
                {
                    sbDids.Remove(sbDids.Length - 1, 1);
                }
            }
            return sbDids.ToString();
        }

        public int GetDIdByName(string departmentName)
        {
            return dal.GetDidByName(departmentName);
        }

        /// <summary>
        /// 根据院系名获取院系id，若不存在该院系则添加该院系并返回其id
        /// </summary>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public int GetInsertDId(string departmentName)
        {
            int did=GetDIdByName(departmentName);
            if (did <= 0)
            {
                Department department = new Department();
                department.DName = departmentName;
                Add(department);
                return department.DId;
            }
            else
            {
                return did;
            }
        }
    }
}
