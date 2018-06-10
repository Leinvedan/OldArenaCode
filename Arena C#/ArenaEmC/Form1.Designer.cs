namespace ArenaEmC {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.HPStLabel = new System.Windows.Forms.Label();
            this.Att1Label = new System.Windows.Forms.Label();
            this.Att2Label = new System.Windows.Forms.Label();
            this.SpecialLabel = new System.Windows.Forms.Label();
            this.UseHeroButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.AttackButton = new System.Windows.Forms.Button();
            this.EnemyNameLabel = new System.Windows.Forms.Label();
            this.EnemyHPLabel = new System.Windows.Forms.Label();
            this.SoloCheckBox = new System.Windows.Forms.CheckBox();
            this.ShowTurnLabel = new System.Windows.Forms.Label();
            this.ProtectButton = new System.Windows.Forms.Button();
            this.DoNothingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 13);
            this.comboBox1.MaxDropDownItems = 12;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // HPStLabel
            // 
            this.HPStLabel.AutoSize = true;
            this.HPStLabel.Location = new System.Drawing.Point(117, 57);
            this.HPStLabel.Name = "HPStLabel";
            this.HPStLabel.Size = new System.Drawing.Size(31, 13);
            this.HPStLabel.TabIndex = 1;
            this.HPStLabel.Text = "Stats";
            this.HPStLabel.Click += new System.EventHandler(this.HPStLabel_Click);
            // 
            // Att1Label
            // 
            this.Att1Label.AutoSize = true;
            this.Att1Label.Location = new System.Drawing.Point(117, 96);
            this.Att1Label.Name = "Att1Label";
            this.Att1Label.Size = new System.Drawing.Size(41, 13);
            this.Att1Label.TabIndex = 2;
            this.Att1Label.Text = "Primary";
            this.Att1Label.Click += new System.EventHandler(this.Att1Label_Click);
            // 
            // Att2Label
            // 
            this.Att2Label.AutoSize = true;
            this.Att2Label.Location = new System.Drawing.Point(117, 149);
            this.Att2Label.Name = "Att2Label";
            this.Att2Label.Size = new System.Drawing.Size(58, 13);
            this.Att2Label.TabIndex = 3;
            this.Att2Label.Text = "Secondary";
            this.Att2Label.Click += new System.EventHandler(this.Att2Label_Click);
            // 
            // SpecialLabel
            // 
            this.SpecialLabel.AutoSize = true;
            this.SpecialLabel.Location = new System.Drawing.Point(117, 199);
            this.SpecialLabel.Name = "SpecialLabel";
            this.SpecialLabel.Size = new System.Drawing.Size(42, 13);
            this.SpecialLabel.TabIndex = 4;
            this.SpecialLabel.Text = "Special";
            this.SpecialLabel.Click += new System.EventHandler(this.SpecialLabel_Click);
            // 
            // UseHeroButton
            // 
            this.UseHeroButton.Location = new System.Drawing.Point(16, 230);
            this.UseHeroButton.Name = "UseHeroButton";
            this.UseHeroButton.Size = new System.Drawing.Size(75, 45);
            this.UseHeroButton.TabIndex = 5;
            this.UseHeroButton.Text = "Use This Hero";
            this.UseHeroButton.UseVisualStyleBackColor = true;
            this.UseHeroButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 167);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(435, 57);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(99, 167);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // AttackButton
            // 
            this.AttackButton.Location = new System.Drawing.Point(120, 235);
            this.AttackButton.Name = "AttackButton";
            this.AttackButton.Size = new System.Drawing.Size(130, 53);
            this.AttackButton.TabIndex = 8;
            this.AttackButton.Text = "ATTACK!";
            this.AttackButton.UseVisualStyleBackColor = true;
            this.AttackButton.Visible = false;
            this.AttackButton.Click += new System.EventHandler(this.AttackButton_Click);
            // 
            // EnemyNameLabel
            // 
            this.EnemyNameLabel.AutoSize = true;
            this.EnemyNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EnemyNameLabel.ForeColor = System.Drawing.Color.Red;
            this.EnemyNameLabel.Location = new System.Drawing.Point(435, 16);
            this.EnemyNameLabel.Name = "EnemyNameLabel";
            this.EnemyNameLabel.Size = new System.Drawing.Size(37, 15);
            this.EnemyNameLabel.TabIndex = 9;
            this.EnemyNameLabel.Text = "label1";
            this.EnemyNameLabel.Visible = false;
            // 
            // EnemyHPLabel
            // 
            this.EnemyHPLabel.AutoSize = true;
            this.EnemyHPLabel.Location = new System.Drawing.Point(437, 41);
            this.EnemyHPLabel.Name = "EnemyHPLabel";
            this.EnemyHPLabel.Size = new System.Drawing.Size(35, 13);
            this.EnemyHPLabel.TabIndex = 10;
            this.EnemyHPLabel.Text = "label1";
            this.EnemyHPLabel.Visible = false;
            // 
            // SoloCheckBox
            // 
            this.SoloCheckBox.AutoSize = true;
            this.SoloCheckBox.Checked = true;
            this.SoloCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SoloCheckBox.Location = new System.Drawing.Point(140, 15);
            this.SoloCheckBox.Name = "SoloCheckBox";
            this.SoloCheckBox.Size = new System.Drawing.Size(47, 17);
            this.SoloCheckBox.TabIndex = 11;
            this.SoloCheckBox.Text = "Solo";
            this.SoloCheckBox.UseVisualStyleBackColor = true;
            // 
            // ShowTurnLabel
            // 
            this.ShowTurnLabel.AutoSize = true;
            this.ShowTurnLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ShowTurnLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ShowTurnLabel.Location = new System.Drawing.Point(194, 20);
            this.ShowTurnLabel.Name = "ShowTurnLabel";
            this.ShowTurnLabel.Size = new System.Drawing.Size(37, 15);
            this.ShowTurnLabel.TabIndex = 12;
            this.ShowTurnLabel.Text = "label1";
            this.ShowTurnLabel.Visible = false;
            this.ShowTurnLabel.Click += new System.EventHandler(this.ShowTurnLabel_Click);
            // 
            // ProtectButton
            // 
            this.ProtectButton.Location = new System.Drawing.Point(256, 235);
            this.ProtectButton.Name = "ProtectButton";
            this.ProtectButton.Size = new System.Drawing.Size(80, 53);
            this.ProtectButton.TabIndex = 14;
            this.ProtectButton.Text = "PROTECT!";
            this.ProtectButton.UseVisualStyleBackColor = true;
            this.ProtectButton.Visible = false;
            this.ProtectButton.Click += new System.EventHandler(this.ProtectButton_Click);
            // 
            // DoNothingButton
            // 
            this.DoNothingButton.Location = new System.Drawing.Point(342, 235);
            this.DoNothingButton.Name = "DoNothingButton";
            this.DoNothingButton.Size = new System.Drawing.Size(80, 53);
            this.DoNothingButton.TabIndex = 15;
            this.DoNothingButton.Text = "DO NOTHING! (+1 Stamina)";
            this.DoNothingButton.UseVisualStyleBackColor = true;
            this.DoNothingButton.Visible = false;
            this.DoNothingButton.Click += new System.EventHandler(this.DoNothingButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(546, 294);
            this.Controls.Add(this.DoNothingButton);
            this.Controls.Add(this.ProtectButton);
            this.Controls.Add(this.ShowTurnLabel);
            this.Controls.Add(this.SoloCheckBox);
            this.Controls.Add(this.EnemyHPLabel);
            this.Controls.Add(this.EnemyNameLabel);
            this.Controls.Add(this.AttackButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UseHeroButton);
            this.Controls.Add(this.SpecialLabel);
            this.Controls.Add(this.Att2Label);
            this.Controls.Add(this.Att1Label);
            this.Controls.Add(this.HPStLabel);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ARENA V0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label HPStLabel;
        private System.Windows.Forms.Label Att1Label;
        private System.Windows.Forms.Label Att2Label;
        private System.Windows.Forms.Label SpecialLabel;
        private System.Windows.Forms.Button UseHeroButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button AttackButton;
        private System.Windows.Forms.Label EnemyNameLabel;
        private System.Windows.Forms.Label EnemyHPLabel;
        private System.Windows.Forms.CheckBox SoloCheckBox;
        private System.Windows.Forms.Label ShowTurnLabel;
        private System.Windows.Forms.Button ProtectButton;
        private System.Windows.Forms.Button DoNothingButton;
        }
    }

