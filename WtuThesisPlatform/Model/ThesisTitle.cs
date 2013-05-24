using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
    /// <summary>
    /// Author: LiuSong
    /// Description: EntityTier -- the entity class of ThesisTitle.
    /// Datetime:2013/5/3 17:24:32
    /// </summary>
    public class ThesisTitle
    {
        public ThesisTitle()
        { }

        #region Protected Properties
        protected int _tId;
        protected Teacher _teacher;
        protected string _tName = String.Empty;
        protected string _tLevel = String.Empty;
        protected int _tNumber;
        protected string _tPlatform = String.Empty;
        protected string _tIntroduct = String.Empty;
        protected string _tRequire = String.Empty;
        protected int _tSelectedNum;
        protected int _tAcceptNum;
        private int _tNewNum;
        protected int _tState;
        protected string _tYear = String.Empty;
        protected int _tDepartmentId;
        protected bool _isDel;
        #endregion

        #region Public Properties
        /// <summary>
        ///  选题id
        /// </summary>
        public int TId
        {
            set { _tId = value; }
            get { return _tId; }
        }

        /// <summary>
        ///  出题教师
        /// </summary>
        public Teacher Teacher
        {
            set { _teacher = value; }
            get { return _teacher; }
        }

        /// <summary>
        ///  选题名称
        /// </summary>
        public string TName
        {
            set { _tName = value; }
            get { return _tName; }
        }

        /// <summary>
        ///  选题难度
        /// </summary>
        public string TLevel
        {
            set { _tLevel = value; }
            get { return _tLevel; }
        }

        /// <summary>
        ///  最多允许人数
        /// </summary>
        public int TNumber
        {
            set { _tNumber = value; }
            get { return _tNumber; }
        }

        /// <summary>
        /// 剩余人数
        /// </summary>
        public int TNewNum
        {
            get
            {
                _tNewNum = _tSelectedNum - TAcceptNum;
                return _tNewNum;
            }
        }

        /// <summary>
        ///  开发平台
        /// </summary>
        public string TPlatform
        {
            set { _tPlatform = value; }
            get { return _tPlatform; }
        }

        /// <summary>
        ///  题目简介
        /// </summary>
        public string TIntroduct
        {
            set { _tIntroduct = value; }
            get { return _tIntroduct; }
        }

        /// <summary>
        ///  功能要求
        /// </summary>
        public string TRequire
        {
            set { _tRequire = value; }
            get { return _tRequire; }
        }

        /// <summary>
        ///  选择人数
        /// </summary>
        public int TSelectedNum
        {
            set { _tSelectedNum = value; }
            get { return _tSelectedNum; }
        }

        /// <summary>
        ///  已选确定人数
        /// </summary>
        public int TAcceptNum
        {
            set { _tAcceptNum = value; }
            get { return _tAcceptNum; }
        }

        /// <summary>
        ///  审核状态（0未审核，1通过，2未通过）
        /// </summary>
        public int TState
        {
            set { _tState = value; }
            get { return _tState; }
        }


        /// <summary>
        /// 选题状态描述
        /// </summary>
        public string StateString
        {
            get
            {
                if (_tState == 0)
                {
                    return "未审核";
                }
                else if (_tState == 1)
                {
                    return "审核通过";
                }
                else if (_tState == 2)
                {
                    return "审核不通过";
                }
                return "";
            }
        }

        /// <summary>
        ///  届数
        /// </summary>
        public string TYear
        {
            set { _tYear = value; }
            get { return _tYear; }
        }

        /// <summary>
        ///  限选院系id
        /// </summary>
        public int TDepartmentId
        {
            set { _tDepartmentId = value; }
            get { return _tDepartmentId; }
        }

        /// <summary>
        ///  软删除标志
        /// </summary>
        public bool IsDel
        {
            set { _isDel = value; }
            get { return _isDel; }
        }

        /// <summary>
        /// 当前学生是否收藏该选题
        /// </summary>
        public string IsStore
        {
            get;
            set;
        }

        /// <summary>
        /// 当前学生是否选择该选题
        /// </summary>
        public string IsSeleted
        {
            get;
            set;
        }



        #endregion
    }
}
