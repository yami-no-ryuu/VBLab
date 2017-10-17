<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LabsForm
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
        Me.LabsList = New System.Windows.Forms.ListBox()
        Me.StartBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LabsList
        '
        Me.LabsList.FormattingEnabled = True
        Me.LabsList.Location = New System.Drawing.Point(0, 0)
        Me.LabsList.Name = "LabsList"
        Me.LabsList.Size = New System.Drawing.Size(494, 355)
        Me.LabsList.TabIndex = 0
        '
        'StartBtn
        '
        Me.StartBtn.Location = New System.Drawing.Point(534, 18)
        Me.StartBtn.Name = "StartBtn"
        Me.StartBtn.Size = New System.Drawing.Size(75, 23)
        Me.StartBtn.TabIndex = 1
        Me.StartBtn.Text = "Zapustit'"
        Me.StartBtn.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 356)
        Me.Controls.Add(Me.StartBtn)
        Me.Controls.Add(Me.LabsList)
        Me.Name = "LabsForm"
        Me.Text = "LabsForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabsList As ListBox
    Friend WithEvents StartBtn As Button
End Class
