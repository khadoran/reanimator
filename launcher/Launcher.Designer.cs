﻿namespace launcher
{
    partial class Launcher
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.enableHCCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.characterCombo = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installToolStripMenuItem,
            this.revertToolStripMenuItem,
            this.toolStripSeparator1,
            this.enableHCCharacterToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // installToolStripMenuItem
            // 
            this.installToolStripMenuItem.Name = "installToolStripMenuItem";
            this.installToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.installToolStripMenuItem.Text = "Install Modifications...";
            this.installToolStripMenuItem.Click += new System.EventHandler(this.installToolStripMenuItem_Click);
            // 
            // revertToolStripMenuItem
            // 
            this.revertToolStripMenuItem.Name = "revertToolStripMenuItem";
            this.revertToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.revertToolStripMenuItem.Text = "Uninstall Modifications...";
            this.revertToolStripMenuItem.Click += new System.EventHandler(this.revertToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // enableHCCharacterToolStripMenuItem
            // 
            this.enableHCCharacterToolStripMenuItem.Name = "enableHCCharacterToolStripMenuItem";
            this.enableHCCharacterToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.enableHCCharacterToolStripMenuItem.Text = "Enable HC Character...";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // launchLabel
            // 
            this.launchLabel.AutoSize = true;
            this.launchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.launchLabel.Location = new System.Drawing.Point(12, 356);
            this.launchLabel.Name = "launchLabel";
            this.launchLabel.Size = new System.Drawing.Size(197, 37);
            this.launchLabel.TabIndex = 5;
            this.launchLabel.Text = "Unleash Hell";
            this.launchLabel.Click += new System.EventHandler(this.launchLabel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(381, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 402);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RSS Feed";
            // 
            // characterCombo
            // 
            this.characterCombo.FormattingEnabled = true;
            this.characterCombo.Location = new System.Drawing.Point(19, 397);
            this.characterCombo.Name = "characterCombo";
            this.characterCombo.Size = new System.Drawing.Size(190, 21);
            this.characterCombo.TabIndex = 7;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.characterCombo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.launchLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HellgateAus.net Launcher 2038";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label launchLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revertToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem enableHCCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox characterCombo;

    }
}
