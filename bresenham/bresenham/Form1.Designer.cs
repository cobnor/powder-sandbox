namespace bresenham
{
    partial class Form1
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
            this.pctDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // pctDisplay
            // 
            this.pctDisplay.Location = new System.Drawing.Point(13, 13);
            this.pctDisplay.Name = "pctDisplay";
            this.pctDisplay.Size = new System.Drawing.Size(775, 380);
            this.pctDisplay.TabIndex = 0;
            this.pctDisplay.TabStop = false;
            this.pctDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctDisplay_MouseDown);
            this.pctDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctDisplay_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pctDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pctDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctDisplay;
    }
}

