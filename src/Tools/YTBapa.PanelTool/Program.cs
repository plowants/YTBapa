using System;
using System.Linq;
using System.Collections.Generic;

namespace YTbapa.PanelTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = { -1, 0, 1, 2, -1, -4 };
            //int[] nums = { 0, 0, 0, 0, 0 };
            //int[] nums = { 3, 0, -2, -1, 1, 2 };
            //int[] nums = { 0, 7, -4, -7, 0, 14, -6, -4, -12, 11, 4, 9, 7, 4, -10, 8, 10, 5, 4, 14, 6, 0, -9, 5, 6, 6, -11, 1, -8, -1, 2, -1, 13, 5, -1, -2, 4, 9, 9, -1, -3, -1, -7, 11, 10, -2, -4, 5, 10, -15, -4, -6, -8, 2, 14, 13, -7, 11, -9, -8, -13, 0, -1, -15, -10, 13, -2, 1, -1, -15, 7, 3, -9, 7, -1, -14, -10, 2, 6, 8, -6, -12, -13, 1, -3, 8, -9, -2, 4, -2, -3, 6, 5, 11, 6, 11, 10, 12, -11, -14 };

            //DateTime beg = DateTime.Now;
            //var cs = ThreeSum(nums);
            //DateTime end = DateTime.Now;
            //TimeSpan timeSpan = end - beg;
            //Console.WriteLine($"时长：{timeSpan.TotalMilliseconds},数据量:{cs.Count}");

            //beg = DateTime.Now;
            //var cst = CThreeSum(nums);
            //end = DateTime.Now;
            //timeSpan = end - beg;
            //Console.WriteLine($"时长：{timeSpan.TotalMilliseconds},数据量:{cst.Count}");

            //foreach (var c in cst)
            //{
            //    string from = string.Join(',', c);
            //    Console.WriteLine(from);
            //}

            var iu = LengthOfLongestSubstring("dvdf");
            Console.WriteLine(iu);
            Console.WriteLine("Hello World!");
            //foreach (var c in cs)
            //{
            //    string from = string.Join(',', c);
            //    Console.WriteLine(from);
            //}

            //var list = ProduceRandomPassword();
            //list.ForEach(item =>
            //{
            //    Console.WriteLine(item);
            //});
            Console.Read();
        }

        private static List<string> ProduceRandomPassword()
        {
            List<string> list = new List<string>();
            int j = 0;
            for (int i = 0; i < 10;)
            {
                Random random = new Random();
                int number = random.Next(100000, 999999);
                if (!list.Contains(number.ToString())) { list.Add(number.ToString()); i++; }
                j++;
            }
            Console.WriteLine($"计算次数：{j}");
            return list;
        }

        private static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> lst = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    for (int t = j + 1; t < nums.Length; t++)
                    {
                        if (nums[i] + nums[j] + nums[t] == 0)
                        {
                            List<int> lt = new List<int>();
                            lt.Add(nums[i]);
                            lt.Add(nums[j]);
                            lt.Add(nums[t]);
                            //if (lst.Any(item => string.Join(',', item.OrderBy(c => c)) == string.Join(',', lt.OrderBy(c => c))))
                            //{
                            //    continue;
                            //}
                            lst.Add(lt);
                        }
                    }
                }
            }
            var lsStr = lst.Select(c => string.Join(',', c.OrderBy(it => it))).ToList();
            var str = lsStr.GroupBy(c => c).Select(c => c.Key).ToList();
            IList<IList<int>> newlst = new List<IList<int>>();
            foreach (var item in str)
            {
                newlst.Add(item.Split(',').Select(c => int.Parse(c)).ToList());
            }
            return newlst;
        }
        private static IList<IList<int>> CThreeSum(int[] nums)
        {
            IList<IList<int>> lst = new List<IList<int>>();
            var maxs = nums.Where(c => c > 0).ToList();
            var mins = nums.Where(c => c < 0).ToList();
            var zero = nums.Where(c => c == 0).ToList();
            if (zero.Count > 0)
            {
                if (zero.Count >= 3)
                {
                    lst.Add(new List<int> { 0, 0, 0 });
                }
                if (maxs.Count > 0 && mins.Count > 0)
                {
                    foreach (var item in maxs)
                    {
                        foreach (var it in mins)
                        {
                            if (item + it == 0)
                            {
                                lst.Add(new List<int> { it, 0, item });
                            }
                        }
                    }
                }
            }
            if (maxs.Count > 0 && mins.Count > 0)
            {
                if (maxs.Count > 1)
                {
                    for (int i = 0; i < maxs.Count - 1; i++)
                    {
                        foreach (var item in mins)
                        {
                            if (maxs[i] + maxs[i + 1] + item == 0)
                            {
                                lst.Add(new List<int> { maxs[i], maxs[i + 1], item });
                            }
                        }
                    }
                }
                if (mins.Count > 1)
                {
                    for (int i = 0; i < mins.Count - 1; i++)
                    {
                        foreach (var item in maxs)
                        {
                            if (mins[i] + mins[i + 1] + item == 0)
                            {
                                lst.Add(new List<int> { mins[i], mins[i + 1], item });
                            }
                        }
                    }
                }
            }
            var lsStr = lst.Select(c => string.Join(',', c.OrderBy(it => it))).ToList();
            var str = lsStr.GroupBy(c => c).Select(c => c.Key).ToList();
            IList<IList<int>> newlst = new List<IList<int>>();
            foreach (var item in str)
            {
                newlst.Add(item.Split(',').Select(c => int.Parse(c)).ToList());
            }
            return newlst;
        }

        public static int LengthOfLongestSubstring(string s)
        {
            int len = 0;
            string str = string.Empty;
            char[] ch = s.ToCharArray();
            int newLen = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (str.Contains(ch[i].ToString()))
                {
                    int index = str.IndexOf(ch[i]);
                    if (index == s.Length) { str = string.Empty; }
                    else
                    {
                        str = str.Substring(index + 1);
                    }
                    if (newLen > len)
                    {
                        len = newLen;
                    }
                }
                str = str + ch[i].ToString();
                newLen = str.Length;
                if (len == 0 || (i == s.Length - 1))
                {
                    if (newLen > len)
                    {
                        len = newLen;
                    }
                }
            }
            return len;
        }
    }
}