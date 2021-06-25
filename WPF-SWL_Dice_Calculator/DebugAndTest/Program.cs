using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LIB_SWL_Dice_Calculator;
using LIB_SWL_Dice_Calculator.DiceModels;
using LIB_SWL_Dice_Calculator.Extensions;

namespace DebugAndTest
{
    class Program
    {
        static List<Type> _lstDiceTypes = Assembly.GetAssembly(typeof(Die)).GetTypes().Where(t => t.IsSubclassOf(typeof(Die)) && !t.IsAbstract && t.IsClass).ToList();

        static void Main(string[] args)
        {
            TestDice();
            TestAverage();
        }

        static private void TestDice()
        {
            Console.WriteLine("\r\n"+ "Test dice faces".PadCenter(30, '-') + "\r\n");

            foreach (Type type in _lstDiceTypes)
            {
                object die = Activator.CreateInstance(type);
                Console.WriteLine(die.ToString());
            }
        }

        static private void TestAverage()
        {
            float fTempAverage = 0f;

            Console.WriteLine("\r\n" + "Test dice averages".PadCenter(30, '-') + "\r\n");

            Console.WriteLine("Without surges\r\n");
            foreach (Type type in _lstDiceTypes)
            {
                object die = Activator.CreateInstance(type);
                fTempAverage = ((Die)die).GetAverage();

                Console.WriteLine(type.Name + " : " + fTempAverage.ToString("0.00"));
            }

            Console.WriteLine("\r\nWith surges\r\n");
            foreach (Type type in _lstDiceTypes)
            {
                object die = Activator.CreateInstance(type);
                fTempAverage = ((Die)die).GetAverage(true);

                Console.WriteLine(type.Name + " : " + fTempAverage.ToString("0.00"));
            }
        }
    }
}
