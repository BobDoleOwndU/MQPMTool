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
            this.authorLabel = new System.Windows.Forms.Label();
            this.outputTestButton = new System.Windows.Forms.Button();
            this.partsLabel = new System.Windows.Forms.Label();
            this.partsComboBox = new System.Windows.Forms.ComboBox();
            this.outfitComboBox = new System.Windows.Forms.ComboBox();
            this.outfitLabel = new System.Windows.Forms.Label();
            this.outputFolderLabel = new System.Windows.Forms.Label();
            this.outputFolderTextBox = new System.Windows.Forms.TextBox();
            this.outputFolderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(124, 299);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(138, 13);
            this.authorLabel.TabIndex = 17;
            this.authorLabel.Text = "Created by BobDoleOwndU";
            // 
            // outputTestButton
            // 
            this.outputTestButton.Location = new System.Drawing.Point(12, 286);
            this.outputTestButton.Name = "outputTestButton";
            this.outputTestButton.Size = new System.Drawing.Size(75, 23);
            this.outputTestButton.TabIndex = 18;
            this.outputTestButton.Text = "Output Test";
            this.outputTestButton.UseVisualStyleBackColor = true;
            this.outputTestButton.Click += new System.EventHandler(this.outputTestButton_Click);
            // 
            // partsLabel
            // 
            this.partsLabel.AutoSize = true;
            this.partsLabel.Location = new System.Drawing.Point(9, 52);
            this.partsLabel.Name = "partsLabel";
            this.partsLabel.Size = new System.Drawing.Size(31, 13);
            this.partsLabel.TabIndex = 24;
            this.partsLabel.Text = "Parts";
            // 
            // partsComboBox
            // 
            this.partsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partsComboBox.FormattingEnabled = true;
            this.partsComboBox.Location = new System.Drawing.Point(12, 68);
            this.partsComboBox.Name = "partsComboBox";
            this.partsComboBox.Size = new System.Drawing.Size(121, 21);
            this.partsComboBox.TabIndex = 25;
            // 
            // outfitComboBox
            // 
            this.outfitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outfitComboBox.FormattingEnabled = true;
            this.outfitComboBox.Location = new System.Drawing.Point(141, 68);
            this.outfitComboBox.Name = "outfitComboBox";
            this.outfitComboBox.Size = new System.Drawing.Size(121, 21);
            this.outfitComboBox.TabIndex = 27;
            // 
            // outfitLabel
            // 
            this.outfitLabel.AutoSize = true;
            this.outfitLabel.Location = new System.Drawing.Point(138, 52);
            this.outfitLabel.Name = "outfitLabel";
            this.outfitLabel.Size = new System.Drawing.Size(32, 13);
            this.outfitLabel.TabIndex = 28;
            this.outfitLabel.Text = "Outfit";
            // 
            // outputFolderLabel
            // 
            this.outputFolderLabel.AutoSize = true;
            this.outputFolderLabel.Location = new System.Drawing.Point(13, 13);
            this.outputFolderLabel.Name = "outputFolderLabel";
            this.outputFolderLabel.Size = new System.Drawing.Size(71, 13);
            this.outputFolderLabel.TabIndex = 29;
            this.outputFolderLabel.Text = "Output Folder";
            // 
            // outputFolderTextBox
            // 
            this.outputFolderTextBox.Location = new System.Drawing.Point(12, 29);
            this.outputFolderTextBox.Name = "outputFolderTextBox";
            this.outputFolderTextBox.Size = new System.Drawing.Size(220, 20);
            this.outputFolderTextBox.TabIndex = 30;
            // 
            // outputFolderButton
            // 
            this.outputFolderButton.Location = new System.Drawing.Point(238, 26);
            this.outputFolderButton.Name = "outputFolderButton";
            this.outputFolderButton.Size = new System.Drawing.Size(24, 23);
            this.outputFolderButton.TabIndex = 31;
            this.outputFolderButton.Text = "...";
            this.outputFolderButton.UseVisualStyleBackColor = true;
            this.outputFolderButton.Click += new System.EventHandler(this.outputFolderButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 321);
            this.Controls.Add(this.outputFolderButton);
            this.Controls.Add(this.outputFolderTextBox);
            this.Controls.Add(this.outputFolderLabel);
            this.Controls.Add(this.outfitLabel);
            this.Controls.Add(this.outfitComboBox);
            this.Controls.Add(this.partsComboBox);
            this.Controls.Add(this.partsLabel);
            this.Controls.Add(this.outputTestButton);
            this.Controls.Add(this.authorLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MQPM Tool v3.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Button outputTestButton;
        private System.Windows.Forms.Label partsLabel;
        private System.Windows.Forms.ComboBox partsComboBox;
        private System.Windows.Forms.ComboBox outfitComboBox;
        private System.Windows.Forms.Label outfitLabel;
        private System.Windows.Forms.Label outputFolderLabel;
        private System.Windows.Forms.TextBox outputFolderTextBox;
        private System.Windows.Forms.Button outputFolderButton;
    }
}

