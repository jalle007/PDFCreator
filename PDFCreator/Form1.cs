using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDFCreator
{
  public partial class Form1 : Form
  {
    public string output = "output.pdf";

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

      if (this.Height > this.Parent.Height)
        this.Parent.Height = this.Height;
      this.Width = this.Parent.Width;
      this.Height = this.Parent.Height;
      this.WindowState = FormWindowState.Maximized;
      
      FillCombo();
      FillTable();

      txtLogo.Text= Path.Combine(Environment.CurrentDirectory, @"Resources\logo.png");
      txtImg1.Text= Path.Combine(Environment.CurrentDirectory, @"Resources\globe.png");
      txtImg2.Text = Path.Combine(Environment.CurrentDirectory, @"Resources\tree.png");
      txtOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), output);
    }

    private void FillCombo()
    {
//Build a list
      var dataSource = new List<PageSizes>();
      for (int a = 0; a < 10; a++)
        dataSource.Add(new PageSizes() {Name = "A" + a, Value = "A" + a});
      for (int b = 0; b < 10; b++)
        dataSource.Add(new PageSizes() {Name = "B" + b, Value = "B" + b});
      this.cb1.DataSource = dataSource;
      this.cb1.DisplayMember = "Name";
      this.cb1.ValueMember = "Value";
      // make it readonly
      cb1.SelectedIndex = 4;
      cb2.SelectedIndex = 0;
    }

    DataTable dt = new DataTable();
    private void FillTable()
    {
      dt.Columns.AddRange(new DataColumn[]
                                                                                {
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
      dataGridView1.DataSource = dt;

      foreach (DataGridViewColumn c in dataGridView1.Columns)
      {
        c.Width = 155;
      }


      dataGridView1.AllowUserToAddRows = false;
      dataGridView1.AllowUserToDeleteRows = false;

    }

    private void button1_Click(object sender, EventArgs e)
    {
     
      BodyInfo body = new BodyInfo
      {
        text1 =textBox1.Text,
        text2 =textBox2.Text,
        image1 = txtImg1.Text,
        image2 =txtImg2.Text,
        table = dt
      };
      HeaderInfo header = new HeaderInfo
      {
        header = txt1.Text,
        logo = txtLogo.Text,
        date = DateTime.Now.ToShortDateString()
      };

      PageInfo page = new PageInfo
      {
        size = cb1.SelectedValue.ToString(),
        marginLeft = float.Parse(mL.Text),
        marginRight = float.Parse(mR.Text),
        marginTop = float.Parse(mT.Text),
        marginBottom = float.Parse(mB.Text),
      };
      AuthorInfo author = new AuthorInfo(txtAuthor.Text,txtKeywords.Text,txtSubject.Text,txtTitle.Text);

      //prepeare doc
      PDFDocument newPDF = new PDFDocument(header, page,body,txtOutput.Text,author);
      //generate PDF
      newPDF.Generate();

      //show file
      if(chkShow.Checked)
       System.Diagnostics.Process.Start(newPDF.outputFile);
    }

    private void btLogo_Click(object sender, EventArgs e)
    {
      openFileDialog1.InitialDirectory = Path.Combine(Environment.CurrentDirectory, @"Resources\");
   DialogResult res=   openFileDialog1.ShowDialog();
      if (res!=DialogResult.Cancel)
      txtLogo.Text = openFileDialog1.FileName;
    }

    private void btImg1_Click(object sender, EventArgs e)
    {
      openFileDialog1.InitialDirectory = Path.Combine(Environment.CurrentDirectory, @"Resources\");
      DialogResult res = openFileDialog1.ShowDialog();
      if (res != DialogResult.Cancel)
        txtImg1.Text = openFileDialog1.FileName;
    }

    private void btImg2_Click(object sender, EventArgs e)
    {openFileDialog1.InitialDirectory= Path.Combine(Environment.CurrentDirectory, @"Resources\" );
      DialogResult res = openFileDialog1.ShowDialog();
      if (res != DialogResult.Cancel)
        txtImg2.Text = openFileDialog1.FileName;
    }

    private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {

    }

    private void btOutput_Click(object sender, EventArgs e)
    {
      folderBrowserDialog1.SelectedPath = txtOutput.Text;
      DialogResult res = folderBrowserDialog1.ShowDialog();
      if(res!=DialogResult.Cancel)
      txtOutput.Text =Path.Combine( folderBrowserDialog1.SelectedPath, output);
    }
  }
  public class PageSizes
  {
    public string Name { get; set; }
    public string Value { get; set; }
  }
}
