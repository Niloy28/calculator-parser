using CalculatorParser;
using System;

string input = Console.ReadLine();

Calculator calculator = new Calculator(input);

Console.WriteLine(calculator.Solve());