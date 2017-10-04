Imports System.Net.Mail

Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text.Contains("@gmail.com") Or TextBox1.Text.Contains("@o2.pl") Or TextBox1.Text.Contains("tlen") Or TextBox1.Text.Contains("prokonto") Or TextBox1.Text.Contains("go2") Or TextBox1.Text.Contains("interia") Or TextBox1.Text.Contains("neostrada") Or TextBox1.Text.Contains("onet") Or TextBox1.Text.Contains("vp") Or TextBox1.Text.Contains("spoko") Or TextBox1.Text.Contains("autograf") Or TextBox1.Text.Contains("opoczta") Or TextBox1.Text.Contains("adres") Or TextBox1.Text.Contains("pseudonim") Then
            wysylka()
        Else
            MsgBox("Ten program nie obsługuje obecnie Twojego adresu." + vbNewLine + "Użyj innego!", MsgBoxStyle.OkOnly, "Nieobsługiwany adres e-mail")
        End If
    End Sub
    Private Sub wysylka()
        Dim message As New MailMessage()
        Dim smtp As New SmtpClient

        If Not TextBox3.Text.Contains("@") Or Not TextBox1.Text.Contains("@") Then
            MsgBox("E-mail nadawcy lub odbiorcy nie ma prawidłowego formatu!", MsgBoxStyle.OkOnly, "Popraw e-mail")
        ElseIf TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Uzupełnij wszystkie pola!", MsgBoxStyle.OkOnly, "Brakujące dane")
        Else
            message.From = New MailAddress(TextBox1.Text)
            message.To.Add(TextBox3.Text)
            message.Subject = TextBox4.Text
            message.Body = TextBox5.Text + vbNewLine + vbNewLine + "Wysłano za pomocą E-mail Sender by Kiełka"
        End If

        Try
            If TextBox1.Text.Contains("gmail.com") Then
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
                smtp.Port = 587
                smtp.EnableSsl = True
                smtp.Host = "smtp.gmail.com"
                smtp.Send(message)
                MsgBox("Pomyślnie dostarczono wiadomość do: " + TextBox3.Text + "!", MsgBoxStyle.OkOnly, "gmail.com")
            ElseIf TextBox1.Text.Contains("o2.pl") Or TextBox1.Text.Contains("tlen.pl") Or TextBox1.Text.Contains("prokonto.pl") Or TextBox1.Text.Contains("go2.pl") Then
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
                smtp.Port = 587
                smtp.EnableSsl = True
                smtp.Host = "poczta.o2.pl"
                smtp.Send(message)
                MsgBox("Pomyślnie dostarczono wiadomość do: " + TextBox3.Text + "!", MsgBoxStyle.OkOnly, "poczta.o2.pl")
            ElseIf TextBox1.Text.Contains("interia.pl") Or TextBox1.Text.Contains("interia.eu") Then
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
                smtp.Port = 587
                smtp.EnableSsl = False
                smtp.Host = "poczta.interia.pl"
                smtp.Send(message)
                MsgBox("Pomyślnie dostarczono wiadomość do: " + TextBox3.Text + "!", MsgBoxStyle.OkOnly, "poczta.interia.pl")
            ElseIf TextBox1.Text.Contains("neostrada.pl") Then
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
                smtp.Port = 587
                smtp.EnableSsl = False
                smtp.Host = "poczta.neostrada.pl"
                smtp.Send(message)
                MsgBox("Pomyślnie dostarczono wiadomość do: " + TextBox3.Text + "!", MsgBoxStyle.OkOnly, "poczta.neostrada.pl")
            ElseIf TextBox1.Text.Contains("onet.pl") Or TextBox1.Text.Contains("op.pl") Or TextBox1.Text.Contains("onet.eu") Or TextBox1.Text.Contains("spoko.pl") Or TextBox1.Text.Contains("autograf.pl") Or TextBox1.Text.Contains("vip.onet.pl") Or TextBox1.Text.Contains("vp.pl") Or TextBox1.Text.Contains("poczta.onet.pl") Or TextBox1.Text.Contains("onet.com.pl") Or TextBox1.Text.Contains("opoczta.pl") Or TextBox1.Text.Contains("adres.pl") Or TextBox1.Text.Contains("pseudonim.pl") Then
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
                smtp.Port = 587
                smtp.EnableSsl = True
                smtp.Host = "smtp.poczta.onet.pl"
                smtp.Send(message)
                MsgBox("Pomyślnie dostarczono wiadomość do: " + TextBox3.Text + "!", MsgBoxStyle.OkOnly, "poczta.onet.pl")
            ElseIf TextBox1.Text.Contains("wp.pl") Then
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
                smtp.Port = 587
                smtp.EnableSsl = False
                smtp.Host = "smtp.wp.pl"
                smtp.Send(message)
                MsgBox("Pomyślnie dostarczono wiadomość do: " + TextBox3.Text + "!", MsgBoxStyle.OkOnly, "wp.pl")
            End If
        Catch error_t As Exception
            MsgBox("Wystąpił błąd, sprawdź czy dobrze wpisałeś dane logowania oraz czy posiadasz połączenie z internetem!", MsgBoxStyle.OkOnly, "Błąd")
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.email = TextBox1.Text
        My.Settings.pass = TextBox2.Text
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.email <> "" Or My.Settings.pass <> "" Then
            TextBox1.Text = My.Settings.email
            TextBox2.Text = My.Settings.pass
        End If
    End Sub
End Class
