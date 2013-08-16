
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ch30_2_Regex
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //IsChengDuTel();
        //    //IsLowerChar();
        //    //IsUpperChar();

        //    //Replace();
        //    //Split();
        //    //ISBN();

        //    //MatchCollection();
        //    //GroupCollection();
        //    //CaptureCollection();
        //    //CaptureCollectionChild();
        //    //StringSearch();

        //    //WriteMatches();





        //    //AnalyzeIISLog();
        //    //AnalyzeIISLog2();
        //    Console.ReadKey();
        //}

        public static void IsChengDuTel()
        {
            string RegexTest = "028\\d{8}";
            string TestSHPhone = "02166666666";
            string TestCDPhone = "02866666666";

            string result = Regex.IsMatch(TestSHPhone, RegexTest).ToString();
            Console.WriteLine(result);
            result = Regex.IsMatch(TestCDPhone, RegexTest).ToString();
            Console.WriteLine(result);
        }

        public static void IsLowerChar()
        {
            string RegexTest = "^[a-z]+$";
            string lower = "aaa";
            string upper = "AAA";

            string result = Regex.IsMatch(lower, RegexTest).ToString();
            Console.WriteLine(result);
            result = Regex.IsMatch(upper, RegexTest).ToString();
            Console.WriteLine(result);
        }


        public static void IsUpperChar()
        {
            string RegexTest = "^[A-Z]+$";
            string lower = "bbb";
            string upper = "BBB";

            string result = Regex.IsMatch(lower, RegexTest).ToString();
            Console.WriteLine(result);
            result = Regex.IsMatch(upper, RegexTest).ToString();
            Console.WriteLine(result);
        }

        public static void Replace()
        {
            // \\是字符串要求转义， 否则编译报错
            string Regextest = "\\w{1,}@\\w{1,}\\.";
            string Email = "liangzhen's E-mail is liangzheng@diyinside.com";
            if (Regex.IsMatch(Email, Regextest))
            {
                Console.WriteLine(Regex.Replace(Email, "@", " AT "));
            }
            else
            {
                Console.WriteLine("无邮箱地址！");
            }

        }

        public static void Split()
        {
            string Regextest = ";";
            string gourpmail = "liangzhen@diyinside.com;webmaster@yanpeng.com;msclub@yaneng.com;din_lz@yaneng.com";

            string[] personmail;
            personmail = Regex.Split(gourpmail, Regextest);
            foreach (string str in personmail)
            {
                Console.WriteLine(str.ToString());
            }

        }

        public static void ISBN()
        {
            string RegexTest = "\\d-\\d{5}-\\d{3}-\\d";
            Regex ISBNRegex = new Regex(RegexTest, RegexOptions.None);
            string temp = "7-80073-798-5";
            if (ISBNRegex.IsMatch(temp))
            {
                Console.WriteLine("合法");
            }
            else { Console.WriteLine("非法"); }


        }

        //Regex  Match MatchCollection 
        public static void MatchCollection()
        {
            MatchCollection mc;
            String[] results = new String[20];
            int[] matchposition = new int[20];
            Regex r = new Regex("abc"); //定义一个Regex对象实例
            mc = r.Matches("123abc4abcd");
            for (int i = 0; i < mc.Count; i++) //在输入字符串中找到所有匹配
            {
                results[i] = mc[i].Value; //将匹配的字符串添在字符串数组中
                matchposition[i] = mc[i].Index; //记录匹配字符的位置
                Console.WriteLine("字符串:" + results[i]);
                Console.WriteLine("位置:" + matchposition[i]);
            }
            //位置  3,7  字符串 abc
        }

        public static void GroupCollection()
        {
            //不明白什么意思？？？
            Regex r = new Regex("(a(b))c"); //定义组
            Match m = r.Match("abdabc");
            Console.WriteLine("Number of groups found = " + m.Groups.Count);
            for (int i = 0; i < m.Groups.Count; i++) //查找每一个组
            {
                Console.WriteLine("Value = " + m.Groups[i]);
            }


        }

        public static void CaptureCollection()
        {
            int counter;
            Match m;
            CaptureCollection cc;
            GroupCollection gc;
            Regex r = new Regex("(Abc)+"); //查找"Abc"
            m = r.Match("XYZAbcAbcAbcXYZAbcAb"); //设定要查找的字符串
            gc = m.Groups;
            //输出查找组的数目
            Console.WriteLine("Captured groups = " + gc.Count.ToString());
            // Loop through each group.
            for (int i = 0; i < gc.Count; i++) //查找每一个组
            {
                cc = gc[i].Captures;
                counter = cc.Count;
                Console.WriteLine("Captures count = " + counter.ToString());
                for (int ii = 0; ii < counter; ii++)
                {
                    // Print capture and position.
                    Console.WriteLine(cc[ii] + " Starts at character " +
                    cc[ii].Index); //输入捕获位置
                }
            }

        }

        public static void CaptureCollectionChild()
        {
            Regex r;
            Match m;
            CaptureCollection cc;
            int posn, length;
            r = new Regex("(abc)*");
            m = r.Match("bcabcabc");
            Console.WriteLine("m.Groups.Count = " + m.Groups.Count);
            for (int i = 0; i < m.Groups.Count; i++)  //m.Groups[i].Value != ""    如果空 ，说明没有值
            {
                cc = m.Groups[i].Captures;
                Console.WriteLine("cc.Count = " + cc.Count);
                for (int j = 0; j < cc.Count; j++)
                {
                    posn = cc[j].Index; //捕获对象位置
                    length = cc[j].Length; //捕获对象长度
                    Console.WriteLine("Index = " + posn);
                    Console.WriteLine("Length = " + length);
                }
            }

        }

        public static void StringSearch()
        {
            String Text = @"I can not find my position in Beijing";
            String Pattern = "ion";
            MatchCollection Matches = Regex.Matches(Text, Pattern, RegexOptions.None);
            foreach (Match NextMatch in Matches)
            { Console.WriteLine(NextMatch.Index); }

            //假定要查找以n开头的字，就可以使用转义序列\b，它表示一个字的边界（字的边界是以某个字母数字标的字符开头，或者后面是一个空白字符或标点符号）
            String Pattern1 = @"\bn";
            MatchCollection Matches1 = Regex.Matches(Text, Pattern1, RegexOptions.IgnoreCase |
            RegexOptions.ExplicitCapture);
            foreach (Match NextMatch1 in Matches)
            { Console.WriteLine(NextMatch1.Index); }

            //如果要查找以序列ion结尾的字
            //String Pattern = @"ion\b";

            //如果要查找以字母n开头，以序列ion结尾的所有字，需要一个以\bn开头，以ion\b结尾的模式
            //String Pattern = @"\bn\S*ion\b";
        }

        static void WriteMatches(string text, MatchCollection matches)
        {
            Console.WriteLine("Original text was: \n\n" + text + "\n");
            Console.WriteLine("No. of matches: " + matches.Count);
            foreach (Match nextMatch in matches)
            {
                int Index = nextMatch.Index;
                string result = nextMatch.ToString();
                int charsBefore = (Index < 5) ? Index : 5;
                int fromEnd = text.Length - Index - result.Length;
                int charsAfter = (fromEnd < 5) ? fromEnd : 5;
                int charsToDisplay = charsBefore + charsAfter + result.Length;
                Console.WriteLine("Index: {0}, \tString: {1}, \t{2}", Index, result,
                text.Substring(Index - charsBefore, charsToDisplay));
            }
        }

        static void Find_po()
        {
            string text = @" I can not find my position in Beijing ";
            string pattern = @"\bpo\S*ion\b";
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase
           | RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture);
            WriteMatches(text, matches);
        }

        String Extension(String url)
        {
            Regex r = new Regex(@"^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/",
            RegexOptions.Compiled);
            return r.Match(url).Result("${proto}${port}");
        }



        private static String text = @"00:41:23 GET /admin_save.asp 202.108.212.39 404 1468 176
