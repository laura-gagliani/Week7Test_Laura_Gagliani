using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Test_Laura_Gagliani
{
    class Studente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Matricola { get; set; }


        
        public override string ToString()
        {
           return $"Studente: {Nome} {Cognome} - Matricola: {Matricola}";
                         
            
        }
    }
}
