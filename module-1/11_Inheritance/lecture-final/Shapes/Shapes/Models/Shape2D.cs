using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    public class Shape2D
    {
        #region Properties
        public bool IsFilled { get; set; }

        public ConsoleColor Color { get; set; }

        virtual public int Area
        {
            get
            {
                return 0;
            }
        }

        virtual public int Perimeter
        {
            get
            {
                return 0;
            }
        }

        #endregion

        public Shape2D()
        {
            Color = ConsoleColor.White;
            IsFilled = false;
        }


        #region Methods

        virtual public void Draw() { }

        public override string ToString()
        {
            return $"A shape with Area={Area} and Perimeter={Perimeter}";
        }

        #endregion


        #region Helper Methods
        // A place to save the current color for restoring after the draw
        private ConsoleColor savedColor = ConsoleColor.White;

        protected void SetConsoleColor()
        {
            this.savedColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
        }

        protected void ResetConsoleColor()
        {
            Console.ForegroundColor = savedColor;
        }
        #endregion


    }
}
