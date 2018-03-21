Imports Microsoft.Office.Interop 'import da biblioteca INTEROP, para ter acesso as classes das aplicações OFFICE
Imports System.IO
Imports Microsoft.Win32

''' <summary>
''' 
''' </summary>
Public Class ExcelBuilder

    'Keep the application object and the workbook object global, so you can  
    'retrieve the data in Button2_Click that was set in Button1_Click.
    Private excelApp As Excel.Application

    'Private Sub Build_Excel(content() As String, directory_temp_file As String, close_file As Boolean)

    'Excel APP
    Private objBooks As Excel.Workbooks
    Private objbook As Excel.Workbook = Nothing
    Private objSheets As Excel.Sheets
    Private objSheet As Excel._Worksheet
    Private header() As String = Nothing 'First line of sheet
    Private tempDirectory As String = generate_File_name_temp(True)
    Private userLocation As String = Nothing
    Private visible As Boolean = False
    '------------------------------------------

    'How to know if a workbook is alredy open:
    Private isWorkbookAlredyOpen As Boolean = False
    Private LineAfterlastRow As Long = 0

    Public Sub New()

        ' Create a new instance of Excel and start a new workbook.
        excelApp = New Excel.Application()

        objBooks = excelApp.Workbooks
        objbook = objBooks.Add
        objSheets = objbook.Worksheets
        objSheet = objSheets(1)
        objSheet.Activate()
        objSheet.Name = "ExportBuild"
        LineAfterlastRow = 1

        excelApp.ActiveWorkbook.SaveAs(tempDirectory & ".xlsx")
        excelApp.Visible = visible

        userLocation = tempDirectory & ".xlsx"

    End Sub

    Public Sub New(Location As String)

        ' Create a new instance of Excel and start a new workbook.
        excelApp = New Excel.Application()

        objBooks = excelApp.Workbooks
        objbook = objBooks.Add
        objSheets = objbook.Worksheets
        objSheet = objSheets(1)
        objSheet.Activate()
        objSheet.Name = "ExportBuild"
        LineAfterlastRow = 1

        excelApp.ActiveWorkbook.SaveAs(Location & generate_File_name_temp(False) & ".xlsx")
        excelApp.Visible = visible

        userLocation = Location & generate_File_name_temp(False) & ".xlsx"

    End Sub



    Public Sub CreateHeader(Content() As String)

        objSheet.Range(objSheet.Cells(LineAfterlastRow, 1), objSheet.Cells(LineAfterlastRow, Content.Length)).Value2 = Content

        header = Content

    End Sub


    Public Sub AddRegistry(Content() As String)

        LineAfterlastRow = objSheet.UsedRange.Rows.Count + 1

        If Content IsNot (Nothing) Then

            objSheet.Range(objSheet.Cells(LineAfterlastRow, 1), objSheet.Cells(LineAfterlastRow, Content.Count)).Value2 = Content

        Else

            MsgBox("ERROR 1: Content is empty")

        End If

        Save()

    End Sub

    Public Sub setLocation(Location As String)

        userLocation = Location

    End Sub

    Public Function getLocation() As String

        Return userLocation

    End Function

    Public Function getTempDirectory() As String

        Return tempDirectory

    End Function

    Public Sub Save()

        excelApp.DisplayAlerts = False
        excelApp.Workbooks(1).SaveAs(userLocation)

    End Sub

    Public Sub SaveAs(directory As String)
        excelApp.DisplayAlerts = False
        excelApp.Workbooks(1).SaveAs(directory)

        Me.userLocation = directory

    End Sub

    Public Sub CloseExcelBuilder(SaveChanges As Boolean)

        objbook.Close(SaveChanges:=SaveChanges)
        excelApp.Quit()

    End Sub

    Public Sub setVisible(showExcel As Boolean)

        visible = showExcel
        excelApp.Visible = showExcel
    End Sub


    Public Function getVisible() As Boolean

        Return visible

    End Function


    Private Function generate_File_name_temp(GenerateTempFolder As Boolean) As String

        Dim date_today As String = DateAndTime.Day(Now) & DateAndTime.MonthName(DateAndTime.Month(Now), True) & " - " & DateAndTime.Hour(Now) & "h" & DateAndTime.Minute(Now) & "Min" & DateAndTime.Second(Now) & "Sec"

        If GenerateTempFolder Then

            Return Path.GetTempPath() & date_today
        Else

            Return date_today

        End If

    End Function

End Class
