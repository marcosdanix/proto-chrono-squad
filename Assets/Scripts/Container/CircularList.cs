using System.Collections.Generic;

public class CircularList<T>
{
    public int Count
    {
        get
        {
            return this.list.Count;
        }
    }

    public T this[int index]
    {
        get
        {
            return this.list[(index + this.index) % this.size];
        }
    }

    private List<T> list;
    private int index;
    private int size;

    public CircularList(int size)
    {
        this.list = new List<T>(size);
        this.size = size;
        this.index = 0;
    }

    public void Add(T item)
    {
        if (this.list.Count == this.size)
        {
            this.list[this.index] = item;
            this.index = (this.index + 1) % this.size;
        }
        else
        {
            list.Add(item);
        }
    }


}