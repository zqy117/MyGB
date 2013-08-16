//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Match
//{
//    //动态规划  最大值
//    public class Triangle
//    {
//        //5
//        //7
//        //3 8
//        //8 1 0
//        //2 7 4 4
//        //4 5 2 6 5
//        //有一个数字三角形，编程求从最顶层到最底层的一条路所经过位置上数字之和的最大值。每一步只能向左下或右下方向走
//        //下图数据的路应为7->3->8->7->5，和为30
//        //输入： 第一行：n(1<=n<=100),数字三角形共有n行；以下R行：依次表示数字三角形中每行中的数字.每个数都是非负的，且<=100. 
//        //输出： 一个正整数，路径上数字之和的最大值     //sanjiao.in
//        static void Main(string[] args)
//        {
//            //StreamReader reader = File.OpenText(@"F:\ceshi\sanjiao2.in");
//            //StreamWriter writer = File.CreateText(@"F:\ceshi\sanjiao2.out");

//            //int num = int.Parse(reader.ReadLine());

//            ////number表示从叶子节点到当前节点的最大值
//            //int[,] number = new int[num, num];
//            ////输入并初始化
//            //for (int i = 0; i < num; i++)
//            //{
//            //    string str = reader.ReadLine();
//            //    string[] strToke = str.Split(" ".ToCharArray());
//            //    for (int j = 0; j <= i; j++)
//            //    {
//            //        number[i, j] = int.Parse(strToke[j]);
//            //    }
//            //}
//            ////状态转移方程,该句是整个动态规划的核心
//            //for (int i = num - 2; i >= 0; i--)
//            //{
//            //    for (int j = 0; j <= i; j++)
//            //    {

//            //        //核心 方程
//            //        //number[3, 0] = Math.Max(number[3 + 1, 0], number[3 + 1, 0 + 1]) + number[3, 0]; 5+2=7
//            //        number[i, j] = Math.Max(number[i + 1, j], number[i + 1, j + 1]) + number[i, j];
//            //        Console.WriteLine("i= {0} ,j= {1} , number= {2}", i, j, number[i, j]);
//            //    }
//            //}

//            //Console.WriteLine(number[0, 0]);
//            //writer.Write(number[0, 0]);
//            //reader.Close();
//            //writer.Close();

//            ////i= 3 ,j= 0 , number= 7
//            ////i= 3 ,j= 1 , number= 12
//            ////i= 3 ,j= 2 , number= 10
//            ////i= 3 ,j= 3 , number= 10
//            ////i= 2 ,j= 0 , number= 20
//            ////i= 2 ,j= 1 , number= 13
//            ////i= 2 ,j= 2 , number= 10
//            ////i= 1 ,j= 0 , number= 23
//            ////i= 1 ,j= 1 , number= 21
//            ////i= 0 ,j= 0 , number= 30

//            //222  输出路径的
//            string[][] trn = ReadTriangle.GetTriangle();
//            Console.WriteLine("toal1=" + trn.Length);
//            //Console.WriteLine("toal2=" + trn[i].length);
//            for (int i = 0; i < trn.Length; i++)
//            {
//                Console.WriteLine("ok=" + trn[i].Length);

//                for (int j = 0; j < trn[i].Length; j++)
//                {
//                    Console.WriteLine(trn[i][j]);

//                }
//            }

//            DynamicSolveTrianglePath dsp = new DynamicSolveTrianglePath();
//            Console.ReadLine();
//        }

//    }

//    /** * 输入文本格式为 * 类似这样一个数字三角形 */
//    public class ReadTriangle
//    {
//        //public static  String TRIANGLE_FILE = "F:\\ceshi\\sanjiao.in";

//        public static String[][] GetTriangle()
//        {
//            String[][] rtn;
//            try
//            {
//                //File f = new File(ReadTriangle.TRIANGLE_FILE);
//                //BufferedReader br = new BufferedReader(new FileReader(f));
//                StreamReader reader = File.OpenText(@"F:\ceshi\sanjiao.in");

//                List<string> l = new List<string>();

//                int num = int.Parse(reader.ReadLine());

//                //String line = reader.ReadLine();

//                //while (line != null)
//                //{
//                //    l.Add(line.Trim());
//                //    line = reader.ReadLine();
//                //}

//                //int heigth = l.Count;

//                int heigth = num;
//                rtn = new String[heigth][];
//                for (int i = 0; i < heigth; i++)
//                {
//                    //String s = (String) l[i];
//                    String s = reader.ReadLine();
//                    String[] tk = s.Split(" ".ToCharArray());
//                    int tklen = tk.Length;
//                    rtn[i] = new String[tklen];
//                    for (int k = 0; k < tklen; k++)
//                    {
//                        rtn[i][k] = tk[k];
//                    }
//                }
//                reader.Close();
//                return rtn;
//            }
//            catch (FileNotFoundException e)
//            {
//                //System.out.println("err1=" + e);
//                Console.WriteLine("err2=" + e);
//            }
//            catch (IOException e)
//            {
//                //System.out.println("err2=" + e);
//                Console.WriteLine("err2=" + e);
//            }
//            return null;
//        }
//    }

