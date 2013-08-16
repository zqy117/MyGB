//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApplication2
//{
//    public class TriangleMY
//    {
//        static void Main(string[] args)
//        {
//            //获取读写流
//            StreamReader reader = File.OpenText(@"F:\ceshi\sanjiao2.in");
//            StreamWriter writer = File.CreateText(@"F:\ceshi\sanjiao2.out");

//            //三角形行数
//            int num = int.Parse(reader.ReadLine());

//            //封装所有数据到二维数组
//            int[,] number = new int[num,num];
//            for (int i = 0; i < num;i++ )
//            {
//                 string line = reader.ReadLine();
//                 string[] vals =  line.Split("".ToCharArray());
//                 for (int j = 0; j < vals.Length; j++)
//                {
//                    number[i, j] = int.Parse(vals[j]);
//                }
//            }

//            //利用状态转移表达式，计算最大值  number[i,j] = Max(number[i+1,j],number[i+1,j+1])+number[i,j];
//            for (int i = num - 2; i >= 0;i--)
//            {
//                for (int j = 0; j <= i; j++)
//                {
//                    number[i, j] = Math.Max(number[i + 1, j], number[i + 1, j + 1]) + number[i, j];
//                    Console.WriteLine("i={0},j={1} , number={2} ",i,j,number[i,j]);
//                }
//            }


//            //输出
//            writer.Write(number[0, 0]);
//            Console.WriteLine(number[0, 0]);
//            Console.ReadLine();
//        }
//    }
//}
