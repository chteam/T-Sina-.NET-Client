namespace CHSNS.Rest
{
    using System.Collections.Generic;

    static public class DictionaryExtensions
    {
        public static void AddOther(this IDictionary<string, object> source,IDictionary<string, object> other)
        {
            if (other == null || source == null) return;
            foreach (var o in other)
            {
                if (source.ContainsKey(o.Key))continue;
                source.Add(o.Key, o.Value);
            }
        }
    }
}