using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PDFCreator
{
  public partial class Form2 : Form
  {
    private string output = "xml2pdf.pdf";
    public Form2()
    {
      InitializeComponent();
    }

    private void Form2_Load(object sender, EventArgs e)
    {
      this.Width = this.Parent.Width;
      this.Height = this.Parent.Height;
      this.WindowState = FormWindowState.Maximized;

      var file = Path.Combine(Environment.CurrentDirectory, @"Resources\PDFTemplate.xml");
      StreamReader sr = new StreamReader(file, System.Text.Encoding.Default);
      richTextBox1.Text=sr.ReadToEnd();

      txtOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),output );
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //deserialize object  from xml file
      PDFDocument PDFTemplate = new PDFDocument();
      string xmlfile = Path.Combine(Environment.CurrentDirectory, @"Resources\PDFTemplate.xml");
      Type[] extraTypes = new Type[] { typeof(BodyInfo), typeof(PageInfo), typeof(HeaderInfo), typeof(AuthorInfo) };
      XmlSerializer serializer = new XmlSerializer(typeof(PDFDocument), extraTypes);
      StreamReader reader = new StreamReader(xmlfile);
      PDFTemplate = (PDFDocument)serializer.Deserialize(reader);
      reader.Close();

      //add table manually
      DataTable dt = new DataTable();
      dt.Columns.AddRange(new DataColumn[]{
                                                                                new DataColumn("Column1"),
                                                                                new DataColumn("Column2"),
                                                                                new DataColumn("Column3"),
                                                                                new DataColumn("Column4"),
                                                                                new DataColumn("Column5")
                                                                                });

      for (int i = 0; i < 9; i++)
      {
        DataRow dr = dt.NewRow();
        dr["Column1"] = "Lorem ipsum ... ";
        dr["Column2"] = "Lorem ipsum ... ";
        dr["Column3"] = "Lorem ipsum ... ";
        dr["Column4"] = "Lorem ipsum ... ";
        dr["Column5"] = "Lorem ipsum ... ";
        dt.Rows.Add(dr);
        dt.AcceptChanges();
      }

      PDFTemplate.body.table = dt;
      PDFTemplate.page.size = "A4";

      PDFTemplate.outputFile = txtOutput.Text;
      PDFTemplate.Generate();

      //show file
      if (chkShow.Checked)
        System.Diagnostics.Process.Start(PDFTemplate.outputFile);
    }

    private void btOutput_Click(object sender, EventArgs e)
    {
      folderBrowserDialog1.SelectedPath = txtOutput.Text;
      DialogResult res = folderBrowserDialog1.ShowDialog();
      if (res != DialogResult.Cancel)
        txtOutput.Text = Path.Combine(folderBrowserDialog1.SelectedPath, "xml2pdf.pdf");
    }
  }
}
