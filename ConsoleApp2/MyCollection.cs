using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class MyCollection : IList<int>
    {
        private int[] MyList;
        private int count;

        public MyCollection() 
        {
            MyList = new int[10];
            count = 0;
        }

        public int this[int index] 
        {
            get 
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                return MyList[index]; 
            } 
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                if (value <= 0)
                {
                    throw new ArgumentException("The value must be a positive integer. ");
                }

                MyList[index] = value;
            } 
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public void Add(int item)
        {
            if (item <= 0)
            {
                throw new ArgumentException("The value must be a positive integer. ");
            }

            if (count == MyList.Length / 2)
            {
                Array.Resize(ref MyList, MyList.Length * 2);
            }

            MyList[count] = item;
            count++;
        }

        public void Clear()
        {
            Array.Clear(MyList, 0, count);
            count = 0;
        }

        public bool Contains(int item)
        {
            return Array.IndexOf(MyList, item, 0, count) >= 0;
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            Array.Copy(MyList, 0, array, arrayIndex, count);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return MyList[i];
            }
        }

        public int IndexOf(int item)
        {
            return Array.IndexOf(MyList, item, 0, count);
        }

        public void Insert(int index, int item)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException();
            }

            if (item <= 0)
            {
                throw new ArgumentException("The value must be a positive integer. ");
            }

            if (count == MyList.Length)
            {
                Array.Resize(ref MyList, MyList.Length * 2);
            }

            Array.Copy(MyList, index, MyList, index + 1, count - index);
            MyList[index] = item;
            count++;
        }

        public bool Remove(int item)
        {
            int index = IndexOf(item);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            Array.Copy(MyList, index + 1, MyList, index, count - index - 1);
            count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
