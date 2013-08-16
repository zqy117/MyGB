using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match
{
    //用动态规划法求解0—1背包问题，并输出问题的最优解。 0—1背包问题描述如下：
    //给定m种物品和一背包。物品i的重量是w[i]，其价值为v[i]，背包的容量是c，问应如何选择装入背包中的物品，
    //使得装入背包中物品的总价值最大。(每种物品只能选择放入0/1次背包）  
    public class Knapsack
    {
        public static void knapsack(int[] v, int[] w, int c, int[][] m)
        {

            int n = v.Length - 1;

            /** v[] w[] c 分别是价值、重量数组和背包容量,
             m[i][j]表示只有w[i],w[i+1]...w[n]这些物品时，背包容量为j时的最大价值。*/

            int jMax = Math.Min(w[n] - 1, c);
            for (int j = 0; j <= jMax; j++)
                m[n][j] = 0;        //当w[n]>j 有 m[n][j]=0
            //m[n][j] 表示只有w[n]物品，背包的容量为j时的最大价值
            for (int l = w[n]; l <= c; l++)
                m[n][l] = v[n];  //当w[n]<=j 有m[n][j]=v[n]
            //递规调用求出m[][]其它值，直到求出m[0][c]
            for (int i = n - 1; i >= 1; i--)
            {
                jMax = Math.Min(w[i] - 1, c);
                for (int k = 0; k <= jMax; k++)
                    m[i][k] = m[i + 1][k];

                for (int h = w[i]; h <= c; h++)
                    m[i][h] = Math.Max(m[i + 1][h], m[i + 1][h - w[i]] + v[i]);
            }
            m[0][c] = m[1][c];
            if (c >= w[0])
                m[0][c] = Math.Max(m[0][c], m[1][c - w[0]] + v[0]);
            //System.out.println("bestw ="+m[0][c]);
            Console.WriteLine("bestw =" + m[0][c]);
        }

        public static void traceback(int[][] m, int[] w, int c, int[] x)
        {// 根据最优值求出最优解
            int n = w.Length - 1;
            for (int i = 0; i < n; i++)
                if (m[i][c] == m[i + 1][c])
                    x[i] = 0;
                else
                {
                    x[i] = 1;
                    c -= w[i];
                }
            x[n] = (m[n][c] > 0) ? 1 : 0;
        }


        static void Main(string[] args)
        {
            //测试
            //int[] ww = { 2, 2, 6, 5, 4 };
            //int[] vv = { 6, 3, 5, 4, 6 };

            //重量
            int[] ww = { 3, 4, 5 };

            //价值
            int[] vv = { 4, 5, 6 };

            int[][] mm = new int[11][]; //11
            for (int i = 0; i < 11; i++)
            {
                mm[i] = new int[11];
            }
            knapsack(vv, ww, 10, mm);
            int[] xx = new int[ww.Length];
            traceback(mm, ww, 10, xx);
            for (int i = 0; i < xx.Length; i++)
            {
                Console.WriteLine(xx[i]);
            }
            //System.out.println(xx[i]);

            Console.ReadLine();
        }


    }
}
