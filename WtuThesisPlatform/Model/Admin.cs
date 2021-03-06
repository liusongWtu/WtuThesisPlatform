﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
        protected string _uPhone = String.Empty;
        protected string _uEmail = String.Empty;
        protected string _uQQ = String.Empty;
        protected int _departmentId;
        protected int _uCheckId;
        protected bool _isDel;
        protected RoleInfo _roleInfo = new RoleInfo();
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
        ///  电话
        /// </summary>
        public string UPhone
        {
            set { _uPhone = value; }
            get { return _uPhone; }
        }

        /// <summary>
        ///  邮箱
        /// </summary>
        public string UEmail
        {
            set { _uEmail = value; }
            get { return _uEmail; }
        }

        /// <summary>
        ///  QQ
        /// </summary>
        public string UQQ
        {
            set { _uQQ = value; }
            get { return _uQQ; }
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
        ///  用户角色
        /// </summary>
        public RoleInfo RoleInfo
        {
            set {_roleInfo = value;}
            get {return _roleInfo;}
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

        #region Public Methods
        #region 克隆当前对象
        /// <summary>
        /// 克隆当前对象
        /// </summary>
        /// <param name="isDeepCopy">是否是深拷贝</param>
        /// <returns></returns>
        public Admin Clone(bool isDeepCopy)
        {
            Admin desAdmin = null;
            if (isDeepCopy)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(memoryStream, this);
                    memoryStream.Position = 0;
                    desAdmin = (Admin)formatter.Deserialize(memoryStream);
                }
            }
            else
            {
                desAdmin = (Admin)this.MemberwiseClone();
            }
            return desAdmin;
        }
        #endregion 
        #endregion
    }
}
