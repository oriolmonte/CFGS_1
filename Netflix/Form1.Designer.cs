namespace Netflix
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
            idbut = new Button();
            generebox = new TextBox();
            indexbox = new TextBox();
            idbox = new TextBox();
            mergebut = new Button();
            rangebut = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            genbut = new Button();
            indexbut = new Button();
            label4 = new Label();
            minbox = new TextBox();
            label5 = new Label();
            maxbox = new TextBox();
            registres = new RichTextBox();
            SuspendLayout();
            // 
            // idbut
            // 
            idbut.Location = new Point(640, 268);
            idbut.Name = "idbut";
            idbut.Size = new Size(131, 23);
            idbut.TabIndex = 0;
            idbut.Text = "Seleciona per ID";
            idbut.UseVisualStyleBackColor = true;
            idbut.Click += idbut_Click;
            // 
            // generebox
            // 
            generebox.Location = new Point(646, 63);
            generebox.Name = "generebox";
            generebox.Size = new Size(100, 23);
            generebox.TabIndex = 2;
            // 
            // indexbox
            // 
            indexbox.Location = new Point(646, 102);
            indexbox.Name = "indexbox";
            indexbox.Size = new Size(100, 23);
            indexbox.TabIndex = 3;
            // 
            // idbox
            // 
            idbox.Location = new Point(646, 144);
            idbox.Name = "idbox";
            idbox.Size = new Size(100, 23);
            idbox.TabIndex = 4;
            // 
            // mergebut
            // 
            mergebut.Location = new Point(642, 355);
            mergebut.Name = "mergebut";
            mergebut.Size = new Size(129, 23);
            mergebut.TabIndex = 7;
            mergebut.Text = "Mescla";
            mergebut.UseVisualStyleBackColor = true;
            mergebut.Click += mergebut_Click;
            // 
            // rangebut
            // 
            rangebut.Location = new Point(642, 384);
            rangebut.Name = "rangebut";
            rangebut.Size = new Size(129, 23);
            rangebut.TabIndex = 8;
            rangebut.Text = "Rang";
            rangebut.UseVisualStyleBackColor = true;
            rangebut.Click += rangebut_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(644, 45);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 9;
            label1.Text = "Genere";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(646, 89);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 10;
            label2.Text = "Index";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(646, 128);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 11;
            label3.Text = "ID";
            // 
            // genbut
            // 
            genbut.Location = new Point(640, 297);
            genbut.Name = "genbut";
            genbut.Size = new Size(131, 23);
            genbut.TabIndex = 12;
            genbut.Text = "Seleciona per Genere";
            genbut.UseVisualStyleBackColor = true;
            genbut.Click += genbut_Click;
            // 
            // indexbut
            // 
            indexbut.Location = new Point(642, 326);
            indexbut.Name = "indexbut";
            indexbut.Size = new Size(131, 23);
            indexbut.TabIndex = 13;
            indexbut.Text = "Seleciona per Index";
            indexbut.UseVisualStyleBackColor = true;
            indexbut.Click += indexbut_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(646, 170);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 15;
            label4.Text = "Minim";
            // 
            // minbox
            // 
            minbox.Location = new Point(646, 186);
            minbox.Name = "minbox";
            minbox.Size = new Size(100, 23);
            minbox.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(646, 210);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 17;
            label5.Text = "Maxim";
            // 
            // maxbox
            // 
            maxbox.Location = new Point(646, 228);
            maxbox.Name = "maxbox";
            maxbox.Size = new Size(100, 23);
            maxbox.TabIndex = 16;
            // 
            // registres
            // 
            registres.Location = new Point(33, 63);
            registres.Name = "registres";
            registres.Size = new Size(569, 336);
            registres.TabIndex = 19;
            registres.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(registres);
            Controls.Add(label5);
            Controls.Add(maxbox);
            Controls.Add(label4);
            Controls.Add(minbox);
            Controls.Add(indexbut);
            Controls.Add(genbut);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(rangebut);
            Controls.Add(mergebut);
            Controls.Add(idbox);
            Controls.Add(indexbox);
            Controls.Add(generebox);
            Controls.Add(idbut);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button idbut;
        private TextBox generebox;
        private TextBox indexbox;
        private TextBox idbox;
        private Button mergebut;
        private Button rangebut;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button genbut;
        private Button indexbut;
        private Label label4;
        private TextBox minbox;
        private Label label5;
        private TextBox maxbox;
        private RichTextBox registres;
    }
}
