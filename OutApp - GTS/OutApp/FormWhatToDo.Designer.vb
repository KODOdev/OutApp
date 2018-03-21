<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWhatToDo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.export = New System.Windows.Forms.RadioButton()
        Me.report = New System.Windows.Forms.RadioButton()
        Me.nextForm = New System.Windows.Forms.Button()
        Me.fomClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(97, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "O que deseja fazer?"
        '
        'export
        '
        Me.export.AutoSize = True
        Me.export.Location = New System.Drawing.Point(61, 107)
        Me.export.Name = "export"
        Me.export.Size = New System.Drawing.Size(216, 17)
        Me.export.TabIndex = 1
        Me.export.TabStop = True
        Me.export.Text = "Exportar Excel com todas as mensagens"
        Me.export.UseVisualStyleBackColor = True
        '
        'report
        '
        Me.report.AutoSize = True
        Me.report.Location = New System.Drawing.Point(61, 130)
        Me.report.Name = "report"
        Me.report.Size = New System.Drawing.Size(91, 17)
        Me.report.TabIndex = 2
        Me.report.TabStop = True
        Me.report.Text = "Gerar relatório"
        Me.report.UseVisualStyleBackColor = True
        '
        'nextForm
        '
        Me.nextForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.nextForm.Location = New System.Drawing.Point(244, 217)
        Me.nextForm.Name = "nextForm"
        Me.nextForm.Size = New System.Drawing.Size(75, 23)
        Me.nextForm.TabIndex = 6
        Me.nextForm.Text = "Próximo"
        Me.nextForm.UseVisualStyleBackColor = True
        '
        'fomClose
        '
        Me.fomClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.fomClose.Location = New System.Drawing.Point(2, 217)
        Me.fomClose.Name = "fomClose"
        Me.fomClose.Size = New System.Drawing.Size(75, 23)
        Me.fomClose.TabIndex = 7
        Me.fomClose.Text = "Voltar"
        Me.fomClose.UseVisualStyleBackColor = True
        '
        'FormWhatToDo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 243)
        Me.Controls.Add(Me.fomClose)
        Me.Controls.Add(Me.nextForm)
        Me.Controls.Add(Me.report)
        Me.Controls.Add(Me.export)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormWhatToDo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormWhatToDo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents export As RadioButton
    Friend WithEvents report As RadioButton
    Friend WithEvents nextForm As Button
    Friend WithEvents fomClose As Button
End Class
