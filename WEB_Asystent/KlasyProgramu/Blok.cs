using System;
using System.Collections.Generic;


namespace WEB_Asystent.KlasyProgramu
{
    public class Blok
    {
        private static int cnt;
        private static List<Blok> listaTymczasowa = new List<Blok>();
        private double x;
        private double y;
        public static List<Blok> OdczytajPotomneBloki(Blok _blok)
        {
            Blok.listaTymczasowa = new List<Blok>();

            _blok.odnajdzBlokiPotomne();

            return listaTymczasowa;
        }
        // dunamiczne elementy
        double szerokosc;
        double wysokosc;
        List<Blok> bloklist = new List<Blok>();
        Blok parent;
        string ustawienie = "";
        int ID = 1;

        public Blok(Blok _parent,double _szerokosc, double _wysokosc, int _nrWKolei)
        {
            szerokosc = _szerokosc;
            wysokosc = _wysokosc;
            parent = _parent;
            cnt++;
            ID = cnt;
            if (_parent.ZwrocUstawienie() == "POZ")
            {
                x = szerokosc * _nrWKolei + _parent.ZwrocX();
                y = _parent.ZwrocY();
            }
            else;
            if (_parent.ZwrocUstawienie() == "PION")
            {
                x=_parent.ZwrocX();
                y = wysokosc * _nrWKolei + _parent.ZwrocY();
            }
            else;

        }
        public Blok(double _szerokosc, double _wysokosc)
        {
            x = 0;
            y = 0;
            szerokosc = _szerokosc;
            wysokosc = _wysokosc;
            cnt++;
            ID = cnt;
        }
        public Blok()
        {
            x = 0;
            y = 0;
            cnt++;
            ID = cnt;
        }
        public void ZmienSzerokosc(double wartoscSzerokosci)
        {

            parent.ZmienSzerokoscDown(wartoscSzerokosci);
        }
        public void ZmienWysokosc(double wartoscWysokosci)
        {

            parent.ZmienWysokoscDown(wartoscWysokosci);
        }

        public Blok NajszerszaGrupaZbierajacaPionowe()
        {
            var ob= new Blok();
            if(parent.ustawienie=="PION")
            {
                ob=parent.NajszerszaGrupaZbierajacaPionowe();
            }
            else
            {
                ob = this;
            }
            return ob;
        }
        public List<Blok> ZrobListeDown(List<Blok> _input)
        {
            _input.Add(this);
            foreach (Blok obc in bloklist)
            {
                obc.ZrobListeDown(_input);
            }
       return _input;
        }
        public void ZmienSzerokoscDown(double wartoscSzerokosci)
        {
            // szerokosc = wartoscSzerokosci;

            switch (ustawienie)
            {
                case "PION":
                    szerokosc = wartoscSzerokosci;
                    foreach (Blok blok in bloklist)
                    {
                        blok.ZmienSzerokoscDown(wartoscSzerokosci);
                    }
                    break;
                case "POZ":

                    break;
                default:
                    szerokosc = wartoscSzerokosci;
                    // parent.ZmienSzerokosc(wartoscSzerokosci);
                    break;
            }



        }
        public void ZmienWysokoscDown(double wartoscWysokosci)
        {
            // szerokosc = wartoscSzerokosci;

            switch (ustawienie)
            {
                case "PION":

                    break;
                case "POZ":
                    wysokosc = wartoscWysokosci;
                    foreach (Blok blok in bloklist)
                    {
                        blok.ZmienWysokoscDown(wartoscWysokosci);
                    }
                    break;
                default:
                    wysokosc = wartoscWysokosci;

                    break;
            }



        }
        private void odnajdzBlokiPotomne()
        {
            //  var zmienna= new List<Blok>();
            foreach (Blok blok in bloklist)
            {
                Blok.listaTymczasowa.Add(blok);
                blok.odnajdzBlokiPotomne();
            }


        }
        public void DodajCharakter(string _ulozenie)
        {
            if (_ulozenie == "PION")
            {
                ustawienie = "PION";
            }
            if (_ulozenie == "POZ")
            {
                ustawienie = "POZ";
            }
        }

        public void dodajBloki(int _liczba, string _ulozenie)
        {
            if (_ulozenie == "PION")
            {
                ustawienie = "PION";
            }
            if (_ulozenie == "POZ")
            {
                ustawienie = "POZ";
            }

            bloklist = new List<Blok>();

            for (int i = 0; i < _liczba; i++)
            {
                //  Console.WriteLine(this.ToString());
                Blok blok;
                switch (ustawienie)
                {
                    case "PION":
                         blok = new Blok(this,szerokosc,wysokosc/_liczba,i);

                        break;
                    case "POZ":
                        blok = new Blok(this, szerokosc / (_liczba), wysokosc,i);
                        break;
                    default:
                        blok = new Blok(this, szerokosc, wysokosc,i);
                        break;

                }
               // Blok blok = new Blok(this,);
                bloklist.Add(blok);

            }
        }
        public double ZwrocX()
        {
            return x;
        }
        public double ZwrocY()
        {
            return y;
        }
        public int getID()
        {
            return ID;
        }
        public Blok Przeszukaj(int _ID)
        {
            Blok zmienna = new Blok();
            if (bloklist != null)
            {
                foreach (Blok _blok in bloklist)
                {
                    if (_blok.getID() == _ID)
                    {
                        zmienna = _blok;
                        break;
                    }
                    else
                    {
                        _blok.Przeszukaj(_ID);

                    }
                }
            }
            return zmienna;

        }

        public Blok PrzeczytajWszystko()
        {
            Blok zmienna = new Blok();
            Console.WriteLine(this.ToString());
            if (bloklist != null)
            {
                foreach (Blok _blok in bloklist)
                {
                    // richTextBox1.AppendText(_blok.ToString()+" ");

                    _blok.PrzeczytajWszystko();
                }
            }
            return zmienna;

        }
        public List<Blok> GetBloki()
        {
            return bloklist;
        }
        public string ZwrocUstawienie()
        {
            return ustawienie;
        }
        public override string ToString()
        {
            return ID+" "+ustawienie+" "+ szerokosc+" "+wysokosc;
        }



    }


}
