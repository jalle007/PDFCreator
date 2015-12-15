using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Image = System.Drawing.Image;

namespace PDFCreator
{

  public class itextEvents2 :  iTextSharp.text.pdf.IPdfPageEvent
  {

    //Create object of PdfContentByte
    PdfContentByte pdfContent;

    public void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
    {
      //We are going to add two strings in header. Create separate Phrase object with font setting and string to be included
      Phrase p1Header = new Phrase("BlueLemonCode generated page", FontFactory.GetFont("verdana", 8));
      Phrase p2Header = new Phrase("confidential", FontFactory.GetFont("verdana", 8));
      //create iTextSharp.text Image object using local image path
      iTextSharp.text.Image imgPDF = null;

      //Create PdfTable object
      PdfPTable pdfTab = new PdfPTable(3);
      //We will have to create separate cells to include image logo and 2 separate strings
      PdfPCell pdfCell1 = new PdfPCell(imgPDF);
      PdfPCell pdfCell2 = new PdfPCell(p1Header);
      PdfPCell pdfCell3 = new PdfPCell(p2Header);
      //set the alignment of all three cells and set border to 0
      pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
      pdfCell2.HorizontalAlignment = Element.ALIGN_LEFT;
      pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT;
      pdfCell1.Border = 0;
      pdfCell2.Border = 0;
      pdfCell3.Border = 0;
      //add all three cells into PdfTable
      pdfTab.AddCell(pdfCell1);
      pdfTab.AddCell(pdfCell2);
      pdfTab.AddCell(pdfCell3);
      pdfTab.TotalWidth = document.PageSize.Width - 20;
      //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
      //first param is start row. -1 indicates there is no end row and all the rows to be included to write
      //Third and fourth param is x and y position to start writing
      pdfTab.WriteSelectedRows(0, -1, 10, document.PageSize.Height - 15, writer.DirectContent);
      //set pdfContent value
      pdfContent = writer.DirectContent;
      //Move the pointer and draw line to separate header section from rest of page
      pdfContent.MoveTo(30, document.PageSize.Height - 35);
      pdfContent.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 35);
      pdfContent.Stroke();
    }
  }

  interface IPdfPageEvent
  {
    void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document);
  }

}
