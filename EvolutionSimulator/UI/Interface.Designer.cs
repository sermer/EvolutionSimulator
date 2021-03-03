namespace EvolutionSimulator
{
    partial class Interface
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.worldGenButton = new System.Windows.Forms.Button();
            this.beginButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(35, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1664, 819);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // worldGenButton
            // 
            this.worldGenButton.Location = new System.Drawing.Point(868, 874);
            this.worldGenButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.worldGenButton.Name = "worldGenButton";
            this.worldGenButton.Size = new System.Drawing.Size(248, 135);
            this.worldGenButton.TabIndex = 2;
            this.worldGenButton.Text = "Generate World";
            this.worldGenButton.UseVisualStyleBackColor = true;
            this.worldGenButton.Click += new System.EventHandler(this.worldGenButton_Click);
            // 
            // beginButton
            // 
            this.beginButton.Location = new System.Drawing.Point(538, 874);
            this.beginButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(248, 135);
            this.beginButton.TabIndex = 3;
            this.beginButton.Text = "Begin Simulation";
            this.beginButton.UseVisualStyleBackColor = true;
            this.beginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(1451, 874);
            this.loadButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(248, 135);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Load Previous Run";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1730, 1023);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.beginButton);
            this.Controls.Add(this.worldGenButton);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Interface";
            this.Text = "Evolution Simulator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button worldGenButton;
        private System.Windows.Forms.Button beginButton;
        private System.Windows.Forms.Button loadButton;
    }
}

