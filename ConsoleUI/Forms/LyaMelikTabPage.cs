using System.Windows.Forms;
using WinFormsUI.Sessions;

namespace ConsoleUI.Forms
{
    class LyaMelikTabPage : TabPage
    {
        public Session CurrentSession;
        public LyaMelikTabPage(Session ses) : base(ses.Name)
        {
            CurrentSession = ses;
        }
    }
}
