using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnginePlugins.Interfaces;

namespace ApplicationPlugins
{ 

    //реализация контракта обмена с плагином
    public class ApplicationImp: IApplication
    {        
        public System.Windows.Forms.MenuStrip MainMenu
        {
            get;
            set;
        }

        public System.Windows.Forms.StatusStrip StatusBar
        {
            get;
            set;
        }

        public System.Windows.Forms.Form MainForm
        {
            get;
            set;
        }
    }
}
