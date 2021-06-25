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
            Console.WriteLine(new string('-',100));
            TestWhiteDefenseRolls();
            TestRedDefenseRolls();

            Console.WriteLine(new string('-', 100));
            TestWhiteAttackRolls();
            TestBlackAttackRolls();
            TestRedAttackRolls();
        }

        static private void TestDice()
        {
            Console.WriteLine("\r\n" + "Test dice faces".PadCenter(100, '-') + "\r\n");

            foreach (Type type in _lstDiceTypes)
            {
                object die = Activator.CreateInstance(type);
                Console.WriteLine(die.ToString());
            }
        }

        static private void TestAverage()
        {
            float fTempAverage = 0f;

            Console.WriteLine("\r\n" + "Test dice averages".PadCenter(100, '-') + "\r\n");

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



        #region RollTests
        static private void TestRolls()
        {
            Console.WriteLine("\r\n" + "Test dice rolls".PadCenter(30, '-') + "\r\n");

            foreach (Type type in _lstDiceTypes)
            {
                object die = Activator.CreateInstance(type);

                Console.WriteLine(type.Name + " : " + ((Die)die).Roll());
            }
        }

        static private void TestWhiteDefenseRolls(int iRolls = 100, bool bLog = false)
        {
            Console.WriteLine("\r\n" + $"Testing {iRolls} white defense rolls".PadCenter(100, '-') + "\r\n");

            uint uiBlanks = 0;
            uint uiSurges = 0;
            uint uiBlocks = 0;

            Die.Result tempResult = Die.Result.Blank;
            Die die = new DefenseWhite();

            for (int i = 0; i < iRolls; i++)
            {
                tempResult = die.Roll();

                switch (tempResult)
                {
                    case Die.Result.Blank:
                        uiBlanks++;
                        break;
                    case Die.Result.Block:
                        uiBlocks++;
                        break;
                    case Die.Result.Surge:
                        uiSurges++;
                        break;
                    default:
                        break;
                }

                if (bLog)
                    Console.WriteLine($"[{DateTime.Now}] {i + 1}/{iRolls} : {tempResult}");
            }

            Console.WriteLine($"\r\nBlanks: {uiBlanks}/{iRolls}, Blocks: {uiBlocks}/{iRolls}, Surges: {uiSurges}/{iRolls}({uiBlocks + uiSurges})");
            Console.WriteLine($"\r\n:NORMAL: Average without surges: {die.GetAverage() * iRolls: 0.00}/{iRolls}");
            Console.WriteLine($"\r\n:NORMAL: Average with surges: {die.GetAverage(true) * iRolls: 0.00}/{iRolls}");
        }

        static private void TestRedDefenseRolls(int iRolls = 100, bool bLog = false)
        {
            Console.WriteLine("\r\n" + $"Testing {iRolls} red defense rolls".PadCenter(100, '-') + "\r\n");

            uint uiBlanks = 0;
            uint uiSurges = 0;
            uint uiBlocks = 0;

            Die.Result tempResult = Die.Result.Blank;
            Die die = new DefenseRed();

            for (int i = 0; i < iRolls; i++)
            {
                tempResult = die.Roll();

                switch (tempResult)
                {
                    case Die.Result.Blank:
                        uiBlanks++;
                        break;
                    case Die.Result.Block:
                        uiBlocks++;
                        break;
                    case Die.Result.Surge:
                        uiSurges++;
                        break;
                    default:
                        break;
                }

                if (bLog)
                    Console.WriteLine($"[{DateTime.Now}] {i + 1}/{iRolls} : {tempResult}");
            }

            Console.WriteLine($"\r\nBlanks: {uiBlanks}/{iRolls}, Blocks: {uiBlocks}/{iRolls}, Surges: {uiSurges}/{iRolls}({uiBlocks + uiSurges})");
            Console.WriteLine($"\r\n:NORMAL: Average without surges: {die.GetAverage() * iRolls: 0.00}/{iRolls}");
            Console.WriteLine($"\r\n:NORMAL: Average with surges: {die.GetAverage(true) * iRolls: 0.00}/{iRolls}");
        }

        

        static private void TestWhiteAttackRolls(int iRolls = 100, bool bLog = false)
        {
            Console.WriteLine("\r\n" + $"Testing {iRolls} white attack rolls".PadCenter(100, '-') + "\r\n");

            uint uiBlanks = 0;
            uint uiSurges = 0;
            uint uiHit = 0;
            uint uiCritical = 0;

            Die.Result tempResult = Die.Result.Blank;
            Die die = new AttackWhite();

            for (int i = 0; i < iRolls; i++)
            {
                tempResult = die.Roll();

                switch (tempResult)
                {
                    case Die.Result.Blank:
                        uiBlanks++;
                        break;
                    case Die.Result.Hit:
                        uiHit++;
                        break;
                    case Die.Result.Surge:
                        uiSurges++;
                        break;
                    case Die.Result.Critical:
                        uiCritical++;
                        break;
                    default:
                        break;
                }

                if (bLog)
                    Console.WriteLine($"[{DateTime.Now}] {i + 1}/{iRolls} : {tempResult}");
            }

            Console.WriteLine($"\r\nBlanks: {uiBlanks}/{iRolls}, Hits: {uiHit}/{iRolls}, Critical hits: {uiCritical}/{iRolls}({uiHit+uiCritical}), Surges: {uiSurges}/{iRolls}({uiHit+uiCritical + uiSurges})");
            Console.WriteLine($"\r\n:NORMAL: Average without surges: {die.GetAverage() * iRolls: 0.00}/{iRolls}");
            Console.WriteLine($"\r\n:NORMAL: Average with surges: {die.GetAverage(true) * iRolls: 0.00}/{iRolls}");
        }

        static private void TestBlackAttackRolls(int iRolls = 100, bool bLog = false)
        {
            Console.WriteLine("\r\n" + $"Testing {iRolls} black attack rolls".PadCenter(100, '-') + "\r\n");

            uint uiBlanks = 0;
            uint uiSurges = 0;
            uint uiHit = 0;
            uint uiCritical = 0;

            Die.Result tempResult = Die.Result.Blank;
            Die die = new AttackBlack();

            for (int i = 0; i < iRolls; i++)
            {
                tempResult = die.Roll();

                switch (tempResult)
                {
                    case Die.Result.Blank:
                        uiBlanks++;
                        break;
                    case Die.Result.Hit:
                        uiHit++;
                        break;
                    case Die.Result.Surge:
                        uiSurges++;
                        break;
                    case Die.Result.Critical:
                        uiCritical++;
                        break;
                    default:
                        break;
                }

                if (bLog)
                    Console.WriteLine($"[{DateTime.Now}] {i + 1}/{iRolls} : {tempResult}");
            }

            Console.WriteLine($"\r\nBlanks: {uiBlanks}/{iRolls}, Hits: {uiHit}/{iRolls}, Critical hits: {uiCritical}/{iRolls}({uiHit + uiCritical}), Surges: {uiSurges}/{iRolls}({uiHit + uiCritical + uiSurges})");
            Console.WriteLine($"\r\n:NORMAL: Average without surges: {die.GetAverage() * iRolls: 0.00}/{iRolls}");
            Console.WriteLine($"\r\n:NORMAL: Average with surges: {die.GetAverage(true) * iRolls: 0.00}/{iRolls}");
        }

        static private void TestRedAttackRolls(int iRolls = 100, bool bLog = false)
        {
            Console.WriteLine("\r\n" + $"Testing {iRolls} red attack rolls".PadCenter(100, '-') + "\r\n");

            uint uiBlanks = 0;
            uint uiSurges = 0;
            uint uiHit = 0;
            uint uiCritical = 0;

            Die.Result tempResult = Die.Result.Blank;
            Die die = new AttackRed();

            for (int i = 0; i < iRolls; i++)
            {
                tempResult = die.Roll();

                switch (tempResult)
                {
                    case Die.Result.Blank:
                        uiBlanks++;
                        break;
                    case Die.Result.Hit:
                        uiHit++;
                        break;
                    case Die.Result.Surge:
                        uiSurges++;
                        break;
                    case Die.Result.Critical:
                        uiCritical++;
                        break;
                    default:
                        break;
                }

                if (bLog)
                    Console.WriteLine($"[{DateTime.Now}] {i + 1}/{iRolls} : {tempResult}");
            }

            Console.WriteLine($"\r\nBlanks: {uiBlanks}/{iRolls}, Hits: {uiHit}/{iRolls}, Critical hits: {uiCritical}/{iRolls}({uiHit + uiCritical}), Surges: {uiSurges}/{iRolls}({uiHit + uiCritical + uiSurges})");
            Console.WriteLine($"\r\n:NORMAL: Average without surges: {die.GetAverage() * iRolls: 0.00}/{iRolls}");
            Console.WriteLine($"\r\n:NORMAL: Average with surges: {die.GetAverage(true) * iRolls: 0.00}/{iRolls}");
        }
        #endregion
    }
}
