using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDFCreator
{
  [XmlRoot("PDFDocument")]
  public class PDFDocument
  {
    [XmlElement("HeaderInfo", typeof(HeaderInfo))]
    public HeaderInfo header  { get; set; }
    [XmlElement("PageInfo", typeof(PageInfo))]
    public PageInfo page { get; set; }
    [XmlElement("BodyInfo", typeof(BodyInfo))]
    public BodyInfo body { get; set; }
    [XmlElement("AuthorInfo", typeof(AuthorInfo))]
    public AuthorInfo author { get; set; }
    [XmlIgnore()]
    public string outputFile { get; set; }

    public PDFDocument(  HeaderInfo header, PageInfo page, BodyInfo body,   string outputFile, AuthorInfo author = null)
    {
      this.header = header;
      this.page = page;
      this.body = body;
      this.author = author;
      this.outputFile = outputFile;
    }
    public PDFDocument()
    {
      var x = 0;
    }

    /*  create Header using PageEvents for its generated on every page
          element sizes are determined as percentage of page size
          that makes possible to use same template for different page sizes
    */
    public bool Generate()
    {
      try
      {
        iTextSharp.text.Rectangle size = iTextSharp.text.PageSize.GetRectangle(page.size);
        var doc = new Document(size, page.marginLeft, page.marginRight, page.marginTop, page.marginBottom);

        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(outputFile, FileMode.Create));
        writer.PageEvent = new ITextEvents() { header = header, page = page };

        if (author != null)
        {
          // Add meta information to the document
          doc.AddAuthor(author.author);
          doc.AddKeywords(author.keywords);
          doc.AddSubject(author.subject);
          doc.AddTitle(author.title);
        }
        //Helvetica translates more or less to  Arial  font

        BaseFont bf2 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        iTextSharp.text.Font aragraphF = new iTextSharp.text.Font(bf2, 12, iTextSharp.text.Font.NORMAL);
        BaseFont bf3 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        iTextSharp.text.Font tableF = new iTextSharp.text.Font(bf3, 8, iTextSharp.text.Font.NORMAL);

        PdfPTable table2 = new PdfPTable(4);
        //table2.DefaultCell.CellEvent = new PDFDocument.CellSpacingEvent(10);
        table2.DefaultCell.Padding = 10;
        table2.TotalWidth = doc.PageSize.Width - doc.LeftMargin - doc.RightMargin; //this centers table
        int border = Rectangle.NO_BORDER;

        //text1
        PdfPCell cell2 = new PdfPCell(new Phrase(body.text1, new Font(Font.FontFamily.HELVETICA, 12)));
        cell2.Border = border;
        cell2.Colspan = 4;
        cell2.Padding = 10;
        cell2.MinimumHeight = doc.PageSize.Height * 12 / 100;
        table2.AddCell(cell2);

        //image1
        Image img = Image.GetInstance(body.image1);
        cell2 = new PdfPCell(img);
        cell2.Border = border;
        cell2.Padding = 10;
        cell2.Colspan = 3;
        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
        cell2.MinimumHeight = doc.PageSize.Height * 22 / 100;
        table2.AddCell(cell2);

        //image2
        img = Image.GetInstance(body.image2);
        cell2 = new PdfPCell(img);
        cell2.Border = border;
        cell2.Colspan = 1;
        cell2.PaddingLeft = 4;
        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
        cell2.MinimumHeight = doc.PageSize.Height * 22 / 100;
        table2.AddCell(cell2);

        //table !
        PdfPTable nested = new PdfPTable(5);
        nested.DefaultCell.Padding = 2;
        nested.TotalWidth = doc.PageSize.Width - doc.LeftMargin - doc.RightMargin;

        for (int r = 0; r < 9; r++)
        {
          DataRow row = body.table.Rows[r];

          for (int c = 0; c < 5; c++)
          {
            var value = row[c].ToString();
            PdfPCell tableCell = new PdfPCell(new Phrase(value, new Font(Font.FontFamily.HELVETICA, 8)));
            tableCell.Border = Rectangle.BOX;
            tableCell.MinimumHeight = (float)(doc.PageSize.Height * 2.5 / 100);
            nested.AddCell(tableCell);
          }
        }

        cell2 = new PdfPCell(nested);
        cell2.Border = Rectangle.NO_BORDER;
        cell2.Colspan = 4;
        cell2.Padding = 10;
        table2.AddCell(cell2);

        //text2
        cell2 = new PdfPCell(new Phrase(body.text2, new Font(Font.FontFamily.HELVETICA, 12)));
        cell2.Border = border;
        cell2.Colspan = 4;
        cell2.Padding = 10;
        cell2.MinimumHeight = doc.PageSize.Height * 24 / 100;
        table2.AddCell(cell2);

        doc.Open();
        float headerHeight = doc.PageSize.Height * 9 / 100;
        table2.WriteSelectedRows(0, -1, doc.LeftMargin, doc.PageSize.Height - doc.TopMargin - headerHeight, writer.DirectContent);
        //doc.Add(table2);
        doc.Close();
        return true;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message.ToString());
        return false;
      }
   
    }

   
}
  [Serializable()]
  public class AuthorInfo
  {
    public string author { get; set; }
    public string keywords { get; set; }
    public string  subject { get; set; }
    public string title { get; set; }

    public AuthorInfo(string author, string keywords, string subject, string title)
    {
      this.author = author;
      this.keywords = keywords;
      this.subject = subject;
      this.title = title;
    }
    public AuthorInfo()
    {
    }
  }
  [Serializable()]
  public class HeaderInfo
  {
    public string  logo  { get; set; }
    public string  header  { get; set; }
    public string  date { get; set; }

    public HeaderInfo(string logo, string header, string date)
    {
      this.logo = logo;
      this.header = header;
      this.date = date;
    }

    public HeaderInfo()
    {
    }

    //public string getImage(string fName)
    //{
    //  return Path.Combine(Environment.CurrentDirectory, @"Resources\"+ fName);
    //}
  }
  [Serializable()]
  public class PageInfo
  {
    [XmlIgnore]
    public  string size { get; set; }
    public float marginLeft { get; set; }
    public float marginRight { get; set; }
    public float marginTop { get; set; }
    public float marginBottom { get; set; }

    public PageInfo(string size, float marginLef, float marginRight, float marginTop, float marginBottom)
    {
      this.size = size;
      this.marginLeft = marginLef;
      this.marginRight = marginRight;
      this.marginTop = marginTop;
      this.marginBottom = marginBottom;
    }
    public PageInfo()
    {
    }
    public PageInfo(SerializationInfo info, StreamingContext ctxt)
    {
      var x = info;

    }
    [OnDeserialized()]
    public void OnDeserialized_Method(StreamingContext context)
    {
      // This code never gets called
      Console.WriteLine("OnDeserialized");
    }
  }
  [Serializable()]
  public class BodyInfo
  {
    public string text1 { get; set; }
    public string text2 { get; set; }
    public string image1 { get; set; }
    public string image2 { get; set; }
    [XmlIgnore]
    public DataTable table { get; set; }

    public BodyInfo(string text1, string text2, string  image1, string image2, DataTable table )
    {
      this.text1 = text1;
      this.text2 = text2;
      this.image1 = image1;
      this.image2 = image2;
      this.table = table;
    }

    public BodyInfo()
    {
    }
  }

   

}
