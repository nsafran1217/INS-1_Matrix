using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace INS_1_MatrixDesigner
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

        private int addButtons(int rows, int cols, int numOfDisplays)   //programatically add a grid of buttons. can be adjusted with the for loops
        {
            List<RoundButton> buttons = new List<RoundButton>();
            List<Button> rowcolButtons = new List<Button>();
            int loopCount = 0;
            
            for (int display = 0; display < numOfDisplays; display++)
            {
                Graphics g = CreateGraphics();
                Point startPoint = new Point(cols * display * 30 + 70, 20);
                Point endPoint = new Point(cols * display * 30 + 70, rows * 30 + 100);
                Pen pen = new Pen(Color.Red, 2);
                g.DrawLine(pen, startPoint, endPoint);
                pen.Dispose();

                int icorrection = cols * display;
                for (int j = 0; j < rows; j++)  //rows
                {
                    for (int i = 0; i < cols; i++)  //cols
                    {

                        if (j == 0)
                        {
                            rowcolButtons.Add(new Button());
                            rowcolButtons[i + icorrection].FlatAppearance.BorderSize = 1;
                            rowcolButtons[i + icorrection].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                            rowcolButtons[i + icorrection].Location = new System.Drawing.Point(((i + icorrection+ 1) * 30) + 40, 40);
                            rowcolButtons[i + icorrection].Name = "ledcol-" + (i + icorrection).ToString();
                            rowcolButtons[i + icorrection].Size = new System.Drawing.Size(30, 30);
                            rowcolButtons[i + icorrection].UseVisualStyleBackColor = false;
                            this.Controls.Add(rowcolButtons[i + icorrection]);
                            rowcolButtons[i + icorrection].Click += new System.EventHandler(this.ledrowcolbtn_Click);
                        }

                        buttons.Add(new RoundButton());
                        buttons[loopCount].BackColor = System.Drawing.ColorTranslator.FromHtml("#290900");
                        buttons[loopCount].FlatAppearance.BorderSize = 0;
                        buttons[loopCount].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        buttons[loopCount].Location = new System.Drawing.Point(((i + icorrection + 1) * 30) + 40, ((j + 1) * 30) + 40);
                        buttons[loopCount].Name = "led-" + j.ToString() + "-" + (i).ToString() + "-" + (display).ToString(); //led-y-x-display
                        buttons[loopCount].Size = new System.Drawing.Size(30, 30);
                        buttons[loopCount].UseVisualStyleBackColor = false;
                        buttons[loopCount].Click += new System.EventHandler(this.ledbtn_Click);
                        this.Controls.Add(buttons[loopCount]);

                        loopCount++;
                    }

                    if (display == numOfDisplays-1)   //only add row buttons for the first display
                    {
                        rowcolButtons.Add(new Button());
                        //rowcolButtons[j + i].BackColor = System.Drawing.ColorTranslator.FromHtml("#290900");
                        rowcolButtons[j + cols + icorrection].FlatAppearance.BorderSize = 1;
                        rowcolButtons[j + cols + icorrection].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        rowcolButtons[j + cols + icorrection].Location = new System.Drawing.Point(40, ((j + 1) * 30) + 40);
                        rowcolButtons[j + cols + icorrection].Name = "ledrow-" + (j).ToString();
                        rowcolButtons[j + cols + icorrection].Size = new System.Drawing.Size(30, 30);
                        rowcolButtons[j + cols + icorrection].UseVisualStyleBackColor = false;
                        this.Controls.Add(rowcolButtons[j + cols + icorrection]);
                        rowcolButtons[j + cols + icorrection].Click += new System.EventHandler(this.ledrowcolbtn_Click);
                    }
                }             
            }
            return rows * cols;
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outTextBox = new System.Windows.Forms.TextBox();
            this.nextbtn = new System.Windows.Forms.Button();
            this.outLines = new System.Windows.Forms.TextBox();
            this.radioGroupBox = new System.Windows.Forms.GroupBox();
            this.hexRadioButton = new System.Windows.Forms.RadioButton();
            this.binaryRadioButton = new System.Windows.Forms.RadioButton();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.clearButton = new System.Windows.Forms.Button();
            this.packingCheckBox = new System.Windows.Forms.CheckBox();
            this.rowsUpDown = new System.Windows.Forms.NumericUpDown();
            this.colsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.numOfDisplaysUpDown = new System.Windows.Forms.NumericUpDown();
            this.makeGridButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.reverseCheckBox = new System.Windows.Forms.CheckBox();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.currLineTxtBox = new System.Windows.Forms.TextBox();
            this.openbutton = new System.Windows.Forms.Button();
            this.savebutton = new System.Windows.Forms.Button();
            this.frameDelayUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.removeFrameBtn = new System.Windows.Forms.Button();
            this.radioGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colsUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOfDisplaysUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameDelayUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // outTextBox
            // 
            this.outTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outTextBox.Location = new System.Drawing.Point(661, 12);
            this.outTextBox.Multiline = true;
            this.outTextBox.Name = "outTextBox";
            this.outTextBox.ReadOnly = true;
            this.outTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outTextBox.Size = new System.Drawing.Size(356, 295);
            this.outTextBox.TabIndex = 16;
            // 
            // nextbtn
            // 
            this.nextbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextbtn.Enabled = false;
            this.nextbtn.Location = new System.Drawing.Point(526, 12);
            this.nextbtn.Name = "nextbtn";
            this.nextbtn.Size = new System.Drawing.Size(129, 48);
            this.nextbtn.TabIndex = 20;
            this.nextbtn.Text = "insertAtFrame";
            this.nextbtn.UseVisualStyleBackColor = true;
            this.nextbtn.Click += new System.EventHandler(this.nextbtn_Click);
            // 
            // outLines
            // 
            this.outLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.outLines.Location = new System.Drawing.Point(661, 314);
            this.outLines.Multiline = true;
            this.outLines.Name = "outLines";
            this.outLines.ReadOnly = true;
            this.outLines.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outLines.Size = new System.Drawing.Size(356, 270);
            this.outLines.TabIndex = 21;
            this.outLines.WordWrap = false;
            // 
            // radioGroupBox
            // 
            this.radioGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioGroupBox.Controls.Add(this.hexRadioButton);
            this.radioGroupBox.Controls.Add(this.binaryRadioButton);
            this.radioGroupBox.Location = new System.Drawing.Point(526, 169);
            this.radioGroupBox.Name = "radioGroupBox";
            this.radioGroupBox.Size = new System.Drawing.Size(129, 138);
            this.radioGroupBox.TabIndex = 25;
            this.radioGroupBox.TabStop = false;
            this.radioGroupBox.Text = "Output Format";
            // 
            // hexRadioButton
            // 
            this.hexRadioButton.AutoSize = true;
            this.hexRadioButton.Checked = true;
            this.hexRadioButton.Location = new System.Drawing.Point(7, 44);
            this.hexRadioButton.Name = "hexRadioButton";
            this.hexRadioButton.Size = new System.Drawing.Size(44, 17);
            this.hexRadioButton.TabIndex = 1;
            this.hexRadioButton.TabStop = true;
            this.hexRadioButton.Text = "Hex";
            this.hexRadioButton.UseVisualStyleBackColor = true;
            // 
            // binaryRadioButton
            // 
            this.binaryRadioButton.AutoSize = true;
            this.binaryRadioButton.Location = new System.Drawing.Point(7, 20);
            this.binaryRadioButton.Name = "binaryRadioButton";
            this.binaryRadioButton.Size = new System.Drawing.Size(54, 17);
            this.binaryRadioButton.TabIndex = 0;
            this.binaryRadioButton.Text = "Binary";
            this.binaryRadioButton.UseVisualStyleBackColor = true;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Enabled = false;
            this.clearButton.Location = new System.Drawing.Point(526, 66);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(129, 48);
            this.clearButton.TabIndex = 26;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // packingCheckBox
            // 
            this.packingCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.packingCheckBox.AutoSize = true;
            this.packingCheckBox.Checked = true;
            this.packingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.packingCheckBox.Enabled = false;
            this.packingCheckBox.Location = new System.Drawing.Point(560, 120);
            this.packingCheckBox.Name = "packingCheckBox";
            this.packingCheckBox.Size = new System.Drawing.Size(95, 17);
            this.packingCheckBox.TabIndex = 27;
            this.packingCheckBox.Text = "Byte Packing?";
            this.packingCheckBox.UseVisualStyleBackColor = true;
            // 
            // rowsUpDown
            // 
            this.rowsUpDown.Location = new System.Drawing.Point(4, 54);
            this.rowsUpDown.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.rowsUpDown.Name = "rowsUpDown";
            this.rowsUpDown.Size = new System.Drawing.Size(120, 20);
            this.rowsUpDown.TabIndex = 0;
            this.rowsUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // colsUpDown
            // 
            this.colsUpDown.Location = new System.Drawing.Point(4, 28);
            this.colsUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.colsUpDown.Name = "colsUpDown";
            this.colsUpDown.Size = new System.Drawing.Size(120, 20);
            this.colsUpDown.TabIndex = 1;
            this.colsUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cols (X)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numOfDisplaysUpDown);
            this.panel1.Controls.Add(this.makeGridButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.colsUpDown);
            this.panel1.Controls.Add(this.rowsUpDown);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 168);
            this.panel1.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of Displays";
            // 
            // numOfDisplaysUpDown
            // 
            this.numOfDisplaysUpDown.Location = new System.Drawing.Point(4, 80);
            this.numOfDisplaysUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numOfDisplaysUpDown.Name = "numOfDisplaysUpDown";
            this.numOfDisplaysUpDown.Size = new System.Drawing.Size(120, 20);
            this.numOfDisplaysUpDown.TabIndex = 6;
            this.numOfDisplaysUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // makeGridButton
            // 
            this.makeGridButton.Location = new System.Drawing.Point(4, 125);
            this.makeGridButton.Name = "makeGridButton";
            this.makeGridButton.Size = new System.Drawing.Size(117, 23);
            this.makeGridButton.TabIndex = 5;
            this.makeGridButton.Text = "Create Grid";
            this.makeGridButton.UseVisualStyleBackColor = true;
            this.makeGridButton.Click += new System.EventHandler(this.makeGridButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rows (Y)";
            // 
            // reverseCheckBox
            // 
            this.reverseCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reverseCheckBox.AutoSize = true;
            this.reverseCheckBox.Enabled = false;
            this.reverseCheckBox.Location = new System.Drawing.Point(563, 143);
            this.reverseCheckBox.Name = "reverseCheckBox";
            this.reverseCheckBox.Size = new System.Drawing.Size(92, 17);
            this.reverseCheckBox.TabIndex = 29;
            this.reverseCheckBox.Text = "Reverse Bits?";
            this.reverseCheckBox.UseVisualStyleBackColor = true;
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(560, 434);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(75, 23);
            this.upButton.TabIndex = 30;
            this.upButton.Text = "UP";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(560, 489);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(75, 23);
            this.downButton.TabIndex = 31;
            this.downButton.Text = "DOWN";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // currLineTxtBox
            // 
            this.currLineTxtBox.Location = new System.Drawing.Point(582, 463);
            this.currLineTxtBox.Name = "currLineTxtBox";
            this.currLineTxtBox.ReadOnly = true;
            this.currLineTxtBox.Size = new System.Drawing.Size(53, 20);
            this.currLineTxtBox.TabIndex = 32;
            // 
            // openbutton
            // 
            this.openbutton.Enabled = false;
            this.openbutton.Location = new System.Drawing.Point(533, 314);
            this.openbutton.Name = "openbutton";
            this.openbutton.Size = new System.Drawing.Size(75, 23);
            this.openbutton.TabIndex = 33;
            this.openbutton.Text = "open";
            this.openbutton.UseVisualStyleBackColor = true;
            this.openbutton.Click += new System.EventHandler(this.openbutton_Click);
            // 
            // savebutton
            // 
            this.savebutton.Enabled = false;
            this.savebutton.Location = new System.Drawing.Point(533, 344);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 23);
            this.savebutton.TabIndex = 34;
            this.savebutton.Text = "save";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // frameDelayUpDown
            // 
            this.frameDelayUpDown.Location = new System.Drawing.Point(560, 408);
            this.frameDelayUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.frameDelayUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frameDelayUpDown.Name = "frameDelayUpDown";
            this.frameDelayUpDown.Size = new System.Drawing.Size(95, 20);
            this.frameDelayUpDown.TabIndex = 35;
            this.frameDelayUpDown.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 466);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Frame";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(493, 410);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "frame delay";
            // 
            // removeFrameBtn
            // 
            this.removeFrameBtn.Location = new System.Drawing.Point(563, 539);
            this.removeFrameBtn.Name = "removeFrameBtn";
            this.removeFrameBtn.Size = new System.Drawing.Size(75, 45);
            this.removeFrameBtn.TabIndex = 38;
            this.removeFrameBtn.Text = "remove Frame";
            this.removeFrameBtn.UseVisualStyleBackColor = true;
            this.removeFrameBtn.Click += new System.EventHandler(this.removeFrameBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 596);
            this.Controls.Add(this.removeFrameBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.frameDelayUpDown);
            this.Controls.Add(this.savebutton);
            this.Controls.Add(this.openbutton);
            this.Controls.Add(this.currLineTxtBox);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.reverseCheckBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.packingCheckBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.radioGroupBox);
            this.Controls.Add(this.outLines);
            this.Controls.Add(this.nextbtn);
            this.Controls.Add(this.outTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.radioGroupBox.ResumeLayout(false);
            this.radioGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colsUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOfDisplaysUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameDelayUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox outTextBox;
        private System.Windows.Forms.Button nextbtn;
        private System.Windows.Forms.TextBox outLines;
        private System.Windows.Forms.GroupBox radioGroupBox;
        private System.Windows.Forms.RadioButton hexRadioButton;
        private System.Windows.Forms.RadioButton binaryRadioButton;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private Button clearButton;
        private CheckBox packingCheckBox;
        private Panel panel1;
        private Button makeGridButton;
        private Label label2;
        private Label label1;
        private NumericUpDown colsUpDown;
        private NumericUpDown rowsUpDown;
        private CheckBox reverseCheckBox;
        private NumericUpDown numOfDisplaysUpDown;
        private Label label3;
        private Button downButton;
        private Button upButton;
        private TextBox currLineTxtBox;
        private Button savebutton;
        private Button openbutton;
        private Label label5;
        private Label label4;
        private NumericUpDown frameDelayUpDown;
        private Button removeFrameBtn;
    }
}

