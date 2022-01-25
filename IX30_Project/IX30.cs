using System;
using System.Globalization;

namespace IX30_Project
{
    class IX30 : Conexion
    {
        private string WeekNumber()
        {

            var d = DateTime.Now;
            CultureInfo cul = CultureInfo.CurrentCulture;


            int weekNum = cul.Calendar.GetWeekOfYear(d, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            weekNum--;

            return weekNum.ToString().PadLeft(2, '0');
        }
        public void cal_mode97Nmac()
        {
            string serial01, serial02;
            //string tempSerial;
            int Mac_increment, IDno;
            object Mac_start, Mac_end;
            string prodID, Mac_head, checkdigit_str, device_name, part_no, datecode;

            prodID = ReturnValue("select code from PN where id_pn = 1 ");
            datecode = DateTime.Now.ToString(WeekNumber() + "yy").ToString();
            serial01 = ReturnValue("select begSerial from config ");
            serial02 = ReturnValue("select endSerial from config ");
            device_name = "DIGIXXXX";
            part_no = "50xxxxx-xx";
            Mac_start = "00270400";
            Mac_end = ReturnValue("select macStart from config ");
            Mac_head = ReturnValue("select macHead from config ");
            Mac_increment = int.Parse(ReturnValue("select increment from config "));
            IDno = 1;
            // Rem clear content

            Clear();

            //do
            //{

            //    // Rem calculate checksum

            //    serial00 = System.Convert.ToString(prodID) + String.Format(serial01, "0000") + String.Format(datecode, "0000") + "00";
                //checksum = 0;
                //for (i = 1; i <= Strings.Len(serial00); i++)
                //    checksum = ((checksum * 10) + (Asc(Mid(serial00, i, 1)) - 48)) % 97;
                //checksum = 98 - checksum;

                //// Rem Create serial number

                //Cells((1 + IDno), 5).Value = "'" + System.Convert.ToString(prodID) + String.Format(serial01, "0000") + String.Format(datecode, "0000") + String.Format(checksum, "00");

                //// Rem Calculate ID no

                //Cells((1 + IDno), 4).Value = "'" + System.Convert.ToString(IDno);

                //// Rem Calculate Mac Address

                //for (temp = 1; temp <= Mac_increment; temp++)
                //{

                //    // Rem adding leading zero if Mac_start < 16
                //    if (Mac_start < 16)
                //        Cells((1 + IDno), (5 + temp)).Value = "'" + System.Convert.ToString(Mac_head) + "000" + System.Convert.ToString(Conversion.Hex(Mac_start));

                //    // Rem adding leading zero if Mac_start < 256
                //    if (Mac_start >= 16 & Mac_start < 256)
                //        Cells((1 + IDno), (5 + temp)).Value = "'" + System.Convert.ToString(Mac_head) + "00" + System.Convert.ToString(Conversion.Hex(Mac_start));

                //    // Rem adding leading zero if Mac_start < 128
                //    if (Mac_start >= 256 & Mac_start < 4095)
                //        Cells((1 + IDno), (5 + temp)).Value = "'" + System.Convert.ToString(Mac_head) + "0" + System.Convert.ToString(Conversion.Hex(Mac_start));

                //    // Rem adding leading zero if Mac_start >=4095
                //    if (Mac_start >= 4095)
                //        Cells((1 + IDno), (5 + temp)).Value = "'" + Mac_head + Conversion.Hex(Mac_start);

                //    // Rem =LEFT(F2,2)&":"&MID(F2,3,2)&":"&MID(F2,5,2)&":"&MID(F2,7,2)&":"&MID(F2,9,2)&":"&RIGHT(F2,2)
                //    Cells(1 + IDno, 15 + temp).Value = Left(Cells(1 + IDno, 5 + temp).Value, 2) + ":" + Mid(Cells(1 + IDno, 5 + temp).Value, 3, 2) + ":" + Mid(Cells(1 + IDno, 5 + temp).Value, 5, 2) + ":" + Mid(Cells(1 + IDno, 5 + temp).Value, 7, 2) + ":" + Mid(Cells(1 + IDno, 5 + temp).Value, 9, 2) + ":" + Right(Cells(1 + IDno, 5 + temp).Value, 2);
                //    Mac_start = Mac_start + 1;
                //}

                //// Rem device id
                //Cells((1 + IDno), 26).Value = "'" + "0000000000000000" + Mid(Cells((1 + IDno), 6).Value, 1, 6) + "FFFF" + Mid(Cells((1 + IDno), 6).Value, 7, 6);

                // Rem the password
                //var objShell, objCmdExec;
                /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 2502
               at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
               at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitEmptyStatement(EmptyStatementSyntax node)
               at Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
               at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
               at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
               at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

            Input: 
            Set objShell = CreateObject("WScript.Shell")

             */
                //string file;
                //file = ActiveWorkbook.Path + @"\encode.exe";
                /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 2609
               at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
               at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitEmptyStatement(EmptyStatementSyntax node)
               at Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
               at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
               at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
               at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

            Input: 
            Set objCmdExec = objShell.exec(file + " " + Cells((1 + IDno), 26).Value)

             */// Rem Set objCmdExec = objShell.exec("\\orange\hardware\Manufacturing\Unique-Password\encode.exe " + Cells((1 + IDno), 26).Value)
               // Rem Set objCmdExec = objShell.exec("C:\Users\Ellick\Desktop\ACC_EX15_SN_PW_QR\encode\encode.exe " + Cells((1 + IDno), 26).Value)
               //string str, salt, passwd, vers;
               //str = objCmdExec.StdOut.ReadAll;
               //salt = Strings.Mid(str, Strings.InStr(str, "salt: ") + 6, 4);
               //passwd = Strings.Mid(str, Strings.InStr(str, "Password: ") + 10, 12);
               //vers = Strings.Mid(str, Strings.InStr(str, "version: ") + 9, 1);
               //    Cells((1 + IDno), 27).Value = "'" + passwd;
               //    Cells((1 + IDno), 28).Value = "'" + salt;
               //    Cells((1 + IDno), 29).Value = "'" + vers;
               //    // Rem device id in new format
               //    Cells((1 + IDno), 26).Value = "'" + "00000000-00000000-" + Mid(Cells((1 + IDno), 6).Value, 1, 6) + "FF-FF" + Mid(Cells((1 + IDno), 6).Value, 7, 6);
               //    // Rem QR code ="Digi EX12"&";"&(Z2)&";"&(AA2)&";"&(E2)&";"&"500xxx-VV"
               //    Cells((1 + IDno), 30).Value = device_name + ";" + Cells(1 + IDno, 26).Value + ";" + Cells(1 + IDno, 27).Value + ";" + Cells(1 + IDno, 5).Value + ";" + part_no;
               //    serial01 = serial01 + 1;
               //    IDno = IDno + 1;
               //}
               //while (!serial01 == serial02);
               //Interaction.MsgBox("Done");
            //}
            }

        public void Clear()
        {
            //int ID;
            //int nextstep;
            //bool quitloop;
            //string col;
            //quitloop = false;
            //nextstep = 2;
            //do
            //{
            //    ID = Cells(nextstep, 4).Value;
            //    if (ID != 0)
            //    {
            //        col = 4;
            //        do
            //        {
            //            Cells(nextstep, col).ClearContents();
            //            col = col + 1;
            //        }
            //        while (!col == 30);
            //        nextstep = nextstep + 1;
            //    }
            //    else
            //        quitloop = true;
            //}
            //while (!quitloop == true);
        }
    }
}

