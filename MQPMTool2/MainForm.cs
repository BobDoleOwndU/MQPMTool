using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MQPMTool2
{
    public partial class MainForm : Form
    {
        static XmlSerializer componentSerializer = new XmlSerializer(typeof(MQPMComponent));
        static XmlSerializer addonSerializer = new XmlSerializer(typeof(MQPMAddon));
        static MQPMComponent mqpmComponents;

        PlayerType selectedPlayerType = new PlayerType();
        PlayerOutfit selectedPlayerOutfit = new PlayerOutfit();
        CharacterOutfit selectedCharacterOutfit = new CharacterOutfit();
        ExtraList selectedExtraList = new ExtraList();
        Head selectedHead = new Head();
        Fcnp selectedFcnp = new Fcnp();

        public MainForm()
        {
            InitializeComponent();
            LoadXml();
            LoadCharacterComboBoxValues();
        } //constructor ends

        /*
         * LoadXml
         * Loads the components.xml file's entries into options for the User Interface.
         */
        private void LoadXml()
        {
            try
            {
                //load and deserialize the components file to get options in the UI.
                using (FileStream xmlStream = new FileStream(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\components.xml", FileMode.Open))
                {
                    mqpmComponents = componentSerializer.Deserialize(xmlStream) as MQPMComponent;
                } //using ends
            } //try ends
            catch
            {
                MessageBox.Show("There was an error with components.xml! Please ensure it exists in the folder with the MQPM Tool.", "FileStream Exception!");
                Environment.Exit(1);
            } //catch ends

            foreach (string file in Directory.EnumerateFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\addons", "*.xml"))
            {
                MQPMAddon addon = new MQPMAddon();

                using (FileStream xmlStream = new FileStream(file, FileMode.Open))
                {
                    try
                    {
                        addon = addonSerializer.Deserialize(xmlStream) as MQPMAddon;
                    }
                    catch
                    {
                        MessageBox.Show("There was an error while reading " + file + "!", "FileStream Exception!");
                        Environment.Exit(1);
                    } //catch ends
                } //using ends

                //add additional excluded Snake outfits.
                for (int i = 0; i < addon.snakeExcludedOutfits.Count; i++)
                    for (int j = 0; j < mqpmComponents.playerTypes.Count; j++)
                        if (mqpmComponents.playerTypes[j].name == "snake")
                            mqpmComponents.playerTypes[j].excludedOutfits.Add(addon.snakeExcludedOutfits[i]);

                //add additional excluded female outfits.
                for (int i = 0; i < addon.femaleExcludedOutfits.Count; i++)
                    for (int j = 0; j < mqpmComponents.playerTypes.Count; j++)
                        if (mqpmComponents.playerTypes[j].name == "female")
                            mqpmComponents.playerTypes[j].excludedOutfits.Add(addon.femaleExcludedOutfits[i]);

                //add additional excluded male outfits.
                for (int i = 0; i < addon.maleExcludedOutfits.Count; i++)
                    for (int j = 0; j < mqpmComponents.playerTypes.Count; j++)
                        if (mqpmComponents.playerTypes[j].name == "male")
                            mqpmComponents.playerTypes[j].excludedOutfits.Add(addon.maleExcludedOutfits[i]);

                //add additional character outfits.
                for (int i = 0; i < addon.addonOutfits.Count; i++)
                {
                    //ensure there are no duplicates.
                    bool isDuplicate = false;

                    for (int j = 0; j < mqpmComponents.characterOutfits.Count; j++)
                        if (addon.addonOutfits[i].name == mqpmComponents.characterOutfits[j].name)
                            isDuplicate = true;

                    if (!isDuplicate)
                    {
                        mqpmComponents.characterOutfits.Add(addon.addonOutfits[i]);

                        //add the entry to the player outfits so the new outfit can be selected.
                        for (int j = 0; j < addon.addonOutfits[i].playerOutfits.Count; j++)
                            for (int h = 0; h < mqpmComponents.playerOutfits.Count; h++)
                                if (addon.addonOutfits[i].playerOutfits[j] == mqpmComponents.playerOutfits[h].name)
                                    if (!mqpmComponents.playerOutfits[h].characterOutfits.Contains(addon.addonOutfits[i].name))
                                        mqpmComponents.playerOutfits[h].characterOutfits.Add(addon.addonOutfits[i].name);
                    } //if
                } //for ends

                //add additional heads.
                for (int i = 0; i < addon.addonHeads.Count; i++)
                {
                    //ensure there are no duplicates.
                    bool isDuplicate = false;

                    for (int j = 0; j < mqpmComponents.heads.Count; j++)
                        if (addon.addonHeads[i].name == mqpmComponents.heads[j].name)
                            isDuplicate = true;

                    if (!isDuplicate)
                    {
                        mqpmComponents.heads.Add(addon.addonHeads[i]);

                        //add the entry to the character outfits so the new head can be selected.
                        for (int j = 0; j < addon.addonHeads[i].characterOutfits.Count; j++)
                            for (int h = 0; h < mqpmComponents.characterOutfits.Count; h++)
                                if (addon.addonHeads[i].characterOutfits[j] == mqpmComponents.characterOutfits[h].name)
                                    mqpmComponents.characterOutfits[h].heads.Add(addon.addonHeads[i].name);
                    } //if ends
                } //for ends

                //add new fcnps.
                for (int i = 0; i < addon.fcnps.Count; i++)
                {
                    //ensure there are no duplicates.
                    bool isDuplicate = false;

                    for (int j = 0; j < mqpmComponents.fcnps.Count; j++)
                        if (addon.fcnps[i].name == mqpmComponents.fcnps[j].name)
                            isDuplicate = true;

                    if (!isDuplicate)
                        mqpmComponents.fcnps.Add(addon.fcnps[i]);
                } //for

                //add new extra lists.
                for (int i = 0; i < addon.extraLists.Count; i++)
                {
                    //ensure there are no duplicates.
                    bool isDuplicate = false;

                    for (int j = 0; j < mqpmComponents.extraLists.Count; j++)
                        if (addon.extraLists[i].name == mqpmComponents.extraLists[j].name)
                            isDuplicate = true;
                    if (!isDuplicate)
                        mqpmComponents.extraLists.Add(addon.extraLists[i]);
                } //for
            } //foreach ends

            if(mqpmComponents.characterOutfits.Count == 0 ||mqpmComponents.heads.Count == 0 || mqpmComponents.fcnps.Count == 0)
            {
                MessageBox.Show("You don't have any outfits (correctly) installed! The MQPM Tool needs some outfits to work with.", "No Outfits!");
                Environment.Exit(1);
            } //if ends
        } //method LoadXml ends

        /*
         * LoadCharacterComboBoxValues
         * Loads the character values from mqpmComponents into the combo box.
         */
        private void LoadCharacterComboBoxValues()
        {
            Dictionary<string, string> characterSource = new Dictionary<string, string>(0);

            //get the list of player types and add them to the character combo box.
            for (int i = 0; i < mqpmComponents.playerTypes.Count; i++)
                characterSource.Add(mqpmComponents.playerTypes[i].name, mqpmComponents.playerTypes[i].display);

            characterComboBox.DataSource = new BindingSource(characterSource, null);
            characterComboBox.ValueMember = "Key";
            characterComboBox.DisplayMember = "Value";
        } //loadCharacterComboBoxValues ends

        /*
         * characterComboBox_SelectedIndexChanged
         * Sets the selected outfit based on the selected character. Also loads the list of compatible player outfits for the character.
         */
        private void characterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check which player type we need to load the outfits for.
            for (int i = 0; i < mqpmComponents.playerTypes.Count; i++)
                if (mqpmComponents.playerTypes[i].name == ((KeyValuePair<string, string>)characterComboBox.SelectedItem).Key)
                    selectedPlayerType = mqpmComponents.playerTypes[i];

            Dictionary<string, string> playerOutfitSource = new Dictionary<string, string>(0);

            //add all of the player outfits to the combo box.
            for (int i = 0; i < mqpmComponents.playerOutfits.Count; i++)
                for (int j = 0; j < selectedPlayerType.playerOutfits.Count; j++)
                    if (mqpmComponents.playerOutfits[i].name == selectedPlayerType.playerOutfits[j])
                        playerOutfitSource.Add(mqpmComponents.playerOutfits[i].name, mqpmComponents.playerOutfits[i].display);

            playerOutfitComboBox.DataSource = new BindingSource(playerOutfitSource, null);
            playerOutfitComboBox.ValueMember = "Key";
            playerOutfitComboBox.DisplayMember = "Value";
        } //snakeRadioButton_CheckedChanged ends

        /*
         * playerOutfitComboBox_SelectedIndexChanged
         * Loads the list of the character's compatible outfits for a selected player outfit.
         */
        private void playerOutfitComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //set the outfit selected in the combo box as the selected outfit.
            for (int i = 0; i < mqpmComponents.playerOutfits.Count; i++)
                if (mqpmComponents.playerOutfits[i].name == ((KeyValuePair<string, string>)playerOutfitComboBox.SelectedItem).Key)
                    selectedPlayerOutfit = mqpmComponents.playerOutfits[i];

            Dictionary<string, string> characterOutfitSource = new Dictionary<string, string>(0);

            //match the outfit's compatible outfit list names to the component's outfit list names. get the matches' display entries as combo box options.
            for (int i = 0; i < mqpmComponents.characterOutfits.Count; i++)
                for (int j = 0; j < selectedPlayerOutfit.characterOutfits.Count; j++)
                    if (mqpmComponents.characterOutfits[i].name == selectedPlayerOutfit.characterOutfits[j])
                    {
                        bool add = true;

                        //make sure the outfit isn't excluded for the player type.
                        for (int h = 0; h < selectedPlayerType.excludedOutfits.Count; h++)
                            if (mqpmComponents.characterOutfits[i].name == selectedPlayerType.excludedOutfits[h])
                                add = false;

                        if (add)
                            characterOutfitSource.Add(mqpmComponents.characterOutfits[i].name, mqpmComponents.characterOutfits[i].display);
                    } //if ends

            characterOutfitComboBox.DataSource = new BindingSource(characterOutfitSource, null);
            characterOutfitComboBox.ValueMember = "Key";
            characterOutfitComboBox.DisplayMember = "Value";
        } //playerOutfitComboBox_SelectedIndexChanged

        /*
         * characterOutfitComboBox_SelectedIndexChanged
         * Loads the list of the characters's compatible heads for a selected character outfit.
         */
        private void characterOutfitComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //set the outfit selected in the combo box as the selected outfit.
            for (int i = 0; i < mqpmComponents.characterOutfits.Count; i++)
                if (mqpmComponents.characterOutfits[i].name == ((KeyValuePair<string, string>)characterOutfitComboBox.SelectedItem).Key)
                    selectedCharacterOutfit = mqpmComponents.characterOutfits[i];

            //get the outfits extra list.
            for (int i = 0; i < mqpmComponents.extraLists.Count; i++)
                if (mqpmComponents.extraLists[i].name == selectedCharacterOutfit.extraList)
                    selectedExtraList = mqpmComponents.extraLists[i];

            Dictionary<string, string> headSource = new Dictionary<string, string>(0);

            //if the player's outfit limits heads, only the default head should be selectable. else, load the list of heads compatible with the outfit.
            if (selectedPlayerOutfit.limitHeads)
            {
                for (int i = 0; i < mqpmComponents.heads.Count; i++)
                    if (mqpmComponents.heads[i].name == selectedCharacterOutfit.defaultHead)
                        headSource.Add(mqpmComponents.heads[i].name, mqpmComponents.heads[i].display);
            } //if ends
            else
                for (int i = 0; i < mqpmComponents.heads.Count; i++)
                    for (int j = 0; j < selectedCharacterOutfit.heads.Count; j++)
                        if (mqpmComponents.heads[i].name == selectedCharacterOutfit.heads[j])
                            headSource.Add(mqpmComponents.heads[i].name, mqpmComponents.heads[i].display);

            headComboBox.DataSource = new BindingSource(headSource, null);
            headComboBox.ValueMember = "Key";
            headComboBox.DisplayMember = "Value";

            Dictionary<string, string> hipSource = new Dictionary<string, string>(0);

            //get the list of compatible fcnps and add them to the hip combo box.
            for (int i = 0; i < mqpmComponents.fcnps.Count; i++)
                for (int j = 0; j < selectedCharacterOutfit.fcnps.Count; j++)
                    if (mqpmComponents.fcnps[i].name == selectedCharacterOutfit.fcnps[j])
                        hipSource.Add(mqpmComponents.fcnps[i].name, mqpmComponents.fcnps[i].display);

            hipComboBox.DataSource = new BindingSource(hipSource, null);
            hipComboBox.ValueMember = "Key";
            hipComboBox.DisplayMember = "Value";
        } //characterOutfitComboBox_SelectedIndexChanged ends

        /*
         * headComboBox_SelectedIndexChanged
         * Sets the head chosen in the combo box as the selected head.
         */
        private void headComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the head selected in the combo box as the selected head.
            for (int i = 0; i < mqpmComponents.heads.Count; i++)
                if (mqpmComponents.heads[i].name == ((KeyValuePair<string, string>)headComboBox.SelectedItem).Key)
                    selectedHead = mqpmComponents.heads[i];
        } //headComboBox_SelectedIndexChanged

        /*
         * hipComboBox_SelectedIndexChanged
         * Sets the fcnp chosen in the combo box as the selected fcnp.
         */
        private void hipComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the fcnp selected in the combo box as the selected fcnp.
            for (int i = 0; i < mqpmComponents.fcnps.Count; i++)
                if (mqpmComponents.fcnps[i].name == ((KeyValuePair<string, string>)hipComboBox.SelectedItem).Key)
                    selectedFcnp = mqpmComponents.fcnps[i];
        } //headComboBox_SelectedIndexChanged

        /*
         * processButton_Click
         * Sends the selected options to the outfit builder.
         */
        private void processButton_Click(object sender, System.EventArgs e)
        {
            if (!Verify())
            {
                MessageBox.Show("Please ensure all options have been selected", "Select all options!");
                return;
            } //if ends

            //have to copy list values to new lists because C# passes Lists by reference.
            List<string> headOutputList = new List<string>(0);
            headOutputList.AddRange(selectedHead.values.ToArray());
            List<string> extraListOuputList = new List<string>(0);
            extraListOuputList.AddRange(selectedExtraList.values.ToArray());

            OutfitBuilder.Build(outputTextBox.Text, selectedPlayerType.name, selectedPlayerOutfit.name, selectedCharacterOutfit.name, selectedHead.name, headOutputList, selectedFcnp.name, selectedCharacterOutfit.sims, selectedCharacterOutfit.includePftxs, selectedCharacterOutfit.useBody, extraListOuputList, selectedHead.includePftxs, selectedHead.useFv2);
        } //processButton_Click ends

        /*
         * outputButton_Click
         * Opens a folder browser dialog to select the output folder.
         */
        private void outputButton_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
                outputTextBox.Text = fbd.SelectedPath;
        } //outputButton_Click ends

        /*
         * Verify
         * Checks to make sure all options have been selected before building an outfit.
         */
        private bool Verify()
        {
            if (string.IsNullOrEmpty(outputTextBox.Text) || characterComboBox.SelectedIndex == -1 || playerOutfitComboBox.SelectedIndex == -1 || characterOutfitComboBox.SelectedIndex == -1 || headComboBox.SelectedIndex == -1)
                return false;

            return true;
        } //method Verify ends
    } //partial class MainForm ends
} //namespace MQPMTool2 ends
