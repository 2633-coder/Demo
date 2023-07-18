using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo.Common;
using Demo.Form_UI;
using Demo.Model;

namespace Demo
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
        }

        private void Form_Menu_Load(object sender, EventArgs e)
        {
            List<DemoMenu> menus = GetConfigInfo(Application.StartupPath + "\\Config\\Menu.txt");

            foreach (DemoMenu menu in menus)
            {
                Button button = new Button
                {
                    Name = "btn_" + menu.Name,
                    Text = menu.Text,
                    Size = new Size { Width = 120, Height = 40 }
                };
                button.Click += new EventHandler(FormShow);

                flowLayoutPanel1.Controls.Add(button);
            }
        }

        public List<DemoMenu> GetConfigInfo(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            string str = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return JsonHelper.Newtonsoft_Deserialize<List<DemoMenu>>(str);
        }

        private void FormShow(object sender, EventArgs e)
        {
            string name = ((ControlAccessibleObject)((ControlAccessibleObject)((Control)sender).AccessibilityObject).Owner.AccessibilityObject).Owner.Name;

            switch (name)
            {
                case "btn_Signature":
                    new Form_Signature().Show();
                    break;
                case "btn_LabelMove":
                    new Form_LabelMove().Show();
                    break;
                case "btn_ChartPoint":
                    new Form_ChartPoint().Show();
                    break;
                case "btn_Calender":
                    new Form_Calender(new SequenceModel()).Show();
                    break;                    
            }

        }
    }
}
