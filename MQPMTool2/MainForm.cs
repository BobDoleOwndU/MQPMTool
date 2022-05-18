using FoxTool.Fox;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Parts parts = Globals.partsList.list[partsComboBox.SelectedIndex];
            Outfit outfit = Globals.outfitList.list[outfitComboBox.SelectedIndex];

            string name = Path.GetFileName(parts.partsPath);

            using (FileStream stream = new FileStream(name, FileMode.Create))
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
        } //button1_Click

        private void partsListWriteTestButton_Click(object sender, EventArgs e)
        {
            Parts parts0 = new Parts();
            parts0.name = "Snake - Fatigues";
            parts0.fpkPath = "/Assets/tpp/pack/player/parts/plparts_normal";
            parts0.partsPath = "/Assets/tpp/parts/chara/sna/sna0_main0_def_v00.parts";
            Globals.partsList.list.Add(parts0);

            Parts parts1 = new Parts();
            parts1.name = "Snake - Sneaking Suit";
            parts1.fpkPath = "/Assets/tpp/pack/player/parts/plparts_venom";
            parts1.partsPath = "/Assets/tpp/parts/chara/sna/sna4_main0_def_v00.parts";
            Globals.partsList.list.Add(parts1);

            Globals.WriteList<PartsList>(Globals.partsList, "PartsList.xml");
        } //partsListWriteTestButton_Click

        private void outfitListWriteTestButton_Click(object sender, EventArgs e)
        {
            Outfit outfit0 = new Outfit();
            outfit0.name = "Quiet - Default";
            outfit0.mdlPath = "/Assets/tpp/chara/qui/Scenes/qui0_main0_def.fmdl";
            outfit0.cnpPath = "/Assets/tpp/chara/qui/Scenes/qui0_main0_def.fcnp";
            outfit0.rdvPath = "/Assets/tpp/chara/qui/Scenes/qui0_main0_def.frdv";
            outfit0.sims = new List<Sim>();

            Sim sim0 = new Sim();
            sim0.name = "Sim_asr";
            sim0.path = "/Assets/tpp/chara/sna/Fox_files/sna0_main0_asr.sim";
            sim0.isActive = true;
            outfit0.sims.Add(sim0);

            Sim sim1 = new Sim();
            sim1.name = "Sim_broken_arm";
            sim1.path = "/Assets/tpp/chara/sna/Fox_files/sna0_broken_arm_r.sim";
            sim1.isActive = false;
            outfit0.sims.Add(sim1);

            Sim sim2 = new Sim();
            sim2.name = "SimQuiet";
            sim2.path = "/Assets/tpp/chara/qui/Fox_files/quip_main0_def.sim";
            sim2.isActive = true;
            outfit0.sims.Add(sim2);

            Globals.outfitList.list.Add(outfit0);
            Globals.WriteList<OutfitList>(Globals.outfitList, "OutfitList.xml");
        }
    } //class ends
}//namespace ends