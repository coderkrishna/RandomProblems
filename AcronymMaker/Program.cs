﻿// <copyright file="Program.cs" company="TCS Ltd">
// Copyright (c) TCS Ltd. All rights reserved.
// </copyright>

namespace AcronymMaker
{
    using System;

    /// <summary>
    /// This main driver class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// This is the main driver method.
        /// </summary>
        /// <param name="args">The project specific arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a phrase to abbreviate: ");
            string inputString = Console.ReadLine();

            Abbreviate(inputString);
            Console.WriteLine("Your program has finished execution - you may press any key to exit");
            Console.ReadKey(); 
        }

        /// <summary>
        /// Method that will abbreviate the input and create an acronym.
        /// </summary>
        /// <param name="input">The string to be converted into an acronym.</param>
        /// <returns>The compressed string - basically the acronym.</returns>
        public static string Abbreviate(string input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var parts = input.Split(new char[] { ' ', '-', '_' });

            Console.WriteLine("parts: ");
            string res = "";
            foreach (var p in parts)
            {
                Console.WriteLine(p);
                if (p.Length > 0)
                {
                    res += p.ToUpper()[0]; 
                }
            }

            Console.WriteLine("res: {0}", res);

            return res; 
        }
    }
}