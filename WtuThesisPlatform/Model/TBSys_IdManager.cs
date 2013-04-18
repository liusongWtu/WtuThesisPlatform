using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of TBSys_IdManager.
	/// Datetime:2013/4/16 15:31:01
    /// </summary>
    public class TBSys_IdManager
    {
        public TBSys_IdManager()
        { }
		
        #region Protected Properties
        protected int _id;
        protected string _tableName = String.Empty;
        protected string _fieldName = String.Empty;
        protected int _currentValue;
        protected int _start;
        protected int _step;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  主键Id
        /// </summary>
        public int Id
        {
            set {_id = value;}
            get {return _id;}
        }

        /// <summary>
        ///  表名
        /// </summary>
        public string TableName
        {
            set {_tableName = value;}
            get {return _tableName;}
        }

        /// <summary>
        ///  主键名
        /// </summary>
        public string FieldName
        {
            set {_fieldName = value;}
            get {return _fieldName;}
        }

        /// <summary>
        ///  主键的当前值
        /// </summary>
        public int CurrentValue
        {
            set {_currentValue = value;}
            get {return _currentValue;}
        }

        /// <summary>
        ///  起始值（只在第一次访问时有效）
        /// </summary>
        public int Start
        {
            set {_start = value;}
            get {return _start;}
        }

        /// <summary>
        ///  主键的增量
        /// </summary>
        public int Step
        {
            set {_step = value;}
            get {return _step;}
        }
        #endregion
    }
}
