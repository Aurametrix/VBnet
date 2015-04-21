Imports System.Xml
Imports System.IO
Imports System.Text
Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim xmlNode As String = "
<?xml version='1.0'?>
" & _
                "
<!-- This is a sample XML document -->
" & _
                "
<Product>
" & _
                  "
<Product_id>1100</Product_id>
" & _
                   "
<Product_name>Windows 7</Product_name>
" & _
                   "
<Product_price>2000</Product_price>
" & _
               "
</Product>
"
        Dim xReader As XmlReader = XmlReader.Create(New StringReader(xmlNode))
        While xReader.Read()
            Select Case xReader.NodeType
                Case XmlNodeType.Element
                    ListBox1.Items.Add("<" + xReader.Name & ">")
                    Exit Select
                Case XmlNodeType.Text
                    ListBox1.Items.Add(xReader.Value)
                    Exit Select
                Case XmlNodeType.EndElement
                    ListBox1.Items.Add("")
                    Exit Select
            End Select
        End While
    End Sub
End Class
