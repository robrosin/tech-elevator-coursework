﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    public class Circle : Shape2D
    {
        public int Radius { get; set; }

        public override int Perimeter
        {
            get
            {
                return (int) (2 * Math.PI * Radius);
            }
        }

        public override int Area
        {
            get
            {
                return (int)(Math.PI * Radius * Radius);
            }
        }

        public Circle(int radius, ConsoleColor color, bool isFilled)
        {
            Radius = radius;
            Color = color;
            IsFilled = isFilled;
        }

        public override void Draw()
        {
            SetConsoleColor();

            #region Do the math to calculate which symbols to draw
            double thickness = .3;
            char symbol = '|';
            char fillSymbol = '=';

            double rIn = this.Radius - thickness;
            double rOut = this.Radius + thickness;
            for (int y = this.Radius; y >= -rOut; --y)
            {
                //                for (double x = -radius; x < rOut; x += .5)
                for (double x = -this.Radius; x <= rOut; x += .4)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        if (this.IsFilled && value <= rIn * rIn)
                        {
                            Console.Write(fillSymbol);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }
            #endregion

            ResetConsoleColor();
        }

        public override string ToString()
        {
            return $"A {Color} Circle with radius {Radius}, {(IsFilled ? "" : " not")} filled.";
        }

    }
}
