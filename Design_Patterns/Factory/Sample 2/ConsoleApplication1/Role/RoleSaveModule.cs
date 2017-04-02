using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    public class RoleSaveModule : ISaveModule
    {
        #region ISaveModule 成员

        public ModuleSavor CreateSavor()
        {
            return new RoleModuleSavor();
        }

        #endregion
    }
}
