// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;
//using System.Collections.Generic;
using SplashKitSDK;




namespace ShapeDrawer
{
    public class Program
    {

        public static void Main()

        {
            Window window = new Window("Test Window", 800, 600);
            window.Clear(Color.White);

            SplashKit.Delay(5000);

        }
    }
}


