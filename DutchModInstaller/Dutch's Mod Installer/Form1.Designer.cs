namespace Dutch_s_Mod_Installer
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
            textBox1 = new TextBox();
            Browse_RDR2 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            Browse_DMI = new Button();
            Start = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(588, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "Red Dead Redemption 2 Folder";
            textBox1.TextChanged += TextBox1_TextChanged;
            // 
            // Browse_RDR2
            // 
            Browse_RDR2.Location = new Point(613, 27);
            Browse_RDR2.Name = "Browse_RDR2";
            Browse_RDR2.Size = new Size(75, 23);
            Browse_RDR2.TabIndex = 1;
            Browse_RDR2.Text = "Browse";
            Browse_RDR2.UseVisualStyleBackColor = true;
            Browse_RDR2.Click += Browse_RDR2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(270, 15);
            label1.TabIndex = 2;
            label1.Text = "Enter your Red Dead Redemption 2 directory here.";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(140, 15);
            label2.TabIndex = 3;
            label2.Text = "Open the DMI config file:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 71);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(588, 23);
            textBox2.TabIndex = 4;
            textBox2.Text = "DMI Config File";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // Browse_DMI
            // 
            Browse_DMI.Location = new Point(613, 71);
            Browse_DMI.Name = "Browse_DMI";
            Browse_DMI.Size = new Size(75, 23);
            Browse_DMI.TabIndex = 5;
            Browse_DMI.Text = "Browse";
            Browse_DMI.UseVisualStyleBackColor = true;
            Browse_DMI.Click += Browse_DMI_Click;
            // 
            // Start
            // 
            Start.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Start.Location = new Point(244, 196);
            Start.Name = "Start";
            Start.Size = new Size(239, 84);
            Start.TabIndex = 6;
            Start.Text = "Start Installing";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(244, 283);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 7;
            label3.Text = "Status:";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(700, 459);
            Controls.Add(label3);
            Controls.Add(Start);
            Controls.Add(Browse_DMI);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Browse_RDR2);
            Controls.Add(textBox1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Dutch's Mod Loader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button Browse_RDR2;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Button Browse_DMI;
        private Button Start;
        private Label label3;
    }
}
