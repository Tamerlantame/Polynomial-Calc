using System.ComponentModel;

namespace ConsoleUI
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
            this.help_button = new System.Windows.Forms.Button();
            this.transpose_button = new System.Windows.Forms.Button();
            this.isbiparted_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(692, 45);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(472, 366);
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
            // help_button
            // 
            this.help_button.Location = new System.Drawing.Point(31, 296);
            this.help_button.Margin = new System.Windows.Forms.Padding(2);
            this.help_button.Name = "help_button";
            this.help_button.Size = new System.Drawing.Size(61, 35);
            this.help_button.TabIndex = 3;
            this.help_button.Text = "help";
            this.help_button.UseVisualStyleBackColor = true;
            this.help_button.Click += new System.EventHandler(this.help_button_Click);
            // 
            // transpose_button
            // 
            this.transpose_button.Location = new System.Drawing.Point(31, 244);
            this.transpose_button.Margin = new System.Windows.Forms.Padding(2);
            this.transpose_button.Name = "transpose_button";
            this.transpose_button.Size = new System.Drawing.Size(61, 35);
            this.transpose_button.TabIndex = 5;
            this.transpose_button.Text = "transpose";
            this.transpose_button.UseVisualStyleBackColor = true;
            this.transpose_button.Click += new System.EventHandler(this.transpose_button_Click);
            // 
            // isbiparted_button
            // 
            this.isbiparted_button.Location = new System.Drawing.Point(128, 244);
            this.isbiparted_button.Margin = new System.Windows.Forms.Padding(2);
            this.isbiparted_button.Name = "isbiparted_button";
            this.isbiparted_button.Size = new System.Drawing.Size(74, 35);
            this.isbiparted_button.TabIndex = 7;
            this.isbiparted_button.Text = "IsBiparted";
            this.isbiparted_button.UseVisualStyleBackColor = true;
            this.isbiparted_button.Click += new System.EventHandler(this.isbiparted_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(128, 296);
            this.delete_button.Margin = new System.Windows.Forms.Padding(2);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(74, 35);
            this.delete_button.TabIndex = 8;
            this.delete_button.Text = "delete";
            this.delete_button.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.graphsToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1175, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // graphsToolStripMenuItem
            // 
            this.graphsToolStripMenuItem.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.graphsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem});
            this.graphsToolStripMenuItem.Name = "graphsToolStripMenuItem";
            this.graphsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.graphsToolStripMenuItem.Text = "Graphs";
            this.graphsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.graphsToolStripMenuItem_DropDownItemClicked);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.createToolStripMenuItem.ForeColor = System.Drawing.Color.Thistle;
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.createToolStripMenuItem.Text = "create";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.помощьToolStripMenuItem.Text = "Help";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(221, 45);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(411, 366);
            this.richTextBox2.TabIndex = 9;
            this.richTextBox2.Text = "";
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 452);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.isbiparted_button);
            this.Controls.Add(this.transpose_button);
            this.Controls.Add(this.help_button);
            this.Controls.Add(this.dialogue_value);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UIForm";
            this.Text = "CosoleForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label dialogue_value;
        private System.Windows.Forms.Button help_button;
        private System.Windows.Forms.Button transpose_button;
        private System.Windows.Forms.Button isbiparted_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem graphsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}