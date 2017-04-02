using System;

namespace Core
{
    public class TestPaper
    {
        public void Question1()
        {
            Console.WriteLine("倚天屠龙剑是怎么炼成的？A:");
            Console.WriteLine("答案是:" + Answer1());
        }

        public void Question2()
        {
            Console.WriteLine("张三丰的父亲是怎么死的？A:被人害死的 B：自杀的");
            Console.WriteLine("答案是：" + Answer2());
        }

        public void Question3()
        {
            Console.WriteLine("明教的光明顶现在在哪里？A：西安 B：陕西 C:根本就不存在");
            Console.WriteLine("答案是：" + Answer3());
        }

        protected virtual string Answer1()
        {
            return string.Empty;
        }

        protected virtual string Answer2()
        {
            return string.Empty;
        }

        protected virtual string Answer3()
        {
            return string.Empty;
        }
    }
}

