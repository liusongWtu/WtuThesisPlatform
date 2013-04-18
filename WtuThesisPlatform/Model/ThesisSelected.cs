using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of ThesisSelected.
	/// Datetime:2013/4/16 15:31:29
    /// </summary>
    public class ThesisSelected
    {
        public ThesisSelected()
        { }
		
        #region Protected Properties
        protected int _tId;
        protected int _thesisTitleId;
        protected int _tearchId;
        protected string _studentId = String.Empty;
        protected bool _tPassed;
        protected string _tYear = String.Empty;
        protected int _messageId;
        protected bool _isDel;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  已选表id
        /// </summary>
        public int TId
        {
            set {_tId = value;}
            get {return _tId;}
        }

        /// <summary>
        ///  选题id
        /// </summary>
        public int ThesisTitleId
        {
            set {_thesisTitleId = value;}
            get {return _thesisTitleId;}
        }

        /// <summary>
        ///  教师id
        /// </summary>
        public int TearchId
        {
            set {_tearchId = value;}
            get {return _tearchId;}
        }

        /// <summary>
        ///  学号
        /// </summary>
        public string StudentId
        {
            set {_studentId = value;}
            get {return _studentId;}
        }

        /// <summary>
        ///  是否通过
        /// </summary>
        public bool TPassed
        {
            set {_tPassed = value;}
            get {return _tPassed;}
        }

        /// <summary>
        ///  毕业届
        /// </summary>
        public string TYear
        {
            set {_tYear = value;}
            get {return _tYear;}
        }

        /// <summary>
        ///  留言id
        /// </summary>
        public int MessageId
        {
            set {_messageId = value;}
            get {return _messageId;}
        }

        /// <summary>
        ///  软删除标志
        /// </summary>
        public bool IsDel
        {
            set {_isDel = value;}
            get {return _isDel;}
        }
        #endregion
    }
}
