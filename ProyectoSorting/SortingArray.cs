using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSorting
{
    public class SortingArray
    {
        public int[] array;
        public int[] arrayCreciente;
        public int[] arrayDecreciente;


        public SortingArray(int elementos, Random random)
        {
            array = new int[elementos];
            arrayCreciente = new int[elementos];
            arrayDecreciente = new int[elementos];
            for (int i = 0; i < elementos; i++)
            {
                array[i] = random.Next();
                Console.Write(array[i]);
            }

            Array.Copy(array, arrayCreciente, array.Length);
            Array.Sort(arrayCreciente);
            Array.Copy(arrayCreciente, arrayDecreciente, array.Length);
            Array.Reverse(arrayDecreciente);

            
        }

        //Pasamos por parametro una funcion con la palabra cable Action
        public void Sort(Action<int[]> func)
        {
            Stopwatch time = new Stopwatch();
            int[] temp = new int[array.Length];
            Array.Copy(array,temp,array.Length);
            Console.WriteLine("Metodo de ordenacion utilizado: ");
            Console.WriteLine(func.Method.Name);

            time.Start();

            func(temp);

            time.Stop();

            Console.WriteLine("Initial: " + time.ElapsedMilliseconds + "ms " + time.ElapsedTicks + " ticks");
            
            time.Reset();

            time.Start();

            func(temp);

            time.Stop();
            
            Console.WriteLine("Increasing: " + time.ElapsedMilliseconds + "ms " + time.ElapsedTicks + " ticks");

            Array.Reverse(temp);

            time.Reset();

            time.Start();

            func(temp);

            time.Stop();

            Console.WriteLine("Decreasing: " + time.ElapsedMilliseconds + "ms " + time.ElapsedTicks + " ticks");

        }


        public void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)

                // loop to compare array elements
                for (int j = 0; j < array.Length - i - 1; j++)

                    // compare two adjacent elements
                    // change > to < to sort in descending order
                    if (array[j] > array[j + 1])
                    {

                        // swapping occurs if elements
                        // are not in the intended order
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        
                    }
        }
        public void BubbleSortEarlyExit(int[] array)
        {
            bool ordered = true;
            for (int i = 0; i < array.Length - 1; i++) { 
                ordered = true;
                // loop to compare array elements
                for (int j = 0; j < array.Length - i - 1; j++)

                    // compare two adjacent elements
                    // change > to < to sort in descending order
                    if (array[j] > array[j + 1])
                    {
                        ordered = false;
                        // swapping occurs if elements
                        // are not in the intended order
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                    }
            }
            if (ordered)
                {
                    return;
                }
        }
        
        public void QuickShort(int[] array)
        {
            QuickShort(array, 0, array.Length - 1);
        }
        public void QuickShort(int[] array, int left, int right)
        {
            //Si el elemento de la izquierda es menor seguir ordenando
            if(left < right)
            {
                int pivot = QuickSortPivot(array,left,right);
                QuickShort(array, left, pivot); 
                QuickShort(array, pivot + 1, right);

            }
        }
        public int QuickSortPivot(int[] array, int left, int right)
        {
            //Centro del array
            int pivot = array[(left + right) / 2];
            while (true)
            {
                //Comprobamos que el lado izquierdo con el centro
                while(array[left] < pivot)
                {
                    left++; 
                }

                //Comprobamos que el lado derecho con el centro
                while (array[right] > pivot)
                {
                    right--;
                }
                if (left >= right)
                {
                    return left;
                }
                else
                {
                    //Cambiamos los valores
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    right--;
                    left++;
                }
            }
           
        }

        public void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length/array[0]; i++)
            {
                int firstElement = array[i];
                int backElement = i-1;
                try
                {
                    while (firstElement < array[backElement] && backElement >= 0)
                    {
                        array[backElement + 1] = array[backElement];
                        --backElement;
                    }
                    array[backElement + 1] = firstElement;
                }
                catch (IndexOutOfRangeException e)
                {

                    throw e;
                }
               
            }
        }
        public void SelectionSort(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = min_idx; j < n; j++)
                {
                    if (array[j] < array[min_idx])
                        min_idx = j;

                    int temp = array[min_idx];
                    array[min_idx] = array[i];
                    array[i] = temp;
                }
            }
        }
        public void BucketSort(int[] array)
        {
           

            // 1) Create n empty buckets
            List<int>[] buckets = new List<int>[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                buckets[i] = new List<int>();
            }

            // 2) Put array elements in different buckets
            for (int i = 0; i < array.Length; i++)
            {
                int idx = array[i] * array.Length;
                buckets[(int)idx].Add(array[i]);
            }

            // 3) Sort individual buckets
            for (int i = 0; i < array.Length; i++)
            {
                buckets[i].Sort();
            }

            // 4) Concatenate all buckets into arr[]
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    array[index++] = buckets[i][j];
                }
            }
        }
        public void BucketSort(float[] arr, int n)
        {
            if (n <= 0)
                return;

            // 1) Create n empty buckets
            List<float>[] buckets = new List<float>[n];

            for (int i = 0; i < n; i++)
            {
                buckets[i] = new List<float>();
            }

            // 2) Put array elements in different buckets
            for (int i = 0; i < n; i++)
            {
                float idx = arr[i] * n;
                buckets[(int)idx].Add(arr[i]);
            }

            // 3) Sort individual buckets
            for (int i = 0; i < n; i++)
            {
                buckets[i].Sort();
            }

            // 4) Concatenate all buckets into arr[]
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    arr[index++] = buckets[i][j];
                }
            }
        }
    }
}

