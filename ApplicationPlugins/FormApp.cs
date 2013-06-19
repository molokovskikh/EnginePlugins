
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnginePlugins;
using EnginePlugins.Interfaces;

namespace ApplicationPlugins
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Инициализация всех доступных плагинов
            IApplication app = new ApplicationImp{ MainMenu = mainMenu, StatusBar = statusBar, MainForm = this };
            PluginsFactory.Instance.Aggregate(0, (z, p) => { p.Init(app); return z; });
        }
    }
}
