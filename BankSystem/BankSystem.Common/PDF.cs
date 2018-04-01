using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Common
{
    public class PDF
    {
        private FileStream fileStream;
        private Document document;
        private PdfWriter pdfWriter;
        private PdfPTable table;

        public PDF(string path) // : this(path, new Document(), PdfWriter.GetInstance())
        {
            this.fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            this.document = new Document();
            this.pdfWriter = PdfWriter.GetInstance(document, fileStream);
            document.Open();
        }

        public void AddParagraph(string content)
        {
            document.Add(new Paragraph(content));
        }

        public void SetDefaultPageSettings()
        {
            Rectangle a4 = PageSize.A4;
            Rectangle a4Landscape = a4.Rotate();
            document.SetPageSize(a4Landscape);
            document.SetMargins(60, 60, 100, 100);
        }
        
        public void CreateTable(int cols, float totalWidth, float spacingBefore, float spacingAfter, string nameOfTable)//float[] widths
        {
            AddParagraph(nameOfTable);
            this.table = new PdfPTable(cols);
            this.table.TotalWidth = totalWidth;
            this.table.LockedWidth = true;
            //this.table.SetWidths(widths);
            this.table.SpacingBefore = spacingBefore;
            this.table.SpacingAfter = spacingAfter;
        }

        public void PopulateRow(IList<string> contents) //array?
        {
            for (int i = 0; i < contents.Count; i++)
            {
                this.table.AddCell(contents[i]);
            }
        }

        public void AddTable()
        {
            this.document.Add(table);
        }

        public void Close()
        {
            this.document.Close();
            this.fileStream.Close();
        }
    }
}
