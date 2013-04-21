using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of Message.
	/// Datetime:2013/4/21 14:09:28
    /// </summary>
    public class Message
    {
        public Message()
        { }
		
        #region Protected Properties
        protected int _mId;
        protected int _thesisTitleSelectedId;
        protected string _mContent = String.Empty;
        protected DateTime _mTime;
        protected string _mName = String.Empty;
        protected bool _isDel;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  留言表id
        /// </summary>
        public int MId
        {
            set {_mId = value;}
            get {return _mId;}
        }

        /// <summary>
        ///  已选题表id
        /// </summary>
        public int ThesisTitleSelectedId
        {
            set {_thesisTitleSelectedId = value;}
            get {return _thesisTitleSelectedId;}
        }

        /// <summary>
        ///  留言内容
        /// </summary>
        public string MContent
        {
            set {_mContent = value;}
            get {return _mContent;}
        }

        /// <summary>
        ///  留言时间
        /// </summary>
        public DateTime MTime
        {
            set {_mTime = value;}
            get {return _mTime;}
        }

        /// <summary>
        ///  留言人姓名
        /// </summary>
        public string MName
        {
            set {_mName = value;}
            get {return _mName;}
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
