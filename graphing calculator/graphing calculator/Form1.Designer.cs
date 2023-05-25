namespace graphing_calculator
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
            textBox1 = new TextBox();
            button1 = new Button();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            listBox1 = new ListBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            textBox7 = new TextBox();
            label6 = new Label();
            textBox6 = new TextBox();
            label5 = new Label();
            label7 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(300, 27);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(318, 10);
            button1.Name = "button1";
            button1.Size = new Size(124, 29);
            button1.TabIndex = 1;
            button1.Text = "Add Condition";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // plotView1
            // 
            plotView1.Location = new Point(332, 58);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(500, 500);
            plotView1.TabIndex = 4;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(12, 47);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(300, 104);
            listBox1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(12, 157);
            button2.Name = "button2";
            button2.Size = new Size(141, 29);
            button2.TabIndex = 6;
            button2.Text = "Remove All";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(159, 157);
            button3.Name = "button3";
            button3.Size = new Size(153, 29);
            button3.TabIndex = 7;
            button3.Text = "Remove Selected";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(33, 457);
            button4.Name = "button4";
            button4.Size = new Size(94, 57);
            button4.TabIndex = 8;
            button4.Text = "Calculate";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(49, 43);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(70, 27);
            textBox2.TabIndex = 9;
            textBox2.Text = "-3";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(125, 43);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(70, 27);
            textBox3.TabIndex = 10;
            textBox3.Text = "3";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(49, 76);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(70, 27);
            textBox4.TabIndex = 11;
            textBox4.Text = "-3";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(125, 76);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(70, 27);
            textBox5.TabIndex = 12;
            textBox5.Text = "3";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 20);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 13;
            label1.Text = "min";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(144, 20);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 14;
            label2.Text = "max";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 46);
            label3.Name = "label3";
            label3.Size = new Size(17, 20);
            label3.TabIndex = 15;
            label3.Text = "a";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 79);
            label4.Name = "label4";
            label4.Size = new Size(18, 20);
            label4.TabIndex = 16;
            label4.Text = "b";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(24, 192);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 125);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Range of complex number a+bi";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(24, 328);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 103);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "Settings";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(149, 59);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(70, 27);
            textBox7.TabIndex = 18;
            textBox7.Text = "0.01";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 59);
            label6.Name = "label6";
            label6.Size = new Size(109, 20);
            label6.TabIndex = 19;
            label6.Text = "accep. err. [0,1]";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(149, 26);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(70, 27);
            textBox6.TabIndex = 17;
            textBox6.Text = "0.1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 26);
            label5.Name = "label5";
            label5.Size = new Size(138, 20);
            label5.TabIndex = 17;
            label5.Text = "appro. freq. [0.01,1]";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 434);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 19;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(889, 570);
            Controls.Add(label7);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Controls.Add(plotView1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Graphing Calculator(?)";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private ListBox listBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox textBox7;
        private Label label6;
        private TextBox textBox6;
        private Label label5;
        private Label label7;
    }
}