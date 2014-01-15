namespace CaptureServerRx
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxConsole = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtconsole = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnControl = new System.Windows.Forms.RadioButton();
            this.rbtnrec = new System.Windows.Forms.RadioButton();
            this.rbtnfull = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxAutoFirewall = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnjpg = new System.Windows.Forms.RadioButton();
            this.rbtnvp = new System.Windows.Forms.RadioButton();
            this.rbtnpng = new System.Windows.Forms.RadioButton();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.txtport = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblfps = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(87, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbxConsole);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 42);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cbxConsole
            // 
            this.cbxConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxConsole.AutoSize = true;
            this.cbxConsole.Location = new System.Drawing.Point(622, 17);
            this.cbxConsole.Name = "cbxConsole";
            this.cbxConsole.Size = new System.Drawing.Size(64, 17);
            this.cbxConsole.TabIndex = 2;
            this.cbxConsole.Text = "Console";
            this.cbxConsole.UseVisualStyleBackColor = true;
            this.cbxConsole.CheckedChanged += new System.EventHandler(this.cbxConsole_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtconsole);
            this.groupBox3.Location = new System.Drawing.Point(206, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(503, 389);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Console";
            // 
            // txtconsole
            // 
            this.txtconsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtconsole.Location = new System.Drawing.Point(7, 20);
            this.txtconsole.Multiline = true;
            this.txtconsole.Name = "txtconsole";
            this.txtconsole.ReadOnly = true;
            this.txtconsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtconsole.Size = new System.Drawing.Size(490, 363);
            this.txtconsole.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbxAutoFirewall);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.trackBarSpeed);
            this.groupBox2.Controls.Add(this.txtport);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblfps);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 389);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settinngs";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnControl);
            this.panel2.Controls.Add(this.rbtnrec);
            this.panel2.Controls.Add(this.rbtnfull);
            this.panel2.Location = new System.Drawing.Point(8, 278);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(173, 86);
            this.panel2.TabIndex = 16;
            // 
            // rbtnControl
            // 
            this.rbtnControl.AutoSize = true;
            this.rbtnControl.Enabled = false;
            this.rbtnControl.Location = new System.Drawing.Point(10, 51);
            this.rbtnControl.Name = "rbtnControl";
            this.rbtnControl.Size = new System.Drawing.Size(84, 17);
            this.rbtnControl.TabIndex = 2;
            this.rbtnControl.TabStop = true;
            this.rbtnControl.Text = "Form Control";
            this.rbtnControl.UseVisualStyleBackColor = true;
            this.rbtnControl.CheckedChanged += new System.EventHandler(this.rbtnControl_CheckedChanged);
            // 
            // rbtnrec
            // 
            this.rbtnrec.AutoSize = true;
            this.rbtnrec.Location = new System.Drawing.Point(10, 27);
            this.rbtnrec.Name = "rbtnrec";
            this.rbtnrec.Size = new System.Drawing.Size(74, 17);
            this.rbtnrec.TabIndex = 1;
            this.rbtnrec.Text = "Rectangle";
            this.rbtnrec.UseVisualStyleBackColor = true;
            this.rbtnrec.CheckedChanged += new System.EventHandler(this.rbtnrec_CheckedChanged);
            // 
            // rbtnfull
            // 
            this.rbtnfull.AutoSize = true;
            this.rbtnfull.Checked = true;
            this.rbtnfull.Location = new System.Drawing.Point(10, 3);
            this.rbtnfull.Name = "rbtnfull";
            this.rbtnfull.Size = new System.Drawing.Size(75, 17);
            this.rbtnfull.TabIndex = 0;
            this.rbtnfull.TabStop = true;
            this.rbtnfull.Text = "FullScreen";
            this.rbtnfull.UseVisualStyleBackColor = true;
            this.rbtnfull.CheckedChanged += new System.EventHandler(this.rbtnfull_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "AREA:";
            // 
            // cbxAutoFirewall
            // 
            this.cbxAutoFirewall.AutoSize = true;
            this.cbxAutoFirewall.Checked = true;
            this.cbxAutoFirewall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAutoFirewall.Location = new System.Drawing.Point(51, 50);
            this.cbxAutoFirewall.Name = "cbxAutoFirewall";
            this.cbxAutoFirewall.Size = new System.Drawing.Size(130, 17);
            this.cbxAutoFirewall.TabIndex = 14;
            this.cbxAutoFirewall.Text = "Auto configure firewall";
            this.cbxAutoFirewall.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(8, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 2);
            this.label9.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(8, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 2);
            this.label8.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(6, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 2);
            this.label7.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnjpg);
            this.panel1.Controls.Add(this.rbtnvp);
            this.panel1.Controls.Add(this.rbtnpng);
            this.panel1.Location = new System.Drawing.Point(7, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 75);
            this.panel1.TabIndex = 10;
            // 
            // rbtnjpg
            // 
            this.rbtnjpg.AutoSize = true;
            this.rbtnjpg.Location = new System.Drawing.Point(11, 49);
            this.rbtnjpg.Name = "rbtnjpg";
            this.rbtnjpg.Size = new System.Drawing.Size(45, 17);
            this.rbtnjpg.TabIndex = 6;
            this.rbtnjpg.Text = "jpeg";
            this.rbtnjpg.UseVisualStyleBackColor = true;
            // 
            // rbtnvp
            // 
            this.rbtnvp.AutoSize = true;
            this.rbtnvp.Location = new System.Drawing.Point(11, 26);
            this.rbtnvp.Name = "rbtnvp";
            this.rbtnvp.Size = new System.Drawing.Size(75, 17);
            this.rbtnvp.TabIndex = 5;
            this.rbtnvp.Text = "vp8(webp)";
            this.rbtnvp.UseVisualStyleBackColor = true;
            // 
            // rbtnpng
            // 
            this.rbtnpng.AutoSize = true;
            this.rbtnpng.Checked = true;
            this.rbtnpng.Location = new System.Drawing.Point(11, 3);
            this.rbtnpng.Name = "rbtnpng";
            this.rbtnpng.Size = new System.Drawing.Size(43, 17);
            this.rbtnpng.TabIndex = 4;
            this.rbtnpng.TabStop = true;
            this.rbtnpng.Text = "png";
            this.rbtnpng.UseVisualStyleBackColor = true;
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(7, 100);
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(164, 45);
            this.trackBarSpeed.TabIndex = 3;
            this.trackBarSpeed.TickFrequency = 2;
            this.trackBarSpeed.Value = 8;
            this.trackBarSpeed.ValueChanged += new System.EventHandler(this.trackBarSpeed_ValueChanged);
            // 
            // txtport
            // 
            this.txtport.Location = new System.Drawing.Point(51, 24);
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(111, 20);
            this.txtport.TabIndex = 2;
            this.txtport.Text = "8080";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "FORMAT:";
            // 
            // lblfps
            // 
            this.lblfps.AutoSize = true;
            this.lblfps.Location = new System.Drawing.Point(56, 80);
            this.lblfps.Name = "lblfps";
            this.lblfps.Size = new System.Drawing.Size(0, 13);
            this.lblfps.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "SPEED:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "PORT:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 444);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Screen Share Application";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtconsole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Label lblfps;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnpng;
        private System.Windows.Forms.RadioButton rbtnjpg;
        private System.Windows.Forms.RadioButton rbtnvp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbxAutoFirewall;
        private System.Windows.Forms.CheckBox cbxConsole;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnrec;
        private System.Windows.Forms.RadioButton rbtnfull;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnControl;
    }
}

