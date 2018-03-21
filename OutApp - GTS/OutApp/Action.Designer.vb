<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Action
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
        Me.components = New System.ComponentModel.Container()
        Me.Label_folder_choosed = New System.Windows.Forms.Label()
        Me.Label_What_to_do = New System.Windows.Forms.Label()
        Me.Label_file_adress = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.iniciar = New System.Windows.Forms.Button()
        Me.CheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.Label_Attribute = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SuspendLayout()
        '
        'Label_folder_choosed
        '
        Me.Label_folder_choosed.AutoSize = True
        Me.Label_folder_choosed.Location = New System.Drawing.Point(12, 17)
        Me.Label_folder_choosed.Name = "Label_folder_choosed"
        Me.Label_folder_choosed.Size = New System.Drawing.Size(97, 13)
        Me.Label_folder_choosed.TabIndex = 4
        Me.Label_folder_choosed.Text = "Pasta selecionada:"
        '
        'Label_What_to_do
        '
        Me.Label_What_to_do.AutoSize = True
        Me.Label_What_to_do.Location = New System.Drawing.Point(12, 42)
        Me.Label_What_to_do.Name = "Label_What_to_do"
        Me.Label_What_to_do.Size = New System.Drawing.Size(67, 13)
        Me.Label_What_to_do.TabIndex = 5
        Me.Label_What_to_do.Text = "Exportando: "
        '
        'Label_file_adress
        '
        Me.Label_file_adress.AutoSize = True
        Me.Label_file_adress.Location = New System.Drawing.Point(12, 69)
        Me.Label_file_adress.Name = "Label_file_adress"
        Me.Label_file_adress.Size = New System.Drawing.Size(95, 13)
        Me.Label_file_adress.TabIndex = 6
        Me.Label_file_adress.Text = "Salvar arquivo em:"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(111, 209)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(199, 23)
        Me.ProgressBar1.TabIndex = 7
        '
        'iniciar
        '
        Me.iniciar.Location = New System.Drawing.Point(15, 209)
        Me.iniciar.Name = "iniciar"
        Me.iniciar.Size = New System.Drawing.Size(75, 23)
        Me.iniciar.TabIndex = 8
        Me.iniciar.Text = "Iniciar"
        Me.iniciar.UseVisualStyleBackColor = True
        '
        'CheckedListBox
        '
        Me.CheckedListBox.FormattingEnabled = True
        Me.CheckedListBox.Items.AddRange(New Object() {"Nome do Remetente", "E-mail do Remetente", "Nome do Destinatário", "E-mail do Destinatário", "Data", "Assunto", "Corpo"})
        Me.CheckedListBox.Location = New System.Drawing.Point(12, 109)
        Me.CheckedListBox.Name = "CheckedListBox"
        Me.CheckedListBox.Size = New System.Drawing.Size(298, 94)
        Me.CheckedListBox.TabIndex = 9
        '
        'Label_Attribute
        '
        Me.Label_Attribute.AutoSize = True
        Me.Label_Attribute.Location = New System.Drawing.Point(12, 93)
        Me.Label_Attribute.Name = "Label_Attribute"
        Me.Label_Attribute.Size = New System.Drawing.Size(51, 13)
        Me.Label_Attribute.TabIndex = 10
        Me.Label_Attribute.Text = "Atributos:"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Action
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 243)
        Me.Controls.Add(Me.Label_Attribute)
        Me.Controls.Add(Me.CheckedListBox)
        Me.Controls.Add(Me.iniciar)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label_file_adress)
        Me.Controls.Add(Me.Label_What_to_do)
        Me.Controls.Add(Me.Label_folder_choosed)
        Me.Name = "Action"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Action"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label_folder_choosed As Label
    Friend WithEvents Label_What_to_do As Label
    Friend WithEvents Label_file_adress As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents iniciar As Button
    Friend WithEvents CheckedListBox As CheckedListBox
    Friend WithEvents Label_Attribute As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
End Class
