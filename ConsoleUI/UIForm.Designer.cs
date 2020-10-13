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
            this.create_button = new System.Windows.Forms.Button();
            this.transpose_button = new System.Windows.Forms.Button();
            this.matrix_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.isbiparted_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.graphs_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(405, 154);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(454, 357);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // dialogue_value
            // 
            this.dialogue_value.AutoSize = true;
            this.dialogue_value.Location = new System.Drawing.Point(38, 61);
            this.dialogue_value.Name = "dialogue_value";
            this.dialogue_value.Size = new System.Drawing.Size(0, 17);
            this.dialogue_value.TabIndex = 2;
            // 
            // help_button
            // 
            this.help_button.Location = new System.Drawing.Point(41, 364);
            this.help_button.Name = "help_button";
            this.help_button.Size = new System.Drawing.Size(81, 43);
            this.help_button.TabIndex = 3;
            this.help_button.Text = "help";
            this.help_button.UseVisualStyleBackColor = true;
            this.help_button.Click += new System.EventHandler(this.help_button_Click);
            // 
            // create_button
            // 
            this.create_button.Location = new System.Drawing.Point(41, 300);
            this.create_button.Name = "create_button";
            this.create_button.Size = new System.Drawing.Size(81, 43);
            this.create_button.TabIndex = 4;
            this.create_button.Text = "create";
            this.create_button.UseVisualStyleBackColor = true;
            this.create_button.Click += new System.EventHandler(this.create_button_Click);
            // 
            // transpose_button
            // 
            this.transpose_button.Location = new System.Drawing.Point(41, 424);
            this.transpose_button.Name = "transpose_button";
            this.transpose_button.Size = new System.Drawing.Size(81, 43);
            this.transpose_button.TabIndex = 5;
            this.transpose_button.Text = "transpose";
            this.transpose_button.UseVisualStyleBackColor = true;
            this.transpose_button.Click += new System.EventHandler(this.transpose_button_Click);
            // 
            // matrix_openFileDialog
            // 
            this.matrix_openFileDialog.FileName = "matrix_openFileDialog";
            // 
            // isbiparted_button
            // 
            this.isbiparted_button.Location = new System.Drawing.Point(170, 300);
            this.isbiparted_button.Name = "isbiparted_button";
            this.isbiparted_button.Size = new System.Drawing.Size(99, 43);
            this.isbiparted_button.TabIndex = 7;
            this.isbiparted_button.Text = "IsBiparted";
            this.isbiparted_button.UseVisualStyleBackColor = true;
            this.isbiparted_button.Click += new System.EventHandler(this.isbiparted_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(170, 364);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(99, 43);
            this.delete_button.TabIndex = 8;
            this.delete_button.Text = "delete";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // graphs_ToolStripMenuItem
            // 
            this.graphs_ToolStripMenuItem.Name = "graphs_ToolStripMenuItem";
            this.graphs_ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.graphs_ToolStripMenuItem.Text = "graphs";
            this.graphs_ToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.graphs_ToolStripMenuItem_DropDownItemClicked_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphs_ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 556);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.isbiparted_button);
            this.Controls.Add(this.transpose_button);
            this.Controls.Add(this.create_button);
            this.Controls.Add(this.help_button);
            this.Controls.Add(this.dialogue_value);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
        private System.Windows.Forms.Button create_button;
        private System.Windows.Forms.Button transpose_button;
        private System.Windows.Forms.OpenFileDialog matrix_openFileDialog;
        private System.Windows.Forms.Button isbiparted_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.ToolStripMenuItem graphs_ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}