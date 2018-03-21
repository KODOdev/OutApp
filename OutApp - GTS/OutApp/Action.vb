Imports Microsoft.Office.Interop 'import da biblioteca INTEROP, para ter acesso as classes das aplicações OFFICE
Imports System.IO
Imports Microsoft.Win32
Public Class Action

    'Temporary path adress for excel file
    Dim output_folder As String = FormSaveFolder.pick_output_Folder() & "\" & FormMain.get_choosedOutlookFolder_name() & " - " & FormMain.get_outlook_username() & " - " & DateAndTime.Day(Now) & "-" & DateAndTime.MonthName(DateAndTime.Month(Now), True) & "-" & DateAndTime.Year(Now)

    'The descríption is enough
    Dim temporary_file_random_name As String = Nothing

    'Keep the application object and the workbook object global, so you can  
    'retrieve the data in Button2_Click that was set in Button1_Click.
    Dim excelApp As Excel.Application
    Dim choosedFolder As Outlook.MAPIFolder = FormMain.get_choosedOutlookFolder_object()
    Dim planilha As ExcelBuilder = New ExcelBuilder()


    Private Sub Action_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label_folder_choosed.Text = "Pasta selecionada: " & FormMain.get_choosedOutlookFolder_name()
        Label_What_to_do.Text = "Realizando: " & FormWhatToDo.get_what_to_do()
        Label_file_adress.Text = "Salvar arquivo em: " & FormSaveFolder.pick_output_Folder()

        check_Uncheck_checkbox(CheckedListBox, True)

        planilha.SaveAs("C:\Users\05899961180\Desktop\CINARA -LISTA DE EMAILS DA CAIXA\")


    End Sub


    Private Sub check_Uncheck_checkbox(checkbox As CheckedListBox, tipoDeSelecao As Boolean)

        'Tipo de seleção:
        'True = Selecionar tudo
        'False = Desselecionar tudo

        If tipoDeSelecao Then

            For i As Integer = 0 To checkbox.Items.Count - 1
                checkbox.SetItemChecked(i, True)
            Next i

        Else

            For i As Integer = 0 To checkbox.Items.Count - 1
                checkbox.SetItemChecked(i, False)
            Next i

        End If

    End Sub

    Private Sub iniciar_Click(sender As Object, e As EventArgs) Handles iniciar.Click


        'Genarate file name (random or not)
        '-------------------------------------------------------
        If temporary_file_random_name Is Nothing Then

            temporary_file_random_name = generate_File_name_random(False)

        End If

        '--------------------------------------------------------------


        'Arrays to:
        '1 - Save the description of Attributes chosen by the user
        '2 - Save the content of atributes chosen

        Dim array_checked_atributes() As String
        Dim array_checked_content() As String

        ReDim array_checked_content(0)
        ReDim array_checked_atributes(0)
        '---------------------------------------------------------

        'Just control. Can be used for any iteration
        Dim i = 0

        'Loading the checked attributes in array. This process is dynamic
        For Each item As String In CheckedListBox.CheckedItems

            array_checked_atributes(i) = item

            If i < (CheckedListBox.CheckedItems.Count - 1) Then


                i = i + 1

                'Redimensioning the size of the total itens in the checkedListBox, at the end of iteration 
                ReDim Preserve array_checked_atributes(i)

            End If

        Next

        '------------------------------------------------------------------------

        planilha.CreateHeader(array_checked_atributes)

        '-------------------------------------------------------------------------

        'Redimensioning the content array to the same size of the atributes array 

        ReDim array_checked_content(array_checked_atributes.Count - 1)

        'Loading content according to selected attibutes

        ProgressBar1.Maximum = choosedFolder.Items.Count

        Dim actualItemStatus As Integer

        For Each item In choosedFolder.Items

            actualItemStatus += 1

            If TypeOf item Is Outlook.MailItem Then

                Dim oMail As Outlook.MailItem = item

                'Deciding what kind of information will be recovered from selected folder
                For i = 0 To (array_checked_atributes.Count - 1)

                    '-------------------------------------------------------------------------
                    'REMEMBER TO INCLUDE THE NEW TYPE OF ATRIBUTE IN THE CASE STATEMENT. 
                    'To avoid runtime error, always use "empty" when the value of the atribute
                    'may return zero.
                    '-------------------------------------------------------------------------

                    Select Case array_checked_atributes(i)

                        Case "Nome do Destinatário"

                            array_checked_content(i) = oMail.To

                        Case "E-mail do Destinatário"
                            Try

                                array_checked_content(i) = GetSMTPAddressForRecipients(oMail)

                            Catch ex As Exception

                                array_checked_content(i) = "Error"

                            End Try

                        Case "Nome do Remetente"


                            array_checked_content(i) = oMail.SenderName


                        Case "E-mail do Remetente"
                            Try


                                Dim senderEmail As String = GetSenderSMTP_EX_Address(oMail)

                                If senderEmail <> Nothing Then

                                    array_checked_content(i) = senderEmail

                                Else

                                    array_checked_content(i) = "Empty"

                                End If

                                My.Application.DoEvents()

                            Catch ex As Exception

                                array_checked_content(i) = "Error"

                            End Try


                        Case "Data"

                            array_checked_content(i) = oMail.ReceivedTime

                        Case "Assunto"

                            If oMail.Subject = Nothing Then

                                array_checked_content(i) = "Empty"

                            Else

                                array_checked_content(i) = oMail.Subject.ToString

                            End If

                        Case "Corpo"

                            If oMail.Body = Nothing Then

                                array_checked_content(i) = "Empty"

                            Else

                                array_checked_content(i) = oMail.Body

                            End If

                        Case Else

                            array_checked_content(i) = "Empty"

                    End Select

                Next

                'Recording all data in the row on the excel file. Line by Line
                planilha.AddRegistry(array_checked_content)

            End If

            'Incrementing progress bar
            ProgressBar1.Increment(actualItemStatus)

        Next
        ProgressBar1.Increment(0)

        planilha.Save()

        MsgBox("Processo Finalizado.")

    End Sub


    Private Function generate_File_name_random(random As Boolean) As String

        Dim date_today As String = DateAndTime.Day(Now) & DateAndTime.MonthName(DateAndTime.Month(Now), True) & " - " & DateAndTime.Hour(Now) & "h" & DateAndTime.Minute(Now) & "Min" & DateAndTime.Second(Now) & "Sec"

        Dim directory_temp_file As String


        If random Then

            directory_temp_file = Path.GetTempPath() & date_today

        Else

            directory_temp_file = output_folder

        End If

        Return directory_temp_file

    End Function



    Private Function GetSenderSMTP_EX_Address(mail As Outlook.MailItem) As String

        Dim outlookApp As Outlook.Application, oOutlook As Object
        Dim oInbox As Outlook.Folder, oMail As Outlook.MailItem

        Dim strAddress As String, strEntryId As String, getSmtpMailAddress As String
        Dim objAddressentry As Outlook.AddressEntry, objExchangeUser As Outlook.ExchangeUser
        Dim objReply As Outlook.MailItem, objRecipient As Outlook.Recipient

        outlookApp = New Outlook.Application
        oOutlook = outlookApp.GetNamespace("MAPI")

        If mail.SenderEmailType = "SMTP" Then


            '            MsgBox("SMTP: " & mail.SenderEmailAddress)
            My.Application.DoEvents()
            Return mail.SenderEmailAddress

        Else

            objReply = mail.Reply()
            objRecipient = objReply.Recipients.Item(1)

            strEntryId = objRecipient.EntryID

            objAddressentry = oOutlook.GetAddressEntryFromID(strEntryId)
            objExchangeUser = objAddressentry.GetExchangeUser()

            strAddress = objExchangeUser.PrimarySmtpAddress()


            'MsgBox("Not SMTP: " & strAddress)
            My.Application.DoEvents()
            Return strAddress

        End If



    End Function




    Private Function GetSenderSMTPAddress(mail As Outlook.MailItem) As String
        Dim PR_SMTP_ADDRESS As String = "http://schemas.microsoft.com/mapi/proptag/0x39FE001E"
        If mail Is Nothing Then
            Throw New ArgumentNullException()
        End If
        If mail.SenderEmailType = "EX" Then
            Dim sender As Outlook.AddressEntry = mail.Sender
            If sender IsNot Nothing Then
                'Now we have an AddressEntry representing the Sender
                If sender.AddressEntryUserType = Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry OrElse sender.AddressEntryUserType = Outlook.OlAddressEntryUserType.olExchangeRemoteUserAddressEntry Then
                    'Use the ExchangeUser object PrimarySMTPAddress
                    Dim exchUser As Outlook.ExchangeUser = sender.GetExchangeUser()
                    If exchUser IsNot Nothing Then
                        Return exchUser.PrimarySmtpAddress
                    Else
                        Return Nothing
                    End If
                Else
                    Return TryCast(sender.PropertyAccessor.GetProperty(PR_SMTP_ADDRESS), String)
                End If
            Else
                Return Nothing
            End If
        Else
            Return mail.SenderEmailAddress
        End If
    End Function

    Private Function GetSMTPAddressForRecipients(mail As Outlook.MailItem) As String
        Dim recips As Outlook.Recipients
        Dim recip As Outlook.Recipient
        Dim pa As Outlook.PropertyAccessor
        Const PR_SMTP_ADDRESS As String =
            "http://schemas.microsoft.com/mapi/proptag/0x39FE001E"
        recips = mail.Recipients

        Dim returnString As String = ""

        For Each recip In recips
            pa = recip.PropertyAccessor

            returnString += pa.GetProperty(PR_SMTP_ADDRESS) & ";"

        Next

        Return returnString

    End Function


End Class