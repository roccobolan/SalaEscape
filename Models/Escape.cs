using System;
using System.Collections.Generic;
using System.IO;

namespace SalaDeEscape.Models
{
    public static class Escape
    {
        private static List<string> _incognitasSalas = new List<string>();
        private static string _logo = "/sources/logo.jpg";
        private static int _estadoJuego = 1;

        public static List<string> IncognitasSalas{
            get{return _incognitasSalas;}
        }

        public static string Logo{
            get{return _logo;}
        }

        public static int EstadoJuego{
            get{return _estadoJuego;}
        }

        public static bool ResolverSala(int Sala, string Incognita){

            if(_incognitasSalas.Count == 0){
                _incognitasSalas.Add("vacio");
                _incognitasSalas.Add("campeon de la premier");
                _incognitasSalas.Add("DIAS DE BRUYNE STERLING");
                _incognitasSalas.Add("2022-05-22");
                _incognitasSalas.Add("99");
            }

            if(_incognitasSalas[Sala] == Convert.ToString(Incognita)){
                _estadoJuego = Sala+1;
                return true;
            }else{
                _estadoJuego = Sala;
                return false;
            }
        }
    }
}
 