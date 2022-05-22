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

            //PartsCreationTest();
            //OutfitCreationTest();

            InitializeComboBox();
        } //MainForm

        private void InitializeComboBox()
        {
            foreach(Parts parts in Globals.partsList.list)
                partsComboBox.Items.Add(parts.name);

            foreach(Outfit outfit in Globals.outfitList.list)
                outfitComboBox.Items.Add(outfit.name);
        } //InitializeComboBox

        private void PartsCreationTest()
        {
            Globals.partsList = new PartsList();
            Globals.partsList.list = new List<Parts>();

            {
                Parts parts = new Parts();
                parts.name = "Snake - Fatigues";
                parts.fpkPath = "/Assets/tpp/pack/player/parts/plparts_normal";
                parts.partsPath = "/Assets/tpp/parts/chara/sna/sna0_main0_def_v00.parts";
                parts.fovas = new List<string>();
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm0_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm1_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm2_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm3_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm4_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm6_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm7_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_face0_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_face1_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_face2_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_face4_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_face5_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_face6_v00.fv2");
                Globals.partsList.list.Add(parts);
            } //block
            {
                Parts parts = new Parts();
                parts.name = "Snake - Sneaking Suit";
                parts.fpkPath = "/Assets/tpp/pack/player/parts/plparts_venom";
                parts.partsPath = "/Assets/tpp/parts/chara/sna/sna4_main0_def_v00.parts";
                parts.fovas = new List<string>();
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm0_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm1_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm2_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm3_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm4_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm6_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_arm7_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_face0_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_face1_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_face2_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_face4_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_face5_v00.fv2");
                parts.fovas.Add("/Assets/tpp/fova/chara/sna/sna0_face6_v00.fv2");
                Globals.partsList.list.Add(parts);
            } //block

            Globals.WriteList(Globals.partsList, "PartsList.xml");
        } //PartsCreationTest

        private void OutfitCreationTest()
        {
            Globals.outfitList = new OutfitList();
            Globals.outfitList.list = new List<Outfit>();

            {
                Outfit outfit = new Outfit();
                outfit.name = "Quiet - Default";
                outfit.mdlPath = "/Assets/tpp/chara/qui/Scenes/qui0_main0_def.fmdl";
                outfit.cnpPath = "/Assets/tpp/chara/qui/Scenes/qui0_main0_def.fcnp";
                outfit.rdvPath = "/Assets/tpp/chara/qui/Scenes/qui0_main0_def.frdv";

                outfit.sims = new List<Sim>();

                {
                    Sim sim = new Sim();
                    sim.name = "Sim_asr";
                    sim.path = "/Assets/tpp/chara/sna/Fox_files/sna0_main0_asr.sim";
                    sim.isActive = true;
                    outfit.sims.Add(sim);
                }//block
                {
                    Sim sim = new Sim();
                    sim.name = "Sim_broken_arm";
                    sim.path = "/Assets/tpp/chara/sna/Fox_files/sna0_broken_arm_r.sim";
                    sim.isActive = false;
                    outfit.sims.Add(sim);
                }//block
                {
                    Sim sim = new Sim();
                    sim.name = "SimQuiet";
                    sim.path = "/Assets/tpp/chara/qui/Fox_files/quip_main0_def.sim";
                    sim.isActive = true;
                    outfit.sims.Add(sim);
                }//block

                outfit.additionalFiles = new List<AdditionalFile>();

                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm0_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm1_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm2_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm3_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm4_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm6_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm7_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_face0_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_face1_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_face2_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_face4_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_face5_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_face6_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block

                Globals.outfitList.list.Add(outfit);
            } //block

            {
                Outfit outfit = new Outfit();
                outfit.name = "Quiet - XOF";
                outfit.mdlPath = "/Assets/tpp/mqpm/body-xof.fmdl";
                outfit.cnpPath = "/Assets/tpp/mqpm/femaleinvisible.fcnp";
                outfit.rdvPath = "/Assets/tpp/mqpm/xof.frdv";

                outfit.sims = new List<Sim>();

                {
                    Sim sim = new Sim();
                    sim.name = "Sim_asr";
                    sim.path = "/Assets/tpp/chara/sna/Fox_files/sna0_main0_asr.sim";
                    sim.isActive = true;
                    outfit.sims.Add(sim);
                }//block
                {
                    Sim sim = new Sim();
                    sim.name = "Sim_broken_arm";
                    sim.path = "/Assets/tpp/chara/sna/Fox_files/sna0_broken_arm_r.sim";
                    sim.isActive = false;
                    outfit.sims.Add(sim);
                }//block
                {
                    Sim sim = new Sim();
                    sim.name = "SimQuiet";
                    sim.path = "/Assets/tpp/chara/qui/Fox_files/quip_main0_def.sim";
                    sim.isActive = true;
                    outfit.sims.Add(sim);
                }//block

                outfit.additionalFiles = new List<AdditionalFile>();

                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm0_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm1_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm2_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm3_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm4_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm6_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/empty.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_arm7_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/headtest.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_face0_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/headtest.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_face1_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/headtest.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_face2_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/headtest.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_face4_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/headtest.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_face5_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileFova additionalFile = new AdditionalFileFova();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/headtest.fv2";
                    additionalFile.targetPath = "/Assets/tpp/fova/chara/sna/sna0_face6_v00.fv2";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFileDefault additionalFile = new AdditionalFileDefault();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/head.fmdl";
                    additionalFile.destinationPath = "/Assets/tpp/mqpm/head.fmdl";
                    outfit.additionalFiles.Add(additionalFile);
                } //block
                {
                    AdditionalFilePftxs additionalFile = new AdditionalFilePftxs();
                    additionalFile.sourcePath = "/Assets/tpp/mqpm/xof.pftxs";
                    outfit.additionalFiles.Add(additionalFile);
                } //block

                Globals.outfitList.list.Add(outfit);
            } //block

            Globals.WriteList(Globals.outfitList, "OutfitList.xml");
        } //OutfitCreationTest

        private void outputTestButton_Click(object sender, EventArgs e)
        {
            string outputFolder = outputFolderTextBox.Text;
            Parts parts = Globals.partsList.list[partsComboBox.SelectedIndex];
            Outfit outfit = Globals.outfitList.list[outfitComboBox.SelectedIndex];

            string mdlPath = $"{outputFolder}{parts.fpkPath}_fpk{outfit.mdlPath}";
            Directory.CreateDirectory(Path.GetDirectoryName(mdlPath));
            File.Copy(outfit.mdlPath.Substring(1), mdlPath, true);

            string cnpPath = $"{outputFolder}{parts.fpkPath}_fpk{outfit.cnpPath}";
            Directory.CreateDirectory(Path.GetDirectoryName(cnpPath));
            File.Copy(outfit.cnpPath.Substring(1), cnpPath, true);

            string rdvPath = $"{outputFolder}{parts.fpkPath}_fpk{outfit.rdvPath}";
            Directory.CreateDirectory(Path.GetDirectoryName(rdvPath));
            File.Copy(outfit.rdvPath.Substring(1), rdvPath, true);

            foreach(Sim sim in outfit.sims)
            {
                string simPath = $"{outputFolder}{parts.fpkPath}_fpkd{sim.path}";
                Directory.CreateDirectory(Path.GetDirectoryName(simPath));
                File.Copy(sim.path.Substring(1), simPath, true);
            } //foreach

            foreach(AdditionalFile additionalFile in outfit.additionalFiles)
            {
                switch(additionalFile)
                {
                    case AdditionalFileDefault afDefault:
                        string filePath = $"{outputFolder}{parts.fpkPath}_fpk{afDefault.destinationPath}";
                        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                        File.Copy(afDefault.sourcePath.Substring(1), filePath, true);
                        break;
                    case AdditionalFileFova afFova:
                        if (parts.fovas.Contains(afFova.targetPath))
                        {
                            string fovaPath = $"{outputFolder}{parts.fpkPath}_fpk{afFova.targetPath}";
                            Directory.CreateDirectory(Path.GetDirectoryName(fovaPath));
                            File.Copy(afFova.sourcePath.Substring(1), fovaPath, true);
                        } //if
                        break;
                    case AdditionalFileFovaFmdl afFovaFmdl:
                        if (parts.fovas.Contains(afFovaFmdl.targetPath))
                        {
                            string fmdlPath = $"{outputFolder}{parts.fpkPath}_fpk{afFovaFmdl.destinationPath}";
                            Directory.CreateDirectory(Path.GetDirectoryName(fmdlPath));
                            File.Copy(afFovaFmdl.sourcePath.Substring(1), fmdlPath, true);
                        } //if
                        break;
                    case AdditionalFilePftxs afPftxs:
                        string pftxsPath = $"{outputFolder}{parts.fpkPath}.pftxs";
                        Directory.CreateDirectory(Path.GetDirectoryName(pftxsPath));
                        File.Copy(afPftxs.sourcePath.Substring(1), pftxsPath, true);
                        break;
                } //switch
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