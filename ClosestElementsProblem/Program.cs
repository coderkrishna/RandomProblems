﻿// <copyright file="Program.cs" company="TCS Ltd">
// Copyright (c) TCS Ltd. All rights reserved.
// </copyright>

namespace ClosestElementsProblem
{
    using System;

    /// <summary>
    /// This is the main driver class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// This is the main driver method.
        /// </summary>
        /// <param name="args">Project specific arguments.</param>
        public static void Main(string[] args)
        {
            int[] arr = { 12, 16, 22, 30, 35, 39, 42, 45, 48, 50, 53, 55, 56 };

            int n = arr.Length;

            int x = 35;

            PrintKClosest(arr, x, 4, n);

            Console.WriteLine("The program execution has completed, you may now press any key to quit");
            Console.ReadKey();
        }

        /// <summary>
        /// This method will get the k closest elements together.
        /// </summary>
        /// <param name="arr">The array of numbers.</param>
        /// <param name="x">The integer to find.</param>
        /// <param name="k">The number of the closest numbers.</param>
        /// <param name="n">The length of the array.</param>
        public static void PrintKClosest(int[] arr, int x, int k, int n)
        {
            // Finding the crossover point
            int l = FindCrossOver(arr, 0, n - 1, x);

            // Right index to search
            int r = l + 1;

            // Keep track of the count of elements
            int count = 0;

            // If x is present in arr[], then reduce the left index
            // Assumption: all elements in arr[] are distinct
            if (arr[l] == x)
            {
                l--;
            }

            // Compare the elements on the left and right of
            // crossover point to find the k closest elements
            while (l >= 0 && r < n && count < k)
            {
                if (x - arr[l] < arr[r] - x)
                {
                    Console.Write(arr[l--] + " ");
                }
                else
                {
                    Console.Write(arr[r++] + " ");
                }

                count++;
            }

            // If there are no more elements on right side, then
            // print the left side elements
            while (count < k && l >= 0)
            {
                Console.Write(arr[l--] + " ");
                count++;
            }

            // If there are no more elements on left side, then
            // print the right side elements
            while (count < k && r < n)
            {
                Console.Write(arr[r++] + " ");
                count++;
            }
        }

        /// <summary>
        /// This method gets the crossover.
        /// </summary>
        /// <param name="arr">The array.</param>
        /// <param name="low">The lower bound.</param>
        /// <param name="high">The upper bound.</param>
        /// <param name="x">The integer to find.</param>
        /// <returns>The integer value of the crossover.</returns>
        public static int FindCrossOver(int[] arr, int low, int high, int x)
        {
            // Base cases
            // x is greater than all
            if (arr[high] <= x)
                return high;

            // x is smaller than all
            if (arr[low] > x)
                return low;

            // Find the middle point
            int mid = (low + high) / 2;

            // If x is same as middle element, then return mid
            if (arr[mid] <= x && arr[mid + 1] > x)
                return mid;

            // If x is greater than arr[mid], then either arr[mid + 1] is
            // ceiling of x or ceiling lies in arr[mid+1...high]
            if (arr[mid] < x)
                return FindCrossOver(arr, mid + 1, high, x);

            return FindCrossOver(arr, low, mid - 1, x);
        }
    }
}