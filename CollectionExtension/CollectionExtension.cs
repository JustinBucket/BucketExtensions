using System;
using System.Collections.Generic;

namespace BucketExtensions.CollectionExtensions
{
    public static class CollectionExtensions
    {
        public static IList<T> Slice<T>(this IList<T> collection, int start, int count)
        {
            var returnCollection = new T[count];
            
            for (int i = start; i < start + count; i++)
            {
                returnCollection[i - start] = collection[i];
            }
            
            return returnCollection;
        }
        
        public static IList<T> Slice<T>(this IList<T> collection, int start)
        {
            var returnCollection = new T[collection.Count - start];

            for (int i = start; i < collection.Count; i++)
            {
                returnCollection[i - start] = collection[i];
            }

            return returnCollection;
        }
    }
}