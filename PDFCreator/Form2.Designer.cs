namespace PDFCreator
{
  partial class Form2
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btOutput = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.txtOutput = new System.Windows.Forms.TextBox();
      this.label17 = new System.Windows.Forms.Label();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.chkShow = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // richTextBox1
      // 
      this.richTextBox1.Location = new System.Drawing.Point(12, 111);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(866, 371);
      this.richTextBox1.TabIndex = 0;
      this.richTextBox1.Text = "";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(855, 51);
      this.label1.TabIndex = 1;
      this.label1.Text = resources.GetString("label1.Text");
      // 
      // btOutput
      // 
      this.btOutput.Location = new System.Drawing.Point(465, 530);
      this.btOutput.Name = "btOutput";
      this.btOutput.Size = new System.Drawing.Size(75, 23);
      this.btOutput.TabIndex = 6;
      this.btOutput.Text = "Browse";
      this.btOutput.UseVisualStyleBackColor = true;
      this.btOutput.Click += new System.EventHandler(this.btOutput_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(743, 513);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(135, 40);
      this.button1.TabIndex = 3;
      this.button1.Text = "Create PDF";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // txtOutput
      // 
      this.txtOutput.Location = new System.Drawing.Point(103, 531);
      this.txtOutput.Name = "txtOutput";
      this.txtOutput.Size = new System.Drawing.Size(356, 22);
      this.txtOutput.TabIndex = 5;
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Location = new System.Drawing.Point(16, 531);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(51, 17);
      this.label17.TabIndex = 4;
      this.label17.Text = "Output";
      // 
      // chkShow
      // 
      this.chkShow.AutoSize = true;
      this.chkShow.Checked = true;
      this.chkShow.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkShow.Location = new System.Drawing.Point(560, 531);
      this.chkShow.Name = "chkShow";
      this.chkShow.Size = new System.Drawing.Size(64, 21);
      this.chkShow.TabIndex = 7;
      this.chkShow.Text = "Show";
      this.chkShow.UseVisualStyleBackColor = true;
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(896, 589);
      this.Controls.Add(this.chkShow);
      this.Controls.Add(this.btOutput);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.txtOutput);
      this.Controls.Add(this.label17);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.richTextBox1);
      this.Name = "Form2";
      this.Text = "XML Template";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.Form2_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btOutput;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox txtOutput;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.CheckBox chkShow;
  }
}