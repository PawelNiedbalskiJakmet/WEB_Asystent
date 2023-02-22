namespace WEB_Asystent.KlasyProgramu
{
    public class Blok
    {
        //  private static int cnt=0;
        private Zakladki zakladka;
        //   private static List<Blok> listaTymczasowa = new List<Blok>();
        private double x;
        private double y;
        //public static List<Blok> OdczytajPotomneBloki(Blok _blok)
        //{
        //    Blok.listaTymczasowa = new List<Blok>();

        //    _blok.odnajdzBlokiPotomne();

        //    return listaTymczasowa;
        // }
        // dunamiczne elementy
        double szerokosc;
        double wysokosc;
        List<Blok> bloklist = new List<Blok>();
        Blok parent;
        string ustawienie = "";
        private int id = 0;
        public double SzerokoscZew
        {
            get
            {
                if (zakladka.szerokosc == 0)
                {
                    return -10;
                }
                else
                {
                    return zakladka.szerokosc * szerokosc / 100.0;
                }

            }
            set
            {
                if (zakladka.szerokosc == 0)
                {

                }
                else
                {
                    szerokosc = value * 100.0 / zakladka.szerokosc;
                }

            }
        }
        public double WysokoscZew
        {
            get
            {
                if (zakladka.wysokosc == 0)
                {
                    return -10;
                }
                else
                {
                    return zakladka.wysokosc * wysokosc / 100.0;
                }
              //  return zakladka.wysokosc * wysokosc / 100.0;
            }
            set
            {
                if (zakladka.wysokosc == 0)
                {

                }
                else
                {
                    wysokosc = value * 100.0 / zakladka.wysokosc;
                }
              
            }
        }
        public double SzerokoscWew
        {
            get
            {
                if (zakladka.szerokosc == 0)
                {
                    return -10;
                }
                else
                {
                    return (zakladka.szerokosc * szerokosc / 100) * 0.9;
                }
            
            }
            set
            {
                if (zakladka.szerokosc == 0)
                {

                }
                else
                {
                    szerokosc = ((value / 0.9) * 100.0 / zakladka.szerokosc);
                }
             
            }
        }
        public double WysokoscWew
        {
            get
            {
                if (zakladka.wysokosc == 0)
                {
                    return -10;
                }
                else
                {
                    return (zakladka.wysokosc * wysokosc / 100.0) * 0.9;
                }

               
            }
            set
            {
                if (zakladka.wysokosc == 0)
                {

                }
                else
                {
                    wysokosc = ((value / 0.9) * 100.0) / zakladka.wysokosc;
                }
               
            }
        }
        public Blok(Blok _parent, double _szerokosc, double _wysokosc, int _nrWKolei)
        {
            szerokosc = _szerokosc;
            wysokosc = _wysokosc;
            parent = _parent;
            zakladka = _parent.zakladka;
            zakladka.IncCNT();
            id = zakladka.wygenerowaneId;
            if (_parent.Ustawienie == "POZ")
            {
                x = szerokosc * _nrWKolei + _parent.X;
                y = _parent.Y;
            }
            else;
            if (_parent.Ustawienie == "PION")
            {
                x = _parent.X;
                y = wysokosc * _nrWKolei + _parent.Y;
            }
            else;

        }
        //public Blok(double _szerokosc, double _wysokosc)
        //{
        //    x = 0;
        //    y = 0;
        //    szerokosc = _szerokosc;
        //    wysokosc = _wysokosc;
        //    cnt++;
        //    id = cnt;
        //}
        public Blok(Zakladki _zakladka)
        {
            x = 0;
            y = 0;

            szerokosc = 100;
            wysokosc = 100;
            //id = cnt;
            zakladka = _zakladka;
            zakladka.IncCNT();
            id = zakladka.wygenerowaneId;
        }
        public Blok()
        {

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
            var ob = this;
            if (parent.ustawienie == "PION")
            {
                ob = parent.NajszerszaGrupaZbierajacaPionowe();
            }
            else
            {
                ob = this;
            }
            return ob;
        }
        private List<Blok> zrobListeDown(List<Blok> _input)
        {
            _input.Add(this);
            foreach (Blok obc in bloklist)
            {
                obc.zrobListeDown(_input);
            }
            return _input;
        }
        public List<Blok> ZrobListeDown()
        {
            var zmienna = new List<Blok>();
            this.zrobListeDown(zmienna);
            return zmienna;
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
        //private void odnajdzBlokiPotomne()
        //{
        //    //  var zmienna= new List<Blok>();
        //    foreach (Blok blok in bloklist)
        //    {
        //        Blok.listaTymczasowa.Add(blok);
        //        blok.odnajdzBlokiPotomne();
        //    }


        //}


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
                        blok = new Blok(this, szerokosc, wysokosc / _liczba, i);

                        break;
                    case "POZ":
                        blok = new Blok(this, szerokosc / (_liczba), wysokosc, i);
                        break;
                    default:
                        blok = new Blok(this, szerokosc, wysokosc, i);
                        break;

                }
                // Blok blok = new Blok(this,);
                bloklist.Add(blok);

            }
        }

        public double X
        {

            get
            {
                return x;
            }
            set
            {
                x = value;
            }

        }
        public double Y
        {

            get
            {
                return y;
            }
            set
            {
                y = value;
            }

        }


        public double Wysokosc
        {
            get
            {
                return wysokosc;
            }
            set
            {
                wysokosc = value;
            }

        }
        public int UserID
        {
            get
            {
                return zakladka.User.UserID;
            }


        }
        public int ZakladkaID
        {
            get
            {
                return zakladka.ZakladkaID;
            }


        }
        public double Szerokosc
        {
            get
            {
                return szerokosc;
            }
            set
            {
                szerokosc = value;
            }

        }

        //private Blok Przeszukaj(int _ID, Blok odszukane) // to chyba nie dziala
        //{
        //    Blok zmienna = odszukane;// = this;
        //                             //  Blok.cnt--;
        //    if (bloklist != null)
        //    {
        //        foreach (Blok _blok in bloklist)
        //        {
        //            if (_blok.ID == _ID)
        //            {
        //                zmienna = _blok;
        //                break;
        //            }
        //            else
        //            {
        //                zmienna = _blok.Przeszukaj(_ID, odszukane);

        //            }
        //        }
        //    }
        //    return zmienna;

        //}
        public Blok Przeszukaj(int _ID)
        {

            return ZrobListeDown().Find(x => x.ID == _ID);

        }

        //public Blok PrzeczytajWszystko()
        //{
        //    Blok zmienna = this;
        //    //Blok.cnt--;
        //    Console.WriteLine(this.ToString());
        //    if (bloklist != null)
        //    {
        //        foreach (Blok _blok in bloklist)
        //        {
        //            // richTextBox1.AppendText(_blok.ToString()+" ");

        //            _blok.PrzeczytajWszystko();
        //        }
        //    }
        //    return zmienna;

        //}

        public List<Blok> BlokiWewnetrzne
        {

            get
            {
                return bloklist;
            }
            set
            {
                bloklist = value;
            }

        }
        public string Ustawienie
        {

            get
            {
                return ustawienie;
            }
            set
            {
                ustawienie = value;
            }

        }
        public override string ToString()
        {
            return id + " " + ustawienie + " " + szerokosc + " " + wysokosc;
        }

        public int ID
        {

            get
            {
                return id;
            }
            set
            {
                id = value;
            }

        }
    }


}
