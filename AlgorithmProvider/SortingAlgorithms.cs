using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsProvider
{
    public class SortingAlgorithms
    {
        public static void QuickSort(int[] numbers, int a, int b)
        {
            if (a < b)
            {
                int pivot = Partition(numbers, a, b);
                QuickSort(numbers, a, pivot - 1);
                QuickSort(numbers, pivot + 1, b);
            }
        }

        static int Partition(int[] numbers, int a, int b)
        {
            int pivot = numbers[b],
                pIndex = a;

            for (int i = a; i < b; i++)
            {
                if (numbers[i] < pivot)
                {
                    Swap(numbers, i, pIndex++);
                }
            }
            Swap(numbers, pIndex, b);
            return pIndex;
        }

        static void Swap(int[] numbers, int a, int b)
        {
            if(numbers[a] == numbers[b])
                return;
            numbers[a] ^= numbers[b];
            numbers[b] ^= numbers[a];
            numbers[a] ^= numbers[b];
        }


        static void MergeSort(int[] numbers, int[] temp, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                MergeSort(numbers, temp, start, mid);
                MergeSort(numbers, temp, mid + 1, end);
                Merge(numbers, temp, start, mid + 1, end);
            }
        }

        static void Merge(int[] numbers, int[] temp, int start, int mid, int end)
        {
            int left_start = start,
                left_end = mid,
                right_start = mid + 1,
                right_end = end,
                tIndex = start,
                size = (end - start) + 1;
            while (left_start < left_end && right_start < right_end)
            {
                if (numbers[left_start] < numbers[right_start])
                {
                    temp[tIndex++] = numbers[left_start++];
                }else if(numbers[left_start] > numbers[right_start])
                {
                    temp[tIndex++] = numbers[right_start++];
                }
            }
            while(left_start < left_end)
            {
                temp[tIndex++] = numbers[left_start++];
            }
            while(right_start < right_end)
            {
                temp[tIndex++] = numbers[right_start++];
            }
            for(int i = start; i < size; i++)
            {
                numbers[right_end] = temp[right_end--];
            }
        }
        public static void QuickSortMethod()
        {
            int[] iInput = { 4, 5, 60, 43, 23, 1, 5 };
            SortingAlgorithms.QuickSort(iInput, 0, iInput.Length - 1);

            for (int i = 0; i < iInput.Length; i++)
            {
                Console.Write(iInput[i] + " ");
            }

            Console.ReadLine();
        }
    



        

    }
}