01:04:36 GET /userbuding.asp 202.108.212.39 404 1468 176
10:00:59 GET /upfile_flash.asp 202.108.212.39 404 1468 178
12:59:00 GET /cp.php 202.108.212.39 404 1468 168
19:23:04 GET /sqldata.php 202.108.212.39 404 1468 173
23:00:00 GET /Evil-Skwiz.htm 202.108.212.39 404 1468 176
23:59:59 GET /bil.html 202.108.212.39 404 1468 170";
        /// <summary>
        /// 分析IIS日志，提取客户端访问的时间、URL、IP地址及服务器响应代码
        /// </summary>
        public static void AnalyzeIISLog()
        {
            //提取访问时间、URL、IP地址及服务器响应代码的正则表达式
            //大家可以看到关于提取时间部分的子表达式比较复杂，因为做了比较严格的时间匹配限制
            //注意为了简化起见，没有对客户端IP格式进行严格验证，因为IIS访问日志中也不会出现不符合要求的IP地址
            Regex regex = new Regex(@"((0[0-9]|1[0-9]|2[0-3])(:[0-5][0-9]){2})/s(GET)/s([^/s]+)/s(/d{1,3}(/./d{1,3}){3})/s(/d{3})", RegexOptions.None);
            MatchCollection matchCollection = regex.Matches(text);
            for (int i = 0; i < matchCollection.Count; i++)
            {
                Match match = matchCollection[i];
                Console.WriteLine("Match[{0}]========================", i);
                for (int j = 0; j < match.Groups.Count; j++)
                {
                    Console.WriteLine("Groups[{0}]={1}", j, match.Groups[j].Value);
                }
            }
        }



        private static String text2 = @"00:41:23 GET /admin_save.asp 202.108.212.39 404 1468 176
