using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            bool inputCorrect;

            do
            {
                inputCorrect = true;
                Console.Write("Enter: ");
                input = Console.ReadLine();
                input = input.Replace(" ", "");

                if (input.Length == 0) // input check begining
                {
                    inputCorrect = false;
                }
                else if (input.Length == 1 && input[0] == ',')
                {
                    inputCorrect = false;
                }
                else
                {
                    if (!Char.IsDigit(input[0]) && input[0] != '(' && input[0] != '+' && input[0] != '-' && input[0] != ',')
                    {
                        inputCorrect = false;
                        Console.WriteLine("Note the first symbol!");
                    }

                    if (!Char.IsDigit(input[input.Length - 1]) && input[input.Length - 1] != ')' && input[input.Length - 1] != ',')
                    {
                        inputCorrect = false;
                        Console.WriteLine("Note the last symbol!");
                    }

                    int openBrackAmount = 0, closeBrackAmount = 0;

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (!Char.IsDigit(input[i]) && input[i] != '*' && input[i] != '/' && input[i] != '+' && input[i] != '-' && input[i] != '^' && input[i] != '(' && input[i] != ')' && input[i] != ',')
                        {
                            inputCorrect = false;
                        }

                        if (i != input.Length - 1)
                        {
                            if (!Char.IsDigit(input[i]) && !Char.IsDigit(input[i + 1]) && input[i] != '(' && input[i + 1] != '(' && input[i] != ')' && input[i + 1] != ')' && input[i] != ',' && input[i + 1] != ',')
                            {
                                inputCorrect = false;
                                Console.WriteLine("Recurring operation signs(Exampe: 1++1, use: 1+(+1) )!");
                            }

                            if (input[i] == '(' && input[i + 1] == ')')
                            {
                                inputCorrect = false;
                                Console.WriteLine("Empty brackets!");
                            }

                            if ((input[i] == ',' || Char.IsDigit(input[i])) && input[i + 1] == '(')
                            {
                                inputCorrect = false;
                                Console.WriteLine("Operation sign probably missed!");
                            }

                            if (input[i] == ')' && (Char.IsDigit(input[i + 1]) || input[i + 1] == ','))
                            {
                                inputCorrect = false;
                                Console.WriteLine("Operation sign probably missed!");
                            }

                            if (!Char.IsDigit(input[i]) && input[i] != ',' && input[i] != ')' && input[i + 1] == ')')
                            {
                                inputCorrect = false;
                                Console.WriteLine("Number probably missed!");
                            }

                            if (input[i] == '(' && (input[i + 1] == '*' || input[i + 1] == '/' || input[i + 1] == '^'))
                            {
                                inputCorrect = false;
                                Console.WriteLine("Number probably missed!");
                            }
                        }

                        if (input[i] == '(')
                        {
                            openBrackAmount++;
                        }
                        else if (input[i] == ')')
                        {
                            closeBrackAmount++;
                        }

                        if (i < input.Length - 2 && !Char.IsDigit(input[i]) && input[i + 1] == ',' && !Char.IsDigit(input[i + 2]))
                        {
                            inputCorrect = false;
                        }

                        if (input[i] == ',')
                        {
                            bool symbol = false, comma = false;
                            int symbolPos = 0, commaPos = 0;

                            for (int j = i + 1; j < input.Length; j++)
                            {
                                if (!Char.IsDigit(input[j]) && input[j] != ',')
                                {
                                    symbol = true;
                                    symbolPos = j;
                                    break;
                                }
                            }

                            for (int j = i + 1; j < input.Length; j++)
                            {
                                if (input[j] == ',')
                                {
                                    comma = true;
                                    commaPos = j;
                                    break;
                                }
                            }

                            if (symbol && comma)
                            {
                                if (commaPos < symbolPos)
                                {
                                    inputCorrect = false;
                                    Console.WriteLine("Operation sign probably missed!");
                                }
                            }
                            else if (comma)
                            {
                                inputCorrect = false;
                                Console.WriteLine("Operation sign probably missed!");
                            }
                        }
                    }

                    if (openBrackAmount != closeBrackAmount)
                    {
                        inputCorrect = false;
                        Console.WriteLine("No opening or closing bracket!");
                    }
                }

                if (!inputCorrect)
                {
                    Console.WriteLine("Invalid input!\n");
                }

            } while (!inputCorrect); // input check end

            if ((input[0] == '+' || input[0] == '-') && Char.IsDigit(input[1]))
            {
                input = input.Insert(0, "0");
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '(' && (input[i + 1] == '+' || input[i + 1] == '-') && (Char.IsDigit(input[i + 2]) || input[i + 2] == ','))
                {
                    input = input.Insert(i + 1, "0");
                }
            }

            input = input.Insert(0, "0+");
            input += " ";
            string arrOperations = "", arrOperands = "";

            for (int i = 0, j = 0, l = 0; i < input.Length; i++) // begining of conversion to a reverse polish notation
            {
                if (!Char.IsDigit(input[i]) && input[i] != ',')
                {
                    arrOperations = arrOperations.Insert(j++, Char.ToString(input[i]));

                    if (j > 1)
                    {
                        while (true)
                        {
                            if (arrOperations[j - 2] == '^' && (arrOperations[j - 1] == '*' || arrOperations[j - 1] == '/' || arrOperations[j - 1] == '+' || arrOperations[j - 1] == '-'))
                            {
                                arrOperands = arrOperands.Insert(l++, Char.ToString(arrOperations[j - 2]));
                                arrOperands = arrOperands.Insert(l++, "|");
                                arrOperations = arrOperations.Remove(j - 2, 1);
                                j--;
                            }
                            else if ((arrOperations[j - 2] == '*' || arrOperations[j - 2] == '/') && (arrOperations[j - 1] == '*' || arrOperations[j - 1] == '/' || arrOperations[j - 1] == '+' || arrOperations[j - 1] == '-'))
                            {
                                arrOperands = arrOperands.Insert(l++, Char.ToString(arrOperations[j - 2]));
                                arrOperands = arrOperands.Insert(l++, "|");
                                arrOperations = arrOperations.Remove(j - 2, 1);
                                j--;
                            }
                            else if ((arrOperations[j - 2] == '+' || arrOperations[j - 2] == '-') && (arrOperations[j - 1] == '+' || arrOperations[j - 1] == '-'))
                            {
                                arrOperands = arrOperands.Insert(l++, Char.ToString(arrOperations[j - 2]));
                                arrOperands = arrOperands.Insert(l++, "|");
                                arrOperations = arrOperations.Remove(j - 2, 1);
                                j--;
                            }
                            else if (arrOperations[j - 1] == ')')
                            {
                                while (arrOperations[j - 2] != '(')
                                {
                                    arrOperands = arrOperands.Insert(l++, Char.ToString(arrOperations[j - 2]));
                                    arrOperands = arrOperands.Insert(l++, "|");
                                    arrOperations = arrOperations.Remove(j - 2, 1);
                                    j--;
                                }

                                arrOperations = arrOperations.Remove(--j, 1);
                                arrOperations = arrOperations.Remove(--j, 1);
                            }

                            if (j > 1)
                            {
                                if (arrOperations[j - 2] == '^' && (arrOperations[j - 1] == '*' || arrOperations[j - 1] == '/' || arrOperations[j - 1] == '+' || arrOperations[j - 1] == '-'))
                                {
                                }
                                else if ((arrOperations[j - 2] == '*' || arrOperations[j - 2] == '/') && (arrOperations[j - 1] == '*' || arrOperations[j - 1] == '/' || arrOperations[j - 1] == '+' || arrOperations[j - 1] == '-'))
                                {
                                }
                                else if ((arrOperations[j - 2] == '+' || arrOperations[j - 2] == '-') && (arrOperations[j - 1] == '+' || arrOperations[j - 1] == '-'))
                                {
                                }
                                else if (arrOperations[j - 1] == ')')
                                {
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    arrOperands = arrOperands.Insert(l++, Char.ToString(input[i]));

                    if (!Char.IsDigit(input[i + 1]) && input[i + 1] != ',')
                    {
                        arrOperands = arrOperands.Insert(l++, "|");
                    }
                }
            }

            arrOperations = arrOperations.Replace(" ", "");
            arrOperands = arrOperands.Replace(" ", "");

            if (arrOperations.Length > 0)
            {
                for (int i = arrOperations.Length - 1, j = arrOperands.Length; i >= 0; i--)
                {
                    arrOperands = arrOperands.Insert(j++, Char.ToString(arrOperations[i]));
                    arrOperands = arrOperands.Insert(j++, "|");
                }
            } // end of conversion to a reverse polish notation

            bool calcu = true, infinity = false;
            int index = 0, repeatPos;

            while (calcu) // begining of calculation of an expression
            {
                calcu = false;
                int insertPos = index;
                double tempD = 0, d1, d2;
                string tempStr = "";

                while (arrOperands[index] != '|')
                {
                    tempStr += Char.ToString(arrOperands[index]);
                    index++;
                }

                d1 = double.Parse(tempStr);
                index++;
                repeatPos = index;
                tempStr = "";

                while (arrOperands[index] != '|')
                {
                    tempStr += Char.ToString(arrOperands[index]);
                    index++;
                }

                d2 = double.Parse(tempStr);
                index++;

                if (!Char.IsDigit(arrOperands[index]) && arrOperands[index] != ',' && arrOperands[index + 1] == '|')
                {
                    if (arrOperands[index] == '+')
                    {
                        tempD = d1 + d2;
                    }
                    else if (arrOperands[index] == '-')
                    {
                        tempD = d1 - d2;
                    }
                    else if (arrOperands[index] == '*')
                    {
                        tempD = d1 * d2;
                    }
                    else if (arrOperands[index] == '/')
                    {
                        tempD = d1 / d2;
                    }
                    else if (arrOperands[index] == '^')
                    {
                        tempD = Math.Pow(d1, d2);
                    }

                    int i = index + 1;

                    while (i >= insertPos)
                    {
                        arrOperands = arrOperands.Remove(i, 1);
                        i--;
                    }

                    tempStr = Convert.ToString(tempD);

                    if (arrOperands.Length == 0)
                    {
                        arrOperands = tempStr;
                    }
                    else
                    {
                        arrOperands = arrOperands.Insert(insertPos, tempStr + "|");
                    }

                    index = 0;
                }
                else
                {
                    index = repeatPos;
                }

                for (int i = 0; i < arrOperands.Length; i++)
                {
                    if (!Char.IsDigit(arrOperands[i]) && arrOperands[i] != ',' && arrOperands[i] != 'E' && arrOperands[i] != '+' && arrOperands[i] != '-')
                    {
                        calcu = true;
                    }

                    if (arrOperands[i] == (char)8734)
                    {
                        calcu = false;
                        infinity = true;
                        break;
                    }
                }
            } // end of calculation of an expression

            if (infinity)
            {
                Console.WriteLine("Infinity");
            }
            else
            {
                Console.WriteLine("Result: " + double.Parse(arrOperands));
            }
        }
    }
}