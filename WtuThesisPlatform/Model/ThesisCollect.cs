using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
    /// <summary>
    /// Author: LiuSong
    /// Description: EntityTier -- the entity class of ThesisCollect.
    /// Datetime:2013/5/2 22:39:40
    /// </summary>
    public class ThesisCollect
    {
        public ThesisCollect()
        { }

        #region Protected Properties
        protected int _cId;
        protected Student _student;
        protected ThesisTitle _thesisTitle;
        private int _leftNum;

        #endregion

        #region Public Properties
        /// <summary>
        ///  收藏表id
        /// </summary>
        public int CId
        {
            set { _cId = value; }
            get { return _cId; }
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
        ///  论文
        /// </summary>
        public ThesisTitle ThesisTitle
        {
            set { _thesisTitle = value; }
            get { return _thesisTitle; }
        }

        /// <summary>
        /// 剩余人数
        /// </summary>
        public int LeftNum
        {
            get
            {
                _leftNum = _thesisTitle.TNumber - _thesisTitle.TAcceptNum;
                return _leftNum;
            }
        }
        #endregion
    }
}
