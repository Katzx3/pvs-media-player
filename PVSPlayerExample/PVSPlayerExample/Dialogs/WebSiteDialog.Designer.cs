﻿using System.ComponentModel;
using System.Windows.Forms;

namespace PVSPlayerExample
{
    partial class WebSiteDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.bottomPanel = new System.Windows.Forms.Panel();
			this.cancelButton = new PVSPlayerExample.CustomButton();
			this.OKButton = new PVSPlayerExample.CustomButton();
			this.panel4 = new System.Windows.Forms.Panel();
			this.pvsPanel = new System.Windows.Forms.Panel();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.bottomPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
			this.label1.Location = new System.Drawing.Point(64, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(265, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Open the CodeProject website in your browser?";
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
			this.radioButton1.Location = new System.Drawing.Point(118, 65);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(145, 19);
			this.radioButton1.TabIndex = 2;
			this.radioButton1.Text = "Go to the Home page.";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Checked = true;
			this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
			this.radioButton2.Location = new System.Drawing.Point(118, 84);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(211, 19);
			this.radioButton2.TabIndex = 3;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Go to the PVS.MediaPlayer article.";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
			// 
			// bottomPanel
			// 
			this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.bottomPanel.Controls.Add(this.cancelButton);
			this.bottomPanel.Controls.Add(this.OKButton);
			this.bottomPanel.Controls.Add(this.panel4);
			this.bottomPanel.Controls.Add(this.pvsPanel);
			this.bottomPanel.Location = new System.Drawing.Point(1, 151);
			this.bottomPanel.Name = "bottomPanel";
			this.bottomPanel.Size = new System.Drawing.Size(402, 49);
			this.bottomPanel.TabIndex = 4;
			// 
			// cancelButton
			// 
			this.cancelButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.FocusBorder = true;
			this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
			this.cancelButton.Location = new System.Drawing.Point(306, 14);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(84, 23);
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "No";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// OKButton
			// 
			this.OKButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.OKButton.FocusBorder = true;
			this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OKButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
			this.OKButton.Location = new System.Drawing.Point(213, 14);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(84, 23);
			this.OKButton.TabIndex = 2;
			this.OKButton.Text = "Yes";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// panel4
			// 
			this.panel4.Location = new System.Drawing.Point(95, 4);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(78, 41);
			this.panel4.TabIndex = 1;
			// 
			// pvsPanel
			// 
			this.pvsPanel.Location = new System.Drawing.Point(10, 9);
			this.pvsPanel.Name = "pvsPanel";
			this.pvsPanel.Size = new System.Drawing.Size(42, 33);
			this.pvsPanel.TabIndex = 0;
			this.pvsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PvsPanel_Paint);
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.ForeColor = System.Drawing.Color.SlateGray;
			this.radioButton3.Location = new System.Drawing.Point(118, 103);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(206, 19);
			this.radioButton3.TabIndex = 5;
			this.radioButton3.Text = "Go to the Sound Recorder article.";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton3.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
			// 
			// WebSiteDialog
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(404, 201);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.bottomPanel);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WebSiteDialog";
			this.Opacity = 0.95D;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "CodeProject";
			this.Shown += new System.EventHandler(this.WebSiteDialog_Shown);
			this.bottomPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Label label1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Panel bottomPanel;
        internal Panel pvsPanel;
        internal Panel panel4;
        private CustomButton cancelButton;
        private CustomButton OKButton;
        private RadioButton radioButton3;
    }
}