01:04:36 GET /userbuding.asp 202.108.212.39 404 1468 176
10:00:59 GET /upfile_flash.asp 202.108.212.39 404 1468 178
12:59:00 GET /cp.php 202.108.212.39 404 1468 168
19:23:04 GET /sqldata.php 202.108.212.39 404 1468 173
23:00:00 GET /Evil-Skwiz.htm 202.108.212.39 404 1468 176
23:59:59 GET /bil.html 202.108.212.39 404 1468 170";
        /// <summary>
        /// 采用命名捕获组提取IIS日志里的相关信息
        /// </summary>
        public static void AnalyzeIISLog2()
        {
            Regex regex = new Regex(@"(?<time>(0[0-9]|1[0-9]|2[0-3])(:[0-5][0-9]){2})/s(GET)/s(?<url>[^/s]+)/s(?<ip>/d{1,3}(/./d{1,3}){3})/s(?<httpCode>/d{3})", RegexOptions.None);
            MatchCollection matchCollection = regex.Matches(text2);
            for (int i = 0; i < matchCollection.Count; i++)
            {
                Match match = matchCollection[i];
                Console.WriteLine("Match[{0}]========================", i);
                Console.WriteLine("time:{0}", match.Groups["time"]);
                Console.WriteLine("url:{0}", match.Groups["url"]);
                Console.WriteLine("ip:{0}", match.Groups["ip"]);
                Console.WriteLine("httpCode:{0}", match.Groups["httpCode"]);
            }
        }

        /// <summary>
        /// 正则表达式 抓取需要的内容
        /// </summary>
        /// <param name="HtmlCode">HTML代码</param>
        /// <param name="RegexString">正则表达式</param>
        /// <param name="GroupKey">关键字</param>
        /// <returns></returns>
        public static string[] GetRegValue(string HtmlCode, string RegexString, string GroupKey)
        {
            MatchCollection m;
            Regex r;
            r = new Regex(RegexString, RegexOptions.Multiline | RegexOptions.Singleline);
            m = r.Matches(HtmlCode);
            string[] MatchValue = new string[m.Count];
            for (int i = 0; i < m.Count; i++)
            {
                MatchValue[i] = m[i].Groups[GroupKey].Value;
            }
            return MatchValue;
        }


        /// <summary>
        /// 正则表达式 抓取需要的内容(从右向左匹配)
        /// </summary>
        /// <param name="HtmlCode">HTML代码</param>
        /// <param name="RegexString">正则表达式</param>
        /// <param name="GroupKey">关键字</param>
        /// <returns></returns>
        public static string[] GetRegValueByRight(string HtmlCode, string RegexString, string GroupKey)
        {
            MatchCollection m;
            Regex r;
            r = new Regex(RegexString, RegexOptions.RightToLeft | RegexOptions.Multiline | RegexOptions.Singleline);
            m = r.Matches(HtmlCode);
            string[] MatchValue = new string[m.Count];
            for (int i = 0; i < m.Count; i++)
            {
                MatchValue[i] = m[i].Groups[GroupKey].Value;
            }
            return MatchValue;
        }



    }


}
