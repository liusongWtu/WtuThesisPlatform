using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of Score.
	/// Datetime:2013/4/21 14:10:02
    /// </summary>
    public class Score
    {
        public Score()
        { }
		
        #region Protected Properties
        protected int _sId;
        protected string _sNo = String.Empty;
        protected int _sTearcherScore;
        protected int _sAppraiserScore;
        protected int _sRejoinScore;
        protected bool _isDel;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  成绩表id
        /// </summary>
        public int SId
        {
            set {_sId = value;}
            get {return _sId;}
        }

        /// <summary>
        ///  学生学号
        /// </summary>
        public string SNo
        {
            set {_sNo = value;}
            get {return _sNo;}
        }

        /// <summary>
        ///  老师成绩
        /// </summary>
        public int STearcherScore
        {
            set {_sTearcherScore = value;}
            get {return _sTearcherScore;}
        }

        /// <summary>
        ///  评阅人成绩
        /// </summary>
        public int SAppraiserScore
        {
            set {_sAppraiserScore = value;}
            get {return _sAppraiserScore;}
        }

        /// <summary>
        ///  答辩成绩
        /// </summary>
        public int SRejoinScore
        {
            set {_sRejoinScore = value;}
            get {return _sRejoinScore;}
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
