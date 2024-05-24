using Project_Hotel.View;
using System;

namespace Project_Hotel
{
    class Program
    {
        static void Main(string[] args)
        {

            MainView mainView = new MainView();
            mainView.initialInterface();
            Console.ReadLine();
        }
    }
}
