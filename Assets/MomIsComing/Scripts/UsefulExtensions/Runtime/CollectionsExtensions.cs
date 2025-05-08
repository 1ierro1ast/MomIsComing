using System.Collections.Generic;
using UnityEngine;

namespace MomIsComing.Scripts.UsefulExtensions.Runtime
{
    public static class CollectionsExtensions
     {
         public static T GetRandom<T>(this List<T> list)
         {
             return list.Count == 0 ? default : list[Random.Range(0, list.Count)];
         }
         
         public static T GetRandom<T>(this T[] array)
         {
             return array.Length == 0 ? default : array[Random.Range(0, array.Length)];
         }

         public static void Shuffle<T>(this IList<T> ts)
         {
             var count = ts.Count;
             var last = count - 1;
             for (var i = 0; i < last; ++i)
             {
                 var r = Random.Range(i, count);
                 (ts[i], ts[r]) = (ts[r], ts[i]);
             }
         }
         
         public static IList<T> ShuffleList<T>(this IList<T> ts)
         {
             var count = ts.Count;
             var last = count - 1;
             for (var i = 0; i < last; ++i)
             {
                 var r = Random.Range(i, count);
                 (ts[i], ts[r]) = (ts[r], ts[i]);
             }

             return ts;
         }
     }
 }