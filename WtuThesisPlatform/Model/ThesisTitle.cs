using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of ThesisTitle.
	/// Datetime:2013/4/21 14:10:37
    /// </summary>
    public class ThesisTitle
    {
        public ThesisTitle()
        { }
		
        #region Protected Properties
        protected int _tId;
        protected int _tTeacherId;
        protected string _tName = String.Empty;
        protected string _tLevel = String.Empty;
        protected string _tField = String.Empty;
        protected int _tNumber;
        protected string _tRequire = String.Empty;
        protected int _tSelectedNum;
        protected int _tAcceptNum;
        protected int _tState;
        protected string _tYear = String.Empty;
        protected int _tDepartmentId;
        protected bool _isDel;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  选题id
        /// </summary>
        public int TId
        {
            set {_tId = value;}
            get {return _tId;}
        }

        /// <summary>
        ///  出题教师id
        /// </summary>
        public int TTeacherId
        {
            set {_tTeacherId = value;}
            get {return _tTeacherId;}
        }

        /// <summary>
        ///  选题名称
        /// </summary>
        public string TName
        {
            set {_tName = value;}
            get {return _tName;}
        }

        /// <summary>
        ///  选题难度
        /// </summary>
        public string TLevel
        {
            set {_tLevel = value;}
            get {return _tLevel;}
        }

        /// <summary>
        ///  选题方向
        /// </summary>
        public string TField
        {
            set {_tField = value;}
            get {return _tField;}
        }

        /// <summary>
        ///  最多允许人数
        /// </summary>
        public int TNumber
        {
            set {_tNumber = value;}
            get {return _tNumber;}
        }

        /// <summary>
        ///  选题要求
        /// </summary>
        public string TRequire
        {
            set {_tRequire = value;}
            get {return _tRequire;}
        }

        /// <summary>
        ///  新选择人数
        /// </summary>
        public int TSelectedNum
        {
            set {_tSelectedNum = value;}
            get {return _tSelectedNum;}
        }

        /// <summary>
        ///  已选确定人数
        /// </summary>
        public int TAcceptNum
        {
            set {_tAcceptNum = value;}
            get {return _tAcceptNum;}
        }

        /// <summary>
        ///  审核状态（0未审核，1通过，2未通过）
        /// </summary>
        public int TState
        {
            set {_tState = value;}
            get {return _tState;}
        }

        /// <summary>
        ///  届数
        /// </summary>
        public string TYear
        {
            set {_tYear = value;}
            get {return _tYear;}
        }

        /// <summary>
        ///  限选院系id
        /// </summary>
        public int TDepartmentId
        {
            set {_tDepartmentId = value;}
            get {return _tDepartmentId;}
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
