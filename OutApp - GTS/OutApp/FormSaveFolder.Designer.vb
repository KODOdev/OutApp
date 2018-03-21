<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSaveFolder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenSaveDialog = New System.Windows.Forms.Button()
        Me.fomClose = New System.Windows.Forms.Button()
        Me.nextForm = New System.Windows.Forms.Button()
        Me.outputfolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label_SelectedFolder = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(77, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Onde deseja salvar o arquivo?"
        '
        'OpenSaveDialog
        '
        Me.OpenSaveDialog.Location = New System.Drawing.Point(94, 114)
        Me.OpenSaveDialog.Name = "OpenSaveDialog"
        Me.OpenSaveDialog.Size = New System.Drawing.Size(120, 23)
        Me.OpenSaveDialog.TabIndex = 1
        Me.OpenSaveDialog.Text = "Selecionar diretório"
        Me.OpenSaveDialog.UseVisualStyleBackColor = True
        '
        'fomClose
        '
        Me.fomClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.fomClose.Location = New System.Drawing.Point(3, 218)
        Me.fomClose.Name = "fomClose"
        Me.fomClose.Size = New System.Drawing.Size(75, 23)
        Me.fomClose.TabIndex = 9
        Me.fomClose.Text = "Voltar"
        Me.fomClose.UseVisualStyleBackColor = True
        '
        'nextForm
        '
        Me.nextForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.nextForm.Location = New System.Drawing.Point(245, 218)
        Me.nextForm.Name = "nextForm"
        Me.nextForm.Size = New System.Drawing.Size(75, 23)
        Me.nextForm.TabIndex = 8
        Me.nextForm.Text = "Próximo"
        Me.nextForm.UseVisualStyleBackColor = True
        '
        'Label_SelectedFolder
        '
        Me.Label_SelectedFolder.AutoSize = True
        Me.Label_SelectedFolder.Location = New System.Drawing.Point(13, 169)
        Me.Label_SelectedFolder.Name = "Label_SelectedFolder"
        Me.Label_SelectedFolder.Size = New System.Drawing.Size(0, 13)
        Me.Label_SelectedFolder.TabIndex = 10
        '
        'FormSaveFolder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 243)
        Me.Controls.Add(Me.Label_SelectedFolder)
        Me.Controls.Add(Me.fomClose)
        Me.Controls.Add(Me.nextForm)
        Me.Controls.Add(Me.OpenSaveDialog)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormSaveFolder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormSaveFolder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents OpenSaveDialog As Button
    Friend WithEvents fomClose As Button
    Friend WithEvents nextForm As Button
    Friend WithEvents outputfolder As FolderBrowserDialog
    Friend WithEvents Label_SelectedFolder As Label
End Class
