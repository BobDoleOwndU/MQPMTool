namespace MQPMTool2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.playerOutfitLabel = new System.Windows.Forms.Label();
            this.playerOutfitComboBox = new System.Windows.Forms.ComboBox();
            this.quietOutfitComboBox = new System.Windows.Forms.ComboBox();
            this.quietOutfitLabel = new System.Windows.Forms.Label();
            this.quietHeadLabel = new System.Windows.Forms.Label();
            this.hipWeaponLabel = new System.Windows.Forms.Label();
            this.headComboBox = new System.Windows.Forms.ComboBox();
            this.hipComboBox = new System.Windows.Forms.ComboBox();
            this.processButton = new System.Windows.Forms.Button();
            this.creditTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.outputButton = new System.Windows.Forms.Button();
            this.outputLabel = new System.Windows.Forms.Label();
            this.characterComboBox = new System.Windows.Forms.ComboBox();
            this.CharacterGroupBox = new System.Windows.Forms.GroupBox();
            this.CharacterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerOutfitLabel
            // 
            this.playerOutfitLabel.AutoSize = true;
            this.playerOutfitLabel.Location = new System.Drawing.Point(10, 111);
            this.playerOutfitLabel.Name = "playerOutfitLabel";
            this.playerOutfitLabel.Size = new System.Drawing.Size(71, 13);
            this.playerOutfitLabel.TabIndex = 1;
            this.playerOutfitLabel.Text = "Player\'s Outfit";
            // 
            // playerOutfitComboBox
            // 
            this.playerOutfitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playerOutfitComboBox.FormattingEnabled = true;
            this.playerOutfitComboBox.Location = new System.Drawing.Point(13, 127);
            this.playerOutfitComboBox.Name = "playerOutfitComboBox";
            this.playerOutfitComboBox.Size = new System.Drawing.Size(121, 21);
            this.playerOutfitComboBox.TabIndex = 2;
            this.playerOutfitComboBox.SelectedIndexChanged += new System.EventHandler(this.playerOutfitComboBox_SelectedIndexChanged);
            // 
            // quietOutfitComboBox
            // 
            this.quietOutfitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quietOutfitComboBox.FormattingEnabled = true;
            this.quietOutfitComboBox.Location = new System.Drawing.Point(140, 127);
            this.quietOutfitComboBox.Name = "quietOutfitComboBox";
            this.quietOutfitComboBox.Size = new System.Drawing.Size(121, 21);
            this.quietOutfitComboBox.TabIndex = 3;
            this.quietOutfitComboBox.SelectedIndexChanged += new System.EventHandler(this.quietOutfitComboBox_SelectedIndexChanged);
            // 
            // quietOutfitLabel
            // 
            this.quietOutfitLabel.AutoSize = true;
            this.quietOutfitLabel.Location = new System.Drawing.Point(137, 111);
            this.quietOutfitLabel.Name = "quietOutfitLabel";
            this.quietOutfitLabel.Size = new System.Drawing.Size(67, 13);
            this.quietOutfitLabel.TabIndex = 4;
            this.quietOutfitLabel.Text = "Quiet\'s Outfit";
            // 
            // quietHeadLabel
            // 
            this.quietHeadLabel.AutoSize = true;
            this.quietHeadLabel.Location = new System.Drawing.Point(10, 151);
            this.quietHeadLabel.Name = "quietHeadLabel";
            this.quietHeadLabel.Size = new System.Drawing.Size(68, 13);
            this.quietHeadLabel.TabIndex = 5;
            this.quietHeadLabel.Text = "Quiet\'s Head";
            // 
            // hipWeaponLabel
            // 
            this.hipWeaponLabel.AutoSize = true;
            this.hipWeaponLabel.Location = new System.Drawing.Point(137, 151);
            this.hipWeaponLabel.Name = "hipWeaponLabel";
            this.hipWeaponLabel.Size = new System.Drawing.Size(72, 13);
            this.hipWeaponLabel.TabIndex = 6;
            this.hipWeaponLabel.Text = "Hip Weapons";
            // 
            // headComboBox
            // 
            this.headComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.headComboBox.FormattingEnabled = true;
            this.headComboBox.Location = new System.Drawing.Point(13, 167);
            this.headComboBox.Name = "headComboBox";
            this.headComboBox.Size = new System.Drawing.Size(121, 21);
            this.headComboBox.TabIndex = 7;
            this.headComboBox.SelectedIndexChanged += new System.EventHandler(this.headComboBox_SelectedIndexChanged);
            // 
            // hipComboBox
            // 
            this.hipComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hipComboBox.FormattingEnabled = true;
            this.hipComboBox.Location = new System.Drawing.Point(140, 167);
            this.hipComboBox.Name = "hipComboBox";
            this.hipComboBox.Size = new System.Drawing.Size(121, 21);
            this.hipComboBox.TabIndex = 8;
            this.hipComboBox.SelectedIndexChanged += new System.EventHandler(this.hipComboBox_SelectedIndexChanged);
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(13, 194);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(75, 23);
            this.processButton.TabIndex = 9;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // creditTextBox
            // 
            this.creditTextBox.Location = new System.Drawing.Point(10, 223);
            this.creditTextBox.Multiline = true;
            this.creditTextBox.Name = "creditTextBox";
            this.creditTextBox.ReadOnly = true;
            this.creditTextBox.Size = new System.Drawing.Size(251, 61);
            this.creditTextBox.TabIndex = 10;
            this.creditTextBox.Text = "Created by BobDoleOwndU";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(13, 29);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(217, 20);
            this.outputTextBox.TabIndex = 11;
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(236, 27);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(24, 23);
            this.outputButton.TabIndex = 12;
            this.outputButton.Text = "...";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(13, 13);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(71, 13);
            this.outputLabel.TabIndex = 13;
            this.outputLabel.Text = "Output Folder";
            // 
            // characterComboBox
            // 
            this.characterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.characterComboBox.FormattingEnabled = true;
            this.characterComboBox.Location = new System.Drawing.Point(32, 19);
            this.characterComboBox.Name = "characterComboBox";
            this.characterComboBox.Size = new System.Drawing.Size(188, 21);
            this.characterComboBox.TabIndex = 15;
            this.characterComboBox.SelectedIndexChanged += new System.EventHandler(this.characterComboBox_SelectedIndexChanged);
            // 
            // CharacterGroupBox
            // 
            this.CharacterGroupBox.Controls.Add(this.characterComboBox);
            this.CharacterGroupBox.Location = new System.Drawing.Point(10, 56);
            this.CharacterGroupBox.Name = "CharacterGroupBox";
            this.CharacterGroupBox.Size = new System.Drawing.Size(251, 52);
            this.CharacterGroupBox.TabIndex = 16;
            this.CharacterGroupBox.TabStop = false;
            this.CharacterGroupBox.Text = "Character";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 314);
            this.Controls.Add(this.CharacterGroupBox);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.creditTextBox);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.hipComboBox);
            this.Controls.Add(this.headComboBox);
            this.Controls.Add(this.hipWeaponLabel);
            this.Controls.Add(this.quietHeadLabel);
            this.Controls.Add(this.quietOutfitLabel);
            this.Controls.Add(this.quietOutfitComboBox);
            this.Controls.Add(this.playerOutfitComboBox);
            this.Controls.Add(this.playerOutfitLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MQPM Tool v2.1";
            this.CharacterGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label playerOutfitLabel;
        private System.Windows.Forms.ComboBox playerOutfitComboBox;
        private System.Windows.Forms.ComboBox quietOutfitComboBox;
        private System.Windows.Forms.Label quietOutfitLabel;
        private System.Windows.Forms.Label quietHeadLabel;
        private System.Windows.Forms.Label hipWeaponLabel;
        private System.Windows.Forms.ComboBox headComboBox;
        private System.Windows.Forms.ComboBox hipComboBox;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.TextBox creditTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.ComboBox characterComboBox;
        private System.Windows.Forms.GroupBox CharacterGroupBox;
    }
}

