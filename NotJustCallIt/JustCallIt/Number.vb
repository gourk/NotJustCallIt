Imports System.Text.RegularExpressions

Friend Class Number

#Region "Variables"
    Private _number As String
#End Region

#Region "Propriétés"
    Property Number() As String
        Get
            Return _number
        End Get
        Set(ByVal value As String)
            _number = value
        End Set
    End Property

    Public Property CountryCode() As String
        Get
            Return My.Settings.CountryCode
        End Get
        Set(ByVal value As String)
            My.Settings.CountryCode = value
        End Set
    End Property

    Public Property ExternalPrefix() As String
        Get
            Return My.Settings.ExternalPrefix
        End Get
        Set(ByVal value As String)
            My.Settings.ExternalPrefix = value
        End Set
    End Property

    Public Property NationalPrefix() As String
        Get
            Return My.Settings.NationalPrefix
        End Get
        Set(ByVal value As String)
            My.Settings.NationalPrefix = value
        End Set
    End Property

    Public Property InternationalPrefix() As String
        Get
            Return My.Settings.InternationalPrefix
        End Get
        Set(ByVal value As String)
            My.Settings.InternationalPrefix = value
        End Set
    End Property

    Public Property LastCall() As String
        Get
            Return My.Settings.LastCall
        End Get
        Set(ByVal value As String)
            My.Settings.LastCall = value
        End Set
    End Property
#End Region

#Region "Méthodes privées"
    Private Function chkIntlNumber(ByVal number As String) As Boolean
        Try
            Dim rg As New Regex("(^\+33\s*\d+)|(^\+32\s*\d+)|(^\+352\s*\d+)|(^\d+\s*\(\d+\))") ' +33 3 83449898 ou 33 (0)3 83449898
            If (rg.IsMatch(number)) And (number.Length < 25) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Source " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function chkNtlNumber(ByVal number As String) As Boolean
        Try
            Dim rg As New Regex("^0[1-9]")
            If (rg.IsMatch(number)) And (number.Length < 25) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Source " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function chkInternalNumber(ByVal number As String) As Boolean
        Try
            If (number.Length < 5) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Source " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function Cleaner(ByVal number As String) As String
        Try
            Dim rgClean As New Regex("\D")
            Return rgClean.Replace(_number, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Source " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "Error"
        End Try
    End Function
#End Region

#Region "Méthodes publiques"
    Public Function IsNumber() As Boolean
        Dim bInternational As Boolean
        Dim bNational As Boolean

        Try
            'check if international number format
            bInternational = chkIntlNumber(_number)
            'check if national number format
            bNational = chkNtlNumber(_number)

            If bInternational Or bNational Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Source " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Sub NormaliseNumber()
        Dim bInternational As Boolean
        Dim bInternal As Boolean
        Dim bNational As Boolean

        Try
            'check if international number format
            bInternational = chkIntlNumber(_number)
            'check if national number format
            bNational = chkNtlNumber(_number)
            'check if internal number format
            bInternal = chkInternalNumber(_number)

            If (bNational = True) Then
                _number = Cleaner(_number)
                _number = ExternalPrefix + _number
                LastCall = _number
            ElseIf (bInternational = True) Then
                _number = Cleaner(_number)
                _number = ExternalPrefix + InternationalPrefix + _number
                LastCall = _number
            ElseIf (bInternal = False) Then
                _number = Cleaner(_number)
                _number = ExternalPrefix + _number
                LastCall = _number
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Source " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Constructeur/Destructeur"
    Public Sub New(ByVal Number As String)
        _number = Number
    End Sub
#End Region

End Class
