﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Reanimator;
using launcher.Properties;
using System.Diagnostics;

namespace launcher
{
    public partial class Launcher : Form
    {
        string _characterFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Hellgate\\Save\\Singleplayer";
        List<string> _availableCharacters;

        string _homepage = "http://www.hellgateaus.net";

        public Launcher()
        {
            _availableCharacters = new List<string>();
            InitializeComponent();
        }

        private void installToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Config.HglDir))
            {
                Reanimator.Forms.ModificationForm modForm = new Reanimator.Forms.ModificationForm();
                modForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Can't locate Hellgate: London directory. Check settings and try again.");
            }
        }

        private void revertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to revert all modifications?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool change_made = false;

                try
                {
                    for (int i = 0; i < Index.FileNames.Length; i++)
                    {
                        FileStream stream = new FileStream(Config.HglDir + "\\data\\" + Index.FileNames[i] + ".idx", FileMode.Open);
                        Index index = new Index(stream);

                        if (index.Modified)
                        {
                            if (index.Restore() == false)
                            {
                                throw new Exception("Problem cleaning file: " + Index.FileNames[i]);
                            }
                            change_made = true;
                        }
                        index.Dispose();
                        stream.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                if (change_made == true)
                {
                    MessageBox.Show("All modifications have been successfully removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The installation already appears clean.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reanimator.Forms.Options options = new Reanimator.Forms.Options();
            options.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HellgateAus.net Launcher 2038" + Environment.NewLine +
                            "Developed by Maeyan, Alex2069, Kite & Malachor." + Environment.NewLine +
                            "Visit us at " + _homepage + " " + Environment.NewLine +
                            "Contact maeyan.zero@gmail.com for info.",
                            "HellgateAus.net Launcher 2038", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Launcher_Load(object sender, EventArgs e)
        {
            _availableCharacters.Add("Start game");
            _availableCharacters.AddRange(Directory.GetFiles(_characterFolder, "*.hg1"));

            //remove path and file extension to get the pure character name
            for (int i = 0; i < _availableCharacters.Count; i++)
            {
                _availableCharacters[i] = _availableCharacters[i].Replace(_characterFolder + @"\", string.Empty).Replace(".hg1", string.Empty);
            }

            characterCombo.DataSource = _availableCharacters;
        }

        private void p_start_Click(object sender, EventArgs e)
        {
            MinimizeWindow();
            StartGame();
        }

        private void StartGame()
        {
            try
            {
                if (characterCombo.SelectedIndex > 0)
                {
                    string characterToLoad = _characterFolder + @"\" + characterCombo.SelectedItem + @".hg1";
                    string arguments = "-singleplayer -load\"" + characterToLoad +"\"";

                    Process.Start(Config.GameClientPath, arguments);
                }
                else
                {
                    Process.Start(Config.GameClientPath, "-singleplayer\"");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start game at:\n" + Config.GameClientPath + "\n\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void p_start_MouseEnter(object sender, EventArgs e)
        {
            p_start.BackgroundImage = Resources.templar_mouseOver;
            toolStripStatusLabel1.Text = "Unlesh Hell!";
        }

        private void p_start_MouseLeave(object sender, EventArgs e)
        {
            p_start.BackgroundImage = Resources.templar_normal;
            toolStripStatusLabel1.Text = "";
        }

        private void p_start_MouseDown(object sender, MouseEventArgs e)
        {
            p_start.BackgroundImage = Resources.templar_normal;
        }

        private void p_start_MouseUp(object sender, MouseEventArgs e)
        {
            p_start.BackgroundImage = Resources.templar_mouseOver;
        }

        private void p_homePageLink_Click(object sender, EventArgs e)
        {
            MinimizeWindow();
            Process.Start(_homepage);
        }

        private void MinimizeWindow()
        {
            //minimizes the window to prevent multiple clicks on the launch/openHomePage button
            this.WindowState = FormWindowState.Minimized;
        }

        private void p_openHomePage_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Visit it at http://www.hellgateaus.net";
        }

        private void p_openHomePage_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void enableHCCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hardcore hardcore = new Hardcore();
            hardcore.ShowDialog();
        }

        private void itemTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transfer transfer = new Transfer();
            transfer.ShowDialog();
        }
    }
}