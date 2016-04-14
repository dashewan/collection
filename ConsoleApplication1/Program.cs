using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Microsoft.Reporting.WebForms.ReportViewer rv = new Microsoft.Reporting.WebForms.ReportViewer();
            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.ReportPath = (@"\ReportTemplate\TmsOrderExportByTn.rdlc");
            ReportDataSource rds = new ReportDataSource("DsTmsOrder", "");
            rv.LocalReport.DataSources.Add(rds);
            rv.LocalReport.Refresh();
            byte[] streamBytes = null;
            string mimeType = "";
            string encoding = "";
            string filenameExtension = "";
            string[] streamids = null;
            Warning[] warnings = null;
            //rv.LocalReport.ListRenderingExtensions()
            streamBytes = rv.LocalReport.Render("Excel", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

        }
    }
}
