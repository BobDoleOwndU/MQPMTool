using FoxTool.Fox;
using MQPMTool2.Static;
using System;
using System.IO;
using System.Windows.Forms;

namespace MQPMTool2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        } //MainForm

        private void button1_Click(object sender, EventArgs e)
        {
            string name = $"{Path.GetFileNameWithoutExtension(textBox2.Text)}.parts";

            using (FileStream stream = new FileStream(name, FileMode.Create))
            {
                try
                {
                    FoxFile foxFile = PartsConverter.GetFoxFile(textBox1.Text, textBox2.Text);
                    foxFile.CalculateHashes();
                    foxFile.CollectStringLookupLiterals();
                    foxFile.Write(stream);
                } //try
                finally
                {
                    stream.Close();
                } //finally
            } //using
        } //button1_Click
    } //partial class MainForm ends
} //namespace MQPMTool2 ends
