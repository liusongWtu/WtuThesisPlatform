﻿using System;
using System.Collections.Generic;
using System.Text;
using WtuThesisPlatform.MODEL;
using WtuThesisPlatform.DAL;

namespace WtuThesisPlatform.BLL
{
    /// <summary>
    /// Author: LiuSong
    /// Description: BLLTier -- the BLL class of Notice.
    /// Datetime:2013/5/7 10:54:19
    /// </summary>
    public class NoticeBLL
    {
        private readonly NoticeDAL dal = new NoticeDAL();
        
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
        public IList<Notice> GetList(int pageIndex, int pageSize, string where, string orderby, out int rowCount, out int pageCount)
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
        public IList<Notice> GetListByProc(string procName,System.Data.SqlClient.SqlParameter[] paras)
        {
            return dal.GetListByProc(procName,paras);
        }
        #endregion
        
        #region GET A Model byId
        /// <summary>
        /// GET A Model byId
        /// </summary>
        public Notice GetModel(int intId)
        {
            return dal.GetModel(intId);
        }
		#endregion
        
        #region GET DATA LIST
        /// <summary>
        /// GET DATA LIST
        /// </summary>
        public IList<Notice> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 根据教师id获取教师对应的公告
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public IList<Notice> GetListByTId(int teacherId)
        {
            IList<Notice> lstNotice= dal.GetList(" NLevel=1 or (NLevel=2 and NPublisherId="+teacherId+" )");
            IList<NewNotice> lstNewNotice = new NewNoticeBLL().GetList(" NUserType=2 and NUserId="+teacherId);
            if (lstNotice == null)
            {
                return null;
            }
            if (lstNewNotice == null)
            {
                lstNewNotice = new List<NewNotice>();
            }
            foreach (Notice noctice in lstNotice)
            {
                foreach (NewNotice item in lstNewNotice)
                {
                    if (item.NoticeId == noctice.NId)
                    {
                        noctice.IsNew = true;
                        break;
                    }
                }
            }

            return lstNotice;
        }

        /// <summary>
        /// 根据学生id获取学生对应的公告
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public IList<Notice> GetListBySId(Student student)
        {
            string sql = string.Empty ;
            if (student.SFlag)//若学生已通过选题，则只能看到自己导师的公告及学校公告
            {
                sql = " StudentId="+student.SId+" and TPassed=1";
            }
            else//否则查看志愿中所有导师公告及学校公告
            {
                sql = " StudentId="+student.SId;
            }
            IList<ThesisSelected> lstThesisSelected = new ThesisSelectedBLL().GetList(sql);
            List<int> lstTid = new List<int>();
            foreach (ThesisSelected item in lstThesisSelected)
            {
                if (!lstTid.Contains(item.ThesisTitle.Teacher.TId))
                {
                    lstTid.Add(item.ThesisTitle.Teacher.TId);
                }
            }

            StringBuilder sbFilter = new StringBuilder();
            sbFilter.Append(" (");
            foreach (int item in lstTid)
            {
                sbFilter.Append(item.ToString ()+",");
            }
            sbFilter.Remove(sbFilter.Length -1,1);
            sbFilter.Append(")");
            IList<Notice> lstNotice = dal.GetList(" NLevel=1 or (NLevel=2 and NPublisherId in " + sbFilter.ToString () + " )");
            IList<NewNotice> lstNewNotice = new NewNoticeBLL().GetList(" NUserType=1 and NUserId=" + student.SId);

            if (lstNotice == null)
            {
                return null;
            }
            if (lstNewNotice == null)
            {
                lstNewNotice = new List<NewNotice>();
            }
            foreach (Notice noctice in lstNotice)
            {
                foreach (NewNotice item in lstNewNotice)
                {
                    if (item.NoticeId == noctice.NId)
                    {
                        noctice.IsNew = true;
                        break;
                    }
                }
            }
            return lstNotice;
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
        public int Add(Notice model)
        {
            return dal.Add(model);
        }
        #endregion
		
		#region Update
        /// <summary>
        /// Update a data
        /// </summary>
        public int Update(Notice model)
        {
            return dal.Update(model);
		}
        #endregion
    }
}
