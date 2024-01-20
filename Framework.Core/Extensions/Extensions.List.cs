using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core
{
    /// <summary>
    /// Contains List Extension Methods 
    /// </summary>
    public static partial class Extensions
    {
        #region| Methods |
        
        /// <summary>
        /// Move an item within the generic list
        /// </summary>
        /// <param name="List">The value.</param>
        /// <param name="oldIndex">Old Index</param>
        /// <param name="newIndex">New Index</param>
        public static void Move<T>(this List<T> @List, int oldIndex, int newIndex)
        {
            if (@List.IsNull() || (oldIndex == newIndex) || (0 > oldIndex) || (oldIndex >= @List.Count) || (0 > newIndex) || (newIndex >= @List.Count))
            {
                return;
            }

            var i = 0;
            T tmp = @List[oldIndex];

            if (oldIndex < newIndex)
            {
                for (i = oldIndex; i < newIndex; i++)
                {
                    @List[i] = @List[i + 1];
                }
            }
            else
            {
                for (i = oldIndex; i > newIndex; i--)
                {
                    @List[i] = @List[i - 1];
                }
            }

            @List[newIndex] = tmp;
        }

        /// <summary>
        /// Determines whether the Generic List is null or empty.
        /// </summary>
        /// <param name="List">The value.</param>
        /// <returns>
        /// 	true if the specified value is null; otherwise, false.
        /// </returns>
        public static bool IsNull<T>(this List<T>? @List)
        {
            if (@List == null || @List.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the Generic List is not null and not empty.
        /// </summary>
        /// <param name="List">The value.</param>
        /// <returns>
        /// 	true if the specified value is null; otherwise, false.
        /// </returns>
        public static bool IsNotNull<T>(this List<T> @List)
        {
            return !@List.IsNull();
        }

        /// <summary>
        /// Adds itens to the end of the System.Collections.Generic.List.
        /// </summary>
        /// <typeparam name="T">param type definition</typeparam>
        /// <param name="List">Generic List</param>
        /// <param name="items">param collection</param>
        public static void AddItems<T>(this List<T> @List, params T[] items)
        {
            if (items==null)
            {
                return;
            }
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    var item = items[i];

                    if (item.IsNotNull())
                    {
                        @List.Add(item);
                    }
                }
            }
        }

        /// <summary>
        /// AddRange of items of same type to IList 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="List"></param>
        /// <param name="items"></param>
        public static void AddRange<T>(this List<T> @List, List<T> items)
        {
            if (@List == null || items == null)
            {
                return;
            }

            foreach (T item in items)
            {
                @List.Add(item);
            }
        }

        /// <summary>
        /// Adds an item to the collection if it isn't already in the collection
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="List">Collection to add to</param>
        /// <param name="Item">Item to add to the collection</param>
        /// <param name="oPredicate">Predicate that an item needs to satisfy in order to be added</param>
        /// <returns>True if it is added, false otherwise</returns>
        private static void AddIf<T>(this List<T> @List, T Item, Predicate<T> oPredicate)
        {
            if (@List!=null && oPredicate.IsNotNull())
            {
                if (@List.Exists(oPredicate) == false)
                {
                    @List.Add(Item);
                }
            }
        }

        /// <summary>
        /// Adds an item to the collection if it isn't already in the collection
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="List">Collection to add to</param>
        /// <param name="Items">Items to add to the collection</param>
        /// <param name="oPredicate">Predicate that an item needs to satisfy in order to be added</param>
        /// <returns>True if it is added, false otherwise</returns>
        private static void AddIf<T>(this List<T> @List, List<T> Items, Predicate<T> oPredicate)
        {
            if (@List!=null && oPredicate.IsNotNull())
            {
                foreach (T Item in Items)
                {
                    @List.AddIf(Item, oPredicate);
                }
            }
        }
        
        /// <summary>
        /// Adds an item to the collection if it isn't already in the collection
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="List">Collection to add to</param>
        /// <param name="Item">Item to add to the collection</param>
        /// <returns>True if it is added, false otherwise</returns>
        public static void AddIfNotExists<T>(this List<T> @List, T Item)
        {
            if (@List!=null)
            {
                @List.AddIf(Item, x => !@List.Contains(x));
            }
        }

        /// <summary>
        /// Adds an item to the collection if it isn't already in the collection
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="List">Collection to add to</param>
        /// <param name="Items">Items to add to the collection</param>
        /// <returns>True if it is added, false otherwise</returns>
        public static void AddIfNotExists<T>(this List<T> @List, List<T> Items)
        {
            if (@List != null)
            {
                @List.AddIf(Items, x => !@List.Contains(x));
            }
        }

        /// <summary>
        /// If the collection is null, returns an empty collection
        /// </summary>
        /// <typeparam name="T">paramtype</typeparam>
        /// <param name="List">Generic Collection List</param>
        /// <returns>Returns an empty System.Collections.Generic.IEnumerable<![CDATA[<T>]]>> that has the specified type argument.</returns>
        public static List<T> EmptyIfNull<T>(this List<T> @List)
        {
            return @List ?? Enumerable.Empty<T>().ToList();
        }


        /// <summary>
        ///   Determines whether a List contains all elements in the string sequence
        /// </summary>
        /// <param name="List">List of String</param>
        /// <param name="items">string sequence</param>
        /// <returns>bool</returns>
        public static bool ContainsAll(this List<string> @List, params string[] items)
        {
            var Has = true;

            foreach (var item in items)
            {
                if (@List.Contains(item, StringComparer.InvariantCultureIgnoreCase) == false)
                {
                    Has = false;
                    break;
                }
            }

            return Has;
        }

        /// <summary>
        ///   Determines whether a List doesn't contain all elements in the string sequence
        /// </summary>
        /// <param name="List">List of String</param>
        /// <param name="items">string sequence</param>
        /// <returns>bool</returns>
        public static bool NotContainsAll(this List<string> @List, params string[] items)
        {
            return !ContainsAll(@List, items);
        }

        /// <summary>
        ///   Determines whether a List<![CDATA[<T>]]> contains all elements in the sequence <![CDATA[<T>]]>
        /// </summary>
        /// <param name="List">List of <![CDATA[<T>]]></param>
        /// <param name="items"><![CDATA[<T>]]> sequence</param>
        /// <returns>bool</returns>
        public static bool ContainsAll<T>(this List<T> @List, params T[] items)
        {
            var Has = true;

            foreach (var item in items)
            {
                if (@List.Contains(item) == false)
                {
                    Has = false;
                    break;
                }
            }

            return Has;
        }

        /// <summary>
        ///   Determines whether a List <![CDATA[<T>]]> doesn't contain all elements in the sequence <![CDATA[<T>]]>
        /// </summary>
        /// <param name="List">List of <![CDATA[<T>]]></param>
        /// <param name="items"><![CDATA[<T>]]> sequence</param>
        /// <returns>bool</returns>
        public static bool NotContainsAll<T>(this List<T> @List, params T[] items)
        {
            return !ContainsAll(@List, items);
        }

        /// <summary>
        /// Convert an ienumerable into a list if it is not null
        /// </summary>
        /// <typeparam name="T">param type</typeparam>
        /// <param name="List"></param>
        /// <returns></returns>
        public static List<T> ToListIfNotNull<T>(this IEnumerable<T> @List)
        {
            return (@List != null ? new List<T>(@List) : null);
        }

        #endregion
    }
}
