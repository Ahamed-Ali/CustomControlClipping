using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1
{
    public class MyClass
    {
        public static bool IsPhone()
        {
            return DeviceInfo.Current.Idiom == DeviceIdiom.Phone;
        }

        public string Value { get; set; }
        //public bool Btn2Visible { get; set; }


        //public bool SwMostraAttivitaBtn { get => UtenteMobile.UteLoggato.lstAbilitazioni.Find(x => x.nomeTransazione == TransazioniFRMK.COL_ATTNOTE_CONF_WO)?.abilitato ?? false; }
        //public bool SwMostraMarketingBtn { get => UtenteMobile.UteLoggato.lstAbilitazioni.Find(x => x.nomeTransazione == TransazioniFRMK.COL_ICONA_MKT_WO)?.abilitato ?? false; }
        public bool SwMostraAttivitaBtn { get; set; }
        public bool SwMostraMarketingBtn { get; set; }

        public int SwColonnaBtnAttivita { get => SwMostraAttivitaBtn ? IsPhone() ? 1 : 4 : 0; }
        public int SwColonnaBtnMarketing { get => SwMostraMarketingBtn ? IsPhone() ? 2 : 5 : SwMostraAttivitaBtn && SwMostraMarketingBtn ? 3 : 0; }

        public ColumnDefinitionCollection SwColDef
        {
            get
            {
                ColumnDefinitionCollection c = new() { new ColumnDefinition(GridLength.Star) };
                if (SwMostraAttivitaBtn) c.Add(new ColumnDefinition(GridLength.Star));
                if (SwMostraMarketingBtn) c.Add(new ColumnDefinition(GridLength.Star));
                return c;
            }
        }
    }

    public partial class ViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<MyClass> _MyList;

        public ViewModel()
        {
            var _list = new List<MyClass>();
            for (int i = 0; i < 20; i++)
            {
                _list.Add(new MyClass { Value = i.ToString(), SwMostraAttivitaBtn = i % 2 == 0, SwMostraMarketingBtn = true });
            }

            MyList = _list;
        }
    }
}
