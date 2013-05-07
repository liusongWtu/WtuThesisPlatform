using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of Major.
	/// Datetime:2013/5/6 21:54:53
    /// </summary>
    public class Major
    {
        public Major()
        { }
		
        #region Protected Properties
        protected int _mId;
        protected Department _department;
        protected string _mName = String.Empty;
        protected int _mnumber;
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
        ///  所在院系
        /// </summary>
        public Department Department
        {
            set {_department = value;}
            get {return _department;}
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
        ///  人数
        /// </summary>
        public int Mnumber
        {
            set {_mnumber = value;}
            get {return _mnumber;}
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
