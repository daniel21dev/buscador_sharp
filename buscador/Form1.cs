using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buscador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void obtenerArchivos(string dir, string query ="" )
        {
            string[] filePaths = Directory.GetFiles(dir, query ,SearchOption.AllDirectories );
            listBox1.Items.Clear();
            if( filePaths.Length == 0)
            {
                listBox1.Items.Add("archivo no encontrado, verfique su busqueda");
            }
            foreach (String file in filePaths )
            {
                listBox1.Items.Add(file);   
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var drv = DriveInfo.GetDrives();
        

            foreach (DriveInfo dInfo in drv)
            {
                if ( dInfo.DriveType.ToString().Equals("Removable") )
                {
                    comboBox1.Items.Add(dInfo.Name);
                }
                
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = comboBox1.SelectedItem.ToString();
            obtenerArchivos(selected);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo( listBox1.SelectedItem.ToString() ) { UseShellExecute = true });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selected = comboBox1.SelectedItem.ToString();
            String query = textBox1.Text.Trim();
            listBox2.Items.Add( query );
            obtenerArchivos(selected, "*"+query+"*");
            
        }
    }
}
