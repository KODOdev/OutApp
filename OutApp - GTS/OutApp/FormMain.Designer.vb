<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
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
        Me.Label_Folders = New System.Windows.Forms.Label()
        Me.SelectFolder = New System.Windows.Forms.Button()
        Me.Label_folder_choosed = New System.Windows.Forms.Label()
        Me.Label_user_active = New System.Windows.Forms.Label()
        Me.nextForm = New System.Windows.Forms.Button()
        Me.CloseMain = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label_Folders
        '
        Me.Label_Folders.AutoSize = True
        Me.Label_Folders.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Folders.ForeColor = System.Drawing.SystemColors.Window
        Me.Label_Folders.Location = New System.Drawing.Point(32, 75)
        Me.Label_Folders.Name = "Label_Folders"
        Me.Label_Folders.Size = New System.Drawing.Size(275, 27)
        Me.Label_Folders.TabIndex = 0
        Me.Label_Folders.Text = "Qual pasta deseja exportar?"
        '
        'SelectFolder
        '
        Me.SelectFolder.BackColor = System.Drawing.Color.Transparent
        Me.SelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SelectFolder.ForeColor = System.Drawing.SystemColors.Window
        Me.SelectFolder.Location = New System.Drawing.Point(125, 113)
        Me.SelectFolder.Name = "SelectFolder"
        Me.SelectFolder.Size = New System.Drawing.Size(75, 21)
        Me.SelectFolder.TabIndex = 2
        Me.SelectFolder.Text = "Selecionar"
        Me.SelectFolder.UseVisualStyleBackColor = False
        '
        'Label_folder_choosed
        '
        Me.Label_folder_choosed.AutoSize = True
        Me.Label_folder_choosed.Location = New System.Drawing.Point(12, 162)
        Me.Label_folder_choosed.Name = "Label_folder_choosed"
        Me.Label_folder_choosed.Size = New System.Drawing.Size(0, 13)
        Me.Label_folder_choosed.TabIndex = 3
        '
        'Label_user_active
        '
        Me.Label_user_active.AutoSize = True
        Me.Label_user_active.Location = New System.Drawing.Point(12, 181)
        Me.Label_user_active.Name = "Label_user_active"
        Me.Label_user_active.Size = New System.Drawing.Size(0, 13)
        Me.Label_user_active.TabIndex = 4
        '
        'nextForm
        '
        Me.nextForm.BackColor = System.Drawing.Color.Transparent
        Me.nextForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.nextForm.ForeColor = System.Drawing.SystemColors.Window
        Me.nextForm.Location = New System.Drawing.Point(244, 217)
        Me.nextForm.Name = "nextForm"
        Me.nextForm.Size = New System.Drawing.Size(75, 23)
        Me.nextForm.TabIndex = 5
        Me.nextForm.Text = "Próximo"
        Me.nextForm.UseVisualStyleBackColor = False
        '
        'CloseMain
        '
        Me.CloseMain.AutoSize = True
        Me.CloseMain.BackColor = System.Drawing.Color.White
        Me.CloseMain.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseMain.ForeColor = System.Drawing.Color.Red
        Me.CloseMain.Location = New System.Drawing.Point(303, 0)
        Me.CloseMain.Name = "CloseMain"
        Me.CloseMain.Size = New System.Drawing.Size(18, 19)
        Me.CloseMain.TabIndex = 6
        Me.CloseMain.Text = "x"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(322, 243)
        Me.Controls.Add(Me.CloseMain)
        Me.Controls.Add(Me.nextForm)
        Me.Controls.Add(Me.Label_user_active)
        Me.Controls.Add(Me.Label_folder_choosed)
        Me.Controls.Add(Me.SelectFolder)
        Me.Controls.Add(Me.Label_Folders)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormMain"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label_Folders As Label
    Friend WithEvents SelectFolder As Button
    Friend WithEvents Label_folder_choosed As Label
    Friend WithEvents Label_user_active As Label
    Friend WithEvents nextForm As Button
    Friend WithEvents CloseMain As Label
End Class
