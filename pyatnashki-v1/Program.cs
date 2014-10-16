using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pyatnashki_v1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a;
            int[] b;
            int ii = 0, x = 0, y = 0, step=0; // (x,y) - координаты пустой ячейки; step - количество сделанных ходов
            Random gen = new Random();
            a = new int[4, 4];
            b = new int[16];
            for (ii = 1; ii < 16; ii++)
            {
                b[ii] = ii;
            }
            b[0] = 0;
            ii = 0;
            // Вывод одномерного массива - потом выкинуть
            /*ii=0;
            for (ii = 0; ii < 16; ii++)
            {
                if (ii == 15) { Console.Write(b[ii] + " "); Console.WriteLine(); Console.WriteLine(); } else { Console.Write(b[ii] + " | "); }
            }*/
            // Конец вывода одномерного массива
            ii = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    a[i, j] = b[ii];
                    ii++;
                }
            }

            vuivod(ref a, ref x, ref y, ref step);
            for (int puzzle = 0; puzzle < gen.Next(450, 9999); puzzle++)
            {
                puzzling(ref a, ref x, ref y, ref step);
                vuivod(ref a, ref x, ref y, ref step); //Console.ReadKey(true); 
            }
            Console.Title = "Пятнашки"; Console.CursorVisible = false;
            Console.Clear(); Console.WindowHeight = 16;
            Console.WriteLine("Добро пожаловать в игру пятнашки!");
            Console.WriteLine("Игру написал Александр Недорезов.");
            Console.WriteLine("Для старта игры нажмите любую клавишу.");
            Console.WriteLine("P.S.: Для завершения работы приложения нажмите клавишу Esc");
            vuivod(ref a, ref x, ref y, ref step);
            Console.ReadKey(true);
            Console.Clear(); Console.WindowHeight = 12; Console.WindowWidth = 25; vuivod(ref a, ref x, ref y, ref step);

            while (a[0, 0] != 1 || a[0, 1] != 2 || a[0, 2] != 3 || a[0, 3] != 4 ||
                  a[1, 0] != 5 || a[1, 1] != 6 || a[1, 2] != 7 || a[1, 3] != 8 ||
                  a[2, 0] != 9 || a[2, 1] != 10 || a[2, 2] != 11 || a[2, 3] != 12 ||
                  a[3, 0] != 13 || a[3, 1] != 14 || a[3, 2] != 15 || a[3, 3] != 0)
            {
                keypress(ref a, ref x, ref y, ref step);
            }

            Console.WriteLine("Поздравляю, Вы собрали пятнашки за " + Convert.ToString(step) + " ходов");
            Console.ReadKey(true); 
        }

        static public void vuivod(ref int[,] a, ref int x, ref int y, ref int step)
        {
                Console.WriteLine(" ---------------------");
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (a[i, j] == 0 || a[i, j] == 1 || a[i, j] == 2 || a[i, j] == 3 || a[i, j] == 4 || a[i, j] == 5 || a[i, j] == 6 || a[i, j] == 7 || a[i, j] == 8 || a[i, j] == 9)
                        { if (j == 0) { Console.Write(" | "); } if (a[i, j] == 0) { x = i; y = j; Console.ForegroundColor = ConsoleColor.Green; Console.Write(a[i, j]); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("  | "); } else { Console.Write(a[i, j] + "  | "); } }
                        if (a[i, j] == 10 || a[i, j] == 11 || a[i, j] == 12 || a[i, j] == 13 || a[i, j] == 14 || a[i, j] == 15)
                        { if (j == 0) { Console.Write(" | "); } Console.Write(a[i, j] + " | "); }
                        if (j == 3) { Console.WriteLine(); Console.WriteLine(" ---------------------"); }
                    }
                }
                if (step >= 0 && step < 10) { Console.WriteLine(" | X=" + Convert.ToString(x) + ", Y=" + Convert.ToString(y) + ". Ход: " + Convert.ToString(step) + "  |"); }
                if (step >= 10 && step < 100) { Console.WriteLine(" | X=" + Convert.ToString(x) + ", Y=" + Convert.ToString(y) + ". Ход: " + Convert.ToString(step) + " |"); }
                if (step >= 100 && step < 1000) { Console.WriteLine(" | X=" + Convert.ToString(x) + ", Y=" + Convert.ToString(y) + ". Ход: " + Convert.ToString(step) + "|"); }
                if (step >= 1000 && step < 10000) { Console.WriteLine(" |X=" + Convert.ToString(x) + ", Y=" + Convert.ToString(y) + ". Ход: " + Convert.ToString(step) + "|"); }
                if (step >= 10000 && step < 100000) { Console.WriteLine(" |X=" + Convert.ToString(x) + ",Y=" + Convert.ToString(y) + ". Ход: " + Convert.ToString(step) + "|"); }
                if (step >= 100000) { Console.WriteLine(" |X=" + Convert.ToString(x) + ",Y=" + Convert.ToString(y) + ".Ход: " + Convert.ToString(step) + "|"); }
                Console.WriteLine(" ---------------------");
        }


        static public void keypress(ref int[,] a, ref int x, ref int y, ref int step)
        {
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);
            //Console.WriteLine(" X=" + Convert.ToString(x) + ", Y=" + Convert.ToString(y) + ". Ход: " + Convert.ToString(step));
            if (input.Key == ConsoleKey.DownArrow)
            {
                if (x == 3) { goto end; }
                else
                {
                    a[x, y] = a[x+1, y];
                    a[x+1, y] = 0;
                    step++;
                    vuivod(ref a, ref x, ref y, ref step);
                    //Console.WriteLine(" ---------------------");
                    //MessageBox.Show("Pressed " + Keys.Shift);
                }
            }
            if (input.Key == ConsoleKey.LeftArrow)
            {
                if (y == 0) { goto end; }
                else
                {
                    a[x, y] = a[x, y-1];
                    a[x, y-1] = 0;
                    step++;
                    vuivod(ref a, ref x, ref y, ref step);
                    //Console.WriteLine(" ---------------------");
                    //MessageBox.Show("Pressed " + Keys.Shift);
                }
            }
            if (input.Key == ConsoleKey.UpArrow)
            {
                if (x == 0) { goto end; }
                else
                {
                    a[x, y] = a[x - 1, y];
                    a[x - 1, y] = 0;
                    step++;
                    vuivod(ref a, ref x, ref y, ref step);
                    //Console.WriteLine(" ---------------------");
                    //MessageBox.Show("Pressed " + Keys.Shift);
                }
            }
            if (input.Key == ConsoleKey.RightArrow)
            {
                if (y == 3) { goto end; }
                else
                {
                    a[x, y] = a[x, y+1];
                    a[x, y+1] = 0;
                    step++;
                    vuivod(ref a, ref x, ref y, ref step);
                    //Console.WriteLine(" ---------------------");
                    //MessageBox.Show("Pressed " + Keys.Shift);
                }
            }
            if (input.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            end: Console.Write("");
        }

        static public void puzzling(ref int[,] a, ref int x, ref int y, ref int step)
        {
            Random gen = new Random();
            int puz = gen.Next(0, 4);
            if (puz==0)
            {
                if (x == 3) { goto end; }
                else
                {
                    a[x, y] = a[x + 1, y];
                    a[x + 1, y] = 0;
                }
            }
            if (puz==1)
            {
                if (y == 0) { goto end; }
                else
                {
                    a[x, y] = a[x, y - 1];
                    a[x, y - 1] = 0;
                }
            }
            if (puz==2)
            {
                if (x == 0) { goto end; }
                else
                {
                    a[x, y] = a[x - 1, y];
                    a[x - 1, y] = 0;
                }
            }
            if (puz==3)
            {
                if (y == 3) { goto end; }
                else
                {
                    a[x, y] = a[x, y + 1];
                    a[x, y + 1] = 0;
                }
            }
        end: Console.Write("");
        }


    }
}
