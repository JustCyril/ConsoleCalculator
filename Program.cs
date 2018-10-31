using System;

namespace ConsoleCalculatorV2
{

    class Program
    {

        static void Main()
        {

            // Greeting for user and start a calculation process
            Console.WriteLine("\nПриветствуем Вас в консольном калькуляторе (V2).");


            //Ask a user about first argument, user enters a number, than calculator tries to parse it
            decimal ArgumentFirst = 0;
            Console.WriteLine("\nПожалуйста, введите первый аргумент:");
            ArgumentFirst = CycleParser();


            // Ask a user about math operator, user enters an operator, than calculator tries to parse it
            Console.WriteLine("\nПожалуйста, введите математический оператор [ + | - | * | / ]:");
            string Operator = "";
            Operator = OperatorParser();


            // Ask a user about second argument, user enters a number, than calculator tries to parse it
            decimal ArgumentSecond = 0;
            Console.WriteLine("\nПожалуйста, введите второй аргумент:");
            ArgumentSecond = CycleParser();

            //Trying to realize calculation
            decimal Result = 0;
            try
            {
                Result = Calculation(ArgumentFirst, ArgumentSecond, Operator);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Output the result with solution of dividing by zero
            if (ArgumentSecond == 0 && Operator == "/")
            {
                Console.WriteLine("\nК сожалению, в данной версии невозможно выполнять деление на ноль");
            }
            else
            {
                Console.WriteLine("\nРезультат: " + ArgumentFirst + " " + Operator + " " + ArgumentSecond + " = " + Result);
            }

            // Asking a user about using the calculator again
            Console.WriteLine("\nПровести ещё одно вычисление? (y/n)");
            Repeater();

            Console.WriteLine("\nБлагодарим за использование данного калькулятора! Нажмите любую клавишу");
            Console.ReadLine();

        }

        //------------------------------End of the block "Main"----------------------------------------------------------------


        static decimal CycleParser()
        {
            // The gist of this block was to create a cycle for both argument and use it from "Main"

            // Variable "ReAskingUser" is needed for "while"-cycle to repeat argument input
            bool ReAskingUser = false;
            decimal ArgumentTemp = 0;
            while (!ReAskingUser)
                {
                    try
                    {
                        ArgumentTemp = ArgumentParser(Console.ReadLine());
                        ReAskingUser = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        ReAskingUser = false;
                    }

                }
            return ArgumentTemp;
            //----------------------------End of the block "CycleParser"---------------------------------------------------------
        }

        static decimal ArgumentParser(string InputString)
        {
            // Parsing as it is
            decimal ArgumentTemp = 0;
            {
                try
                {
                    ArgumentTemp = Decimal.Parse(InputString);
                }
                catch (Exception)
                {
                    throw new Exception("Неверно введен аргумент! Введите аргумент ещё раз:");
                }
             
            }
            return ArgumentTemp;
            //----------------------------End of the block "ArgumentParser"---------------------------------------------------------
        }

        static string OperatorParser()
        {
            // Variable "ReAskingUser" is needed for "while"-cycle to repeat operator input
            bool ReAskingUser = false;
            string OperatorTemp = "";
            
            while (!ReAskingUser)
            {
                OperatorTemp = Console.ReadLine();
                if (OperatorTemp.Length > 1)
                {
                    Console.WriteLine("Некорректно введен математический оператор! Введите оператор ещё раз:");
                    ReAskingUser = false;
                }
                else
                {
                    switch (OperatorTemp)
                    {
                        case "+":
                            ReAskingUser = true;
                            break;
                        case "-":
                            ReAskingUser = true;
                            break;
                        case "*":
                            ReAskingUser = true;
                            break; ;
                        case "/":
                            ReAskingUser = true;
                            break;
                        default:
                            Console.WriteLine("Некорректно введен математический оператор! Введите оператор ещё раз:");
                            ReAskingUser = false;
                            break;

                    }
                }
            }
            return OperatorTemp;
            //---------------------------End of the block "OperatorParser"------------------------------------------------------------
        }

        static decimal Calculation( decimal ArgumentFirst, decimal ArgumentSecond, string Operator)
        {
            // Calculation process as it is. Can be modified into more complicated method.

            decimal Result = 0;
            switch (Operator)
            {
                case "+":
                    Result = ArgumentFirst + ArgumentSecond;
                    break;
                case "-":
                    Result = ArgumentFirst - ArgumentSecond;
                    break;
                case "*":
                    Result = ArgumentFirst * ArgumentSecond;
                    break;
                case "/":
                    if (ArgumentSecond != 0)
                    {
                        Result = ArgumentFirst / ArgumentSecond;
                    }
                    break;
            }
            return Result;

            //----------------------------End of the block "Calculation"---------------------------------------------------------------
        }

        static void Repeater()
        {
            // This method is needed for using calculator again

            bool ReAskingUser = false;
            string Answer = "";
            while (!ReAskingUser)
            {
             
                Answer = Console.ReadLine();
                switch (Answer)
                {
                    case "y":
                        ReAskingUser = true;
                        Main();
                        break;
                    case "n":
                        ReAskingUser = true;
                        break;
                    default:
                        ReAskingUser = false;
                        Console.WriteLine("Неверный формат ответа! Введите ответ ещё раз:");
                        break;
                }
            }

            //----------------------------End of the block "Repeater"---------------------------------------------------------------
        }

    }
}
