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
            this.characterGroupBox = new System.Windows.Forms.GroupBox();
            this.femaleRadioButton = new System.Windows.Forms.RadioButton();
            this.snakeRadioButton = new System.Windows.Forms.RadioButton();
            this.playerOutfitLabel = new System.Windows.Forms.Label();
            this.playerOutfitComboBox = new System.Windows.Forms.ComboBox();
            this.quietOutfitComboBox = new System.Windows.Forms.ComboBox();
            this.quietOutfitLabel = new System.Windows.Forms.Label();
            this.quietHeadLabel = new System.Windows.Forms.Label();
            this.hipWeaponLabel = new System.Windows.Forms.Label();
            this.headComboBox = new System.Windows.Forms.ComboBox();
            this.hipWeaponComboBox = new System.Windows.Forms.ComboBox();
            this.processButton = new System.Windows.Forms.Button();
            this.creditTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.outputButton = new System.Windows.Forms.Button();
            this.outputLabel = new System.Windows.Forms.Label();
            this.characterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // characterGroupBox
            // 
            this.characterGroupBox.Controls.Add(this.femaleRadioButton);
            this.characterGroupBox.Controls.Add(this.snakeRadioButton);
            this.characterGroupBox.Location = new System.Drawing.Point(12, 56);
            this.characterGroupBox.Name = "characterGroupBox";
            this.characterGroupBox.Size = new System.Drawing.Size(248, 48);
            this.characterGroupBox.TabIndex = 0;
            this.characterGroupBox.TabStop = false;
            this.characterGroupBox.Text = "Character";
            // 
            // femaleRadioButton
            // 
            this.femaleRadioButton.AutoSize = true;
            this.femaleRadioButton.Location = new System.Drawing.Point(69, 20);
            this.femaleRadioButton.Name = "femaleRadioButton";
            this.femaleRadioButton.Size = new System.Drawing.Size(127, 17);
            this.femaleRadioButton.TabIndex = 1;
            this.femaleRadioButton.TabStop = true;
            this.femaleRadioButton.Text = "Female Diamond Dog";
            this.femaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // snakeRadioButton
            // 
            this.snakeRadioButton.AutoSize = true;
            this.snakeRadioButton.Location = new System.Drawing.Point(7, 20);
            this.snakeRadioButton.Name = "snakeRadioButton";
            this.snakeRadioButton.Size = new System.Drawing.Size(56, 17);
            this.snakeRadioButton.TabIndex = 0;
            this.snakeRadioButton.TabStop = true;
            this.snakeRadioButton.Text = "Snake";
            this.snakeRadioButton.UseVisualStyleBackColor = true;
            this.snakeRadioButton.CheckedChanged += new System.EventHandler(this.snakeRadioButton_CheckedChanged);
            // 
            // playerOutfitLabel
            // 
            this.playerOutfitLabel.AutoSize = true;
            this.playerOutfitLabel.Location = new System.Drawing.Point(9, 112);
            this.playerOutfitLabel.Name = "playerOutfitLabel";
            this.playerOutfitLabel.Size = new System.Drawing.Size(71, 13);
            this.playerOutfitLabel.TabIndex = 1;
            this.playerOutfitLabel.Text = "Player\'s Outfit";
            // 
            // playerOutfitComboBox
            // 
            this.playerOutfitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playerOutfitComboBox.FormattingEnabled = true;
            this.playerOutfitComboBox.Location = new System.Drawing.Point(12, 128);
            this.playerOutfitComboBox.Name = "playerOutfitComboBox";
            this.playerOutfitComboBox.Size = new System.Drawing.Size(121, 21);
            this.playerOutfitComboBox.TabIndex = 2;
            this.playerOutfitComboBox.SelectedIndexChanged += new System.EventHandler(this.playerOutfitComboBox_SelectedIndexChanged);
            // 
            // quietOutfitComboBox
            // 
            this.quietOutfitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quietOutfitComboBox.FormattingEnabled = true;
            this.quietOutfitComboBox.Location = new System.Drawing.Point(139, 128);
            this.quietOutfitComboBox.Name = "quietOutfitComboBox";
            this.quietOutfitComboBox.Size = new System.Drawing.Size(121, 21);
            this.quietOutfitComboBox.TabIndex = 3;
            this.quietOutfitComboBox.SelectedIndexChanged += new System.EventHandler(this.quietOutfitComboBox_SelectedIndexChanged);
            // 
            // quietOutfitLabel
            // 
            this.quietOutfitLabel.AutoSize = true;
            this.quietOutfitLabel.Location = new System.Drawing.Point(136, 112);
            this.quietOutfitLabel.Name = "quietOutfitLabel";
            this.quietOutfitLabel.Size = new System.Drawing.Size(67, 13);
            this.quietOutfitLabel.TabIndex = 4;
            this.quietOutfitLabel.Text = "Quiet\'s Outfit";
            // 
            // quietHeadLabel
            // 
            this.quietHeadLabel.AutoSize = true;
            this.quietHeadLabel.Location = new System.Drawing.Point(9, 152);
            this.quietHeadLabel.Name = "quietHeadLabel";
            this.quietHeadLabel.Size = new System.Drawing.Size(68, 13);
            this.quietHeadLabel.TabIndex = 5;
            this.quietHeadLabel.Text = "Quiet\'s Head";
            // 
            // hipWeaponLabel
            // 
            this.hipWeaponLabel.AutoSize = true;
            this.hipWeaponLabel.Location = new System.Drawing.Point(136, 152);
            this.hipWeaponLabel.Name = "hipWeaponLabel";
            this.hipWeaponLabel.Size = new System.Drawing.Size(72, 13);
            this.hipWeaponLabel.TabIndex = 6;
            this.hipWeaponLabel.Text = "Hip Weapons";
            // 
            // headComboBox
            // 
            this.headComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.headComboBox.FormattingEnabled = true;
            this.headComboBox.Location = new System.Drawing.Point(12, 168);
            this.headComboBox.Name = "headComboBox";
            this.headComboBox.Size = new System.Drawing.Size(121, 21);
            this.headComboBox.TabIndex = 7;
            this.headComboBox.SelectedIndexChanged += new System.EventHandler(this.headComboBox_SelectedIndexChanged);
            // 
            // hipWeaponComboBox
            // 
            this.hipWeaponComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hipWeaponComboBox.Enabled = false;
            this.hipWeaponComboBox.FormattingEnabled = true;
            this.hipWeaponComboBox.Location = new System.Drawing.Point(139, 168);
            this.hipWeaponComboBox.Name = "hipWeaponComboBox";
            this.hipWeaponComboBox.Size = new System.Drawing.Size(121, 21);
            this.hipWeaponComboBox.TabIndex = 8;
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(12, 195);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(75, 23);
            this.processButton.TabIndex = 9;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // creditTextBox
            // 
            this.creditTextBox.Location = new System.Drawing.Point(9, 224);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 308);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.creditTextBox);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.hipWeaponComboBox);
            this.Controls.Add(this.headComboBox);
            this.Controls.Add(this.hipWeaponLabel);
            this.Controls.Add(this.quietHeadLabel);
            this.Controls.Add(this.quietOutfitLabel);
            this.Controls.Add(this.quietOutfitComboBox);
            this.Controls.Add(this.playerOutfitComboBox);
            this.Controls.Add(this.playerOutfitLabel);
            this.Controls.Add(this.characterGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MQPM Tool v2.1";
            this.characterGroupBox.ResumeLayout(false);
            this.characterGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox characterGroupBox;
        private System.Windows.Forms.RadioButton femaleRadioButton;
        private System.Windows.Forms.RadioButton snakeRadioButton;
        private System.Windows.Forms.Label playerOutfitLabel;
        private System.Windows.Forms.ComboBox playerOutfitComboBox;
        private System.Windows.Forms.ComboBox quietOutfitComboBox;
        private System.Windows.Forms.Label quietOutfitLabel;
        private System.Windows.Forms.Label quietHeadLabel;
        private System.Windows.Forms.Label hipWeaponLabel;
        private System.Windows.Forms.ComboBox headComboBox;
        private System.Windows.Forms.ComboBox hipWeaponComboBox;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.TextBox creditTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Label outputLabel;
    }
}

