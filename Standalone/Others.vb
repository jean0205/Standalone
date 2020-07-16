Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop

Public Class Others
    Public Function GetImage(ByVal nisnum As String) As Image

        Dim tokenHandle As New IntPtr(0)
        Dim myimage As Image
        Try


            'create file name and check if file exist.
            Dim filname As String

            'add dash 
            Dim fnlen As Integer
            fnlen = nisnum.Length
            filname = Mid(nisnum, 1, fnlen - 1) + "-" + Mid(nisnum, fnlen, 1) + ".jpg"
            If File.Exists("C:\Photos\" + filname) Then
                myimage = Image.FromFile("C:\Photos\" + filname)
                Return myimage
            Else
                While filname.Length < 14
                    filname = "0" + filname
                End While
                If File.Exists("C:\Photos\" + filname) Then
                    Return Image.FromFile("C:\Photos\" + filname)
                Else
                    myimage = Image.FromFile("noimages.jpg")
                    Return myimage
                End If
            End If
        Catch ex As Exception
            myimage = Image.FromFile("noimages.jpg")
            Return myimage
            'exception
        End Try

    End Function


    Sub SetAccount(mail As Outlook.MailItem, ByVal accountName As String)
        Dim session As Outlook.NameSpace = mail.Session
        Dim accounts As Outlook.Accounts = session.Accounts
        For i As Integer = 1 To accounts.Count
            Dim account As Outlook.Account = accounts(i)
            If account.DisplayName.ToLower() = accountName.ToLower() Then
                mail.SendUsingAccount = account
                Marshal.ReleaseComObject(account)
                Exit For
            End If
            Marshal.ReleaseComObject(account)
        Next i
        Marshal.ReleaseComObject(accounts)
        Marshal.ReleaseComObject(session)
    End Sub

    Function sendEmailUsingOutlook(subject As String, body As String, emailAddress As String) As Integer
        Try
            Dim oApp As Outlook.Application = New Outlook.Application()
            Dim oNS As Outlook.[NameSpace] = oApp.GetNamespace("mapi")
            Dim oMsg As Outlook.MailItem = CType(oApp.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)
            oMsg.Subject = subject
            oMsg.HTMLBody = body
            Dim files() As String = IO.Directory.GetFiles("C:\TempRemittance\", "*.xlsx")
            Dim oAttachs As Outlook.Attachments = oMsg.Attachments
            Dim oAttach As Outlook.Attachment
            Dim sDisplayName As String = Trim(files(0))
            Dim sBodyLen As Integer = oMsg.Body.Length
            oAttach = oAttachs.Add(files(0), , sBodyLen + 1, Path.GetFileName(files(0)))
            Dim oRecips As Outlook.Recipients = CType(oMsg.Recipients, Outlook.Recipients)
            Dim oRecip As Outlook.Recipient = CType(oRecips.Add(emailAddress), Outlook.Recipient)

            oRecip.Resolve()
            SetAccount(oMsg, "nisgrenada@gmail.com")
            oMsg.DeleteAfterSubmit = True
            oMsg.Send()
            oNS.Logoff()
            oRecip = Nothing
            oRecips = Nothing
            oMsg = Nothing
            oNS = Nothing
            oApp = Nothing

        Catch e As Exception
            Throw e
        End Try

        Return 0
    End Function
    'Private Sub SendMailBankListing(email As String, subject As String, body As String, idx As Integer)
    '    Dim m_OutLook As Outlook.Application

    '    Try
    '        '* Creamos un Objeto tipo Mail
    '        Dim objMail As Outlook.MailItem

    '        '* Inicializamos nuestra apliación OutLook
    '        m_OutLook = New Outlook.Application

    '        '* Creamos una instancia de un objeto tipo MailItem
    '        objMail = CType(m_OutLook.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)

    '        '* Asignamos las propiedades a nuestra Instancial del objeto
    '        '* MailItem
    '        '   Dim attachment As New Net.Mail.Attachment(TextAdjunto.Text) '
    '        If Trim(email) = "" Then
    '        Else
    '            objMail.To = Trim(email)
    '            objMail.CC = "listing@nisgrenada.org"
    '        End If

    '        objMail.Subject = Trim(subject)
    '        objMail.Body = Trim(body)

    '        ' Agregar un archivo adjunto 
    '        ' Reemplazar con una ruta de acceso válida del archivo adjunto. 
    '        Dim sSource As String = "C:\Listing\" + Trim(PdfNam)

    '        'Reemplazar con el nombre del archivo adjunto 

    '        Dim sDisplayName As String = Trim(PdfNam)

    '        Dim sBodyLen As Integer = objMail.Body.Length

    '        Dim oAttachs As Outlook.Attachments = objMail.Attachments
    '        Dim oAttach As Outlook.Attachment
    '        oAttach = oAttachs.Add(sSource, , sBodyLen + 1, sDisplayName)
    '        '* Enviamos nuestro Mail y listo!

    '        objMail.Send()

    '        bankNotif.updateListingStatus("SENT", UserSENT, DateTime.Now, idx)
    '        '* Desplegamos un mensaje indicando que todo fue exitoso
    '        ' MessageBox.Show("Mail enviado", "Claim Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    Catch ex As Exception
    '        '* Si se produce algun Error Notificar al usuario

    '        bankNotif.updateListingStatus("ERROR EMAIL", UserSENT, DateTime.Now, idx)
    '        ' MessageBox.Show("Error sending mail.")
    '    Finally
    '        m_OutLook = Nothing
    '    End Try

    'End Sub

    Sub tesEmail()
        Try
            Dim Mail As New MailMessage
            Dim SMTP As New SmtpClient("smtp.gmail.com")

            Mail.Subject = "Security Update"
            Mail.From = New MailAddress("kioshremittance@gmail.com")
            SMTP.Credentials = New System.Net.NetworkCredential("kioshremittance@gmail.com", "alpha00beta01") '<-- Password Here

            Mail.To.Add("jeanc.soto0205" & "@gmail.com") 'I used ByVal here for address

            Mail.Body = "hgnhnhnhg" 'Message Here

            SMTP.EnableSsl = True
            SMTP.Port = "25"
            SMTP.Send(Mail)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Function IsValidEmail(ByVal email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False
        ' Compruebo si el formato de la dirección es correcto.
        Dim re As Regex = New Regex("^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
        '("^[\w._%-]+@[\w.-]+\.[a-zA-Z]{2,4}$")
        Dim m As Match = re.Match(email)
        Return (m.Captures.Count <> 0)
    End Function
    Sub SendEmail()
        Using mm As New MailMessage("jeanc.nis0205@gamail.com", "jeanc.soto0205@gamail.com")
            mm.Subject = "subject"
            mm.Body = "bvody"
            Dim smtp As New SmtpClient()
            smtp.Host = "smtp.gmail.com"
            smtp.EnableSsl = True
            Dim NetworkCred As New NetworkCredential("jeanc.nis0205@gamail.com", "alpha00beta01")
            smtp.UseDefaultCredentials = True
            smtp.Credentials = NetworkCred
            smtp.Port = 587
            smtp.Send(mm)
        End Using
    End Sub
    Sub sendMailGmail()
        Dim GGmail As New GGSMTP_GMAIL("jeanc.nis0205@gmail.com", "alpha00beta01", )

        Dim ToAddressies As String() = {"jcsoto@nisgrenada.org", "jeanc.soto0205@gmail.com"}
        Dim attachs() As String = {"d:\datatable.xlsx"}
        Dim subject As String = "My TestSubject"
        Dim body As String = "My text goes here ...."
        Dim result As Boolean = GGmail.SendMail(ToAddressies, subject, body, attachs)
        If result Then
            MsgBox("mails sended successfully", MsgBoxStyle.Information)
        Else
            MsgBox(GGmail.ErrorText, MsgBoxStyle.Critical)
        End If
    End Sub

End Class

Public Class GGSMTP_GMAIL
    Dim Temp_GmailAccount As String
    Dim Temp_GmailPassword As String
    Dim Temp_SMTPSERVER As String
    Dim Temp_ServerPort As Int32
    Dim Temp_ErrorText As String = ""
    Dim Temp_EnableSSl As Boolean = True
    Public ReadOnly Property ErrorText() As String
        Get
            Return Temp_ErrorText
        End Get
    End Property
    Public Property EnableSSL() As Boolean
        Get
            Return Temp_EnableSSl
        End Get
        Set(ByVal value As Boolean)
            Temp_EnableSSl = value
        End Set
    End Property
    Public Property GmailAccount() As String
        Get
            Return Temp_GmailAccount
        End Get
        Set(ByVal value As String)
            Temp_GmailAccount = value
        End Set
    End Property
    Public Property GmailPassword() As String
        Get
            Return Temp_GmailPassword
        End Get
        Set(ByVal value As String)
            Temp_GmailPassword = value
        End Set
    End Property
    Public Property SMTPSERVER() As String
        Get
            Return Temp_SMTPSERVER
        End Get
        Set(ByVal value As String)
            Temp_SMTPSERVER = value
        End Set
    End Property
    Public Property ServerPort() As Int32
        Get
            Return Temp_ServerPort
        End Get
        Set(ByVal value As Int32)
            Temp_ServerPort = value
        End Set
    End Property
    Public Sub New(ByVal GmailAccount As String, ByVal GmailPassword As String, Optional ByVal SMTPSERVER As String = "smtp.gmail.com", Optional ByVal ServerPort As Int32 = 587, Optional ByVal EnableSSl As Boolean = True)
        Temp_GmailAccount = GmailAccount
        Temp_GmailPassword = GmailPassword
        Temp_SMTPSERVER = SMTPSERVER
        Temp_ServerPort = ServerPort
        Temp_EnableSSl = EnableSSl
    End Sub
    Public Function SendMail(ByVal ToAddressies As String(), ByVal Subject As String, ByVal BodyText As String, Optional ByVal AttachedFiles As String() = Nothing) As Boolean
        Temp_ErrorText = ""
        Dim Mail As New MailMessage
        Dim SMTP As New SmtpClient(Temp_SMTPSERVER)
        Mail.Subject = Subject
        Mail.From = New MailAddress(Temp_GmailAccount)
        SMTP.Credentials = New System.Net.NetworkCredential(Temp_GmailAccount, Temp_GmailPassword) '<-- Password Here
        Mail.To.Clear()
        For i As Int16 = 0 To ToAddressies.Length - 1
            Mail.To.Add(ToAddressies(i))
        Next i
        Mail.Body = BodyText
        Mail.Attachments.Clear()

        If AttachedFiles IsNot Nothing Then
            For i As Int16 = 0 To AttachedFiles.Length - 1
                Mail.Attachments.Add(New Attachment(AttachedFiles(i)))
            Next
        End If

        SMTP.EnableSsl = Temp_EnableSSl
        'SMTP.en
        SMTP.Port = Temp_ServerPort

        Try
            SMTP.Send(Mail)
            Return True
        Catch ex As Exception
            Me.Temp_ErrorText = ex.Message.ToString
            Return False
        End Try

    End Function

End Class