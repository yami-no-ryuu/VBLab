Public Class LabsForm

    Private Sub LabsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Globals.Init(My.Application.CommandLineArgs(0))

        ' Pokazat' na forme
        If Globals.Name <> "" Then
            Me.Text = Globals.Name
        End If

        For Each x In Labs
            LabsList.Items.Add(x.name)
        Next

        If Labs.Count > 0 Then
            LabsList.SetSelected(0, True)
        End If
    End Sub

    Private Sub StartBtn_Click(sender As Object, e As EventArgs) Handles StartBtn.Click
        Dim idx = LabsList.SelectedIndex

        If idx < 0 Then
            MsgBox("Vyberite rabotu")
        Else
            Dim lab = Labs(idx)
            ' Nuzhno otkryt' vtoruju formu dla samoj laby
            ViewWord(lab, "vvedenie.rtf")
        End If
    End Sub
End Class
