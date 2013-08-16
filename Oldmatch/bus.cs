using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match
{
    // 8 7 11
    //4 3 4
    //6 2 4
    //2 3 2
    //5 6 1
    //2 5 2
    //1 5 5
    //2 1 1
    //3 1 1
    //7 7 1
    //7 4 2
    //8 6 2
    //动态规划  最多乘客
    class Bus
    {
        static List<Station> StationList = new List<Station>();
        static Dictionary<KeyValuePair<int, int>, Tree<Station>> StationDictionary = new Dictionary<KeyValuePair<int, int>, Tree<Station>>();
        static int x = 0;
        static int y = 0;
        static void Main(string[] args)
        {
            StreamReader reader = File.OpenText(@"F:\ceshi\bus1.in");
            StreamWriter writer = File.CreateText(@"F:\ceshi\bus.out");

            //获取东西的数量
            String[] totalInf = reader.ReadLine().Split(" ".ToCharArray());
            x = int.Parse(totalInf[0]);
            y = int.Parse(totalInf[1]);

            //站牌集合            
            while (!reader.EndOfStream)
            {
                //抽出所有的站台
                String[] input = reader.ReadLine().Split(" ".ToCharArray());
                KeyValuePair<int, int> location = new KeyValuePair<int, int>(int.Parse(input[0]), int.Parse(input[1]));
                int count = int.Parse(input[2]);
                StationList.Add(new Station() { StationLocation = location, Count = count });
            }
            Station startStation = new Station() { StationLocation = new KeyValuePair<int, int>(1, 1) { }, Count = 0 };
            Tree<Station> stationTree = new Tree<Station>(startStation);
            //构造站台的树
            CreateTree(stationTree, startStation);

            //stationTree
            //对人数进行统计
            PostOrderTree(stationTree);

            writer.WriteLine(stationTree.Count);


            reader.Close();
            writer.Close();

            Console.ReadLine();
        }

        /// <summary>
        /// 产生二叉树
        /// </summary>
        /// <param name="stationTree">二叉树</param>
        /// <param name="currentStation">当前节点</param>
        private static void CreateTree(Tree<Station> stationTree, Station currentStation)
        {
            List<Station> candidateList = new List<Station>();
            foreach (var station in StationList)
            {
                if (IsValid(currentStation, station))
                {
                    candidateList.Add(station);
                }
            }
            foreach (var station in candidateList)
            {
                if (FindNextNode(station, candidateList))
                {
                    if (!StationDictionary.Keys.Contains(station.StationLocation))
                    {
                        stationTree.Insert(station);
                        CreateTree(stationTree.Nodes[station.StationLocation], station);
                        StationDictionary.Add(station.StationLocation, stationTree.Nodes[station.StationLocation]);
                    }
                    else
                    {
                        stationTree.Nodes.Add(station.StationLocation, StationDictionary[station.StationLocation]);
                    }
                }
            }
        }

        //后序遍历整个树
        public static void PostOrderTree(Tree<Station> root)
        {
            if (root != null && !root.isCount)
            {
                List<int> countList = new List<int>();
                foreach (var node in root.Nodes)
                {
                    //1.5 开始一个树   2.1 开始一个树
                    Console.WriteLine("node.Value=" + node.Value);  //Dictionary<KeyValuePair<int, int>, Tree<T>> nodes
                    Console.WriteLine("node.Value.Count=" + node.Value.Count);
                    PostOrderTree(node.Value);
                    countList.Add(node.Value.Count);
                }
                root.Count += Max(countList);
                root.isCount = true;
            }
        }

        public static bool FindNextNode(Station candidate, List<Station> candidateList)
        {
            foreach (var station in candidateList)
            {
                if (station.CompareTo(candidate) == -1)
                {
                    return false;
                }
            }
            return true;
        }


        private static bool IsValid(Station s1, Station s2)
        {
            if (s2.StationLocation.Key >= s1.StationLocation.Key && s2.StationLocation.Value >= s1.StationLocation.Value && s1.CompareTo(s2) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int Max(List<int> countList)
        {
            int maxCount = 0;
            foreach (int count in countList)
            {
                maxCount = count > maxCount ? count : maxCount;
            }
            return maxCount;
        }
    }

    public class Station : IComparable
    {
        public KeyValuePair<int, int> StationLocation
        {
            set;
            get;
        }

        public int Count
        {
            set;
            get;
        }


        public int CompareTo(object obj)
        {
            Station obj2 = obj as Station;
            if (this.StationLocation.Key == obj2.StationLocation.Key && this.StationLocation.Value == obj2.StationLocation.Value && this.Count == obj2.Count)
            {
                return 0;
            }
            else if (this.StationLocation.Key <= obj2.StationLocation.Key && this.StationLocation.Value <= obj2.StationLocation.Value)
            {
                return -1;
            }
            return 1;
        }
    }

    public class Tree<T> //where 指定T从IComparable<T>继承
    {
        /// <summary>
        /// 定义二叉树
        /// </summary>
        private T data;
        private Dictionary<KeyValuePair<int, int>, Tree<T>> nodes = new Dictionary<KeyValuePair<int, int>, Tree<T>>();
        /// <summary>
        /// 构造函数：定义二叉树的根节点
        /// </summary>
        /// <param name="nodeValue">二叉树的根节点</param>
        public Tree(T nodeValue)
        {
            this.data = nodeValue;
            this.isCount = false;
            this.Count = (nodeValue as Station).Count;
        }
        /// <summary>
        /// 数据节点属性
        /// </summary>
        public T NodeData
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public int Count
        {
            get;
            set;
        }

        public bool isCount
        {
            get;
            set;
        }

        /// <summary>
        /// 树
        /// </summary>
        public Dictionary<KeyValuePair<int, int>, Tree<T>> Nodes
        {
            get { return this.nodes; }
            set { this.nodes = value; }
        }


        public void Insert(T newItem)
        {
            T currentNodeValue = this.NodeData;
            this.Nodes.Add((newItem as Station).StationLocation, new Tree<T>(newItem));
        }
    }

}
