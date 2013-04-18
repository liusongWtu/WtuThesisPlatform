using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of OnlineUser.
	/// Datetime:2013/4/16 15:29:18
    /// </summary>
    public class OnlineUser
    {
        public OnlineUser()
        { }
		
        #region Protected Properties
        protected string _iD = String.Empty;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  在线用户id
        /// </summary>
        public string ID
        {
            set {_iD = value;}
            get {return _iD;}
        }
        #endregion
    }
}
