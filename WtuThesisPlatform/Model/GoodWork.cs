using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
    /// <summary>
    /// Author: LiuSong
    /// Description: EntityTier -- the entity class of GoodWork.
    /// Datetime:2013/5/18 13:13:40
    /// </summary>
    public class GoodWork
    {
        public GoodWork()
        { }

        #region Protected Properties
        protected int _gId;
        protected string _gTitle = String.Empty;
        protected Student _student = new Student();
        protected DateTime _gTime;
        protected string _gContent = String.Empty;
        protected string _gCoverPic = String.Empty;
        protected int _gPassed;
        protected string _stateString;
        #endregion

        #region Public Properties
        /// <summary>
        ///  id
        /// </summary>
        public int GId
        {
            set { _gId = value; }
            get { return _gId; }
        }

        /// <summary>
        ///  标题
        /// </summary>
        public string GTitle
        {
            set { _gTitle = value; }
            get { return _gTitle; }
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
        ///  时间
        /// </summary>
        public DateTime GTime
        {
            set { _gTime = value; }
            get { return _gTime; }
        }

        /// <summary>
        ///  内容
        /// </summary>
        public string GContent
        {
            set { _gContent = value; }
            get { return _gContent; }
        }

        /// <summary>
        ///  封面图片
        /// </summary>
        public string GCoverPic
        {
            set { _gCoverPic = value; }
            get { return _gCoverPic; }
        }

        /// <summary>
        ///  审核状态（0.未审核，1，通过，2未通过）
        /// </summary>
        public int GPassed
        {
            set { _gPassed = value; }
            get { return _gPassed; }
        }

        /// <summary>
        ///  审核状态（0.未审核，1，通过，2未通过）
        /// </summary>
        public string StateString
        {
            get
            {
                if (_gPassed == 0)
                {
                    return "未审核";
                }
                else if (_gPassed == 1)
                {
                    return "通过";
                }
                else
                {
                    return "未通过";
                }
            }
        }

        #endregion
    }
}
