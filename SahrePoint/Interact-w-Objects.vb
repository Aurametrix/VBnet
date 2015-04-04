Using oSiteCollection As New SPSite("http://Server_Name")
    Using oWebsite As SPWeb = oSiteCollection.OpenWeb("Website_URL")
        Using oWebsiteRoot As SPWeb = oSiteCollection.RootWeb
            ...
        End Using
    End Using 
End Using
