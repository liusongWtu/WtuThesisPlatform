using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of Admin.
	/// Datetime:2013/4/21 14:32:10
    /// </summary>
    public class Admin
    {
        public Admin()
        { }
		
        #region Protected Properties
        protected int _uId;
        protected string _uUserName = String.Empty;
        protected string _uPassword = String.Empty;
        protected string _uName = String.Empty;
        protected int _departmentId;
        protected int _roleId;
        protected int _uCheckId;
        protected bool _isDel;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  管理员表id
        /// </summary>
        public int UId
        {
            set {_uId = value;}
            get {return _uId;}
        }

        /// <summary>
        ///  用户名
        /// </summary>
        public string UUserName
        {
            set {_uUserName = value;}
            get {return _uUserName;}
        }

        /// <summary>
        ///  密码
        /// </summary>
        public string UPassword
        {
            set {_uPassword = value;}
            get {return _uPassword;}
        }

        /// <summary>
        ///  姓名
        /// </summary>
        public string UName
        {
            set {_uName = value;}
            get {return _uName;}
        }

        /// <summary>
        ///  所在系（若为校级管理员则此字段为空）
        /// </summary>
        public int DepartmentId
        {
            set {_departmentId = value;}
            get {return _departmentId;}
        }

        /// <summary>
        ///  用户角色id
        /// </summary>
        public int RoleId
        {
            set {_roleId = value;}
            get {return _roleId;}
        }

        /// <summary>
        ///  验证码（修改密码时用）
        /// </summary>
        public int UCheckId
        {
            set {_uCheckId = value;}
            get {return _uCheckId;}
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
