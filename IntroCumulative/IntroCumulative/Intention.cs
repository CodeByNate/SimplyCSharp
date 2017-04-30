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
using System.Management;

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
                            ChangeConsoleBackgroundColor();
                            break;
                        case 2:
                            ShowSystemInformation();
                            break;
                        case 0:
                            break;
                        default:break;
                    }
                }
                else
                {
                    Console.WriteLine("Selection invalid!");
                    response = 500;
                }
            }

        }
        private void ChangeConsoleBackgroundColor()
        {
            string input;
            bool success = false;

            while(!success)
            {
                Console.Write("Change console color.  Please type a color to try: ");
                input = Console.ReadLine();
                input = input.ToLower();
                //Cycle throught the available console colors.  If there's a match, use it!
                foreach (string s in Enum.GetNames(typeof(ConsoleColor)))
                {
                    if(s.ToLower() == input)
                    {
                        ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), s);
                        if (Enum.IsDefined(typeof(ConsoleColor), color))
                            Console.BackgroundColor = color;
                        success = true;
                    }

                }
            }
            
        }
        private void ShowSystemInformation()
        {
            throw new NotImplementedException();
        }
    }
}
