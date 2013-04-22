using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of NewNotice.
	/// Datetime:2013/4/22 16:14:21
    /// </summary>
    public class NewNotice
    {
        public NewNotice()
        { }
		
        #region Protected Properties
        protected int _nId;
        protected int _noticeId;
        protected int _nUserType;
        protected int _nUserId;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  id
        /// </summary>
        public int NId
        {
            set {_nId = value;}
            get {return _nId;}
        }

        /// <summary>
        ///  公告id（公告表）
        /// </summary>
        public int NoticeId
        {
            set {_noticeId = value;}
            get {return _noticeId;}
        }

        /// <summary>
        ///  未读用户类型
        /// </summary>
        public int NUserType
        {
            set {_nUserType = value;}
            get {return _nUserType;}
        }

        /// <summary>
        ///  未读用户id
        /// </summary>
        public int NUserId
        {
            set {_nUserId = value;}
            get {return _nUserId;}
        }
        #endregion
    }
}
