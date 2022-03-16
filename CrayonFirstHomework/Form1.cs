using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrayonFirstHomework
{
    public partial class Form1 : Form
    {
        bool folderSelected = false;
        string outputPath = "";
        string finalVideoName = "";
        ScreenREC screenrecord;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderSelected)
            {
                tmrRecord.Start();
            }
            else
            {
                MessageBox.Show("You must select a folder to save to before recording", "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Select an Output Folder";

            if(folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                outputPath = folderBrowser.SelectedPath;
                folderSelected = true;

                Rectangle bounds = Screen.FromControl(this).Bounds;
                screenrecord = new ScreenREC(bounds, outputPath);
            }
            else
            {
                MessageBox.Show("Please select a Folder", "Error");
            }

        }

        private void tmrRecord_Tick(object sender, EventArgs e)
        {
            screenrecord.RecordAudio();
            screenrecord.RecordVideo();

            visibleTimer.Text = screenrecord.GetElapsed() + "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tmrRecord.Stop();
            screenrecord.Stop();
            Application.Restart();
        }
    }
}
