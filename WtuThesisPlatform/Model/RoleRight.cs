using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of RoleRight.
	/// Datetime:2013/4/16 15:29:47
    /// </summary>
    public class RoleRight
    {
        public RoleRight()
        { }
		
        #region Protected Properties
        protected int _roleRightId;
        protected int _roleId;
        protected int _nodeId;
        protected bool _isDel;
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
        ///  系统资料表Id
        /// </summary>
        public int NodeId
        {
            set {_nodeId = value;}
            get {return _nodeId;}
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
