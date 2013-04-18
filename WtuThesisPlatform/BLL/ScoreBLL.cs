using System;
using System.Collections.Generic;
using System.Text;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.DAL;

namespace WtuThesisPlatform.BLL
{
    /// <summary>
    /// Author: LiuSong
    /// Description: BLLTier -- the BLL class of Score.
    /// Datetime:2013/4/16 15:30:01
    /// </summary>
    public class ScoreBLL
    {
        private readonly ScoreDAL dal = new ScoreDAL();
        
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
            return dal.GetList(pageIndex, pageSize, where, orderby, out rowCount, out pageCount);
        }
        #endregion
        #region GetListByProc
        /// <summary>
        /// GetListByProc
        /// </summary>
        /// <param name="procName">procName</param>
        /// <param name="paras">paras</param>
        public IList<Score> GetListByProc(string procName,System.Data.SqlClient.SqlParameter[] paras)
        {
            return dal.GetListByProc(procName,paras);
        }
        #endregion
        #region GET A Model byId
        /// <summary>
        /// GET A Model byId
        /// </summary>
        public Score GetModel(int intId)
        {
            return dal.GetModel(intId);
        }
		#endregion
        #region GET DATA LIST
        /// <summary>
        /// GET DATA LIST
        /// </summary>
        public IList<Score> GetList(string strWhere)
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
        public int Add(Score model)
        {
            return dal.Add(model);
        }
        #endregion
		
		#region Update
        /// <summary>
        /// Update a data
        /// </summary>
        public int Update(Score model)
        {
            return dal.Update(model);
		}
        #endregion
    }
}
