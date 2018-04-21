using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Collections;
using System.Reflection;

namespace ConsoleApp1
{
    class DataFormater //数据格式化类
    {
        public static DataFormater FormaterInstense = new DataFormater();

        public const int Flux = 0;
        public const int Time = 1;
        public const int Balance = 2;

        public DataFormater()
        {

        }

        #region Ipgw信息格式

        public Dictionary<int, String> GetIpgwDataInf(String data)  //Ipgw网关信息格式化获取
        {
            Dictionary<int, String> temp = new Dictionary<int, string>();
            try
            {
                String[] t = data.Split(new char[] { ',' });
                temp.Add(Flux, FluxFormater(t[0]));
                temp.Add(Time, TimeFormater(t[1]));
                temp.Add(Balance, t[2]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Username or password wrong!");
                return null;
            }
            return temp;
        }

        private String FluxFormater(String flux)//流量信息格式化 in(Byte)
        {
            Int64 a = 0;
            try
            {
                a = Convert.ToInt64(flux);
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong Format Information !");
            }
            if (a > 1000000000)
                return String.Format("{0} G {1:000} M", a / 1000000000, (a % 1000000000) / 1000000);
            if (a > 1000000)
                return String.Format("{0:000} M", a / 1000000);
            if (a > 1000)
                return String.Format("{0:#0000} K", a / 1000);
            return String.Format("{0:#0} B", a);
        }

        private String TimeFormater(String Data)//时间信息格式化 in(s)
        {
            Int64 a = 0;
            try
            {
                a = Convert.ToInt64(Data);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Wrong Format Information !");
            }
            double h = Math.Round(a / 3600.0);
            double m = Math.Round((a % 3600) / 60.0);
            double s = a % 3600 % 60;
            return String.Format("{0}:{1}:{2}", h, m, s);
        }

        #endregion


        #region 教务处


        #endregion


        #region One信息格式


        #endregion
    }
}
