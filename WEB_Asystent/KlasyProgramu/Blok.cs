namespace WEB_Asystent.KlasyProgramu
{
    public class Blok
    {
        //  private static int cnt=0;
        private Zakladki zakladka;
        //   private static List<Blok> listaTymczasowa = new List<Blok>();
        private double x;
        private double y;
        private bool ustawionoWymiar = false;
        public bool zablokowanaSzerokosc { get; set; }
        public bool zablokowanaWysokosc { get; set; }
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

        public void UsunWiazania()
        {
            zablokowanaSzerokosc = false;
            zablokowanaWysokosc = false;
            WskaznikUstawieniaWymiaruPrzezUzytkownika = false;

            foreach (var blok in bloklist)
            {
                blok.UsunWiazania();
            }
        }
        public void usunGrupe()
        {
            if (parent != null)
            {
                parent.bloklist.Clear();
            }
        }
        public void usunBlok()
        {
            if (parent != null)
            {
                if (parent.bloklist.Count > 2)
                {
                    parent.bloklist.Remove(this);
                    parent.updateXY();
                }
                else
                {
                    parent.bloklist.Clear();
                }

                // parent.bloklist.Clear();
            }
        }

        public void updateXY()
        {
            if (bloklist.Count > 0)
            {
                bloklist[0].X = X;
                bloklist[0].Y = Y;
                //    bloklist[0].updateXY();

                var liczbaSzerokosci = liczbaSzerokosciNieZablokowanych();
                var liczbaWysokosci = liczbaWysokosciNieZablokowanych();
                var dlugoscSzerokosci = szerokoscZablokowanychDisplay();
                var dlugoscWysokosci = wysokoscZablokowanychDisplay();

                for (var i = 1; i < bloklist.Count; i++)
                {

                    switch (ustawienie)
                    {
                        case "POZ":

                            if (bloklist[i - 1].zablokowanaSzerokosc)
                            {
                                bloklist[i].X = bloklist[i - 1].X + bloklist[i - 1].szerokosc;
                            }
                            else
                            {
                                bloklist[i - 1].szerokosc = (szerokosc - dlugoscSzerokosci) / liczbaSzerokosci;
                                bloklist[i].X = bloklist[i - 1].X + (szerokosc - dlugoscSzerokosci) / liczbaSzerokosci;
                            }
                            if (!bloklist[i].zablokowanaSzerokosc)
                            {
                                bloklist[i].szerokosc = (szerokosc - dlugoscSzerokosci) / liczbaSzerokosci;
                            }
                            bloklist[i - 1].wysokosc = wysokosc;
                            bloklist[i].wysokosc = wysokosc;
                            bloklist[i].Y = bloklist[i - 1].Y;

                            break;
                        case "PION":
                            if (bloklist[i - 1].zablokowanaWysokosc)
                            {
                                bloklist[i].Y = bloklist[i - 1].Y + bloklist[i - 1].wysokosc;
                            }
                            else
                            {
                                bloklist[i - 1].wysokosc = (wysokosc - dlugoscWysokosci) / liczbaWysokosci;
                                bloklist[i].Y = bloklist[i - 1].Y + (wysokosc - dlugoscWysokosci) / liczbaWysokosci;
                            }
                            if (!bloklist[i].zablokowanaWysokosc)
                            {
                                bloklist[i].wysokosc = (wysokosc - dlugoscWysokosci) / liczbaWysokosci;
                            }
                            bloklist[i].X = bloklist[i - 1].X;
                            bloklist[i - 1].szerokosc = szerokosc;
                            bloklist[i].szerokosc = szerokosc;
                            break;
                        default:
                            break;
                    }
                    //   bloklist[i].updateXY();

                }
                foreach (var blok in bloklist)
                {
                    blok.updateXY();
                }
            }

        }
        public void WstawZablokujSzerokoscDown(double _szerokosc)
        {
            if (!zablokowanaSzerokosc)
            {
                SzerokoscZew = _szerokosc;
                zablokowanaSzerokosc = true;
                switch (ustawienie)
                {
                    case "PION":

                        // szerokosc = wartoscSzerokosci;
                        // if (!czyWDownZablokowanoSzerokosc())
                        // {
                        //SzerokoscZew = _szerokosc;
                        //zablokowanaSzerokosc = true;
                        foreach (Blok blok in bloklist)
                        {
                            blok.WstawZablokujSzerokoscDown(_szerokosc);
                        }
                        //   }

                        break;
                    case "POZ":

                        //  SzerokoscZew = wartoscSzerokosci;

                        var roznica = _szerokosc - szerokoscZablokowanych();
                        var liczba = liczbaSzerokosciNieZablokowanych();

                        if (liczba == 1)
                        {
                            zablokowanaSzerokosc = true;
                            foreach (Blok blok in bloklist)
                            {
                                if (!blok.zablokowanaSzerokosc)
                                {
                                    blok.WstawZablokujSzerokoscDown(roznica / liczba);
                                    // blok.zablokowanaSzerokosc = true;
                                }

                            }

                            //    blok.WstawZablokujSzerokoscDown(_szerokosc);
                        }
                        else
                        {
                            if (liczba == 0)
                            {

                            }
                        }

                        //if (liczba != 0)
                        //{
                        //    foreach (Blok blok in bloklist)
                        //    {
                        //        if (!blok.zablokowanaSzerokosc)
                        //        {
                        //            blok.ZmienSzerokoscDown(roznica / liczba);
                        //        }

                        //    }
                        //}


                        break;
                    default:

                        //  SzerokoscZew = wartoscSzerokosci;
                        // parent.ZmienSzerokosc(wartoscSzerokosci);
                        break;
                }
            }

        }
        public void WstawZablokujSzerokoscUp(double _szerokosc)
        {
            WstawZablokujSzerokoscDown(_szerokosc); // zjechanie z blokada w dół
            if (parent != null) // gdy nie ma rodzica (blok 1 )
            {
                switch (parent.ustawienie) // sprw ustawienia rodzica
                {
                    case "PION":
                        if (!parent.zablokowanaSzerokosc)// gdy mozna zmienic szerokosc
                        {
                            parent.WstawZablokujSzerokoscUp(_szerokosc);

                        }
                        break;
                    case "POZ":
                        var roznica = parent.SzerokoscZew - parent.szerokoscZablokowanych();
                        var liczba = parent.liczbaSzerokosciNieZablokowanych();
                        if (parent.zablokowanaSzerokosc) //parent jest zablokowany
                        {
                            if (liczba == 1) // kiedy zostal jeden element w liscie a parent jest zablokowany
                            {
                                foreach (Blok blok in parent.bloklist)
                                {
                                    if (!blok.zablokowanaSzerokosc)
                                    {
                                        blok.WstawZablokujSzerokoscDown(roznica); // dla tego elementu nalezy zablokowac wysokosc
                                    }
                                }
                            }
                            else { }
                        }
                        else
                        {
                            if (liczba == 0)// kiedy parent nie zablokowany to nalezy parenta zablokowac
                            {
                                parent.WstawZablokujSzerokoscUp(parent.szerokoscZablokowanych());
                            }
                            else
                            {
                            }
                        }

                        break;
                    default:
                        break;
                }
            }
            //WstawZablokujSzerokoscDown(_szerokosc);
            //if (parent != null)
            //{
            //    switch (parent.ustawienie)
            //    {
            //        case "PION":

            //            if (!parent.zablokowanaSzerokosc)// gdy mozna zmienic szerokosc
            //            {

            //                parent.WstawZablokujSzerokoscUp(_szerokosc);

            //            }


            //            break;
            //        case "POZ":

            //            if (!parent.zablokowanaSzerokosc)// gdy mozna zmienic szerokosc
            //            {
            //                var roznica = _szerokosc - parent.szerokoscZablokowanych();
            //                var liczba = parent.liczbaSzerokosciNieZablokowanych();

            //                //   parent.WstawZablokujSzerokoscUp(_szerokosc);
            //                if (liczba == 1)
            //                {
            //                    // zablokowanaSzerokosc = true;
            //                    foreach (Blok blok in bloklist)
            //                    {
            //                        if (!blok.zablokowanaSzerokosc)
            //                        {
            //                            parent.WstawZablokujSzerokoscUp(_szerokosc);
            //                            blok.WstawZablokujSzerokoscDown(roznica / liczba);
            //                            // parent.WstawZablokujSzerokoscUp(_szerokosc);
            //                            // blok.zablokowanaSzerokosc = true;
            //                        }

            //                    }


            //                }
            //                else
            //                {
            //                    if (liczba == 0)
            //                    {

            //                    }
            //                }
            //            }


            //            break;
            //        default:


            //            break;
            //    }
            //}

        }
        public void WstawZablokujWysokoscUp(double _wysokosc)
        {
            WstawZablokujWysokoscDown(_wysokosc); // zjechanie z blokada w dół
            if (parent != null) // gdy nie ma rodzica (blok 1 )
            {
                switch (parent.ustawienie) // sprw ustawienia rodzica
                {
                    case "PION":
                        var roznica = parent.WysokoscZew - parent.wysokoscZablokowanych();
                        var liczba = parent.liczbaWysokosciNieZablokowanych();
                        if (parent.zablokowanaWysokosc) //parent jest zablokowany
                        {
                            if (liczba == 1) // kiedy zostal jeden element w liscie a parent jest zablokowany
                            {
                                foreach (Blok blok in parent.bloklist)
                                {
                                    if (!blok.zablokowanaWysokosc)
                                    {
                                        blok.WstawZablokujWysokoscDown(roznica); // dla tego elementu nalezy zablokowac wysokosc
                                    }
                                }
                            }
                            else { }
                        }
                        else
                        {
                            if (liczba == 0)// kiedy parent nie zablokowany to nalezy parenta zablokowac
                            {
                                parent.WstawZablokujWysokoscUp(parent.wysokoscZablokowanych());
                            }
                            else
                            {
                            }
                        }

                        break;
                    case "POZ":
                        if (!parent.zablokowanaWysokosc)// gdy mozna zmienic szerokosc
                        {
                            parent.WstawZablokujWysokoscUp(_wysokosc);

                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public void WstawZablokujWysokoscDown(double _wysokosc)
        {
            WysokoscZew = _wysokosc;
            zablokowanaWysokosc = true;
            switch (ustawienie)
            {
                case "PION":
                    //  SzerokoscZew = wartoscSzerokosci;

                    var roznica = _wysokosc - wysokoscZablokowanych();
                    var liczba = liczbaWysokosciNieZablokowanych();

                    if (liczba == 1)
                    {
                        zablokowanaWysokosc = true;
                        foreach (Blok blok in bloklist)
                        {
                            if (!blok.zablokowanaWysokosc)
                            {
                                blok.WstawZablokujWysokoscDown(roznica / liczba);
                                // blok.zablokowanaSzerokosc = true;
                            }

                        }

                        //    blok.WstawZablokujSzerokoscDown(_szerokosc);
                    }
                    else
                    {
                        if (liczba == 0)
                        {

                        }
                    }



                    break;
                case "POZ":
                    // szerokosc = wartoscSzerokosci;
                    // if (!czyWDownZablokowanoSzerokosc())
                    // {
                    //SzerokoscZew = _szerokosc;
                    //zablokowanaSzerokosc = true;
                    foreach (Blok blok in bloklist)
                    {
                        blok.WstawZablokujWysokoscDown(_wysokosc);
                    }
                    //   }
                    //  SzerokoscZew = wartoscSzerokosci;




                    break;
                default:

                    //  SzerokoscZew = wartoscSzerokosci;
                    // parent.ZmienSzerokosc(wartoscSzerokosci);
                    break;
            }
        }
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
                    if (!zablokowanaSzerokosc)
                    {
                        szerokosc = value * 100.0 / zakladka.szerokosc;
                        //  zablokowanaSzerokosc = true;
                    }
                    else
                    {

                    }


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
                    if (!zablokowanaWysokosc)
                    {
                        wysokosc = value * 100.0 / zakladka.wysokosc;
                        //  zablokowanaWysokosc = true;
                    }
                    else
                    {

                    }
                    // wysokosc = value * 100.0 / zakladka.wysokosc;
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
        public bool WskaznikUstawieniaWymiaruPrzezUzytkownika
        {
            get
            {
                return ustawionoWymiar;

            }
            set
            {
                ustawionoWymiar = value;

            }
        }
        public Blok(Blok _parent, double _szerokosc, double _wysokosc, int _nrWKolei)
        {
            zablokowanaSzerokosc = false;
            zablokowanaWysokosc = false;

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
            zablokowanaSzerokosc = false;
            zablokowanaWysokosc = false;

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
            WskaznikUstawieniaWymiaruPrzezUzytkownika = true;
            if (!zablokowanaSzerokosc)
            {
                WstawZablokujSzerokoscUp(wartoscSzerokosci);
                //   parent.ZmienSzerokoscDown(wartoscSzerokosci);
            }

        }
        public void ZmienWysokosc(double wartoscWysokosci)
        {
            WskaznikUstawieniaWymiaruPrzezUzytkownika = true;
            if (!zablokowanaWysokosc)
            {

                WstawZablokujWysokoscUp(wartoscWysokosci);
                // parent.ZmienWysokoscDown(wartoscWysokosci);
            }

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

                    // szerokosc = wartoscSzerokosci;
                    if (!czyWDownZablokowanoSzerokosc())
                    {
                        SzerokoscZew = wartoscSzerokosci;

                        foreach (Blok blok in bloklist)
                        {
                            blok.ZmienSzerokoscDown(wartoscSzerokosci);
                        }
                    }

                    break;
                case "POZ":

                    //  SzerokoscZew = wartoscSzerokosci;

                    var roznica = wartoscSzerokosci - szerokoscZablokowanych();
                    var liczba = liczbaSzerokosciNieZablokowanych();
                    if (liczba != 0)
                    {
                        foreach (Blok blok in bloklist)
                        {
                            if (!blok.zablokowanaSzerokosc)
                            {
                                blok.ZmienSzerokoscDown(roznica / liczba);
                            }

                        }
                    }


                    break;
                default:

                    SzerokoscZew = wartoscSzerokosci;
                    // parent.ZmienSzerokosc(wartoscSzerokosci);
                    break;
            }



        }
        private double szerokoscZablokowanych()
        {
            var suma = 0.0;
            foreach (var blok in bloklist)
            {
                if (blok.zablokowanaSzerokosc)
                {
                    suma = suma + blok.SzerokoscZew;
                }
            }
            return suma;
        }
        private double szerokoscZablokowanychDisplay()
        {
            var suma = 0.0;
            foreach (var blok in bloklist)
            {
                if (blok.zablokowanaSzerokosc)
                {
                    suma = suma + blok.szerokosc;
                }
            }
            return suma;
        }
        private double liczbaSzerokosciNieZablokowanych()
        {
            var suma = 0;
            foreach (var blok in bloklist)
            {
                if (!blok.zablokowanaSzerokosc)
                {
                    suma++;
                }
            }
            return suma;
        }
        private double wysokoscZablokowanych()
        {
            var suma = 0.0;
            foreach (var blok in bloklist)
            {
                if (blok.zablokowanaWysokosc)
                {
                    suma = suma + blok.WysokoscZew;
                }
            }
            return suma;
        }
        private double wysokoscZablokowanychDisplay()
        {
            var suma = 0.0;
            foreach (var blok in bloklist)
            {
                if (blok.zablokowanaWysokosc)
                {
                    suma = suma + blok.wysokosc;
                }
            }
            return suma;
        }
        private double liczbaWysokosciNieZablokowanych()
        {
            var suma = 0;
            foreach (var blok in bloklist)
            {
                if (!blok.zablokowanaWysokosc)
                {
                    suma++;
                }
            }
            return suma;
        }
        private bool czyWDownZablokowanoSzerokosc()
        {
            bool czy = false;
            foreach (Blok blok in bloklist)
            {
                if (blok.zablokowanaSzerokosc)
                {
                    czy = true;
                    break;
                };
            }
            return czy;
        }
        private bool czyWDownZablokowanoWysokosc()
        {
            bool czy = false;
            foreach (Blok blok in bloklist)
            {
                if (blok.zablokowanaWysokosc)
                {
                    czy = true;
                    break;
                };
            }
            return czy;
        }
        public void ZmienWysokoscDown(double wartoscWysokosci)
        {
            // szerokosc = wartoscSzerokosci;

            switch (ustawienie)
            {
                case "PION":
                    //var roznica = wartoscWysokosci - wysokoscZablokowanych();
                    //var liczba = liczbaWysokosciZablokowanych();
                    //if (liczba != 0)
                    //{
                    //    foreach (Blok blok in bloklist)
                    //    {
                    //        if (!blok.zablokowanaSzerokosc)
                    //        {
                    //            blok.ZmienWysokoscDown(roznica / liczba);
                    //        }

                    //    }
                    //}
                    break;
                case "POZ":
                    WysokoscZew = wartoscWysokosci;
                    foreach (Blok blok in bloklist)
                    {
                        blok.ZmienWysokoscDown(wartoscWysokosci);
                    }
                    break;
                default:
                    WysokoscZew = wartoscWysokosci;

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
            var dodajGrupe = true;
            if (parent != null)
            {
                if (parent.ustawienie == _ulozenie)
                {
                    var iter = parent.bloklist.FindIndex(blok => blok.ID == this.ID);

                    parent.dodajBlok(iter);
                    parent.updateXY();
                    dodajGrupe = false;
                }
                else
                {
                    dodajGrupe = true;
                }
            }
            else
            {
                dodajGrupe = true;
            }
            if (dodajGrupe)
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


        }
        private void dodajBlok(int _iter)
        {
            Blok blok = new Blok(this, 0, 0, bloklist.Count);
            bloklist.Insert(_iter, blok);
            for (int i = 0; i < bloklist.Count; i++)
            {
                switch (ustawienie)
                {
                    case "PION":
                        bloklist[i].wysokosc = wysokosc / bloklist.Count;
                        bloklist[i].szerokosc = szerokosc;
                        bloklist[i].X = X;
                        bloklist[i].Y = Y + i * wysokosc / bloklist.Count;

                        break;
                    case "POZ":
                        bloklist[i].szerokosc = szerokosc / bloklist.Count;
                        bloklist[i].wysokosc = wysokosc;
                        bloklist[i].Y = Y;
                        bloklist[i].X = X + i * szerokosc / bloklist.Count;
                        break;
                    default:

                        break;

                }
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
