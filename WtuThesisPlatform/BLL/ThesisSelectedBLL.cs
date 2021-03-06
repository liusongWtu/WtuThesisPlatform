﻿using System;
using System.Collections.Generic;
using System.Text;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.DAL;

namespace WtuThesisPlatform.BLL
{
    /// <summary>
    /// Author: LiuSong
    /// Description: BLLTier -- the BLL class of ThesisSelected.
    /// Datetime:2013/5/3 10:04:44
    /// </summary>
    public class ThesisSelectedBLL
    {
        private readonly ThesisSelectedDAL dal = new ThesisSelectedDAL();

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
        public IList<ThesisSelected> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
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
        public IList<ThesisSelected> GetListByProc(string procName, System.Data.SqlClient.SqlParameter[] paras)
        {
            return dal.GetListByProc(procName, paras);
        }
        #endregion

        #region GET A Model byId
        /// <summary>
        /// GET A Model byId
        /// </summary>
        public ThesisSelected GetModel(int intId)
        {
            return dal.GetModel(intId);
        }

        public object GetModel(string thesisId)
        {
            return dal.GetModel(" ThesisTitleId="+thesisId);
        }
        #endregion

        #region GET DATA LIST
        /// <summary>
        /// GET DATA LIST
        /// </summary>
        public IList<ThesisSelected> GetList(string strWhere)
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
        public int Add(ThesisSelected model)
        {
            return dal.Add(model);
        }
        #endregion

        #region Update
        /// <summary>
        /// Update a data
        /// </summary>
        public int Update(ThesisSelected model)
        {
            return dal.Update(model);
        }
        #endregion

        #region Get list by StudentId
        /// <summary>
        /// Get list by StudentId
        /// </summary>
        public IList<ThesisSelected> GetListById(string studentId)
        {
            return dal.GetList("StudentId=" + studentId);
        }
        #endregion

        #region Contains the ThesisSelected
        /// <summary>
        /// Contains the ThesisSelected
        /// </summary>
        public bool Contains(ThesisSelected thesisSelected)
        {
            object obj = dal.GetModel("ThesisTitleId=" + thesisSelected.TId + " and StudentId=" + thesisSelected.Student.SId);
            return obj == null ? false : true;
        } 
        #endregion

        public IList<ThesisSelected> GetListByThesisId(string thesisTitleId,bool passed)
        {
            return dal.GetList(" ThesisTitleId="+thesisTitleId+" and TPassed="+(passed? "1":"0"));
        }


        public int GetSelectNum(int studentId)
        {
            return dal.GetSelectNum(studentId);
        }

      
    }
}
