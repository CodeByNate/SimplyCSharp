/*IntroCumulative
 * An introduction to fundamental C# programming constructs
 * using a console interface.
 * This program was created using in-situ design techniques.
 * No formal programming desing document exists for this program,
 * as its functionality was formatted on-the-fly using
 * a non-proprietary Just-In-Time thought-design process ;)
 * First Version created 30 April, 2017 by Nate Wilkins
 * enjoy
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroCumulative
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi Tom, Roger, Jane, Richard, or whoever may be reading this! Thanks.");
            Console.WriteLine("What were you expecting?  A fully featured cross-platform, enterprise grade");
            Console.WriteLine("marketing specialty app?  Well you'll have to wait.\n\n");
            Intention myIntent = new Intention { ID = 501, name = "My Intent" };
            Console.WriteLine("Created class:\n" + myIntent.ToString() + " \n" + "ID: " + myIntent.ID + "\n" + "name: " + myIntent.name);
            myIntent.Options();
            Console.WriteLine("End of program");
            Console.ReadLine();
        }
    }
}
