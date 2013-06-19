using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using EnginePlugins;
using EnginePlugins.Interfaces;
using System;


namespace PluginsInfo
{
    public class PluginsInfo:IPlugin
    {
        public string Name
        {
            get { return "PluginsInfo"; }
        }

        public string Description
        {
            get { return "Возвращает информацию по плагинам доступным приложению"; }
        }

        public bool Init(IApplication app)
        {
            app.MainMenu.Items.Add("Plugins Info").Click += delegate(object sender, EventArgs e)
            {
                string info = string.Empty;
                int count = 0;
                MessageBox.Show(
                app.MainForm,
                string.Format(
                            "Количество плагинов:{0}\n",
                            PluginsFactory.Instance.Aggregate(count, (z, p) =>
                            {
                                info += string.Format("{0}  -  Название:\"{1}\"  Описание:\"{2}\"\n", ++z, p.Name, p.Description);
                                return z;
                            })
                              ) + info,
               "Информация по плагинам");
            };
            return true;
        }

        public void Done()
        {
            throw new System.NotImplementedException();
        }
    }
}
