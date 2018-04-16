namespace NeuralNetwork
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainContainer = new System.Windows.Forms.TableLayoutPanel();
            this.numberPanel = new System.Windows.Forms.Panel();
            this.prevGuessLabel = new System.Windows.Forms.Label();
            this.correctLabel = new System.Windows.Forms.Label();
            this.drawPanelLabel = new System.Windows.Forms.Label();
            this.numToDrawLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.submitButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.drawPanel = new NeuralNetwork.GUI.DrawPanel();
            this.menuStrip1.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.numberPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1144, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadNetMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 38);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadNetMenuItem
            // 
            this.loadNetMenuItem.Name = "loadNetMenuItem";
            this.loadNetMenuItem.Size = new System.Drawing.Size(317, 38);
            this.loadNetMenuItem.Text = "Load Net From File";
            this.loadNetMenuItem.Click += new System.EventHandler(this.loadNetMenuItem_Click);
            // 
            // mainContainer
            // 
            this.mainContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.mainContainer.ColumnCount = 2;
            this.mainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainContainer.Controls.Add(this.numberPanel, 1, 0);
            this.mainContainer.Controls.Add(this.panel2, 0, 0);
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 42);
            this.mainContainer.Margin = new System.Windows.Forms.Padding(4);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.RowCount = 1;
            this.mainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 774F));
            this.mainContainer.Size = new System.Drawing.Size(1144, 773);
            this.mainContainer.TabIndex = 2;
            // 
            // numberPanel
            // 
            this.numberPanel.BackColor = System.Drawing.SystemColors.Control;
            this.numberPanel.Controls.Add(this.prevGuessLabel);
            this.numberPanel.Controls.Add(this.correctLabel);
            this.numberPanel.Controls.Add(this.drawPanelLabel);
            this.numberPanel.Controls.Add(this.numToDrawLabel);
            this.numberPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberPanel.Location = new System.Drawing.Point(576, 5);
            this.numberPanel.Margin = new System.Windows.Forms.Padding(4);
            this.numberPanel.Name = "numberPanel";
            this.numberPanel.Size = new System.Drawing.Size(563, 763);
            this.numberPanel.TabIndex = 0;
            // 
            // prevGuessLabel
            // 
            this.prevGuessLabel.AutoSize = true;
            this.prevGuessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevGuessLabel.Location = new System.Drawing.Point(145, 682);
            this.prevGuessLabel.Name = "prevGuessLabel";
            this.prevGuessLabel.Size = new System.Drawing.Size(259, 37);
            this.prevGuessLabel.TabIndex = 3;
            this.prevGuessLabel.Text = "Previous Guess: ";
            // 
            // correctLabel
            // 
            this.correctLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.correctLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correctLabel.Location = new System.Drawing.Point(0, 723);
            this.correctLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.correctLabel.Name = "correctLabel";
            this.correctLabel.Size = new System.Drawing.Size(563, 40);
            this.correctLabel.TabIndex = 2;
            this.correctLabel.Text = "0 of 0 Correct";
            this.correctLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // drawPanelLabel
            // 
            this.drawPanelLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.drawPanelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawPanelLabel.Location = new System.Drawing.Point(0, 0);
            this.drawPanelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.drawPanelLabel.Name = "drawPanelLabel";
            this.drawPanelLabel.Size = new System.Drawing.Size(563, 48);
            this.drawPanelLabel.TabIndex = 1;
            this.drawPanelLabel.Text = "Number to Draw";
            this.drawPanelLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // numToDrawLabel
            // 
            this.numToDrawLabel.BackColor = System.Drawing.SystemColors.Control;
            this.numToDrawLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numToDrawLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 200F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numToDrawLabel.Location = new System.Drawing.Point(0, 0);
            this.numToDrawLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numToDrawLabel.Name = "numToDrawLabel";
            this.numToDrawLabel.Size = new System.Drawing.Size(563, 763);
            this.numToDrawLabel.TabIndex = 0;
            this.numToDrawLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.buttonPanel);
            this.panel2.Controls.Add(this.drawPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(564, 765);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Last Drawn Number";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(328, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(56, 54);
            this.panel1.TabIndex = 2;
            // 
            // buttonPanel
            // 
            this.buttonPanel.ColumnCount = 2;
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonPanel.Controls.Add(this.submitButton, 0, 0);
            this.buttonPanel.Controls.Add(this.clearButton, 1, 0);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 665);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.RowCount = 1;
            this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonPanel.Size = new System.Drawing.Size(564, 100);
            this.buttonPanel.TabIndex = 5;
            // 
            // submitButton
            // 
            this.submitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.submitButton.Location = new System.Drawing.Point(4, 4);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(274, 92);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearButton.Location = new System.Drawing.Point(285, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(276, 94);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // drawPanel
            // 
            this.drawPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawPanel.Location = new System.Drawing.Point(39, 106);
            this.drawPanel.Margin = new System.Windows.Forms.Padding(4);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(476, 476);
            this.drawPanel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1144, 815);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainContainer.ResumeLayout(false);
            this.numberPanel.ResumeLayout(false);
            this.numberPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadNetMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainContainer;
        private System.Windows.Forms.Panel numberPanel;
        private System.Windows.Forms.Label numToDrawLabel;
        private System.Windows.Forms.Label drawPanelLabel;
        private System.Windows.Forms.Label correctLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private GUI.DrawPanel drawPanel;
        private System.Windows.Forms.TableLayoutPanel buttonPanel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label prevGuessLabel;
    }
}

