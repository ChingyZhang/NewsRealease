using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsRealease.DAL.MODEL
{
    public class ArgsHelper
    {
        /// <summary>
        /// 由于在执行方法的时候返回bool类型的话，只能得知成功与否，没有描述，所以就封了此类
        /// </summary>

        private bool flag;

        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        private string msg = string.Empty;

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }


        /// <summary>
        /// 默认返回true，描述为空
        /// </summary>
        public ArgsHelper() : this(true, "") { }

        /// <summary>
        /// 默认返回描述为空
        /// </summary>
        public ArgsHelper(bool Flag) : this(Flag, "") { }

        /// <summary>
        /// 默认返回false，描述为空
        /// </summary>
        public ArgsHelper(string Msg)
            : this(false, Msg) { }

        /// <summary>
        /// 具有最多参数的构造函数作为类的主构造函数，其他构造函数可用this关键字调用该构造函数
        /// </summary>
        /// <param name="Flag"></param>
        /// <param name="Msg"></param>
        public ArgsHelper(bool Flag, string Msg)
        {
            this.flag = Flag;
            this.msg = Msg;
        }


        


    }
}
