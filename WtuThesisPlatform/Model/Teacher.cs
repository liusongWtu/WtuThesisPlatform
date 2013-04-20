using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of Teacher.
	/// Datetime:2013/4/20 21:00:54
    /// </summary>
    public class Teacher
    {
        public Teacher()
        { }
		
        #region Protected Properties
        protected int _tId;
        protected string _tUserName = String.Empty;
        protected string _tPassword = String.Empty;
        protected string _tName = String.Empty;
        protected string _tZhiCheng = String.Empty;
        protected int _tTeachNum;
        protected string _tPhone = String.Empty;
        protected string _tEmail = String.Empty;
        protected int _majorId;
        protected string _tTeachCourse = String.Empty;
        protected string _tResearchFields = String.Empty;
        protected string _tCheckCode = String.Empty;
        protected bool _isDel;
        #endregion
		
        #region Public Properties
        /// <summary>
        ///  教师id
        /// </summary>
        public int TId
        {
            set {_tId = value;}
            get {return _tId;}
        }

        /// <summary>
        ///  用户名
        /// </summary>
        public string TUserName
        {
            set {_tUserName = value;}
            get {return _tUserName;}
        }

        /// <summary>
        ///  密码
        /// </summary>
        public string TPassword
        {
            set {_tPassword = value;}
            get {return _tPassword;}
        }

        /// <summary>
        ///  教师姓名
        /// </summary>
        public string TName
        {
            set {_tName = value;}
            get {return _tName;}
        }

        /// <summary>
        ///  职称
        /// </summary>
        public string TZhiCheng
        {
            set {_tZhiCheng = value;}
            get {return _tZhiCheng;}
        }

        /// <summary>
        ///  限带人数
        /// </summary>
        public int TTeachNum
        {
            set {_tTeachNum = value;}
            get {return _tTeachNum;}
        }

        /// <summary>
        ///  电话
        /// </summary>
        public string TPhone
        {
            set {_tPhone = value;}
            get {return _tPhone;}
        }

        /// <summary>
        ///  Email
        /// </summary>
        public string TEmail
        {
            set {_tEmail = value;}
            get {return _tEmail;}
        }

        /// <summary>
        ///  专业id
        /// </summary>
        public int MajorId
        {
            set {_majorId = value;}
            get {return _majorId;}
        }

        /// <summary>
        ///  主讲课程
        /// </summary>
        public string TTeachCourse
        {
            set {_tTeachCourse = value;}
            get {return _tTeachCourse;}
        }

        /// <summary>
        ///  研究方向
        /// </summary>
        public string TResearchFields
        {
            set {_tResearchFields = value;}
            get {return _tResearchFields;}
        }

        /// <summary>
        ///  验证码（修改密码时使用）
        /// </summary>
        public string TCheckCode
        {
            set {_tCheckCode = value;}
            get {return _tCheckCode;}
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
