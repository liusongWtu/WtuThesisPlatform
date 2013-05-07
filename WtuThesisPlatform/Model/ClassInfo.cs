using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of ClassInfo.
	/// Datetime:2013/5/6 21:54:31
    /// </summary>
    public class ClassInfo
    {
        public ClassInfo()
        { }
		
        #region Protected Properties
        protected int _cId;
        protected string _cName = String.Empty;
        protected Major _major;
        protected int _cNumber;
        protected bool _isDel;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  班级表id
        /// </summary>
        public int CId
        {
            set {_cId = value;}
            get {return _cId;}
        }

        /// <summary>
        ///  班级名称
        /// </summary>
        public string CName
        {
            set {_cName = value;}
            get {return _cName;}
        }

        /// <summary>
        ///  专业
        /// </summary>m
        public Major Major
        {
            set {_major = value;}
            get {return _major;}
        }

        /// <summary>
        ///  人数
        /// </summary>
        public int CNumber
        {
            set {_cNumber = value;}
            get {return _cNumber;}
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
