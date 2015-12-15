using System;
using System.Windows.Forms;

namespace PDFCreator
{
  public partial class Main : Form
  {
    public Main()
    {
      InitializeComponent();
    }

    private void fromXMLTemplateToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Form2 newMDIChild = new Form2();
      newMDIChild.MdiParent = this;
      newMDIChild.Show();
    }

    private void usingFormToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Form1 newMDIChild = new Form1();
      newMDIChild.AutoScroll = true;
      newMDIChild.MdiParent = this;
      newMDIChild.Show();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void Main_Load(object sender, EventArgs e)
    {
      //fromXMLTemplateToolStripMenuItem.PerformClick();
      usingFormToolStripMenuItem.PerformClick();
    }
  }
}
