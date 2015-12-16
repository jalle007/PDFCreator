using System;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDFCreator
{
  public class ITextEvents : PdfPageEventHelper
  {

    public HeaderInfo header { get; set; }
    public PageInfo page { get; set; }

    public override void OnEndPage(PdfWriter writer, Document doc)
    {
      try
      {
        PdfPTable table2 = new PdfPTable(3) {TotalWidth = doc.PageSize.Width - doc.LeftMargin - doc.RightMargin};
        //this centers [table]

        //logo
        PdfPCell cell2 = new PdfPCell(Image.GetInstance(header.logo)) {Border = Rectangle.NO_BORDER};
        table2.AddCell(cell2);

        //title
        cell2 = new PdfPCell(new Phrase(header.header, new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD)));
        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
        cell2.Border = Rectangle.NO_BORDER;
        table2.AddCell(cell2);

        //date
        cell2 = new PdfPCell(new Phrase(header.date, new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD)));
        cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
        cell2.Border = Rectangle.NO_BORDER;
        table2.AddCell(cell2);

        table2.WriteSelectedRows(0, -1, doc.LeftMargin, doc.PageSize.Height - page.marginTop, writer.DirectContent);
      }
      catch (Exception)
      {
        MessageBox.Show("Something went wrong with header. Pease try again.");
       
      }
    
    }
  }
  
}
