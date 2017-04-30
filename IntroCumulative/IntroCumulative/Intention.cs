/*Intention.cs (base class)
 * Every program should have some way of
 * meeting a users intent.  
 * The intention class was inspired by the
 * concept of intents, which are found in
 * developing android applications using 
 * Java
 * This class has nothing to do with Android
 * development or Java.  Not yet at least.
 * All this class does is provide some methods
 * which demonstrate some of the possibilites
 * of working from the console!
 * First Version 
 * created 30 April, 2017 by Nate Wilkins
 * */

using System;
//Add references for GetDesktopScreenshot (thanks Bedford on Stackoverflow)
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

namespace IntroCumulative
{
    class Intention
    {
        //Imports for the Bedford inclusion
        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hdc, uint nFlags);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr handle, ref Rectangle rect);

        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);
        //end of imports for the Bedford inclusion

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
                Console.WriteLine("3. Get a screenshot of the desktop");
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
                        case 3:
                            GetDesktopScreenshot();
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("Invalid entry!");
                            break;
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
                Console.WriteLine("Change console background color.");
                Console.Write("Please type a color to try: ");
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
                        break;
                    }
                }
            }
            
        }
        private void ShowSystemInformation()
        {
            throw new NotImplementedException();
        }

        //Thanks Bedford on StackOverflow
        //Code retrieved from:
        //http://stackoverflow.com/questions/25500137/get-a-screenshot-of-desktop-in-full-screen-3d-application
        private void GetDesktopScreenshot()
        {
            // get the desktop window handle without the task bar
            // if you only use GetDesktopWindow() as the handle then you get and empty image
            IntPtr desktopHwnd = FindWindowEx(GetDesktopWindow(), IntPtr.Zero, "Progman", "Program Manager");

            // get the desktop dimensions
            // if you don't get the correct values then set it manually
            var rect = new Rectangle();
            GetWindowRect(desktopHwnd, ref rect);

            // saving the screenshot to a bitmap
            var bmp = new Bitmap(rect.Width, rect.Height);
            Graphics memoryGraphics = Graphics.FromImage(bmp);
            IntPtr dc = memoryGraphics.GetHdc();
            PrintWindow(desktopHwnd, dc, 0);
            memoryGraphics.ReleaseHdc(dc);

            // and now you can use it as you like
            // let's just save it to the desktop folder as a png file
            //Path.Combine() MODIFIED by Nate to include the date and condensed time for a unique file name
            string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string screenshotPath = Path.Combine(desktopDir, "desktopcapture" + 
                                                              DateTime.Now.Month.ToString() + "-" + 
                                                              DateTime.Now.Day.ToString() + "-" +
                                                              DateTime.Now.Year.ToString() + "-" +
                                                              DateTime.Now.Hour.ToString() + 
                                                              DateTime.Now.Minute.ToString() +
                                                              DateTime.Now.Second.ToString() +
                                                              ".png");
            bmp.Save(screenshotPath, ImageFormat.Png);
            Console.WriteLine("Screenshot saved to desktop as: " + screenshotPath);

        }
    }
}
