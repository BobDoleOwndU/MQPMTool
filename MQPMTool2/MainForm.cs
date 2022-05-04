using MQPMTool2.Static;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Xml2CSharp;

namespace MQPMTool2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        } //MainForm

        private void button1_Click(object sender, System.EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Fox));

            using (FileStream stream = new FileStream("test.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(stream, PartsConverter.ConvertToFox());
            } //using
        } //button1_Click
    } //partial class MainForm ends
} //namespace MQPMTool2 ends
