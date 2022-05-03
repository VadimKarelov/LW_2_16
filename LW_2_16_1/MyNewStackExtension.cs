using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_16_1
{
    public static class MyNewStackExtension
    {
        public static List<T> Select<T>(this MyNewStack<T> ms, Func<T, bool> selector)
        {
            List<T> res = new List<T>();
            foreach (var item in ms)
            {
                if (selector(item))
                {
                    res.Add(item);
                }
            }
            return res;
        }

        // классический вариант Select() из Linq
        public static List<OutT> Select<T, OutT>(this MyNewStack<T> ms, Func<T, OutT> selector)
        {
            List<OutT> res = new List<OutT>();
            foreach (var item in ms)
            {
                res.Add(selector(item));
            }
            return res;
        }

        public static int Count<T>(this MyNewStack<T> ms, Func<T, bool> predicate)
        {
            int res = 0;
            foreach (var item in ms)
            {
                if (predicate(item))
                {
                    res++;
                }
            }
            return res;
        }

        public static double Average<T>(this MyNewStack<T> ms) where T : Organization
        {
            if (ms.Count > 0)
            {
                return ms.Average(x => x.AverageSalary);
            }
            else
            {
                throw new Exception("Collection empty");
            }
        }

        public static double Min<T>(this MyNewStack<T> ms) where T : Organization
        {
            if (ms.Count > 0)
            {
                return ms.Min(x => x.AverageSalary);
            }
            else
            {
                throw new Exception("Collection empty");
            }
        }

        public static double Max<T>(this MyNewStack<T> ms) where T : Organization
        {
            if (ms.Count > 0)
            {
                return ms.Max(x => x.AverageSalary);
            }
            else
            {
                throw new Exception("Collection empty");
            }
        }

        public static double Sum<T>(this MyNewStack<T> ms) where T : Organization
        {
            if (ms.Count > 0)
            {
                return ms.Sum(x => x.AverageSalary);
            }
            else
            {
                throw new Exception("Collection empty");
            }
        }

        public static List<IGrouping<string, T>> Group<T>(this MyNewStack<T> ms) where T : Organization
        {
            if (ms.Count > 0)
            {
                return ms.GroupBy(x => x.City).ToList(); ;
            }
            else
            {
                throw new Exception("Collection empty");
            }
        }

        public static MyNewStack<T> ToMyNewStack<T>(this IEnumerable<T> collection)
        {
            MyNewStack<T> res = new MyNewStack<T>();
            foreach (var item in collection)
            {
                res.Push(item);
            }
            return res;
        }
    }
}
