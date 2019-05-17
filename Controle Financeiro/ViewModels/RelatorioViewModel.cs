using Controle_Financeiro.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle_Financeiro.ViewModels
{
    public class RelatorioViewModel
    {
        public bool GerarRelatorio(int Mes, string mesExtenso, string Ano, string RelatorioTitulo, int colunas)
        {
            Document document = new Document(PageSize.A4);
            try
            {
                document.SetMargins(3, 2, 3, 2);

                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string receitasFolder = Path.Combine(desktop, RelatorioTitulo, Ano);
                if (!Directory.Exists(receitasFolder))
                {
                    Directory.CreateDirectory(receitasFolder);
                }
                string FilePath = Path.Combine(receitasFolder, mesExtenso + ".pdf");
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FilePath, FileMode.Create));

                document.Open();

                BaseColor preto = new BaseColor(0, 0, 0);

                PdfPTable table = new PdfPTable(colunas);
                table.DefaultCell.Border = PdfPCell.BOTTOM_BORDER;
                table.DefaultCell.BorderColor = preto;
                table.DefaultCell.BorderColorBottom = new BaseColor(255, 255, 255);
                table.DefaultCell.Padding = 10;

                Font fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 14, Font.BOLD, preto);
                Font conteudo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12, Font.NORMAL, preto);
                Font footer = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12, Font.BOLD, preto);
                Font titulo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 16, Font.BOLD, preto);
                var contentByte = writer.DirectContent;

                var image = iTextSharp.text.Image.GetInstance(@"Resources\lovesnacks_logo.jpg");
                image.ScaleToFit(120, 120);
                image.SetAbsolutePosition(50, 670);
                contentByte.AddImage(image);

                var paragraph = new iTextSharp.text.Paragraph("                       " + RelatorioTitulo.ToUpper() + " - " + mesExtenso.ToUpper() + " " + Ano.ToUpper(), titulo);
                paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                var space = new iTextSharp.text.Paragraph(" ", fonte);
                document.Add(space);
                document.Add(space);
                document.Add(space);
                document.Add(space);
                document.Add(paragraph);
                document.Add(space);
                document.Add(space);
                document.Add(space);
                document.Add(space);

                if (RelatorioTitulo.Equals("Receitas"))
                {

                    Paragraph coluna1 = new Paragraph("Nº Fatura", fonte);
                    Paragraph coluna2 = new Paragraph("Data", fonte);
                    Paragraph coluna3 = new Paragraph("Cliente", fonte);
                    Paragraph coluna4 = new Paragraph("Valor", fonte);

                    coluna1.Alignment = Element.ALIGN_CENTER;
                    coluna2.Alignment = Element.ALIGN_CENTER;
                    coluna3.Alignment = Element.ALIGN_CENTER;
                    coluna4.Alignment = Element.ALIGN_CENTER;

                    var cell1 = new PdfPCell();
                    var cell2 = new PdfPCell();
                    var cell3 = new PdfPCell();
                    var cell4 = new PdfPCell();

                    cell1.AddElement(coluna1);
                    cell2.AddElement(coluna2);
                    cell3.AddElement(coluna3);
                    cell4.AddElement(coluna4);

                    table.AddCell(cell1);
                    table.AddCell(cell2);
                    table.AddCell(cell3);
                    table.AddCell(cell4);

                    NovaReceitaModel nrmodel = new NovaReceitaModel();
                    List<NovaReceitaModel> nrList = new List<NovaReceitaModel>();
                    nrList = nrmodel.GetMonth(Mes, Ano).ToList();

                    PdfPCell cell;

                    string ValorSemCifrao = "";
                    double SomaValor = 0;
                    int i = 0;

                    foreach (var l in nrList)
                    {
                        Phrase NumFatura = new Phrase(l.NumFatura.ToString().PadLeft(6, '0'), conteudo);
                        cell = new PdfPCell(NumFatura);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cell);

                        Phrase Data = new Phrase(l.Data.ToShortDateString(), conteudo);
                        cell = new PdfPCell(Data);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cell);

                        Phrase Cliente = new Phrase(l.Cliente, conteudo);
                        cell = new PdfPCell(Cliente);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cell);

                        Phrase Valor = new Phrase(l.Valor, conteudo);
                        cell = new PdfPCell(Valor);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cell);

                        ValorSemCifrao = l.Valor.Substring(1, l.Valor.Length - 1);
                        ValorSemCifrao = ValorSemCifrao.Replace(".", "/");
                        ValorSemCifrao = ValorSemCifrao.Replace(",", "*");
                        ValorSemCifrao = ValorSemCifrao.Replace("/", ",");
                        ValorSemCifrao = ValorSemCifrao.Replace("*", ".");

                        SomaValor += Convert.ToDouble(ValorSemCifrao);
                        i++;

                        if (i == nrList.Count)
                        {
                            Phrase w = new Phrase("-------------", footer);
                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            Phrase Total = new Phrase("Total", footer);
                            cell = new PdfPCell(Total);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            Phrase ValorTotal = new Phrase(SomaValor.ToString("C", CultureInfo.CreateSpecificCulture("en-US")), footer);
                            cell = new PdfPCell(ValorTotal);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                            table.AddCell(cell);
                        }
                    }
                }
                else
                {
                    Paragraph coluna1 = new Paragraph("Nº Fatura", fonte);
                    Paragraph coluna2 = new Paragraph("Data", fonte);
                    Paragraph coluna3 = new Paragraph("Fornecedor", fonte);
                    Paragraph coluna4 = new Paragraph("Descrição", fonte);
                    Paragraph coluna5 = new Paragraph("Centro de Custo", fonte);
                    Paragraph coluna6 = new Paragraph("Valor", fonte);

                    coluna1.Alignment = Element.ALIGN_CENTER;
                    coluna2.Alignment = Element.ALIGN_CENTER;
                    coluna3.Alignment = Element.ALIGN_CENTER;
                    coluna4.Alignment = Element.ALIGN_CENTER;
                    coluna5.Alignment = Element.ALIGN_CENTER;
                    coluna6.Alignment = Element.ALIGN_CENTER;

                    var cell1 = new PdfPCell();
                    var cell2 = new PdfPCell();
                    var cell3 = new PdfPCell();
                    var cell4 = new PdfPCell();
                    var cell5 = new PdfPCell();
                    var cell6 = new PdfPCell();

                    cell1.AddElement(coluna1);
                    cell2.AddElement(coluna2);
                    cell3.AddElement(coluna3);
                    cell4.AddElement(coluna4);
                    cell5.AddElement(coluna5);
                    cell6.AddElement(coluna6);

                    table.AddCell(cell1);
                    table.AddCell(cell2);
                    table.AddCell(cell3);
                    table.AddCell(cell4);
                    table.AddCell(cell5);
                    table.AddCell(cell6);

                    NovaDespesaModel ndmodel = new NovaDespesaModel();
                    List<NovaDespesaModel> nrList = new List<NovaDespesaModel>();
                    nrList = ndmodel.GetMonth(Mes, Ano).ToList();

                    PdfPCell cell;

                    string ValorSemCifrao = "";
                    double SomaValor = 0;
                    int i = 0;

                    foreach (var l in nrList)
                    {
                        Phrase NumFatura = new Phrase(l.NumFatura.ToString().PadLeft(6, '0'), conteudo);
                        cell = new PdfPCell(NumFatura);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cell);

                        Phrase Data = new Phrase(l.Data.ToShortDateString(), conteudo);
                        cell = new PdfPCell(Data);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cell);

                        Phrase Fornecedor = new Phrase(l.Fornecedor, conteudo);
                        cell = new PdfPCell(Fornecedor);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cell);

                        Phrase Descricao = new Phrase(l.Descricao, conteudo);
                        cell = new PdfPCell(Descricao);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cell);

                        Phrase CentroCusto = new Phrase(l.CentroCusto, conteudo);
                        cell = new PdfPCell(CentroCusto);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cell);

                        Phrase Valor = new Phrase(l.Valor, conteudo);
                        cell = new PdfPCell(Valor);
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cell);

                        ValorSemCifrao = l.Valor.Substring(1, l.Valor.Length - 1);
                        ValorSemCifrao = ValorSemCifrao.Replace(".", "/");
                        ValorSemCifrao = ValorSemCifrao.Replace(",", "*");
                        ValorSemCifrao = ValorSemCifrao.Replace("/", ",");
                        ValorSemCifrao = ValorSemCifrao.Replace("*", ".");

                        SomaValor += Convert.ToDouble(ValorSemCifrao);
                        i++;

                        if (i == nrList.Count)
                        {
                            Phrase w = new Phrase("-------------", footer);
                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            Phrase Total = new Phrase("Total", footer);
                            cell = new PdfPCell(Total);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            cell = new PdfPCell(w);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            table.AddCell(cell);

                            Phrase ValorTotal = new Phrase(SomaValor.ToString("C", CultureInfo.CreateSpecificCulture("en-US")), footer);
                            cell = new PdfPCell(ValorTotal);
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                            table.AddCell(cell);
                        }
                    }
                }
                if (document.Add(table))
                {
                    System.Diagnostics.Process.Start(FilePath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                document.Close();
            }
        }

        public bool GerarRelatorioGeral(int Mes, string mesExtenso, string Ano, string RelatorioTitulo)
        {
            Document document = new Document(PageSize.A4);
            try
            {
                document.SetMargins(3, 2, 3, 2);

                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string receitasFolder = Path.Combine(desktop, RelatorioTitulo, Ano);
                if (!Directory.Exists(receitasFolder))
                {
                    Directory.CreateDirectory(receitasFolder);
                }
                string FilePath = Path.Combine(receitasFolder, mesExtenso + ".pdf");
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FilePath, FileMode.Create));

                document.Open();

                BaseColor preto = new BaseColor(0, 0, 0);
                BaseColor red = new BaseColor(255, 0, 0);
                BaseColor green = new BaseColor(0, 255, 0);

                Font fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 14, Font.BOLD, preto);
                Font conteudo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 16, Font.NORMAL, preto);
                Font titulo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 16, Font.BOLD, preto);

                Font positivo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 16, Font.BOLD, green);
                Font negativo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 16, Font.BOLD, red);


                var contentByte = writer.DirectContent;

                var image = iTextSharp.text.Image.GetInstance(@"Resources\lovesnacks_logo.jpg");
                image.ScaleToFit(120, 120);
                image.SetAbsolutePosition(50, 670);
                contentByte.AddImage(image);

                var paragraph = new iTextSharp.text.Paragraph("                       " + RelatorioTitulo.ToUpper() + " - " + mesExtenso.ToUpper() + " " + Ano.ToUpper(), titulo);
                paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                var space = new iTextSharp.text.Paragraph(" ", fonte);
                document.Add(space);
                document.Add(space);
                document.Add(space);
                document.Add(space);
                document.Add(paragraph);
                document.Add(space);
                document.Add(space);
                document.Add(space);
                document.Add(space);

                NovaReceitaModel nrmodel = new NovaReceitaModel();
                List<NovaReceitaModel> nrList = new List<NovaReceitaModel>();
                nrList = nrmodel.GetMonth(Mes, Ano).ToList();

                NovaDespesaModel ndmodel = new NovaDespesaModel();
                List<NovaDespesaModel> ndList = new List<NovaDespesaModel>();
                ndList = ndmodel.GetMonth(Mes, Ano).ToList();

                string ValorSemCifrao = "";
                double SomaValorReceita = 0;
                double SomaValorDespesa = 0;
                int i = 0;
                int y = 0;

                foreach (var l in nrList)
                {
                    ValorSemCifrao = l.Valor.Substring(1, l.Valor.Length - 1);
                    ValorSemCifrao = ValorSemCifrao.Replace(".", "/");
                    ValorSemCifrao = ValorSemCifrao.Replace(",", "*");
                    ValorSemCifrao = ValorSemCifrao.Replace("/", ",");
                    ValorSemCifrao = ValorSemCifrao.Replace("*", ".");

                    SomaValorReceita += Convert.ToDouble(ValorSemCifrao);
                    i++;

                    if (i == nrList.Count)
                    {
                        StringBuilder receitas = new StringBuilder();
                        receitas.Append("Total de Receitas para o mês de ");
                        receitas.Append(mesExtenso);
                        receitas.Append(": ");
                        receitas.Append(SomaValorReceita.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        paragraph = new iTextSharp.text.Paragraph(receitas.ToString(), conteudo);
                        paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                        document.Add(paragraph);
                    }
                }
                foreach (var l in ndList)
                {
                    ValorSemCifrao = l.Valor.Substring(1, l.Valor.Length - 1);
                    ValorSemCifrao = ValorSemCifrao.Replace(".", "/");
                    ValorSemCifrao = ValorSemCifrao.Replace(",", "*");
                    ValorSemCifrao = ValorSemCifrao.Replace("/", ",");
                    ValorSemCifrao = ValorSemCifrao.Replace("*", ".");

                    SomaValorDespesa += Convert.ToDouble(ValorSemCifrao);
                    y++;

                    if (y == ndList.Count)
                    {
                        StringBuilder despesas = new StringBuilder();
                        despesas.Append("Total de Despesas para o mês de ");
                        despesas.Append(mesExtenso);
                        despesas.Append(": ");
                        despesas.Append(SomaValorDespesa.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        paragraph = new iTextSharp.text.Paragraph(despesas.ToString(), conteudo);
                        paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                        document.Add(paragraph);
                    }
                }

                double lucro = SomaValorReceita - SomaValorDespesa;

                if(lucro > 0)
                {
                    StringBuilder lucroMsg = new StringBuilder();
                    lucroMsg.Append("Você fechou o mês de ");
                    lucroMsg.Append(mesExtenso.ToUpper());
                    paragraph = new iTextSharp.text.Paragraph(lucroMsg.ToString(), conteudo);
                    paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    document.Add(space);
                    document.Add(space);
                    document.Add(paragraph);

                    string positivoMsg = "POSITIVO";
                    paragraph = new iTextSharp.text.Paragraph(positivoMsg, positivo);
                    paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    document.Add(paragraph);

                    StringBuilder lucroMsg2 = new StringBuilder();
                    lucroMsg2.Append("em ");
                    lucroMsg2.Append(lucro.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                    paragraph = new iTextSharp.text.Paragraph(lucroMsg2.ToString(), conteudo);
                    paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    if (document.Add(paragraph))
                    {
                        System.Diagnostics.Process.Start(FilePath);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    StringBuilder lucroMsg = new StringBuilder();
                    lucroMsg.Append("Você fechou o mês de ");
                    lucroMsg.Append(mesExtenso.ToUpper());
                    paragraph = new iTextSharp.text.Paragraph(lucroMsg.ToString(), conteudo);
                    paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    document.Add(space);
                    document.Add(space);
                    document.Add(paragraph);

                    string negativoMsg = "NEGATIVO";
                    paragraph = new iTextSharp.text.Paragraph(negativoMsg, negativo);
                    paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    document.Add(paragraph);

                    StringBuilder lucroMsg2 = new StringBuilder();
                    lucroMsg2.Append("em ");
                    lucroMsg2.Append(lucro.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                    paragraph = new iTextSharp.text.Paragraph(lucroMsg2.ToString(), conteudo);
                    paragraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    if (document.Add(paragraph))
                    {
                        System.Diagnostics.Process.Start(FilePath);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                document.Close();
            }
        }
    }
}
