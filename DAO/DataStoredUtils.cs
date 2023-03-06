using bases;
using network;
using persistent;
using persistent.network;
using System;
using System.Collections.Generic;

namespace DAO
{
    public class DataStoredUtils
    {
        public static ICollection<T> findAll<T>(Case cases, Dictionary<Case, List<T>> dic)
        {
            if (dic.ContainsKey(cases))
            {
                return dic[cases];
            }
            else
            {
                return new List<T>();
            }

        }
        public static void add<T>(T general, Case cases, Dictionary<Case, List<T>> dic)
        {
            if (dic.ContainsKey(cases))
            {
                List<T> tList = dic[cases];
                tList.Add(general);
                dic[cases] = tList;
            }
            else
            {
                List<T> tList = new List<T>();
                tList.Add(general);
                dic.Add(cases, tList);
            }

        }
        public static void edit<T>(T general, Case cases, Dictionary<Case, List<T>> dic) where T : BaseEntity
        {
            if (dic.ContainsKey(cases))
            {
                List<T> tList = dic[cases];
                int i = 0;
                foreach (T t in tList)
                {
                    if (t.ID == general.ID)
                    {
                        i = tList.IndexOf(t);
                    }
                }
                tList.RemoveAt(i);
                tList.Insert(i, general);
                dic[cases] = tList;
            }
        }

        public static void remove<T>(T general, Case cases, Dictionary<Case, List<T>> dic)
        {
            if (dic.ContainsKey(cases))
            {
                List<T> tList = dic[cases];
                tList.Remove(general);
                dic[cases] = tList;
            }

        }
        public static void removeAll<T>(Case cases, Dictionary<Case, List<T>> dic)
        {
            if (dic.ContainsKey(cases))
            {
                dic.Remove(cases);
            }
        }

        internal static ICollection<Substations> findAll(object cases, Dictionary<Case, List<YgYgDTransformer>> ygYgDTransformers)
        {
            throw new NotImplementedException();
        }
    }
}
