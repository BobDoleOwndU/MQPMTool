using FoxTool.Fox;
using Microsoft.WindowsAPICodePack.Dialogs;
using MQPMTool2.Classes;
using MQPMTool2.Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MQPMTool2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeComboBox();
        } //MainForm

        private void InitializeComboBox()
        {
            foreach(Parts parts in Globals.partsList.list)
                partsComboBox.Items.Add(parts.name);

            foreach(Outfit outfit in Globals.outfitList.list)
                outfitComboBox.Items.Add(outfit.name);
        } //InitializeComboBox

        private void outputTestButton_Click(object sender, EventArgs e)
        {
            string outputFolder = outputFolderTextBox.Text;
            Parts parts = Globals.partsList.list[partsComboBox.SelectedIndex];
            Outfit outfit = Globals.outfitList.list[outfitComboBox.SelectedIndex];

            string mdlPath = $"{outputFolder}{parts.fpkPath}_fpk{outfit.mdlPath}";
            Directory.CreateDirectory(Path.GetDirectoryName(mdlPath));
            File.Copy(outfit.mdlPath.Substring(1), mdlPath);

            string cnpPath = $"{outputFolder}{parts.fpkPath}_fpk{outfit.cnpPath}";
            Directory.CreateDirectory(Path.GetDirectoryName(cnpPath));
            File.Copy(outfit.cnpPath.Substring(1), cnpPath);

            string rdvPath = $"{outputFolder}{parts.fpkPath}_fpk{outfit.rdvPath}";
            Directory.CreateDirectory(Path.GetDirectoryName(rdvPath));
            File.Copy(outfit.rdvPath.Substring(1), rdvPath);

            foreach(Sim sim in outfit.sims)
            {
                string simPath = $"{outputFolder}{parts.fpkPath}_fpkd{sim.path}";
                Directory.CreateDirectory(Path.GetDirectoryName(simPath));
                File.Copy(sim.path.Substring(1), simPath);
            } //foreach

            string partsPath = $"{outputFolder}{parts.fpkPath}_fpkd{parts.partsPath}";
            Directory.CreateDirectory(Path.GetDirectoryName(partsPath));

            using (FileStream stream = new FileStream(partsPath, FileMode.Create))
            {
                try
                {
                    FoxFile foxFile = PartsConverter.GetFoxFile(parts, outfit);
                    foxFile.CalculateHashes();
                    foxFile.CollectStringLookupLiterals();
                    foxFile.Write(stream);
                } //try
                finally
                {
                    stream.Close();
                } //finally
            } //using
        } //outputTestButton_Click

        private void outputFolderButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog folderDialog = new CommonOpenFileDialog();
            folderDialog.IsFolderPicker = true;
            if(folderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                outputFolderTextBox.Text = folderDialog.FileName;
            } //if
        } //outputFolderButton_Click
    } //class ends
}//namespace ends