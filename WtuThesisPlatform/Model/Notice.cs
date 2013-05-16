using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of Notice.
	/// Datetime:2013/5/7 10:54:18
    /// </summary>
    public class Notice
    {
        public Notice()
        { }
		
        #region Protected Properties
        protected int _nId;
        protected int _nLevel;
        protected string _nName = String.Empty;
        protected int _nPublisherId;
        protected string _nPublishUnits = String.Empty;
        protected string _nTitle = String.Empty;
        protected string _nContent = String.Empty;
        protected DateTime _nPublishTime;
        protected DateTime _nDeadTime;
        protected bool _isNew;
        protected bool _isDel;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  公告表id
        /// </summary>
        public int NId
        {
            set {_nId = value;}
            get {return _nId;}
        }

        /// <summary>
        ///  公告级别 1校级 2院系级  3教师级
        /// </summary>
        public int NLevel
        {
            set {_nLevel = value;}
            get {return _nLevel;}
        }

        /// <summary>
        ///  发布者姓名
        /// </summary>
        public string NName
        {
            set {_nName = value;}
            get {return _nName;}
        }

        /// <summary>
        ///  发布者id
        /// </summary>
        public int NPublisherId
        {
            set {_nPublisherId = value;}
            get {return _nPublisherId;}
        }

        /// <summary>
        ///  发布单位
        /// </summary>
        public string NPublishUnits
        {
            set {_nPublishUnits = value;}
            get {return _nPublishUnits;}
        }

        /// <summary>
        ///  标题
        /// </summary>
        public string NTitle
        {
            set {_nTitle = value;}
            get {return _nTitle;}
        }

        /// <summary>
        ///  公告内容
        /// </summary>
        public string NContent
        {
            set {_nContent = value;}
            get {return _nContent;}
        }

        /// <summary>
        ///  发布时间
        /// </summary>
        public DateTime NPublishTime
        {
            set {_nPublishTime = value;}
            get {return _nPublishTime;}
        }

        /// <summary>
        ///  有效期
        /// </summary>
        public DateTime NDeadTime
        {
            set {_nDeadTime = value;}
            get {return _nDeadTime;}
        }

        /// <summary>
        ///  软删除标志
        /// </summary>
        public bool IsDel
        {
            set {_isDel = value;}
            get {return _isDel;}
        }

        /// <summary>
        /// 是否为未读信息
        /// </summary>
        public bool IsNew
        {
            set { _isNew = value; }
            get { return _isNew; }
        }
        #endregion
    }
}