//    //节点，主要记录path 路径
//    public class Node
//    {
//        private int value;
//        private List<string> path = new List<string>();

//        public List<string> getPath()
//        {
//            return path;
//        }

//        public void setPath(List<string> p)
//        {
//            path = p;
//        }

//        // n=(0,0) or (0,1) or (2,2)
//        public void addPath(String n)
//        {
//            path.Add(n);
//        }

//        public void addPath(List<string> pa)
//        {
//            path.AddRange(pa);
//        }

//        public int getValue()
//        {
//            return value;
//        }

//        public void setValue(int value)
//        {
//            this.value = value;
//        }
//    }

//    public class DynamicSolveTrianglePath
//    {
//        //二维数组 原始三角形
//        private String[][] str_triangle = null;
//        //计算使用的，并最后获取最大值的节点二维数组，三角形节点数组
//        private Node[][] triangle_nodes = null;

//        //private List<string> nodes;

//        //private List<string> paths;

//        // 节点

//        public DynamicSolveTrianglePath()
//        {
//            initNodes();
//            findPath();
//        }

//        // 从根节点开始,逆向推解出到达所有节点的最佳路径
//        private void initNodes()
//        {
//            this.str_triangle = ReadTriangle.GetTriangle();
//            triangle_nodes = new Node[str_triangle.Length][];
//            //triangle_nodes = new Node[str_triangle.Length, str_triangle[i].length];
//            //nodes = new List<string>();
//            for (int i = 0; i < str_triangle.Length; i++)
//            {
//                triangle_nodes[i] = new Node[str_triangle[i].Length];
//                for (int j = 0; j < str_triangle[i].Length; j++)
//                {
//                    String currentPath = "(" + i + "," + j + ")";
//                    Node n = new Node();
//                    if (i == 0 && j == 0)
//                    {
//                        n.setValue(c(str_triangle[0][0]));
//                        n.addPath(currentPath);
//                        triangle_nodes[i][j] = n;
//                        continue;
//                    }

//                    // 左右边界节点
//                    if ((j == 0 || j == str_triangle[i].Length - 1))
//                    {
//                        if (i == 1)
//                        {
//                            // 第2行的节点
//                            int value = c(str_triangle[0][0])
//                                    + c(str_triangle[i][j]);
//                            List<string> ph = triangle_nodes[0][0].getPath();
//                            n.addPath(ph);
//                            n.addPath(currentPath);
//                            n.setValue(value);
//                            ph = null;
//                        }
//                        else
//                        {
//                            // 0,1行以下的其他边界节点
//                            int value = j == 0 ? c(str_triangle[i][j])
//                                    + triangle_nodes[i - 1][j].getValue()
//                                    : c(str_triangle[i][j])
//                                            + triangle_nodes[i - 1][j - 1]
//                                                    .getValue();
//                            List<string> ph = j == 0 ? triangle_nodes[i - 1][j].getPath()
//                                    : triangle_nodes[i - 1][j - 1].getPath();
//                            n.addPath(ph);
//                            n.addPath(currentPath);
//                            n.setValue(value);
//                        }
//                    }
//                    else
//                    {
//                        // 除边界节点外其他节点  
//                        Node node1 = triangle_nodes[i - 1][j - 1];
//                        Node node2 = triangle_nodes[i - 1][j];
//                        Node bigger = max(node1, node2);
//                        List<string> ph = bigger.getPath();
//                        n.addPath(ph);
//                        n.addPath(currentPath);
//                        int val = bigger.getValue() + c(str_triangle[i][j]);
//                        n.setValue(val);
//                    }

//                    triangle_nodes[i][j] = n;
//                    Console.WriteLine("i={0},j={1} , Path.Count={2}, Value={2} ", i, j, n.getPath().Count, n.getValue());
//                    n = null;
//                }
//            }
//        }

//        private Node max(Node node1, Node node2)
//        {
//            int i1 = node1.getValue();
//            int i2 = node2.getValue();
//            return i1 > i2 ? node1 : node2;
//        }

//        private int c(String s)
//        {
//            return int.Parse(s.Trim());
//        }

//        // 找出最佳路径  根据算出每个节点值的三角形，逐行判断每行最大值，并输出节点下标，直到最后一行，为了路径，必须遍历
//        private void findPath()
//        {
//            if (this.triangle_nodes == null)
//                return;
//            int max = 0;
//            int mi = 0;
//            int mj = 0;
//            for (int i = 0; i < triangle_nodes.Length; i++)
//            {
//                for (int j = 0; j < triangle_nodes[i].Length; j++)
//                {
//                    int t = triangle_nodes[i][j].getValue();
//                    if (t > max)
//                    {
//                        max = t;
//                        mi = i;
//                        mj = j;
//                    }

//                }
//                Console.WriteLine("Max Path:" + triangle_nodes[mi][mj].getPath()[i]);
//                Console.WriteLine("Max Value:" + max);

//            }

//        }

//    }

//}
