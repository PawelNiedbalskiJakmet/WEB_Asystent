using WEB_Asystent.KlasyProgramu;

namespace WEB_Asystent.Global
{
    public class Zakladki
    {
        public static int cnt_zakladek = 0;

        private User user;
        public User User { get { return user; } }
        public Zakladki(string _nazwa, User _user)
        { 
            CNT = 0;
            cnt_zakladek++;
           
            Nazwa = _nazwa;
            ZakladkaID = cnt_zakladek;
            Blok = new Blok(this);
            user = _user;
        }
        public void IncCNT()
        {
            CNT++;
        }
        public int wygenerowaneId
        {
            get
            {
                return CNT;
            }
        }

        public string Nazwa { get; set; }
       
        public Blok Blok;

        public int ZakladkaID { get; set; }
        public int UserID
        {
            get
            {
                return User.UserID;
            }
        }
        private int CNT;

    }
}
