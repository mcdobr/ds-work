﻿namespace PongClient
{
    partial class PongClientForm
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
            this.SuspendLayout();
            // 
            // PongClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PongClientForm";
            this.Text = "Pong";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PongClientForm_FormClosing);
            this.Load += new System.EventHandler(this.PongClientForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PongClientForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PongClientForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PongClientForm_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

