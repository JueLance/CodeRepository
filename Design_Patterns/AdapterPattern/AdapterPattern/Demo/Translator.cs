/**
 *
 *  在这个适配器模式中， 作者采用的是对象的Adapter模式。
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern.Demo
{
    /// <summary>
    /// 
    /// </summary>
    public class Translator : Player
    {
        private ForeignCenter wjzf = new ForeignCenter();
        public Translator(string name)
            : base(name)
        {
            wjzf.Name = name;
        }

        public override void Attack()
        {
            wjzf.进攻();
        }

        public override void Defense()
        {
            wjzf.防守();
        }
    }
}
