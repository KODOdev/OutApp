Imports Microsoft.Office.Interop 'import da biblioteca INTEROP, para ter acesso as classes das aplicações OFFICE
Imports System
Imports Microsoft.Win32

Public Class FormMain

    'Oulook Variable class
    Dim outlookApp As Microsoft.Office.Interop.Outlook.Application

    '----------------------------------------------------------------------------------------------------
    Dim choosedFolder As Outlook.MAPIFolder

    'Informações do usuário


    Dim email As Outlook.MailItem
    Dim OL_FolderWorker As Outlook.NameSpace
    Dim OL_Folder As Outlook.MAPIFolder
    Dim start_folder As Outlook.Folder

    'Item selecionado na combobox
    Dim choosedItemCombobox As String

    'Away
    Dim lCountOfFound As Long
    Public strFolders As String
    '--------------------------------------




    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        nextForm.Hide()

        If OfficeAppIsInstalled("Outlook") = False Or OfficeAppIsInstalled("excel") = False Then

            Dim msg As String = "Detectamos que: " & vbNewLine & vbNewLine

            If OfficeAppIsInstalled("Outlook") = False Then

                msg += "- Microsoft Outlook" & vbNewLine

            End If

            If OfficeAppIsInstalled("Excel") = False Then

                msg += "- Microsoft Excel" & vbNewLine & vbNewLine

            End If

            msg += "Precisa(m) ser instalado(s) em sua máquina. Por favor, instale-o(s) e tente novamente."

            MsgBox(msg)

            Close()

        End If

    End Sub



    Private Function pick_folder() As Outlook.MAPIFolder

        ' Dim item As Object

        outlookApp = New Outlook.Application

        outlookApp = CreateObject("Outlook.Application")

        OL_FolderWorker = outlookApp.GetNamespace("MAPI")

        '  Dim subfolder As Outlook.Folder

        OL_Folder = OL_FolderWorker.PickFolder

        'ComboBox.Items.Clear()

        'If OL_Folder.Folders.Count > 0 Then

        '    For Each subfolder In OL_Folder.Folders

        '        ComboBox.Items.Add(subfolder.Name)

        '    Next

        'End If

        Return OL_Folder

    End Function

    Private Sub nextForm_Click(sender As Object, e As EventArgs) Handles nextForm.Click

        Me.Hide()
        FormWhatToDo.ShowDialog()

    End Sub



    Private Sub Test_Click(sender As Object, e As EventArgs) Handles SelectFolder.Click


        choosedFolder = pick_folder()

        If choosedFolder IsNot Nothing Then

            Label_folder_choosed.Text = "Pasta selecionada: " & choosedFolder.Name
            Label_user_active.Text = "Usuário ativo: " & OL_FolderWorker.CurrentUser.Name

            nextForm.Show()

        Else
            Label_folder_choosed.Text = ""
            Label_user_active.Text = ""

            nextForm.Hide()

        End If


    End Sub

    Public Function get_choosedOutlookFolder_name() As String

        Return choosedFolder.Name

    End Function

    Public Function get_outlook_username() As String

        Return OL_FolderWorker.CurrentUser.Name

    End Function


    Public Function get_choosedOutlookFolder_object() As Outlook.MAPIFolder

        Return choosedFolder

    End Function

    'Exemplo de CASCA. Apagar assim que o APP estiver pronto
    Private Sub setEmailSend(sSubject As String, sBody As String,
                             sTo As String, sCC As String,
                             sFilename As String, sDisplayname As String)


        'Instância da classe. Necessário pois a variável é global
        outlookApp = New Microsoft.Office.Interop.Outlook.Application


        Dim oMsg As Microsoft.Office.Interop.Outlook._MailItem

        oMsg = outlookApp.CreateItem(Outlook.OlItemType.olMailItem)

        oMsg.Subject = sSubject
        oMsg.Body = sBody

        oMsg.To = sTo
        oMsg.CC = sCC


        Dim strS As String = sFilename
        Dim strN As String = sDisplayname

        If sFilename <> "" Then
            Dim sBodyLen As Integer = Int(sBody.Length)
            Dim oAttachs As Microsoft.Office.Interop.Outlook.Attachments = oMsg.Attachments
            Dim oAttach As Microsoft.Office.Interop.Outlook.Attachment

            oAttach = oAttachs.Add(strS, , sBodyLen, strN)

        End If

        oMsg.Send()
        MessageBox.Show("Email Send", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    End Sub
    '------------------------------------------------------------------------------------------------------------------------


    Private Sub GetSubFolder()


        'Dim email As Outlook.MailItem
        Dim OL_FolderWorker As Outlook.NameSpace
        Dim OL_Folder As Outlook.MAPIFolder
        'Dim item As Object

        outlookApp = New Outlook.Application

        outlookApp = CreateObject("Outlook.Application")

        OL_FolderWorker = outlookApp.GetNamespace("MAPI")


        OL_Folder = OL_FolderWorker.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)

        OL_Folder = OL_FolderWorker.GetDefaultFolder(Outlook.OlDefaultFolders.olPublicFoldersAllPublicFolders)

    End Sub

    Public Sub GetFolderNames()
        Dim olApp As Outlook.Application
        Dim ListFolders As Outlook.Application = Nothing
        Dim olSession As Outlook.NameSpace
        Dim olStartFolder As Outlook.MAPIFolder


        lCountOfFound = 0

        olApp = New Outlook.Application
        olSession = olApp.GetNamespace("MAPI")

        ' Allow the user to pick the folder in which to start the search.
        olStartFolder = olSession.PickFolder

        ' Check to make sure user didn't cancel PickFolder dialog.
        If Not (olStartFolder Is Nothing) Then
            ' Start the search process.
            ProcessFolder(olStartFolder)
        End If

        ' Create a new mail message with the folder list inserted
        'ListFolders = Application.CreateItem(Outlook.MailItem)
        ListFolders.Body = strFolders
        ListFolders.Display

        ' clear the string so you can run it on another folder
        strFolders = ""
    End Sub

    Sub ProcessFolder(CurrentFolder As Outlook.MAPIFolder)
        Dim olcount As Long
        Dim i As Long
        Dim olNewFolder As Outlook.MAPIFolder
        Dim olTempFolder As Outlook.MAPIFolder
        Dim olTempFolderPath As String
        ' Loop through the items in the current folder.
        For i = CurrentFolder.Folders.Count To 1 Step -1

            olTempFolder = CurrentFolder.Folders(i)

            olTempFolderPath = olTempFolder.FolderPath

            ' Get the count of items in the folder
            olCount = olTempFolder.Items.Count

            'prints the folder path and name in the VB Editor's Immediate window
            Debug.Print(olTempFolderPath & " " & olCount)

            ' prints the folder name only
            ' Debug.Print olTempFolder

            ' create a string with the folder names.
            ' use olTempFolder if you want foldernames only
            strFolders = strFolders & vbCrLf & olTempFolderPath & " " & olCount

            lCountOfFound = lCountOfFound + 1

        Next
        ' Loop through and search each subfolder of the current folder.
        For Each olNewFolder In CurrentFolder.Folders

            'Don't need to process the Deleted Items folder
            If olNewFolder.Name <> "Deleted Items" Then
                ProcessFolder(olNewFolder)
            End If

        Next

    End Sub

    Private Sub CloseMain_Click(sender As Object, e As EventArgs) Handles CloseMain.Click
        Me.Close()
    End Sub

    'Private Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)

    '    choosedItemCombobox = ComboBox.SelectedItem



    '    Dim item As Object

    '    Dim folder As Outlook.MAPIFolder

    '    MsgBox(choosedItemCombobox)

    '    folder = choosedFolder.Folders(choosedItemCombobox)


    '    'CheckedListBox.Items.Clear()
    '    'For Each item In folder.Items

    '    '    If TypeOf item Is Outlook.MailItem Then

    '    '        Dim email As Outlook.MailItem = item

    '    '        CheckedListBox.Items.Add(email.Sender.Name)

    '    '    End If


    '    'Next



    'End Sub

    Private Function OfficeAppIsInstalled(AppName As String) As Boolean

        Dim installed As Boolean

        Dim TargetKey As RegistryKey
        TargetKey = Registry.ClassesRoot.OpenSubKey(AppName & ".application")
        If TargetKey Is Nothing Then

            installed = False

        Else    'key is found

            installed = True
            TargetKey.Close()
        End If

        Return installed

    End Function

    Private Sub Label_Folders_Click(sender As Object, e As EventArgs) Handles Label_Folders.Click

    End Sub
End Class