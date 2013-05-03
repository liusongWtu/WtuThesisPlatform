using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
    /// <summary>
    /// Author: LiuSong
    /// Description: EntityTier -- the entity class of ThesisSelected.
    /// Datetime:2013/5/3 10:04:44
    /// </summary>
    public class ThesisSelected
    {
        public ThesisSelected()
        { }

        #region Protected Properties
        protected int _tId;
        protected ThesisTitle _thesisTitle;
        protected Student _student;
        protected bool _tPassed;
        protected string _tYear = String.Empty;
        protected int _messageId;
        protected bool _isDel;
        private int _leftNum;
        private string _stateString;


        #endregion

        #region Public Properties
        /// <summary>
        ///  已选表id
        /// </summary>
        public int TId
        {
            set { _tId = value; }
            get { return _tId; }
        }

        /// <summary>
        ///  选题
        /// </summary>
        public ThesisTitle ThesisTitle
        {
            set { _thesisTitle = value; }
            get { return _thesisTitle; }
        }

        /// <summary>
        ///  学生
        /// </summary>
        public Student Student
        {
            set { _student = value; }
            get { return _student; }
        }

        /// <summary>
        ///  是否通过
        /// </summary>
        public bool TPassed
        {
            set { _tPassed = value; }
            get { return _tPassed; }
        }

        /// <summary>
        ///  毕业届
        /// </summary>
        public string TYear
        {
            set { _tYear = value; }
            get { return _tYear; }
        }

        /// <summary>
        ///  留言id
        /// </summary>
        public int MessageId
        {
            set { _messageId = value; }
            get { return _messageId; }
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
        /// 剩余人数
        /// </summary>
        public int LeftNum
        {
            get
            {
                _leftNum = ThesisTitle.TNumber = ThesisTitle.TAcceptNum;
                return _leftNum;
            }
        }

        /// <summary>
        /// 状态描述
        /// </summary>
        public string StateString
        {
            get
            {
                if (_tPassed)
                {
                    _stateString = "已通过";
                }
                else
                {
                    _stateString =  "等待处理...";
                }
                return _stateString;
            }
        }
        #endregion
    }
}
