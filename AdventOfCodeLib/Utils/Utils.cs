using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeLib.Utils
{
    public static class Utils
    {
        public static IEnumerable<T> Intersect<T>(this IEnumerable<IEnumerable<T>> source)
        {
            return source.Aggregate((current, next) => current.Intersect(next));
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, T separator)
        {
            var chunk = new List<T>();
            foreach (var item in source)
            {
                if (Equals(item, separator))
                {
                    yield return chunk;
                    chunk = new List<T>();
                }
                else
                {
                    chunk.Add(item);
                }
            }
            yield return chunk;
        }
    }
}