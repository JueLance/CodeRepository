using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ConsoleApplication3
{
    public class DataAccess
    {
        //private string db = "SqlServer";
        private static readonly string AssemblyName = "ConsoleApplication3";//可以将此字段放入配置文件中
        private static readonly string db = "SqlServer";//可以将此字段放入配置文件中

        public IUser CreaterUser()
        {
            //常规方式：
            //IUser user = null;
            //switch (db)
            //{
            //    case "SqlServer":
            //        user = new SqlServerUser();
            //        break;

            //    case "AccessServer":
            //        user = new AccessUser();
            //        break;

            //    default:
            //        break;
            //}

            //return user;

            //采用反射方式
            string classname = string.Format("{0}.{1}User", AssemblyName, db);
            IUser user = (IUser)Assembly.Load(AssemblyName).CreateInstance(classname);
            return user;
        }


        public IDepartment CreaterDepartment()
        {
            IDepartment department = null;
            switch (db)
            {
                case "SqlServer":
                    department = new SqlServerDepartment();
                    break;

                case "AccessServer":
                    department = new AccessDepatment();
                    break;

                default:
                    break;
            }
            return department;
        }

    }
}
