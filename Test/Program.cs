﻿using System;
using LitePixel;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (Window w = new Window()){
                Console.ReadLine();
                w.DrawAnotherTriangle();
                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}