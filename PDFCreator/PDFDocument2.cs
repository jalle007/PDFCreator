using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDFDocument2
{
  [XmlRoot("PDFDocument2")]
  public class PDFDocument2
  {
    [XmlElement("HeaderInfo", typeof(HeaderInfo))]
    public HeaderInfo header { get; set; }
    [XmlElement("PageInfo", typeof(PageInfo))]
    public PageInfo page { get; set; }
    [XmlElement("BodyInfo", typeof(BodyInfo))]
    public BodyInfo body { get; set; }
    [XmlElement("AuthorInfo", typeof(AuthorInfo))]
    public AuthorInfo author { get; set; }

    public PDFDocument2(HeaderInfo header, PageInfo page, BodyInfo body,  AuthorInfo author = null)
    {
      this.header = header;
      this.page = page;
      this.body = body;
      this.author = author;
    }
    public PDFDocument2()
    {
    }
  }

  public class AuthorInfo
  {
    public string author { get; set; }
    public string keywords { get; set; }
    public string subject { get; set; }
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

  public class HeaderInfo
  {
    public string logo { get; set; }
    public string header { get; set; }
    public string date { get; set; }

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

  public class PageInfo
  {
    public  string  size { get; set; }
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
  }

  public class BodyInfo
  {
    public string text1 { get; set; }
    public string text2 { get; set; }
    public string image1 { get; set; }
    public string image2 { get; set; }
    public string table { get; set; }

    public BodyInfo(string text1, string text2, string image1, string image2, string table)
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

  public class TableInfo
  {
    public string text1 { get; set; }
    public string text2 { get; set; }
    public string image1 { get; set; }
    public string image2 { get; set; }
    public DataTable table { get; set; }

    public TableInfo(string text1, string text2, string image1, string image2, DataTable table)
    {
      this.text1 = text1;
      this.text2 = text2;
      this.image1 = image1;
      this.image2 = image2;
      this.table = table;
    }

    public TableInfo()
    {
    }
  }
}
