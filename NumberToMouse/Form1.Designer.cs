namespace NumberToMouse
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            trackBar1 = new TrackBar();
            button1 = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(26, 60);
            label1.Name = "label1";
            label1.Size = new Size(19, 21);
            label1.TabIndex = 2;
            label1.Text = "0";
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 100;
            trackBar1.Location = new Point(26, 110);
            trackBar1.Maximum = 3000;
            trackBar1.Minimum = 200;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(254, 45);
            trackBar1.SmallChange = 100;
            trackBar1.TabIndex = 3;
            trackBar1.TickFrequency = 100;
            trackBar1.UseWaitCursor = true;
            trackBar1.Value = 500;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // button1
            // 
            button1.Location = new Point(26, 23);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "500";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label2.Location = new Point(336, 9);
            label2.Name = "label2";
            label2.Size = new Size(59, 24);
            label2.TabIndex = 4;
            label2.Text = "label";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 202);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(trackBar1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NumberToMouse";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TrackBar trackBar1;
        private Button button1;
        private Label label2;
    }
}
