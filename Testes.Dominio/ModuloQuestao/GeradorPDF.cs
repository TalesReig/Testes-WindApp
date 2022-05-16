using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Testes.Dominio.ModuloTeste;

namespace Testes.Dominio.ModuloQuestao
{
    public class GeradorPDF
    {
        public GeradorPDF(string caminho, Teste teste)
        {
            this.caminho = caminho;
            Teste = teste;
        }

        public string caminho { get; set; }

        IDictionary<int, string> Letras = new Dictionary<int, string>();

        public Teste Teste { get; set; }

        public void GerarPdf()
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);

            PdfWriter write = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            CriaCabecalhoImpressao(doc);

            CriaIdentificacaoImpressao(doc);

            int numeroQuestao = 1;

            foreach (Questao item in Teste.questaos)
            {
                CriaQuestao(doc, numeroQuestao, item);

                numeroQuestao++;
            }

            doc.Close();


        }

        private void CriaQuestao(Document doc, int numeroQuestao, Questao item)
        {
            Paragraph paragrafo = new Paragraph();

            string questao = numeroQuestao.ToString() + "- " + item.enunciado + "\n";
            
            questao += "  a) " + item.a + "\n";
            questao += "  b) " + item.b + "\n";
            questao += "  c) " + item.c + "\n";
            questao += "  d) " + item.d + "\n";

            questao += "\n";

            paragrafo.Add(questao);

            doc.Add(paragrafo);
        }

        private void CriaCabecalhoImpressao(Document doc)
        {
            Paragraph titulo = new Paragraph();
            titulo.Font = new Font(Font.FontFamily.COURIER, 32);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add(Teste.titulo + "\n\n");
            doc.Add(titulo);
        }

        private void CriaIdentificacaoImpressao(Document doc)
        {
            Paragraph Identificacao = new Paragraph();
            Identificacao.Font = new Font(Font.FontFamily.COURIER, 18);
            Identificacao.Alignment = Element.ALIGN_LEFT;
            Identificacao.Add("Aluno: \n");
            Identificacao.Add("Série: " + Teste.turma + "\n\n\n");
            doc.Add(Identificacao);
        }
    }
}
