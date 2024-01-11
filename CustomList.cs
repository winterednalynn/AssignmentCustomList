using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AssignmentCustomList
{
    public class CustomList<T>
    {
        private T[] items; // T = GENERIC 
        private int count; 

        public CustomList() : this(10) { }

        public CustomList(int initialSize)
        {
            items = new T[initialSize];
        }

        //Explanation: We begin with two constructors, one default and another that allows specifying the initial size. <T> makes our class generic.
        public void Add(T item)
        {
            CheckIntegrity();
            items[count++] = item;
        }
        public void AddAtIndex(T item, int index)
        {
            CheckIntegrity();
            if (index < 0 || index > count) throw new ArgumentOutOfRangeException(nameof(index));
            for (int i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
            items[index] = item;
            count++;
        }
        //Explanation: Add inserts items at the end, while AddAtIndex places items at a specified index. Both methods call CheckIntegrity to ensure there's enough space.

        public bool Remove(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(item))
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        items[j] = items[j + 1];
                    }
                    count--;
                    return true;
                }
            }
            return false;
        }
        //Explanation: Remove searches for an item and, if found, shifts subsequent elements forward.

        private void CheckIntegrity()
        {
            if (count >= 0.8 * items.Length)
            {
                T[] largerArray = new T[items.Length * 2];
                Array.Copy(items, largerArray, count);
                items = largerArray;
            }
        }
        public T GetItem(int index)
        {
            if (index < 0 || index >= count) throw new ArgumentOutOfRangeException(nameof(index));
            return items[index];
        }
        //Explanation: CheckIntegrity ensures the array size is sufficient, expanding it when 80% full. GetItem retrieves an item by index, with bounds checking.

        public int Count => count;
        //Explanation: This property provides the current item count.
    }
}
