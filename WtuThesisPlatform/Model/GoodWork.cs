using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of GoodWork.
	/// Datetime:2013/5/16 23:53:41
    /// </summary>
    public class GoodWork
    {
        public GoodWork()
        { }
		
        #region Protected Properties
        protected int _gId;
        protected string _gTitle = String.Empty;
        protected int _gStudentId;
        protected DateTime _gTime;
        protected string _gContent = String.Empty;
        protected string _gCoverPic = String.Empty;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  id
        /// </summary>
        public int GId
        {
            set {_gId = value;}
            get {return _gId;}
        }

        /// <summary>
        ///  标题
        /// </summary>
        public string GTitle
        {
            set {_gTitle = value;}
            get {return _gTitle;}
        }

        /// <summary>
        ///  学号
        /// </summary>
        public int GStudentId
        {
            set {_gStudentId = value;}
            get {return _gStudentId;}
        }

        /// <summary>
        ///  时间
        /// </summary>
        public DateTime GTime
        {
            set {_gTime = value;}
            get {return _gTime;}
        }

        /// <summary>
        ///  内容
        /// </summary>
        public string GContent
        {
            set {_gContent = value;}
            get {return _gContent;}
        }

        /// <summary>
        ///  封面图片
        /// </summary>
        public string GCoverPic
        {
            set {_gCoverPic = value;}
            get {return _gCoverPic;}
        }
        #endregion
    }
}
