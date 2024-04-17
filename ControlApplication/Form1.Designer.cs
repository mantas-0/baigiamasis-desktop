namespace ControlApplication
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
            this.connectButton = new System.Windows.Forms.Button();
            this.staticStatusLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.comPortDropdown = new System.Windows.Forms.ComboBox();
            this.baudDropdown = new System.Windows.Forms.ComboBox();
            this.serialOutput = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stepButton = new System.Windows.Forms.Button();
            this.voltageProbeDropdown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.motorStartPositionInput = new System.Windows.Forms.NumericUpDown();
            this.motorStepLengthInput = new System.Windows.Forms.NumericUpDown();
            this.motorPositionStaticLabel = new System.Windows.Forms.Label();
            this.motorPositionLabel = new System.Windows.Forms.Label();
            this.stepStatusLabel = new System.Windows.Forms.Label();
            this.stepStatusStaticLabel = new System.Windows.Forms.Label();
            this.commandInput = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.executeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.motorStartPositionInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motorStepLengthInput)).BeginInit();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(289, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // staticStatusLabel
            // 
            this.staticStatusLabel.AutoSize = true;
            this.staticStatusLabel.Location = new System.Drawing.Point(370, 17);
            this.staticStatusLabel.Name = "staticStatusLabel";
            this.staticStatusLabel.Size = new System.Drawing.Size(40, 13);
            this.staticStatusLabel.TabIndex = 1;
            this.staticStatusLabel.Text = "Status:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(416, 17);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(10, 13);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "-";
            // 
            // comPortDropdown
            // 
            this.comPortDropdown.FormattingEnabled = true;
            this.comPortDropdown.Location = new System.Drawing.Point(12, 14);
            this.comPortDropdown.Name = "comPortDropdown";
            this.comPortDropdown.Size = new System.Drawing.Size(144, 21);
            this.comPortDropdown.TabIndex = 3;
            this.comPortDropdown.Text = "Select COM port";
            // 
            // baudDropdown
            // 
            this.baudDropdown.FormattingEnabled = true;
            this.baudDropdown.Location = new System.Drawing.Point(162, 14);
            this.baudDropdown.Name = "baudDropdown";
            this.baudDropdown.Size = new System.Drawing.Size(121, 21);
            this.baudDropdown.TabIndex = 4;
            this.baudDropdown.Text = "Select baud";
            // 
            // serialOutput
            // 
            this.serialOutput.Location = new System.Drawing.Point(12, 219);
            this.serialOutput.Name = "serialOutput";
            this.serialOutput.ReadOnly = true;
            this.serialOutput.Size = new System.Drawing.Size(776, 395);
            this.serialOutput.TabIndex = 5;
            this.serialOutput.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Motor step length, mm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Voltage probe:";
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(289, 72);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(75, 23);
            this.stepButton.TabIndex = 13;
            this.stepButton.Text = "Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // voltageProbeDropdown
            // 
            this.voltageProbeDropdown.FormattingEnabled = true;
            this.voltageProbeDropdown.Location = new System.Drawing.Point(162, 72);
            this.voltageProbeDropdown.Name = "voltageProbeDropdown";
            this.voltageProbeDropdown.Size = new System.Drawing.Size(121, 21);
            this.voltageProbeDropdown.TabIndex = 14;
            this.voltageProbeDropdown.Text = "Select voltage probe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Motor starting position, mm:";
            // 
            // motorStartPositionInput
            // 
            this.motorStartPositionInput.DecimalPlaces = 3;
            this.motorStartPositionInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.motorStartPositionInput.Location = new System.Drawing.Point(12, 111);
            this.motorStartPositionInput.Name = "motorStartPositionInput";
            this.motorStartPositionInput.Size = new System.Drawing.Size(144, 20);
            this.motorStartPositionInput.TabIndex = 17;
            this.motorStartPositionInput.ValueChanged += new System.EventHandler(this.motorStartPositionInput_ValueChanged);
            // 
            // motorStepLengthInput
            // 
            this.motorStepLengthInput.DecimalPlaces = 3;
            this.motorStepLengthInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.motorStepLengthInput.Location = new System.Drawing.Point(12, 72);
            this.motorStepLengthInput.Name = "motorStepLengthInput";
            this.motorStepLengthInput.Size = new System.Drawing.Size(144, 20);
            this.motorStepLengthInput.TabIndex = 18;
            // 
            // motorPositionStaticLabel
            // 
            this.motorPositionStaticLabel.AutoSize = true;
            this.motorPositionStaticLabel.Location = new System.Drawing.Point(12, 136);
            this.motorPositionStaticLabel.Name = "motorPositionStaticLabel";
            this.motorPositionStaticLabel.Size = new System.Drawing.Size(114, 13);
            this.motorPositionStaticLabel.TabIndex = 19;
            this.motorPositionStaticLabel.Text = "Current Motor Position:";
            // 
            // motorPositionLabel
            // 
            this.motorPositionLabel.AutoSize = true;
            this.motorPositionLabel.Location = new System.Drawing.Point(12, 149);
            this.motorPositionLabel.Name = "motorPositionLabel";
            this.motorPositionLabel.Size = new System.Drawing.Size(53, 13);
            this.motorPositionLabel.TabIndex = 20;
            this.motorPositionLabel.Text = "0.000 mm";
            // 
            // stepStatusLabel
            // 
            this.stepStatusLabel.AutoSize = true;
            this.stepStatusLabel.Location = new System.Drawing.Point(416, 77);
            this.stepStatusLabel.Name = "stepStatusLabel";
            this.stepStatusLabel.Size = new System.Drawing.Size(10, 13);
            this.stepStatusLabel.TabIndex = 22;
            this.stepStatusLabel.Text = "-";
            // 
            // stepStatusStaticLabel
            // 
            this.stepStatusStaticLabel.AutoSize = true;
            this.stepStatusStaticLabel.Location = new System.Drawing.Point(370, 77);
            this.stepStatusStaticLabel.Name = "stepStatusStaticLabel";
            this.stepStatusStaticLabel.Size = new System.Drawing.Size(40, 13);
            this.stepStatusStaticLabel.TabIndex = 21;
            this.stepStatusStaticLabel.Text = "Status:";
            // 
            // commandInput
            // 
            this.commandInput.Location = new System.Drawing.Point(541, 111);
            this.commandInput.Name = "commandInput";
            this.commandInput.Size = new System.Drawing.Size(247, 20);
            this.commandInput.TabIndex = 23;
            this.commandInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.commandInput_KeyPress);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(713, 14);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 10;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(713, 137);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(75, 23);
            this.executeButton.TabIndex = 24;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 626);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.commandInput);
            this.Controls.Add(this.stepStatusLabel);
            this.Controls.Add(this.stepStatusStaticLabel);
            this.Controls.Add(this.motorPositionLabel);
            this.Controls.Add(this.motorPositionStaticLabel);
            this.Controls.Add(this.motorStepLengthInput);
            this.Controls.Add(this.motorStartPositionInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.voltageProbeDropdown);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serialOutput);
            this.Controls.Add(this.baudDropdown);
            this.Controls.Add(this.comPortDropdown);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.staticStatusLabel);
            this.Controls.Add(this.connectButton);
            this.Name = "Form1";
            this.Text = "Control Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.motorStartPositionInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motorStepLengthInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label staticStatusLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox comPortDropdown;
        private System.Windows.Forms.ComboBox baudDropdown;
        private System.Windows.Forms.RichTextBox serialOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.ComboBox voltageProbeDropdown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown motorStartPositionInput;
        private System.Windows.Forms.NumericUpDown motorStepLengthInput;
        private System.Windows.Forms.Label motorPositionStaticLabel;
        private System.Windows.Forms.Label motorPositionLabel;
        private System.Windows.Forms.Label stepStatusLabel;
        private System.Windows.Forms.Label stepStatusStaticLabel;
        private System.Windows.Forms.TextBox commandInput;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button executeButton;
    }
}

