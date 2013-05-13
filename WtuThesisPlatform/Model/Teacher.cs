using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace WtuThesisPlatform.MODEL
{
    [Serializable]
	/// <summary>
	/// Author: LiuSong
	/// Description: EntityTier -- the entity class of Teacher.
	/// Datetime:2013/5/4 11:06:34
    /// </summary>
    public class Teacher
    {
        public Teacher()
        { }
		
        #region Protected Properties
        protected int _tId;
        protected string _tNo = String.Empty;
        protected string _tPassword = String.Empty;
        protected string _tName = String.Empty;
        protected string _tZhiCheng = String.Empty;
        protected int _tTeachNum;
        protected string _tSex = String.Empty;
        protected string _tPhone = String.Empty;
        protected string _tEmail = String.Empty;
        protected string _tQQ = String.Empty;
        protected Department _department;
        protected Major _major;
        protected string _tTeachCourse = String.Empty;
        protected string _tResearchFields = String.Empty;
        protected string _tCheckCode = String.Empty;
        protected RoleInfo _roleInfo;
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
        ///  工号
        /// </summary>
        public string TNo
        {
            set {_tNo = value;}
            get {return _tNo;}
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
        ///  性别
        /// </summary>
        public string TSex
        {
            set { _tSex = value; }
            get { return _tSex; }
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
        ///  QQ
        /// </summary>
        public string TQQ
        {
            set {_tQQ = value;}
            get {return _tQQ;}
        }

        /// <summary>
        ///  院系
        /// </summary>
        public Department Department
        {
            set {_department = value;}
            get {return _department;}
        }

        /// <summary>
        ///  专业
        /// </summary>
        public Major Major
        {
            set {_major = value;}
            get {return _major;}
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
        ///  用户角色
        /// </summary>
        public RoleInfo RoleInfo
        {
            set {_roleInfo = value;}
            get {return _roleInfo;}
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

        /// <summary>
        /// 克隆当前对象
        /// </summary>
        /// <param name="isDeepCopy">是否是深拷贝</param>
        /// <returns></returns>
        public Teacher Clone(bool isDeepCopy)
        {
            Teacher teacher = null;
            if (isDeepCopy)
            {
                using (MemoryStream memoryStream=new MemoryStream ())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(memoryStream,this);
                    memoryStream.Position = 0;
                    teacher = (Teacher)formatter.Deserialize(memoryStream);
                }
            }
            else
            {
                teacher = (Teacher)this.MemberwiseClone();
            }
            return teacher;
        }
    }
}
