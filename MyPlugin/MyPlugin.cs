using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using EnginePlugins.Interfaces;
using System.Windows.Forms;

namespace MyPlugin
{
    public class MyPlugin:IPlugin
    {
        public string Name
        {
            get { return "MyPlugin"; }
        }

        public string Description
        {
            get { return "My Demo Plugin"; }
        }

        public bool Init(IApplication app)
        {
            try
            {                
                app.MainMenu.Items.Add("Item from MyPlugin").Click+=delegate(object sender,EventArgs e)
                {
                   Form childDoc = new Form() {  MdiParent =  app.MainForm };
                   childDoc.Text = this.Description;
                   childDoc.Controls.Add(new Label() { Text = "This MDI child form MyPlugin" });
                   childDoc.Show();
                };
                app.StatusBar.Items.Add("Click test").Click += delegate(object sender, EventArgs e)
                {
                    MessageBox.Show(app.MainForm, "Click Test OK!");
                };               
                return true;
            }
            catch(Exception e)
            {
                Debug.Assert(false,e.Message);                
            }
            finally                
            {
                
            }
            return false;
        }

        public void Done()
        {
            throw new NotImplementedException();
        }
    }
}
