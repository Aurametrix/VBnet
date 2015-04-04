Partial Class _Default
    Inherits System.Web.UI.Page
 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
 
        Dim wsUserProfiles As wsUP.UserProfileService = New wsUP.UserProfileService
        wsUserProfiles.Credentials = System.Net.CredentialCache.DefaultCredentials
 
        Dim numProfiles As Integer = CType(wsUserProfiles.GetUserProfileCount, Integer)
 
        For i As Integer = 0 To numProfiles
 
            Dim profileIndex As wsUP.GetUserProfileByIndexResult = wsUserProfiles.GetUserProfileByIndex(i)
 
            'Login Name
            Response.Write(profileIndex.UserProfile(1).Values(0).Value)
 
            'First Name
            Response.Write(profileIndex.UserProfile(2).Values(0).Value)
 
            'Last Name
            Response.Write(profileIndex.UserProfile(3).Values(0).Value)
 
        Next
 
    End Sub
 
End Class
