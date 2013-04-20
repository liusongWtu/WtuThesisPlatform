using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of Major.
	/// Datetime:2013/4/20 20:59:37
    /// </summary>
    public class Major
    {
        public Major()
        { }
		
        #region Protected Properties
        protected int _mId;
        protected int _dId;
        protected string _mName = String.Empty;
        protected bool _isDel;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  专业id
        /// </summary>
        public int MId
        {
            set {_mId = value;}
            get {return _mId;}
        }

        /// <summary>
        ///  所在院系id
        /// </summary>
        public int DId
        {
            set {_dId = value;}
            get {return _dId;}
        }

        /// <summary>
        ///  专业名称
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
