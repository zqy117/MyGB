//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Match  //有错
//{
////    4 6
////1 0 1 0 1 0
////0 1 1 0 1 1
////1 1 1 0 1 0
////0 1 0 0 1 0
//    class Matrix
//    {
//        //未完成
//        // static int r = 0;
//        //static int c = 0;
//        //static int[,] matrix;
//        //static int maxlength = 0;
//        //static int maxi = 0;
//        //static int maxj = 0;
//        //static void Main(string[] args)
//        //{
//        //    //输入和输出文件读写
//        //    StreamReader reader = File.OpenText(@"F:\ceshi\matrix19.in");
//        //    StreamWriter writer = File.CreateText(@"F:\ceshi\matrix19.out");
//        //    //获取东西的数量
//        //    String[] matrixInf = reader.ReadLine().Split(" ".ToCharArray());
//        //    r = int.Parse(matrixInf[0]);
//        //    c = int.Parse(matrixInf[1]);

//        //    int min = r-c >0 ? c : r;

//        //    matrix = new int[r+r, c+c];
//        //    for (int i = 0; i < r; i++)
//        //    {
//        //        string[] temp = reader.ReadLine().Split(" ".ToCharArray());
//        //        for (int j = 0; j < c; j++)
//        //        {
//        //            matrix[i, j] = int.Parse(temp[j]);
//        //        }
//        //    }

//        //   int maxSize =1;
//        //    for (int i = 0; i<r-1; i++)
//        //    {
//        //        for (int j = 0; j< c - 1; j++)
//        //        {
//        //            if (matrix[i, j] == 1 && matrix[i + 1, j] == 1 && matrix[i, j + 1] == 1 && matrix[i + 1, j + 1] == 1 && maxSize<4)
//        //            {
//        //                Console.WriteLine("i={0},j={1} , matrix={2} ", i, j, 4);
//        //                maxSize = 4;
//        //            }

//        //            if (matrix[i, j] == 1 && matrix[i ,j + 1] == 1 && matrix[i, j + 2] == 1 
//        //                && matrix[i+1, j] == 1 && matrix[i + 1, j + 1] == 1 && matrix[i, j + 2] == 1
//        //                && matrix[i + 2, j ] == 1 && matrix[i + 2, j + 1] == 1 && matrix[i + 2, j + 2] == 1 && maxSize<9)
//        //            {
//        //                Console.WriteLine("i={0},j={1} , matrix={2} ", i, j,9);
//        //                maxSize = 9;
//        //            }

//        //            //if (Math.Pow(Convert.ToDouble(min),2) ==9)
//        //            //{
                    
//        //            //}

//        //        }
//        //    }
      
//        //    Console.WriteLine(maxSize);
//        //    writer.WriteLine(maxSize);
           
//        //    //关闭文件流
//        //    reader.Close();
//        //    writer.Close();
//        //    Console.ReadLine();
//        //}

//        static int r = 0;
//        static int c = 0;
//        static string[,] matrix;
//        static int maxlength = 0;
//        static int maxi = 0;
//        static int maxj = 0;
//        static void Main(string[] args)
//        {
//            //输入和输出文件读写
//            StreamReader reader = File.OpenText(@"F:\ceshi\matrix1.in");
//            StreamWriter writer = File.CreateText(@"F:\ceshi\matrix1.out");
//            //获取东西的数量
//            String[] matrixInf = reader.ReadLine().Split(" ".ToCharArray());
//            r = int.Parse(matrixInf[0]);
//            c = int.Parse(matrixInf[1]);

//            matrix = new string[r, c];
//            for (int i = 0; i < r; i++)
//            {
//                string[] temp = reader.ReadLine().Split(" ".ToCharArray());
//                for (int j = 0; j < c; j++)
//                {
//                    matrix[i, j] = temp[j];
//                }
//            }

//            int maxSize = CalSquareSize();

//            Console.WriteLine(maxSize);
//            writer.WriteLine(maxSize);

//            //关闭文件流
//            reader.Close();
//            writer.Close();
//            Console.ReadLine();
//        }

//        /// <summary>
//        /// 计算矩阵中最大正方形的大小
//        /// </summary>
//        /// <returns>最大正方形的大小</returns>
//        private static int CalSquareSize()
//        {
//            int maxSquareSize = 0;
//            int maxi = 0;
//            int maxj = 0;
//            for (int i = 0; i < r; i++)
//            {
//                for (int j = 0; j < c; j++)
//                {
//                    //不是横长方形不行。不是偶数不行，差2
//                    if (j < c - maxlength && matrix[i, j] == "1" && matrix[i, j + 1] == "1")
//                    {
//                        if (maxi < i && i < maxi + maxlength && maxj < j && j < maxj + maxlength)
//                        {
//                            continue;
//                        }
//                        else
//                        {
//                            int size = IsSquare(2, i, j);
//                            if (maxlength < Math.Sqrt(IsSquare(2, i, j)))
//                            {
//                                maxlength = (int)Math.Sqrt(IsSquare(2, i, j));
//                                maxi = i;
//                                maxj = j;
//                            }
//                            maxSquareSize = maxSquareSize > size ? maxSquareSize : size;
//                        }
//                    }
//                }
//            }
//            return maxSquareSize;
//        }

//        /// <summary>
//        /// 判断是否是正方形
//        /// </summary>
//        /// <param name="length">长度</param>
//        /// <param name="candicateI">候选x坐标</param>
//        /// <param name="candicateJ">候选y坐标</param>
//        /// <returns>正方形的面积</returns>
//        private static int IsSquare(int length, int candicateI, int candicateJ)
//        {
//            int correctr = candicateI + length > r ? r : candicateI + length;
//            int correctc = candicateJ + length > c ? c : candicateJ + length;
//            for (int i = candicateI; i < correctr; i++)
//            {
//                for (int j = candicateJ; j < correctc; j++)
//                {
//                    //如果是零的话，说明构成了不了正方形
//                    if (matrix[i, j] == "0")
//                    {
//                        length = length > r - candicateI ? r - candicateI : length;

//                        return (length - 1) * (length - 1);
//                    }
//                    else if (i == r - 1 && j == c - 1)
//                    {
//                        length = length > r - candicateI ? r - candicateI : length;
//                        return length * length;
//                    }
//                }
//            }
//            return IsSquare(length + 1, candicateI, candicateJ);
//        }
//    }
//}
