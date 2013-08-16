using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match
{
    public class LotteryYP
    {
        static void Main(string[] args)
        {
            StreamReader reader = File.OpenText(@"F:\ceshi\lottery.in");
            StreamWriter writer = File.CreateText(@"F:\ceshi\lottery.out");

            int n = int.Parse(reader.ReadLine());
            //23 1 11 14 19 17 18
            string biaoZhun = reader.ReadLine();

            int[] bz = StringToInt(biaoZhun.Split(' '));

            int[] sj = null;

            int[] zhongJiang = new int[7];

            for (int i = 0; i < n; i++)
            {
                //12 8 9 23 1 16 7
                //11 7 10 21 2 9 31
                string shiJi = reader.ReadLine();

                sj = StringToInt(shiJi.Split(' '));

                int jiDengJiang = 0;
                for (int j = 0; j < sj.Length; j++)
                {
                    int temp = sj[j];
                    bool isHavePP = false;
                    for (int k = 0; k < bz.Length; k++)
                    {
                        if (bz[k] == temp)
                        {
                            isHavePP = true;
                            break;
                        }
                    }

                    if (isHavePP)
                    {
                        jiDengJiang++;
                    }

                }

                zhongJiang[7 - jiDengJiang] = zhongJiang[7 - jiDengJiang] + 1;
            }

            for (int i = 0; i < zhongJiang.Length; i++)
            {
                writer.Write(zhongJiang[i] + " ");
            }


            reader.Close();
            writer.Close();

        }

        private static int[] StringToInt(string[] srcs)
        {
            int[] result = new int[srcs.Length];
            for (int i = 0; i < srcs.Length; i++)
            {
                result[i] = int.Parse(srcs[i]);
            }
            return result;
        }
    }
}
