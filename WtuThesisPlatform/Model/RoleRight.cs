using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of RoleRight.
	/// Datetime:2013/4/21 14:09:57
    /// </summary>
    public class RoleRight
    {
        public RoleRight()
        { }
		
        #region Protected Properties
        protected int _roleRightId;
        protected int _roleId;
        protected bool _isDel;
        protected SysFun _sysFun = new SysFun();
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  权限表id
        /// </summary>
        public int RoleRightId
        {
            set {_roleRightId = value;}
            get {return _roleRightId;}
        }

        /// <summary>
        ///  角色表id
        /// </summary>
        public int RoleId
        {
            set {_roleId = value;}
            get {return _roleId;}
        }

        /// <summary>
        ///  系统资料表对象
        /// </summary>
        public SysFun SysFun
        {
            set {_sysFun = value;}
            get {return _sysFun;}
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
