using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using EnginePlugins.Interfaces;
using System.Windows.Forms;

namespace nextPlugin
{
    public class nextPlugin:IPlugin
    {
        public string Name
        {
            get { return "nextPlugin"; }
        }

        public string Description
        {
            get { return "Description nextPlugin"; }
        }

        public bool Init(IApplication app)
        {
            app.MainMenu.Items.Add("Item from nextPlugin").Click += delegate(object sender, EventArgs e)
            {
                Process.Start("http://novosibirsk.hh.ru/resume/ebec0130ff010893820039ed1f3133546b3756");
            };
            return true;
        }

        public void Done()
        {
            throw new NotImplementedException();
        }
    }
}
