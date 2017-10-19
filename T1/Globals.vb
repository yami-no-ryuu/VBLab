Imports System.Environment
Imports System.Text

Module Globals
    Private Const mainIniFile As String = "labs.ini"
    Private Const labIniFile As String = "lab.ini"
    Private Const wordViewer As String = "\Microsoft Office\OFFICE11\WORDVIEW.EXE"

    ' Sluzhebnyje
    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" _
(ByVal IpApplication As String, ByVal Ipkeyname As String,
ByVal IpString As String, ByVal IpFileName As String) As Integer

    Private Declare Auto Function GetPrivateProfileString Lib "Kernel32" _
(ByVal IpApplicationName As String, ByVal IpKeyName As String,
ByVal IpDefault As String, ByVal IPReturnedString As System.Text.StringBuilder,
ByVal nsize As Integer, ByVal IpFileName As String) As Integer
    ' -----

    Public Function GetIniValue(iniFile As String, key As String, Optional section As String = "Labs", Optional defVal As String = Nothing, Optional bufferSize As Integer = 255) _
      As String
        Dim buf As New StringBuilder(bufferSize)
        GetPrivateProfileString(section, key, defVal, buf, bufferSize, iniFile)
        Return buf.ToString
    End Function

    Public Sub ViewInBrowser(lab As LabInfo, file As String)
        Dim path = lab.FullPath + "\" + file

        If My.Computer.FileSystem.FileExists(path) Then
            Dim b As New WebBrowser()
            b.Navigate(path)
        End If
    End Sub

    Public Sub ViewWord(path As String)
        Shell("""" + GetFolderPath(SpecialFolder.ProgramFilesX86) + wordViewer + """ """ + path + """", AppWinStyle.NormalFocus)
    End Sub

    Class LabInfo
        Public ReadOnly name As String
        Public ReadOnly path As String
        Public ReadOnly simulator As String

        Public Sub New(dir As IO.DirectoryInfo, defSimulator As String)
            ' Sobiraem info
            Dim iniF As String = dir.FullName + "\" + labIniFile
            Dim sim = GetIniValue(iniF, "simulator")
            Dim name = GetIniValue(iniF, "name")
            Me.name = If(name = "", dir.Name, name)
            Me.simulator = If(sim = "", defSimulator, sim)
            Me.path = dir.Name
            ' etc etc
        End Sub

        Public Overrides Function ToString() As String
            Return "LabInfo {name=" + name +
                          ", path=" + FullPath() +
                          ", simulator=" + simulator +
                          "}"
        End Function

        Public Function FullPath()
            Return Globals.Path + "\" + Me.path
        End Function

        Public Sub ViewWord(fileName As String)
            Globals.ViewWord(FullPath() + "\" + fileName)
        End Sub
    End Class

    Private _labs As New List(Of LabInfo)
    Private _path As String
    Private _name As String
    Private _prefix As String = ""

    Public ReadOnly Property Labs As List(Of LabInfo)
        Get
            Return _labs
        End Get
    End Property

    Public ReadOnly Property Path As String
        Get
            Return _path
        End Get
    End Property

    Public ReadOnly Property Name As String
        Get
            Return _name
        End Get
    End Property

    Public Sub Init(labsPath As String)
        Dim fs = My.Computer.FileSystem
        Dim iniF = labsPath + "\" + mainIniFile

        If (Not fs.DirectoryExists(labsPath)) Or (Not fs.FileExists(iniF)) Then
            Throw New ArgumentException("Papka " + labsPath + " ne javlajetsa papkoj laboratornyh")
        End If
        _path = labsPath
        _prefix = GetIniValue(iniF, "prefix")

        Dim name = GetIniValue(iniF, "name")
        If (name = "") Then
            Debug.WriteLine("WARNING: Ne zadano imja nabora laboratornych")
        End If

        _name = name

        Dim defSimulator = GetIniValue(iniF, "simulator")
        If (defSimulator = "") Then
            Debug.WriteLine("WARNING: Ne zadan simulator")
        End If

        For Each x In fs.GetDirectories(labsPath)
            Dim dir = fs.GetDirectoryInfo(x)

            If dir.Name.StartsWith(_prefix) Then
                _labs.Add(New LabInfo(dir, defSimulator))
            End If
        Next
    End Sub
End Module
