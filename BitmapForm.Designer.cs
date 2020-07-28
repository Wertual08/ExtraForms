namespace ExtraForms
{
    partial class BitmapForm
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
            this.ExportButton = new System.Windows.Forms.Button();
            this.PropertiesTextBox = new System.Windows.Forms.TextBox();
            this.ImportButton = new System.Windows.Forms.Button();
            this.PreviewPanel = new System.Windows.Forms.Panel();
            this.ExportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ImportFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.ControlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExportButton.Location = new System.Drawing.Point(54, 3);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(45, 20);
            this.ExportButton.TabIndex = 7;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // PropertiesTextBox
            // 
            this.PropertiesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertiesTextBox.Location = new System.Drawing.Point(105, 3);
            this.PropertiesTextBox.Name = "PropertiesTextBox";
            this.PropertiesTextBox.ReadOnly = true;
            this.PropertiesTextBox.Size = new System.Drawing.Size(476, 20);
            this.PropertiesTextBox.TabIndex = 6;
            // 
            // ImportButton
            // 
            this.ImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ImportButton.Location = new System.Drawing.Point(3, 3);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(45, 20);
            this.ImportButton.TabIndex = 5;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // PreviewPanel
            // 
            this.PreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewPanel.Location = new System.Drawing.Point(0, 0);
            this.PreviewPanel.Name = "PreviewPanel";
            this.PreviewPanel.Size = new System.Drawing.Size(584, 435);
            this.PreviewPanel.TabIndex = 4;
            this.PreviewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PreviewPanel_Paint);
            this.PreviewPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PreviewPanel_MouseDown);
            this.PreviewPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PreviewPanel_MouseMove);
            this.PreviewPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PreviewPanel_MouseUp);
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Controls.Add(this.ImportButton);
            this.ControlsPanel.Controls.Add(this.PropertiesTextBox);
            this.ControlsPanel.Controls.Add(this.ExportButton);
            this.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ControlsPanel.Location = new System.Drawing.Point(0, 435);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(584, 26);
            this.ControlsPanel.TabIndex = 8;
            // 
            // BitmapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.PreviewPanel);
            this.Controls.Add(this.ControlsPanel);
            this.Name = "BitmapForm";
            this.Text = "BitmapForm";
            this.Resize += new System.EventHandler(this.TextureForm_Resize);
            this.ControlsPanel.ResumeLayout(false);
            this.ControlsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.TextBox PropertiesTextBox;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Panel PreviewPanel;
        private System.Windows.Forms.SaveFileDialog ExportFileDialog;
        private System.Windows.Forms.OpenFileDialog ImportFileDialog;
        private System.Windows.Forms.Panel ControlsPanel;
    }
}