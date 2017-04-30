/*Intention.cs (base class)
 * Every program should have some way of
 * meeting a users intent.  
 * The intention class was inspired by the
 * concept of intents, which are found in
 * developing android applications using 
 * Java
 * This class has nothing to do with Android
 * development or Java.  Not yet at least.
 * First Version 
 * created 30 April, 2017 by Nate Wilkins
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroCumulative
{
    class Intention
    {
        public int ID { get; set; }
        public string name { get; set; }

        //Every class needs a method.  Let the options class 
        //be a method to demonstrate how easy it is to 
        //do some work with the console in C#!
        public void Options()
        {

            int response = 500;
            while(response !=0)
            {
                string input;
                Console.WriteLine("1. Change console background color");
                Console.WriteLine("2. Get system information");
                Console.Write("Please make your selection, or type 0 to exit: ");
                input = Console.ReadLine();
                if(int.TryParse(input, out response))
                {
                    switch(response)
                    {
                        case 1:
                            ChangeConsoleColor();
                            break;
                        case 2:
                            break;
                        case 0:
                            break;
                        default:break;
                    }
                }
                else
                {
                    Console.WriteLine("Selection invalid!");
                }
            }

        }
        private void ChangeConsoleColor()
        {
            string input;
            bool success = false;

            while(!success)
            {
                Console.Write("Change console color.  Please enter a color to try: ");
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "red")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    success = true;
                }
                else if (input == "yellow")
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    success = true;
                }
                else if (input == "blue")
                {
                   Console.BackgroundColor = ConsoleColor.Blue;
                    success = true;
                }
                else
                    Console.WriteLine("Sorry, didn't recognize a color");
            }
            
        }
    }
}
