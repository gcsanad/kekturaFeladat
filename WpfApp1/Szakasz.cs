using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Szakasz
    {
        int sorszam;
        string utvonalLeiras;
        double tavolsagKm;
        int tengerszintFelettiMagassag;
        int teljesitesVarhatoIdeje;
        char nehezseg;

        public Szakasz(int sorszam, string utvonalLeiras, double tavolsagKm, int tengerszintFelettiMagassag, int teljesitesVarhatoIdeje)
        {
            this.sorszam = sorszam;
            this.utvonalLeiras = utvonalLeiras;
            this.tavolsagKm = tavolsagKm;
            this.tengerszintFelettiMagassag = tengerszintFelettiMagassag;
            this.teljesitesVarhatoIdeje = teljesitesVarhatoIdeje;
        }

        public int Sorszam { get => sorszam;}
        public string UtvonalLeiras { get => utvonalLeiras;}
        public double TavolsagKm { get => tavolsagKm;}
        public int TengerszintFelettiMagassag { get => tengerszintFelettiMagassag;}
        public int TeljesitesVarhatoIdeje { get => teljesitesVarhatoIdeje;}
        public char Nehezseg { get => nehezseg; set => nehezseg = value; }

        public static void NehezsegMegadasa (List<Szakasz> nehezsegiLista)
        {
            foreach (var elem in nehezsegiLista)
            {
                if (elem.tavolsagKm <= 5)
                {
                    elem.nehezseg = 'e'; //e = könnyű, easy
                }
                else if (elem.tavolsagKm > 5 && elem.tavolsagKm < 10)
                {
                    elem.nehezseg = 'm'; //m = közepes, medium
                }
                else if (elem.tavolsagKm >= 10)
                {
                    elem.nehezseg = 'h'; //h = nehéz, hard
                }
            }
        }
    }
}
