using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of RoleInfo.
	/// Datetime:2013/4/21 14:09:50
    /// </summary>
    public class RoleInfo
    {
        public RoleInfo()
        { }
		
        #region Protected Properties
        protected int _roleId;
        protected string _roleName = String.Empty;
        protected string _roleDesc = String.Empty;
        protected bool _isDel;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  角色表id
        /// </summary>
        public int RoleId
        {
            set {_roleId = value;}
            get {return _roleId;}
        }

        /// <summary>
        ///  角色名称
        /// </summary>
        public string RoleName
        {
            set {_roleName = value;}
            get {return _roleName;}
        }

        /// <summary>
        ///  角色描述
        /// </summary>
        public string RoleDesc
        {
            set {_roleDesc = value;}
            get {return _roleDesc;}
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
