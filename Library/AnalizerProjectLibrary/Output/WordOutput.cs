using System;
using System.IO;
using NPOI.XWPF;
using NPOI.XWPF.UserModel;

namespace Library.AnalizerProjectLibrary.Output{

    public static class WordOutput{

        #region Static Methods

        public static void CreateDocument(){

            var newFile2 = @"C:\Temp\newbook.core.docx";
            using (var fs = new FileStream(newFile2, FileMode.Create, FileAccess.Write)) {
                XWPFDocument doc = new XWPFDocument();
                var p0 = doc.CreateParagraph();
                p0.Alignment = ParagraphAlignment.CENTER;
                XWPFRun r0 = p0.CreateRun();
                r0.FontFamily = "microsoft yahei";
                r0.FontSize = 18;
                r0.IsBold = true;
                r0.SetText("This is title");

                var p1 = doc.CreateParagraph();
                p1.Alignment = ParagraphAlignment.LEFT;
                p1.IndentationFirstLine = 500;
                XWPFRun r1 = p1.CreateRun();
                r1.FontFamily = "·ÂËÎ";
                r1.FontSize = 12;
                r1.IsBold = true;
                r1.SetText("This is content, content content content content content content content content content");

                doc.Write(fs);
            }
        }

        #endregion
    }
}