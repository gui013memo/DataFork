namespace DataFork
{
    partial class SerialDataFork
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
            lastReadingsTextBox = new TextBox();
            lastReadingsLabel = new Label();
            sentToTMSLabel = new Label();
            sentToTMSTextBox = new TextBox();
            sentToSQSLabel = new Label();
            sentToSQSTextBox = new TextBox();
            connectionStateCOM3 = new Label();
            connectionStateCOM10 = new Label();
            connectionStateCOM12 = new Label();
            connectButton = new Button();
            SuspendLayout();
            // 
            // lastReadingsTextBox
            // 
            lastReadingsTextBox.BackColor = Color.White;
            lastReadingsTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lastReadingsTextBox.Location = new Point(12, 49);
            lastReadingsTextBox.Multiline = true;
            lastReadingsTextBox.Name = "lastReadingsTextBox";
            lastReadingsTextBox.ReadOnly = true;
            lastReadingsTextBox.ScrollBars = ScrollBars.Vertical;
            lastReadingsTextBox.Size = new Size(347, 143);
            lastReadingsTextBox.TabIndex = 1;
            lastReadingsTextBox.Text = "VBKABP21110004720S1070TB1B1EK1617111BBBBCCC\r\n[)>\u001e06\u001dVT6MP\u001dP2410007010\u001dT230627L1C1A0026\u001d\u001e\u00040026\r\n";
            // 
            // lastReadingsLabel
            // 
            lastReadingsLabel.AutoSize = true;
            lastReadingsLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lastReadingsLabel.Location = new Point(43, 14);
            lastReadingsLabel.Name = "lastReadingsLabel";
            lastReadingsLabel.Size = new Size(286, 32);
            lastReadingsLabel.TabIndex = 0;
            lastReadingsLabel.Text = "Ultimas leituras - COM3";
            // 
            // sentToTMSLabel
            // 
            sentToTMSLabel.AutoSize = true;
            sentToTMSLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            sentToTMSLabel.Location = new Point(4, 204);
            sentToTMSLabel.Name = "sentToTMSLabel";
            sentToTMSLabel.Size = new Size(355, 25);
            sentToTMSLabel.TabIndex = 3;
            sentToTMSLabel.Text = "Enviado ao TMS - COM10 para COM11";
            // 
            // sentToTMSTextBox
            // 
            sentToTMSTextBox.BackColor = Color.White;
            sentToTMSTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            sentToTMSTextBox.Location = new Point(12, 241);
            sentToTMSTextBox.Multiline = true;
            sentToTMSTextBox.Name = "sentToTMSTextBox";
            sentToTMSTextBox.ReadOnly = true;
            sentToTMSTextBox.ScrollBars = ScrollBars.Vertical;
            sentToTMSTextBox.Size = new Size(347, 143);
            sentToTMSTextBox.TabIndex = 2;
            sentToTMSTextBox.Text = "VBKABP21110004720S1070TB1B1EK1617111BBBBCCC\r\n";
            // 
            // sentToSQSLabel
            // 
            sentToSQSLabel.AutoSize = true;
            sentToSQSLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            sentToSQSLabel.Location = new Point(8, 404);
            sentToSQSLabel.Name = "sentToSQSLabel";
            sentToSQSLabel.Size = new Size(351, 25);
            sentToSQSLabel.TabIndex = 5;
            sentToSQSLabel.Text = "Enviado ao SQS - COM12 para COM13";
            // 
            // sentToSQSTextBox
            // 
            sentToSQSTextBox.BackColor = Color.White;
            sentToSQSTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            sentToSQSTextBox.Location = new Point(12, 432);
            sentToSQSTextBox.Multiline = true;
            sentToSQSTextBox.Name = "sentToSQSTextBox";
            sentToSQSTextBox.ReadOnly = true;
            sentToSQSTextBox.ScrollBars = ScrollBars.Vertical;
            sentToSQSTextBox.Size = new Size(347, 143);
            sentToSQSTextBox.TabIndex = 4;
            sentToSQSTextBox.Text = "[)>\u001e06\u001dVT6MP\u001dP2410007010\u001dT230627L1C1A0026\u001d\u001e\u00040026\r\n";
            // 
            // connectionStateCOM3
            // 
            connectionStateCOM3.AutoSize = true;
            connectionStateCOM3.BackColor = Color.Red;
            connectionStateCOM3.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            connectionStateCOM3.ForeColor = Color.White;
            connectionStateCOM3.Location = new Point(14, 578);
            connectionStateCOM3.Name = "connectionStateCOM3";
            connectionStateCOM3.Size = new Size(99, 37);
            connectionStateCOM3.TabIndex = 6;
            connectionStateCOM3.Text = " COM3";
            // 
            // connectionStateCOM10
            // 
            connectionStateCOM10.AutoSize = true;
            connectionStateCOM10.BackColor = Color.Red;
            connectionStateCOM10.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            connectionStateCOM10.ForeColor = Color.White;
            connectionStateCOM10.Location = new Point(120, 578);
            connectionStateCOM10.Name = "connectionStateCOM10";
            connectionStateCOM10.Size = new Size(114, 37);
            connectionStateCOM10.TabIndex = 7;
            connectionStateCOM10.Text = " COM10";
            // 
            // connectionStateCOM12
            // 
            connectionStateCOM12.AutoSize = true;
            connectionStateCOM12.BackColor = Color.Red;
            connectionStateCOM12.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            connectionStateCOM12.ForeColor = Color.White;
            connectionStateCOM12.Location = new Point(240, 578);
            connectionStateCOM12.Name = "connectionStateCOM12";
            connectionStateCOM12.Size = new Size(114, 37);
            connectionStateCOM12.TabIndex = 8;
            connectionStateCOM12.Text = " COM12";
            // 
            // connectButton
            // 
            connectButton.BackColor = Color.ForestGreen;
            connectButton.FlatStyle = FlatStyle.Flat;
            connectButton.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            connectButton.ForeColor = Color.White;
            connectButton.Location = new Point(12, 618);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(343, 60);
            connectButton.TabIndex = 9;
            connectButton.Text = "CONNECTAR";
            connectButton.UseVisualStyleBackColor = false;
            // 
            // SerialDataFork
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 682);
            Controls.Add(connectButton);
            Controls.Add(connectionStateCOM12);
            Controls.Add(connectionStateCOM10);
            Controls.Add(connectionStateCOM3);
            Controls.Add(sentToSQSLabel);
            Controls.Add(sentToSQSTextBox);
            Controls.Add(sentToTMSLabel);
            Controls.Add(sentToTMSTextBox);
            Controls.Add(lastReadingsLabel);
            Controls.Add(lastReadingsTextBox);
            Name = "SerialDataFork";
            Text = "SerialDataFork";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox lastReadingsTextBox;
        private Label lastReadingsLabel;
        private Label sentToTMSLabel;
        private TextBox sentToTMSTextBox;
        private Label sentToSQSLabel;
        private TextBox sentToSQSTextBox;
        private Label connectionStateCOM3;
        private Label connectionStateCOM10;
        private Label connectionStateCOM12;
        private Button connectButton;
    }
}
