using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of Department.
	/// Datetime:2013/5/6 21:54:40
    /// </summary>
    public class Department
    {
        public Department()
        { }
		
        #region Protected Properties
        protected int _dId;
        protected string _dName = String.Empty;
        protected string _dTelPhone = String.Empty;
        protected int _dNumber;
        protected bool _isDel;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  院系id
        /// </summary>
        public int DId
        {
            set {_dId = value;}
            get {return _dId;}
        }

        /// <summary>
        ///  院系名称
        /// </summary>
        public string DName
        {
            set {_dName = value;}
            get {return _dName;}
        }

        /// <summary>
        ///  院系电话
        /// </summary>
        public string DTelPhone
        {
            set {_dTelPhone = value;}
            get {return _dTelPhone;}
        }

        /// <summary>
        ///  人数
        /// </summary>
        public int DNumber
        {
            set {_dNumber = value;}
            get {return _dNumber;}
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
