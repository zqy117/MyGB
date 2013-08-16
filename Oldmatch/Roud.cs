using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Match
{
    // 3
    //7
    //6 7
    //4 7 3 6
    //1 2 3 5
    public class Round
    {
        // 每条线路每个站点都建一个点（不同线路的同一个站也看成不同的点）。
        //然后同一条线路上点和点之间连边，边权为0。不同线路的同一个站之间也连边，边权为1。
        //然后一个源点s连到所有起始站点（虽然实际起始点只有一个，但是我们建模有多个点，这里指建模的多个点），边权为0。
        //  所有到达站点连边到t，边权也为0。最后s到t最短路径求出来就是答案了。
        static void Main(string[] args)
        {
            //m条线路  n个站  1-n结束   求 换车次数 2  动态规划可以解决 画图分析  数组承载 
            //不是有向图最短路径 因为  没有权重  但可以给换程站增加权重，求最短路，  普通权重1   换程权重10  思路不对

            StreamReader reader = File.OpenText(@"F:\ceshi\round1.in");
            StreamWriter writer = File.CreateText(@"F:\ceshi\round1.out");
            int xianLu = int.Parse(reader.ReadLine());
            int zhanDian = int.Parse(reader.ReadLine());

            //加顶点
            Graph theGraph = new Graph(zhanDian + 1);
            for (int i = 1; i <= zhanDian; i++)
            {
                theGraph.AddVertex(i.ToString());
            }
            //特殊顶点
            theGraph.AddVertex("s");
            theGraph.AddVertex("t");

            //加边权0
            int[][] stationArray = new int[zhanDian][];
            for (int i = 0; i < xianLu; i++)
            {

                string stations = reader.ReadLine();
                string[] sta =  stations.Split("".ToCharArray());
                for(int j = 0; j < sta.Length; j++)
                {
                    stationArray[i][j] = int.Parse(sta[j]);
                }

                for (int j = 0; j < stationArray[i].Length - 1; j++)
                {
                    theGraph.AddEdge(stationArray[i][j], stationArray[i][j + 1], 0);
                }

            }

           //特殊边
            for (int i = 0; i < xianLu; i++)
            {
                theGraph.AddEdge(0, stationArray[i][0], 0);
                theGraph.AddEdge(stationArray[i][stationArray[i].Length], zhanDian, 0);
            }

            //加边权1
            int count = 0;
            int current;
            for (int k = 0; k < xianLu; k++)
            {
                for (int g = 0; g < xianLu; g++)
                {
                    current = stationArray[k][g];

                    //加边权1
                    for (int i = 0; i < xianLu; i++)
                    {
                        for (int j = 0; j < stationArray[i].Length - 1; j++)
                        {
                            if (current == stationArray[i][j])
                            {
                                theGraph.AddEdge(stationArray[i][j], stationArray[i][j],1);
                                count++;
                            }
                        }
                    }

                }
            }
            
            int[] path = new int[zhanDian + 1];
            int rrr = theGraph.GetShortedPath(path);
            Console.WriteLine("最短路径长度:" + rrr);
            reader.Close();
            writer.Close();
            Console.ReadLine();

        }

        //有方向 不对  应该 AB  ADCE 10+60   结果给的ABCE AD  30 +70   ？？？
        public void GraphDijkstra2()
        {
            Graph theGraph = new Graph(5);
            theGraph.AddVertex("A");  //0
            theGraph.AddVertex("B");  //1
            theGraph.AddVertex("C");  //2
            theGraph.AddVertex("D");  //3
            theGraph.AddVertex("E");  //4
            theGraph.AddEdge(0, 1, 10);
            theGraph.AddEdge(0, 3, 30);
            theGraph.AddEdge(0, 4, 100);
            theGraph.AddEdge(1, 2, 50);
            theGraph.AddEdge(2, 4, 10);
            theGraph.AddEdge(3, 2, 20);
            theGraph.AddEdge(3, 4, 60);

            //Console.WriteLine("最短路径：");
            int[] path = new int[5];
            int rrr = theGraph.GetShortedPath(path);

            Dictionary<int, string> dir = new Dictionary<int, string>();
            dir.Add(0, "A"); dir.Add(1, "B"); dir.Add(2, "C"); dir.Add(3, "D"); dir.Add(4, "E");

            Console.WriteLine("最短路径长度:" + rrr);
            Console.Write("最短路径: ");
            for (int i = 0; i < path.Length; i++)
            {
                Console.Write(dir[path[i]] + " ");
                if (path[i] == path.Length - 1)
                {
                    break;
                }
            }
        }


    }

    public class Vertex
    {
        public string label;
        public bool isInTree;
        public Vertex(string lab)
        {
            label = lab;
            isInTree = false;
        }
    }
    public class DistOriginal
    {
        public int distance;
        public int parentVert;

        public DistOriginal(int pv, int d)
        {
            distance = d;
            parentVert = pv;
        }
    }
    public class Graph
    {
        private int max;
        int infinity = 1000000;
        Vertex[] vertexList;
        int[,] adjMat;
        int nVerts;
        int nTree;
        DistOriginal[] sPath;
        int currentVert;
        int startToCurrent;
        public Graph(int max_verts)
        {
            this.max = max_verts;
            vertexList = new Vertex[max_verts];
            adjMat = new int[max_verts, max_verts];
            nVerts = 0;
            nTree = 0;
            for (int j = 0; j <= max_verts - 1; j++)
            {
                for (int k = 0; k <= max_verts - 1; k++)
                {
                    adjMat[j, k] = infinity;
                }
            }
            sPath = new DistOriginal[max_verts];
        }
        public void AddVertex(string lab)
        {
            vertexList[nVerts] = new Vertex(lab);
            nVerts++;
        }
        public void AddEdge(int start, int theEnd, int weight)
        {
            adjMat[start, theEnd] = weight;
        }

        //从某一源点出发，找到到某一结点的最短路径
        public int GetShortedPath(int[] path)
        {
            int end = max - 1;
            int start = 0;
            int[,] G = adjMat;
            int MaxSize = 1000;
            int length = max;
            bool[] s = new bool[length]; //表示找到起始结点与当前结点间的最短路径
            int min;  //最小距离临时变量
            int curNode = 0; //临时结点，记录当前正计算结点
            int[] dist = new int[length];
            int[] prev = new int[length];

            //初始结点信息
            for (int v = 0; v < length; v++)
            {
                s[v] = false;
                dist[v] = G[start, v];
                if (dist[v] > MaxSize)
                    prev[v] = 0;
                else
                    prev[v] = start;
            }
            path[0] = end;
            dist[start] = 0;
            s[start] = true;
            //主循环
            for (int i = 1; i < length; i++)
            {
                min = MaxSize;
                for (int w = 0; w < length; w++)
                {
                    if (!s[w] && dist[w] < min)
                    {
                        curNode = w;
                        min = dist[w];
                    }
                }

                s[curNode] = true;

                for (int j = 0; j < length; j++)
                    if (!s[j] && min + G[curNode, j] < dist[j])
                    {
                        dist[j] = min + G[curNode, j];
                        prev[j] = curNode;
                    }

            }
            //输出路径结点
            int e = end, step = 0;
            while (e != start)
            {
                step++;
                path[step] = prev[e];
                e = prev[e];
            }
            for (int i = step; i > step / 2; i--)
            {
                int temp = path[step - i];
                path[step - i] = path[i];
                path[i] = temp;
            }
            return dist[end];
        }



    }



    ////有向图接口类
    //public interface IDireGraph<T>
    //{
    //    int GetNumOfVertex();      //获取顶点的数目
    //    int GetNumOfArc();         //获取弧的数目
    //    bool IsGvNode(GvNode<T> v);     //v是否为图的顶点
    //    int GetIndex(GvNode<T> v);      //获得顶点V在顶点数组中的索引
    //    void SetArc(GvNode<T> v1, GvNode<T> v2, int v);    //在顶点v1和v2之间添加权值为v的弧
    //    void DelArc(GvNode<T> v1, GvNode<T> v2);   //删除顶点v1和v2之间的弧
    //    bool IsArc(GvNode<T> v1, GvNode<T> v2);    //判断v1和v2之间是否存在弧
    //}

    //public class GvNode<T>
    //{
    //    private T data;
    //    public T Data
    //    {
    //        get
    //        {
    //            return data;
    //        }
    //        set
    //        {
    //            data = value;
    //        }
    //    }
    //    public GvNode(T val)
    //    {
    //        data = val;
    //    }
    //}

    ////有向网邻接矩阵类(Directed Net Adjacency Matrix Class)
    //public class DireNetAdjMatrix<T> : IDireGraph<T>
    //{
    //   // Fields
    //    private GvNode<T>[] nodes;  //有向网的顶点数组
    //    private int numArcs;        //弧的数目
    //    private int[,] matrix;      //邻接矩阵数组
    //   // Constructor
    //    public DireNetAdjMatrix(int n)
    //    {
    //        nodes = new GvNode<T>[n];
    //        matrix = new int[n, n];

    //        for (int i = 0; i < n; i++)
    //        {
    //            for (int j = 0; j < n; j++)
    //            {
    //                SetMatrix(i, j, 2000);
    //            }
    //        }

    //        numArcs = 0;
    //    }
    //   // Properties
    //    public GvNode<T> GetGvNode(int index)
    //    {
    //        return nodes[index];
    //    }
    //    public void SetGvNode(int index, GvNode<T> v)
    //    {
    //        nodes[index] = v;
    //    }
    //    public int NumArcs
    //    {
    //        get
    //        {
    //            return numArcs;
    //        }
    //        set
    //        {
    //            numArcs = value;
    //        }
    //    }
    //    public int GetMatrix(int index1, int index2)
    //    {
    //        return matrix[index1, index2];
    //    }
    //    public void SetMatrix(int index1, int index2, int v)
    //    {
    //        matrix[index1, index2] = v;
    //    }
    //   // Base methods
    //    public int GetNumOfVertex()
    //    {
    //        return nodes.Length;
    //    }
    //    public int GetNumOfArc()
    //    {
    //        return numArcs;
    //    }
    //    public bool IsGvNode(GvNode<T> v)
    //    {
    //        foreach (GvNode<T> nd in nodes)
    //        {
    //            if (nd.Equals(v))
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }
    //    public int GetIndex(GvNode<T> v)
    //    {
    //        int i = -1;
    //        for (i = 0; i < nodes.Length; ++i)
    //        {
    //            if (nodes[i].Equals(v))
    //            {
    //                return i;
    //            }
    //        }
    //        return i;
    //    }
    //    public void SetArc(GvNode<T> v1, GvNode<T> v2, int v)
    //    {
    //        if (!IsGvNode(v1) || !IsGvNode(v2))
    //        {
    //            Console.WriteLine("GvNode is not belong to Graph!");
    //            return;
    //        }
    //        if (v != 0)
    //        {
    //            matrix[GetIndex(v1), GetIndex(v2)] = v;
    //            ++numArcs;
    //        }
    //        else
    //        {
    //            Console.WriteLine("Weight is not right!");
    //            return;
    //        }
    //    }
    //    public void DelArc(GvNode<T> v1, GvNode<T> v2)
    //    {
    //        if (!IsGvNode(v1) || !IsGvNode(v2))
    //        {
    //            Console.WriteLine("GvNode is not belong to Graph!");
    //            return;
    //        }
    //        if (matrix[GetIndex(v1), GetIndex(v2)] != 0)
    //        {
    //            matrix[GetIndex(v1), GetIndex(v2)] = 0;
    //            --numArcs;
    //        }
    //        else
    //        {
    //            Console.WriteLine("Arc is not existent!");
    //            return;
    //        }
    //    }
    //    public bool IsArc(GvNode<T> v1, GvNode<T> v2)
    //    {
    //        if (!IsGvNode(v1) || !IsGvNode(v2))
    //        {
    //            Console.WriteLine("GvNode is not belong to Graph!");
    //            return false;
    //        }
    //        if (matrix[GetIndex(v1), GetIndex(v2)] != 0)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //   // 狄克斯特拉算法(最短路径问题(Shortest Path))
    //    public void Dijkstra(ref bool[,] pathMatrixArr, ref int[] shortPathArr, GvNode<T> n)
    //    {
    //        int k = 0;
    //        bool[] final = new bool[nodes.Length];
    //       // 初始化
    //        for (int i = 0; i < nodes.Length; ++i)
    //        {
    //            final[i] = false;
    //            shortPathArr[i] = matrix[GetIndex(n), i];
    //            for (int j = 0; j < nodes.Length; ++j)
    //            {
    //                pathMatrixArr[i, j] = false;
    //            }
    //            if (shortPathArr[i] != 0 && shortPathArr[i] < int.MaxValue)
    //            {
    //                pathMatrixArr[i, GetIndex(n)] = true;
    //                pathMatrixArr[i, i] = true;
    //            }
    //        }
    //      //  n为源点
    //        shortPathArr[GetIndex(n)] = 0;
    //        final[GetIndex(n)] = true;
    //       // 处理从源点到其余顶点的最短路径
    //        for (int i = 0; i < nodes.Length; ++i)
    //        {
    //            int min = int.MaxValue;
    //           // 比较从源点到其余顶点的路径长度
    //            for (int j = 0; j < nodes.Length; ++j)
    //            {
    //               // 从源点到j顶点的最短路径还没有找到
    //                if (!final[j])
    //                {
    //                 //   从源点到j顶点的路径长度最小
    //                    if (shortPathArr[j] < min)
    //                    {
    //                        k = j;
    //                        min = shortPathArr[j];
    //                    }
    //                }
    //            }
    //          //  从源点到顶点k的路径长度最小
    //            final[k] = true;
    //           // 更新当前最短路径及距离
    //            for (int j = 0; j < nodes.Length; ++j)
    //            {
    //                if (!final[j] && (min + matrix[k, j] < shortPathArr[j]))
    //                {
    //                    shortPathArr[j] = min + matrix[k, j];
    //                    for (int w = 0; w < nodes.Length; ++w)
    //                    {
    //                        pathMatrixArr[j, w] = pathMatrixArr[k, w];
    //                    }
    //                    pathMatrixArr[j, j] = true;
    //                }
    //            }
    //        }
    //    }

    //}


    //class Roud
    //{

    //    static void Main(string[] args)
    //    {
    //        StreamReader reader = File.OpenText("roud.in");
    //        StreamWriter writer = File.CreateText("roud.out");
    //        int m_xianlu = int.Parse(reader.ReadLine());
    //        int n_chezhan = int.Parse(reader.ReadLine());

    //        Dictionary<int, int[]> dics = new Dictionary<int, int[]>();

    //        for (int j = 0; j < m_xianlu; j++)
    //        {
    //            String[] values = reader.ReadLine().Split(" ".ToCharArray());
    //            //67  1235  4736
    //            int[] seq = new int[values.Count()];
    //            for (int i = 0; i < values.Count(); i++)
    //            {
    //                seq[i] = int.Parse(values[i]);
    //            }
    //            dics.Add(j, seq);
    //        }

    //        DireNetAdjMatrix<int> dgam = new DireNetAdjMatrix<int>(n_chezhan);

    //        for (int i = 0; i < n_chezhan; i++)
    //        {
    //            dgam.SetGvNode(i, new GvNode<int>(i));

    //        }

    //        foreach (KeyValuePair<int, int[]> zhan in dics)
    //        {
    //            int[] temp = zhan.Value;
    //            for (int i = 0; i < temp.Count() - 1; i++)
    //            {
    //                dgam.SetArc(dgam.GetGvNode(temp[i] - 1), dgam.GetGvNode(temp[i + 1] - 1), 1);
    //            }
    //        }

    //        bool[,] pathMatrixArr = new bool[n_chezhan, n_chezhan];
    //        int[] shortPathArr = new int[n_chezhan];
    //        dgam.Dijkstra(ref pathMatrixArr, ref shortPathArr, dgam.GetGvNode(0));

    //        Console.WriteLine(pathMatrixArr);
    //        Console.WriteLine(shortPathArr);

    //        bool[] my = new bool[n_chezhan];
    //        int[] my2 = new int[n_chezhan];
    //        int count = 0;
    //        for (int i = 0; i < n_chezhan; i++)
    //        {
    //            my[i] = pathMatrixArr[n_chezhan - 1, i];
    //            if (my[i] == true)
    //            {
    //                my2[i] = i;
    //                count++;
    //            }
    //        }

    //        int result = n_chezhan % count;

    //        //12367


    //        //List<int[]> mylist = new List<int[]>();
    //        //foreach (KeyValuePair<int, int[]> zhan in dics)
    //        //{
    //        //    mylist.Add(zhan.Value);
    //        //}


    //        //for (int i = 0; i < mylist.Count(); i++)
    //        //{
    //        //   mylist[i]
    //        //}

    //        //for (int i = 0; i < my2.Count(); i++)
    //        //{


    //        //}

    //        //int result = shortPathArr[n_chezhan - 1];

    //        writer.WriteLine(result);

    //        reader.Close();
    //        writer.Close();
    //    }


    //var va = new GvNode<int>(0);
    //var vb = new GvNode<int>(1);
    //var vc = new GvNode<int>(2);
    //var vd = new GvNode<int>(3);
    //var ve = new GvNode<int>(4);
    //var vf = new GvNode<int>(5);
    //var vg = new GvNode<int>(6);

    //dgam.SetGvNode(0, va);
    //dgam.SetGvNode(1, vb);
    //dgam.SetGvNode(2, vc);
    //dgam.SetGvNode(3, vd);
    //dgam.SetGvNode(4, ve);
    //dgam.SetGvNode(5, vf);


    //dgam.SetArc(va, vc, 5);
    //dgam.SetArc(vb, va, 2);
    //dgam.SetArc(vb, ve, 8);
    //dgam.SetArc(vc, vb, 15);
    //dgam.SetArc(vc, vf, 7);
    //dgam.SetArc(ve, vd, 4);
    //dgam.SetArc(vf, vd, 10);
    //dgam.SetArc(vf, ve, 18);

    //}



}

