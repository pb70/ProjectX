using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoadReaderUtils;

namespace LoadReaderServiceConfigUtil
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LogEntries log = Common.LoadConfig<LogEntries>(openFileDialog1.FileName);
                propertyGrid1.SelectedObject = log;
                propertyGrid1.PropertySort = PropertySort.Alphabetical;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Common.SaveCofig(((LogEntries)propertyGrid1.SelectedObject), saveFileDialog1.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            propertyGrid1.SelectedObject = new LogEntries();
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            // Ensure the Form remains square (Height = Width).
            if (control.Size.Height != control.Size.Width)
            {
                propertyGrid1.Size = new Size(control.Size.Width-30, control.Size.Height-80);

            }
        }
    }
}
