using System;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
    /// <summary>
    /// Author: LiuSong
    /// Description: EntityTier -- the entity class of Student.
    /// Datetime:2013/4/21 14:10:07
    /// </summary>
    public class Student
    {
        public Student()
        { }

        #region Protected Properties
        protected int _sId;
        protected string _sNo = String.Empty;
        protected string _sName = String.Empty;
        protected Department _department = new Department();
        protected Major _major = new Major();
        protected string _sSex = String.Empty;
        protected ClassInfo _classInfo = new ClassInfo();
        protected string _sPhone = String.Empty;
        protected string _sQQ = String.Empty;
        protected string _sEmail = String.Empty;
        protected string _sPassword = String.Empty;
        protected bool _sFlag;
        protected string _sYear = String.Empty;
        protected string _sCheckCode = String.Empty;
        protected bool _isDel;
        protected RoleInfo _roleInfo = new RoleInfo();
        #endregion

        #region Public Properties
        /// <summary>
        ///  
        /// </summary>
        public int SId
        {
            set { _sId = value; }
            get { return _sId; }
        }

        /// <summary>
        ///  学号
        /// </summary>
        public string SNo
        {
            set { _sNo = value; }
            get { return _sNo; }
        }

        /// <summary>
        ///  姓名
        /// </summary>
        public string SName
        {
            set { _sName = value; }
            get { return _sName; }
        }

        /// <summary>
        ///  院系
        /// </summary>
        public Department Department
        {
            set { _department = value; }
            get { return _department; }
        }

        /// <summary>
        ///  专业id
        /// </summary>
        public Major Major
        {
            set { _major = value; }
            get { return _major; }
        }

        /// <summary>
        ///  性别
        /// </summary>
        public string SSex
        {
            set { _sSex = value; }
            get { return _sSex; }
        }


        /// <summary>
        ///  班级
        /// </summary>
        public ClassInfo ClassInfo 
        {
            set { _classInfo = value; }
            get { return _classInfo; }
        }

        /// <summary>
        ///  电话
        /// </summary>
        public string SPhone
        {
            set { _sPhone = value; }
            get { return _sPhone; }
        }

        /// <summary>
        ///  QQ
        /// </summary>
        public string SQQ
        {
            set { _sQQ = value; }
            get { return _sQQ; }
        }

        /// <summary>
        ///  Email
        /// </summary>
        public string SEmail
        {
            set { _sEmail = value; }
            get { return _sEmail; }
        }

        /// <summary>
        ///  密码
        /// </summary>
        public string SPassword
        {
            set { _sPassword = value; }
            get { return _sPassword; }
        }

        /// <summary>
        ///  是否选题
        /// </summary>
        public bool SFlag
        {
            set { _sFlag = value; }
            get { return _sFlag; }
        }

        /// <summary>
        ///  毕业届
        /// </summary>
        public string SYear
        {
            set { _sYear = value; }
            get { return _sYear; }
        }

        /// <summary>
        ///  用户角色对象
        /// </summary>
        public RoleInfo RoleInfo
        {
            set { _roleInfo = value; }
            get { return _roleInfo; }
        }

        /// <summary>
        ///  验证码（修改密码时用）
        /// </summary>
        public string SCheckCode
        {
            set { _sCheckCode = value; }
            get { return _sCheckCode; }
        }

        /// <summary>
        ///  软删除标志
        /// </summary>
        public bool IsDel
        {
            set { _isDel = value; }
            get { return _isDel; }
        }
        #endregion
    }
}
