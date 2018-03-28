﻿namespace NeuralNetwork
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMNISTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mainContainer = new System.Windows.Forms.TableLayoutPanel();
            this.numberPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.correctLabel = new System.Windows.Forms.Label();
            this.drawPanelLabel = new System.Windows.Forms.Label();
            this.numToDrawLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.drawPanel = new NeuralNetwork.GUI.DrawPanel();
            this.clearButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.buttonPanel = new System.Windows.Forms.TableLayoutPanel();
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
            this.menuStrip1.Size = new System.Drawing.Size(1144, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importMNISTToolStripMenuItem,
            this.loadNetMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importMNISTToolStripMenuItem
            // 
            this.importMNISTToolStripMenuItem.Name = "importMNISTToolStripMenuItem";
            this.importMNISTToolStripMenuItem.Size = new System.Drawing.Size(264, 38);
            this.importMNISTToolStripMenuItem.Text = "Import MNIST";
            // 
            // loadNetMenuItem
            // 
            this.loadNetMenuItem.Name = "loadNetMenuItem";
            this.loadNetMenuItem.Size = new System.Drawing.Size(264, 38);
            this.loadNetMenuItem.Text = "Load Net";
            this.loadNetMenuItem.Click += new System.EventHandler(this.loadNetMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
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
            this.mainContainer.Location = new System.Drawing.Point(0, 40);
            this.mainContainer.Margin = new System.Windows.Forms.Padding(4);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.RowCount = 1;
            this.mainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 775F));
            this.mainContainer.Size = new System.Drawing.Size(1144, 775);
            this.mainContainer.TabIndex = 2;
            // 
            // numberPanel
            // 
            this.numberPanel.BackColor = System.Drawing.SystemColors.Control;
            this.numberPanel.Controls.Add(this.panel1);
            this.numberPanel.Controls.Add(this.correctLabel);
            this.numberPanel.Controls.Add(this.drawPanelLabel);
            this.numberPanel.Controls.Add(this.numToDrawLabel);
            this.numberPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberPanel.Location = new System.Drawing.Point(576, 5);
            this.numberPanel.Margin = new System.Windows.Forms.Padding(4);
            this.numberPanel.Name = "numberPanel";
            this.numberPanel.Size = new System.Drawing.Size(563, 765);
            this.numberPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(234, 83);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(56, 54);
            this.panel1.TabIndex = 2;
            // 
            // correctLabel
            // 
            this.correctLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.correctLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correctLabel.Location = new System.Drawing.Point(0, 725);
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
            this.numToDrawLabel.Size = new System.Drawing.Size(563, 765);
            this.numToDrawLabel.TabIndex = 0;
            this.numToDrawLabel.Text = "2";
            this.numToDrawLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonPanel);
            this.panel2.Controls.Add(this.drawPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(564, 767);
            this.panel2.TabIndex = 1;
            // 
            // drawPanel
            // 
            this.drawPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drawPanel.Location = new System.Drawing.Point(39, 106);
            this.drawPanel.Margin = new System.Windows.Forms.Padding(4);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(476, 476);
            this.drawPanel.TabIndex = 2;
            // 
            // clearButton
            // 
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.Location = new System.Drawing.Point(285, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(276, 94);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.submitButton.Location = new System.Drawing.Point(4, 4);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(274, 92);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // buttonPanel
            // 
            this.buttonPanel.ColumnCount = 2;
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonPanel.Controls.Add(this.submitButton, 0, 0);
            this.buttonPanel.Controls.Add(this.clearButton, 1, 0);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 667);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.RowCount = 1;
            this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonPanel.Size = new System.Drawing.Size(564, 100);
            this.buttonPanel.TabIndex = 5;
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
            this.panel2.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMNISTToolStripMenuItem;
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
    }
}

