﻿using System;

namespace Week7Test_Laura_Gagliani
{
    class Program
    {
        static void Main(string[] args)
        {
            /* DOMANDE
             * 
             * 1) C, D
             * 
             * 2) B, C
             * 
             * 3) A, D
             * */


            bool parse;
            int matricola;
            Console.WriteLine("Inserisci il numero di matricola dello studente cercato:");
            Console.WriteLine("(Matricole presenti nel db: 1 - 2 - 4 - 5 - 6)");

            do
            {
                parse = int.TryParse(Console.ReadLine(), out matricola);
            } while (!parse);

            StampaDatiStudente(matricola);
        }

        private static void StampaDatiStudente(int code)
        {
             Studente s = DbStudenteManager.GetByCode(code);

                if (s != null)
                {
                    string stampa = s.ToString();
                    Console.WriteLine(stampa);
                }
            
        }
    }
}
