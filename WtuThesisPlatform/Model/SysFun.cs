using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of SysFun.
	/// Datetime:2013/4/21 14:10:12
    /// </summary>
    public class SysFun
    {
        public SysFun()
        { }
		
        #region Protected Properties
        protected int _nodeId;
        protected string _displayName = String.Empty;
        protected string _nodeURL = String.Empty;
        protected int _parentNodeId;
        protected int _displayOrder;
        protected bool _isDel;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  资料表id
        /// </summary>
        public int NodeId
        {
            set {_nodeId = value;}
            get {return _nodeId;}
        }

        /// <summary>
        ///  显示名称
        /// </summary>
        public string DisplayName
        {
            set {_displayName = value;}
            get {return _displayName;}
        }

        /// <summary>
        ///  资料对应url
        /// </summary>
        public string NodeURL
        {
            set {_nodeURL = value;}
            get {return _nodeURL;}
        }

        /// <summary>
        ///  上一级id
        /// </summary>
        public int ParentNodeId
        {
            set {_parentNodeId = value;}
            get {return _parentNodeId;}
        }

        /// <summary>
        ///  同一级的显示顺序
        /// </summary>
        public int DisplayOrder
        {
            set {_displayOrder = value;}
            get {return _displayOrder;}
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
