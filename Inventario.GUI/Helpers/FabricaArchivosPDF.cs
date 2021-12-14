
using Inventario.GUI.Models.Parametros;
using Inventario.GUI.Models.Producto;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Helpers
{
    public class FabricaArchivosPDF
    {
        //en lugar de modeloCategoriaGUI va modeloProductoGUI
        public bool CrearListadoDeProductosEnPDF(string pdfpath, string titulo, IEnumerable<ModeloProductoGUI> listaDatos)
        {
            try
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath, FileMode.Create));
                doc.Open();
                doc.Add(new Paragraph(new Phrase(titulo)));
                doc.Add(new Paragraph(new Phrase("")));
                doc.AddAuthor("Pepito Pérez");
                doc.AddCreationDate();
                doc.AddLanguage("ES");

                PdfPTable tabla = new PdfPTable(2);
                float anchoColumna = (PageSize.A4.Width - (doc.LeftMargin + doc.RightMargin)) / 2;
                foreach (var registro in listaDatos)
                {
                    PdfPCell celda = new PdfPCell(new Paragraph(new Phrase(registro.Id)));
                    tabla.AddCell(celda);
                    celda = new PdfPCell(new Paragraph(new Phrase(registro.Nombre)));
                    tabla.AddCell(celda);
                }
                doc.Add(tabla);
                doc.Close();
                writer.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}