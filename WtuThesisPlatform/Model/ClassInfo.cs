using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of ClassInfo.
	/// Datetime:2013/4/16 16:16:06
    /// </summary>
    public class ClassInfo
    {
        public ClassInfo()
        { }
		
        #region Protected Properties
        protected int _cId;
        protected string _cName = String.Empty;
        protected int _majorId;
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
        ///  专业Id
        /// </summary>
        public int MajorId
        {
            set {_majorId = value;}
            get {return _majorId;}
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
