
using ProyectoSorting;

Console.WriteLine("How many elements need?");
int elements = int.Parse(Console.ReadLine());

Console.WriteLine("What seed do you want to use?");
int seed = int.Parse(Console.ReadLine());

Random random = new Random(seed);
SortingArray array = new SortingArray(elements, random);
//array.Sort(array.BubbleSortEarlyExit);
//array.Sort(array.QuickShort);
//array.Sort(array.BubbleSort);
//array.Sort(array.InsertionSort);
//array.Sort(array.QuickShort);
//array.Sort(array.SelectionSort);
//array.Sort(array.SelectionSort);
//Console.WriteLine(random.ToString());
//array.Sort(array.BucketSort());