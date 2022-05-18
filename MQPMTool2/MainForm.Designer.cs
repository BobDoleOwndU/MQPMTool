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
            this.partsListWriteTestButton = new System.Windows.Forms.Button();
            this.partsLabel = new System.Windows.Forms.Label();
            this.partsComboBox = new System.Windows.Forms.ComboBox();
            this.outfitListWriteTestButton = new System.Windows.Forms.Button();
            this.outfitComboBox = new System.Windows.Forms.ComboBox();
            this.outfitLabel = new System.Windows.Forms.Label();
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
            this.outputTestButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // partsListWriteTestButton
            // 
            this.partsListWriteTestButton.Location = new System.Drawing.Point(152, 273);
            this.partsListWriteTestButton.Name = "partsListWriteTestButton";
            this.partsListWriteTestButton.Size = new System.Drawing.Size(110, 23);
            this.partsListWriteTestButton.TabIndex = 23;
            this.partsListWriteTestButton.Text = "Parts List Write Test";
            this.partsListWriteTestButton.UseVisualStyleBackColor = true;
            this.partsListWriteTestButton.Click += new System.EventHandler(this.partsListWriteTestButton_Click);
            // 
            // partsLabel
            // 
            this.partsLabel.AutoSize = true;
            this.partsLabel.Location = new System.Drawing.Point(13, 13);
            this.partsLabel.Name = "partsLabel";
            this.partsLabel.Size = new System.Drawing.Size(31, 13);
            this.partsLabel.TabIndex = 24;
            this.partsLabel.Text = "Parts";
            // 
            // partsComboBox
            // 
            this.partsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partsComboBox.FormattingEnabled = true;
            this.partsComboBox.Location = new System.Drawing.Point(12, 29);
            this.partsComboBox.Name = "partsComboBox";
            this.partsComboBox.Size = new System.Drawing.Size(121, 21);
            this.partsComboBox.TabIndex = 25;
            // 
            // outfitListWriteTestButton
            // 
            this.outfitListWriteTestButton.Location = new System.Drawing.Point(152, 244);
            this.outfitListWriteTestButton.Name = "outfitListWriteTestButton";
            this.outfitListWriteTestButton.Size = new System.Drawing.Size(110, 23);
            this.outfitListWriteTestButton.TabIndex = 26;
            this.outfitListWriteTestButton.Text = "OutfitListWriteTest";
            this.outfitListWriteTestButton.UseVisualStyleBackColor = true;
            this.outfitListWriteTestButton.Click += new System.EventHandler(this.outfitListWriteTestButton_Click);
            // 
            // outfitComboBox
            // 
            this.outfitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outfitComboBox.FormattingEnabled = true;
            this.outfitComboBox.Location = new System.Drawing.Point(139, 29);
            this.outfitComboBox.Name = "outfitComboBox";
            this.outfitComboBox.Size = new System.Drawing.Size(121, 21);
            this.outfitComboBox.TabIndex = 27;
            // 
            // outfitLabel
            // 
            this.outfitLabel.AutoSize = true;
            this.outfitLabel.Location = new System.Drawing.Point(136, 13);
            this.outfitLabel.Name = "outfitLabel";
            this.outfitLabel.Size = new System.Drawing.Size(32, 13);
            this.outfitLabel.TabIndex = 28;
            this.outfitLabel.Text = "Outfit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 321);
            this.Controls.Add(this.outfitLabel);
            this.Controls.Add(this.outfitComboBox);
            this.Controls.Add(this.outfitListWriteTestButton);
            this.Controls.Add(this.partsComboBox);
            this.Controls.Add(this.partsLabel);
            this.Controls.Add(this.partsListWriteTestButton);
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
        private System.Windows.Forms.Button partsListWriteTestButton;
        private System.Windows.Forms.Label partsLabel;
        private System.Windows.Forms.ComboBox partsComboBox;
        private System.Windows.Forms.Button outfitListWriteTestButton;
        private System.Windows.Forms.ComboBox outfitComboBox;
        private System.Windows.Forms.Label outfitLabel;
    }
}

