using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class Resume : ICloneable
    {
        private string _name;
        private string _sex;
        private string _age;
        private string _timearea;
        private string _company;

        public Resume(string name)
        {
            _name = name;
        }

        public void SetPersonInfo(string sex, string age)
        {
            _sex = sex;
            _age = age;
        }

        public void SetWorkExperience(string timeArea, string company)
        {
            _timearea = timeArea;
            _company = company;
        }

        public void Display()
        {
            Console.WriteLine("{0} {1} {2}", _name, _sex, _age);
            Console.WriteLine("工作经历：{0} {1}", _timearea, _company);
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
