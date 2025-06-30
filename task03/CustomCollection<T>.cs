namespace task03;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomCollection<T> : IEnumerable<T>
{
    private readonly List<T> _items = new();

    public void Add(T item) => _items.Add(item);
    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerable GetReverseEnumerator() {
        foreach(var item in _items)
        {
            yield return _items[_items.Count - _items.IndexOf(item) - 1];
        }
    }

    public static IEnumerable GenerateSequence(int start, int count)
    {
        for(int i = 1; i <= count; i++) yield return start++;
    }
    
    public IEnumerable FilterAndSort(Func<T, bool> predicate, Func<T, IComparable> keySelector)
    => _items.Where(item => predicate(item)).OrderBy(item => keySelector(item));
}