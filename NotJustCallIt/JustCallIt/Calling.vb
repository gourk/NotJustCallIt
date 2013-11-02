Imports System.Net

Friend Class Calling

#Region "Variables"
    Private _cookie As CookieCollection
#End Region

#Region "Propriétés"
    Public Property PbxIp() As String
        Get
            Return My.Settings.PbxAdressIP
        End Get
        Set(ByVal value As String)
            My.Settings.PbxAdressIP = value
        End Set
    End Property

    Public Property UserNum() As String
        Get
            Return My.Settings.UserNum
        End Get
        Set(ByVal value As String)
            My.Settings.UserNum = value
        End Set
    End Property

    Public Property UserPwd() As String
        Get
            Return My.Settings.UserPwd
        End Get
        Set(ByVal value As String)
            My.Settings.UserPwd = value
        End Set
    End Property
#End Region

#Region "Méthodes privées"
    Private Function Get_request(ByVal url As String, Optional ByVal proxy As String = Nothing, Optional ByVal proxyport As Integer = Nothing, Optional ByVal timeout As Integer = 30000, Optional ByVal login As String = "", Optional ByVal pass As String = "") As String
        Dim reader As IO.StreamReader
        Dim res As String = ""
        Try
            'Création de la requête web
            Dim hwebrequest As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(url)
            hwebrequest.Timeout = timeout
            If proxy <> "" Then
                Dim hproxy As WebProxy
                hproxy = New WebProxy(proxy, proxyport)
                WebRequest.DefaultWebProxy = hproxy
            End If
            If login <> "" Then
                Dim hcredential As New System.Net.NetworkCredential(login, pass)
                hwebrequest.Credentials = hcredential
            End If
            'Préparation cookie
            hwebrequest.CookieContainer = New CookieContainer
            
            Dim cook As Cookie
            For Each cook In _cookie
                hwebrequest.CookieContainer.Add(cook)
                hwebrequest.Headers.Add(HttpRequestHeader.Cookie, cook.ToString)
            Next
            'Envoi et récupération de la réponse
            Dim hwebresponse As System.Net.HttpWebResponse = hwebrequest.GetResponse
            reader = New IO.StreamReader(hwebresponse.GetResponseStream)
            res = reader.ReadToEnd()
            reader.Close()
            hwebresponse.Close()
            Return res
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function

    Private Function Post_request(ByVal url As String, ByVal data As String, Optional ByVal cookies As String = "", Optional ByVal proxy As String = Nothing, Optional ByVal proxyport As Integer = Nothing, Optional ByVal timeout As Integer = 30000, Optional ByVal login As String = "", Optional ByVal pass As String = "") As String
        Dim reader As IO.StreamReader
        Dim writer As IO.StreamWriter
        Dim res As String = ""
        Try
            'Création de la requête web
            Dim hwebrequest As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(url)
            If proxy <> "" Then
                Dim hproxy As WebProxy
                hproxy = New WebProxy(proxy, proxyport)
                WebRequest.DefaultWebProxy = hproxy
            End If
            If login <> "" Then
                Dim hcredential As New System.Net.NetworkCredential(login, pass)
                hwebrequest.Credentials = hcredential
            End If
            If cookies <> "" Then
                hwebrequest.CookieContainer = New CookieContainer
                hwebrequest.CookieContainer.SetCookies(New Uri(url.Substring(0, url.IndexOf("/", 8))), cookies)
            End If
            'Paramétrage de la requête
            hwebrequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.5; Windows NT 4.0)"
            hwebrequest.Method = "POST"
            hwebrequest.ContentType = "application/x-www-form-urlencoded"
            hwebrequest.ContentLength = data.Length
            hwebrequest.CookieContainer = New CookieContainer()
            'Envoi de la requête
            writer = New IO.StreamWriter(hwebrequest.GetRequestStream) 'on crée un objet streamwriter qui va nous permettre d'envoyer nos données
            writer.Write(data)
            writer.Close()
            'Récupération de la réponse
            Dim hwebresponse As System.Net.HttpWebResponse = hwebrequest.GetResponse
            reader = New IO.StreamReader(hwebresponse.GetResponseStream)
            res = reader.ReadToEnd()
            reader.Close()
            'Récupération des cookies lié à la réponse
            _cookie = hwebresponse.Cookies
            Return res
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function
#End Region

#Region "Méthodes publiques"
    Public Sub StartCall(ByVal Number As String)
        Dim url As String
        'Authentification
        Try
            url = "http://" + My.Settings.PbxAdressIP + "/cgi/com/authModule"
            Dim postData As String = "Method=Login&user=" + My.Settings.UserNum + "&passwd=" + My.Settings.UserPwd
            Dim Reponse As String = Post_request(url, postData)
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Source " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'Calling
        Try
            url = "http://" + My.Settings.PbxAdressIP + "/cgi/usr/ctgModule?Method=CtiRequest&user=" + My.Settings.UserNum + "&cmd=MC" + Number
            Dim Reponse As String = Get_request(url)
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Source " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Constructeur/Destructeur"
#End Region

End Class
