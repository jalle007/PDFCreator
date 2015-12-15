namespace PDFCreator
{
  partial class Main
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
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.createPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.fromXMLTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.usingFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.createPDFToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(976, 28);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // createPDFToolStripMenuItem
      // 
      this.createPDFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usingFormToolStripMenuItem,
            this.fromXMLTemplateToolStripMenuItem});
      this.createPDFToolStripMenuItem.Name = "createPDFToolStripMenuItem";
      this.createPDFToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
      this.createPDFToolStripMenuItem.Text = "Create PDF";
      // 
      // fromXMLTemplateToolStripMenuItem
      // 
      this.fromXMLTemplateToolStripMenuItem.Name = "fromXMLTemplateToolStripMenuItem";
      this.fromXMLTemplateToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
      this.fromXMLTemplateToolStripMenuItem.Text = "From XML template";
      this.fromXMLTemplateToolStripMenuItem.Click += new System.EventHandler(this.fromXMLTemplateToolStripMenuItem_Click);
      // 
      // usingFormToolStripMenuItem
      // 
      this.usingFormToolStripMenuItem.Name = "usingFormToolStripMenuItem";
      this.usingFormToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
      this.usingFormToolStripMenuItem.Text = "Using form";
      this.usingFormToolStripMenuItem.Click += new System.EventHandler(this.usingFormToolStripMenuItem_Click);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(976, 653);
      this.Controls.Add(this.menuStrip1);
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Main";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Create PDF";
      this.Load += new System.EventHandler(this.Main_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem createPDFToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem fromXMLTemplateToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem usingFormToolStripMenuItem;
  }
}