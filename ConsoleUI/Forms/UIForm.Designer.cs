using System.ComponentModel;

namespace WinFormsUI
{
    partial class UIForm
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dialogue_value = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.graphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.createToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polynomialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(475, 45);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(411, 366);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // dialogue_value
            // 
            this.dialogue_value.AutoSize = true;
            this.dialogue_value.Location = new System.Drawing.Point(28, 50);
            this.dialogue_value.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dialogue_value.Name = "dialogue_value";
            this.dialogue_value.Size = new System.Drawing.Size(0, 13);
            this.dialogue_value.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphsToolStripMenuItem,
            this.polynomialToolStripMenuItem,
            this.logicToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(921, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // graphsToolStripMenuItem
            // 
            this.graphsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.graphsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.createToolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.graphsToolStripMenuItem.Name = "graphsToolStripMenuItem";
            this.graphsToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.graphsToolStripMenuItem.Text = "Graph";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.createToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(33, 45);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(411, 366);
            this.richTextBox2.TabIndex = 9;
            this.richTextBox2.Text = "";
            // 
            // createToolStripMenuItem1
            // 
            this.createToolStripMenuItem1.Name = "createToolStripMenuItem1";
            this.createToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.createToolStripMenuItem1.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // polynomialToolStripMenuItem
            // 
            this.polynomialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem2,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem1,
            this.helpToolStripMenuItem1});
            this.polynomialToolStripMenuItem.Name = "polynomialToolStripMenuItem";
            this.polynomialToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.polynomialToolStripMenuItem.Text = "Polynomial";
            // 
            // createToolStripMenuItem2
            // 
            this.createToolStripMenuItem2.Name = "createToolStripMenuItem2";
            this.createToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.createToolStripMenuItem2.Text = "Create";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // logicToolStripMenuItem
            // 
            this.logicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem3});
            this.logicToolStripMenuItem.Name = "logicToolStripMenuItem";
            this.logicToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.logicToolStripMenuItem.Text = "Logic";
            // 
            // createToolStripMenuItem3
            // 
            this.createToolStripMenuItem3.Name = "createToolStripMenuItem3";
            this.createToolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.createToolStripMenuItem3.Text = "Create";
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 452);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.dialogue_value);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UIForm";
            this.Text = "TrivialComputerMath";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label dialogue_value;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem graphsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polynomialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem3;
    }
}