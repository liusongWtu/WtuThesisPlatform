﻿using System;
using System.Collections.Generic;
using System.Text;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.DAL;

namespace WtuThesisPlatform.BLL
{
    /// <summary>
    /// Author: LiuSong
    /// Description: BLLTier -- the BLL class of ThesisTitle.
    /// Datetime:2013/5/3 17:24:34
    /// </summary>
    public class ThesisTitleBLL
    {
        private readonly ThesisTitleDAL dal = new ThesisTitleDAL();

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
        public IList<ThesisTitle> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
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
        public IList<ThesisTitle> GetListByProc(string procName, System.Data.SqlClient.SqlParameter[] paras)
        {
            return dal.GetListByProc(procName, paras);
        }
        #endregion

        #region GET A Model byId
        /// <summary>
        /// GET A Model byId
        /// </summary>
        public ThesisTitle GetModel(int intId)
        {
            return dal.GetModel(intId);
        }

        public object GetModel(int teacherId, string title,string year)
        {
            return dal.GetModel(" TTeacherId="+teacherId+" and TName='"+title+"' and TYear='"+year+"'");
        }
        #endregion

        #region GET DATA LIST
        /// <summary>
        /// GET DATA LIST
        /// </summary>
        public IList<ThesisTitle> GetList(string strWhere)
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
        public int Add(ThesisTitle model)
        {
            return dal.Add(model);
        }
        #endregion

        #region Update
        /// <summary>
        /// Update a data
        /// </summary>
        public int Update(ThesisTitle model)
        {
            return dal.Update(model);
        }
        #endregion

        #region Get list by teacherId
        /// <summary>
        /// Get list by teacherId
        /// </summary>
        public IList<ThesisTitle> GetListByTId(string teacherId)
        {
            return dal.GetList("TTeacherId=" + teacherId + " and IsDel=0 order by TYear");
        }

        public IList<ThesisTitle> GetListByTId(string teacherId,string year)
        {
            return dal.GetList("TTeacherId=" + teacherId + " and IsDel=1 and TState=1 and TYear='"+year+"'");
        }
        /// <summary>
        /// 获取所有教师选题
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public IList<ThesisTitle> GetListByTId(string teacherId,string year,bool pass)
        {
            return dal.GetList("TTeacherId=" + teacherId+(year==""? "":" and TYear="+year)+" and TState"+(pass? "=1":"!=1"));
        }

        public IList<ThesisTitle> GetAllListByTid(string teacherId)
        {
            return dal.GetList("TTeacherId="+teacherId+" order by TYear desc,TState");
        }
        #endregion

        
    }
}
