using System;

namespace Core
{
    public class TestPaper
    {
        public void Question1()
        {
            Console.WriteLine("��������������ô���ɵģ�A:");
            Console.WriteLine("����:" + Answer1());
        }

        public void Question2()
        {
            Console.WriteLine("������ĸ�������ô���ģ�A:���˺����� B����ɱ��");
            Console.WriteLine("���ǣ�" + Answer2());
        }

        public void Question3()
        {
            Console.WriteLine("���̵Ĺ��������������A������ B������ C:�����Ͳ�����");
            Console.WriteLine("���ǣ�" + Answer3());
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

