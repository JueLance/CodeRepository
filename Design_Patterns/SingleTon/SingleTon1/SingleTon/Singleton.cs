using System;
using System.Collections.Generic;
using System.Text;

namespace SingleTonDemo
{
    //����ʽ�����ࣺ ���־�̬��ʼ�������Լ�������ʱ�ͽ��Լ�ʵ������ ���Ա�����س�֮Ϊ������
    public sealed class Singleton2
    {
        private static readonly Singleton2 instance = new Singleton2();

        private Singleton2()
        {

        }

        public static Singleton2 GetInstance()
        {
            return instance;
        }
    }

    class Singleton
    {
        private static Singleton instance;

        //���̸�������
        private static readonly object syncRoot = new object();

        private Singleton()
        {

        }

        //����ʽ�����ࣺ ��Ҫ�ڵ�һ�α�����ʱ�� �ŻὫ�Լ�ʵ����
        public static Singleton GetInstance()
        {
            //lock��ȷ����һ���߳�λ�ڴ�����ٽ���ʱ�� ��һ���̲߳������ٽ����� ��������߳���ͼ����
            //�����Ĵ��룬 ������һֱ�ȴ�(������ֹ)�� ֱ���ö����ͷš� ������ȷ����lock�Ĵ���Σ� 
            //��ͬһ��ʱ�̣� ֻ��һ���߳̿��Խ��롣
            lock (syncRoot)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
            }

            return instance;
        }

        //˫����������
        //public static Singleton GetInstance()
        //{
        //    if (instance == null)
        //    {

        //        lock (syncRoot)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new Singleton();
        //            }
        //        }
        //    }
        //    return instance;
        //}

    }

}