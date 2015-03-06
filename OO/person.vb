Public Class Person
    Protected c_sFirstName as String
    Protected c_sLastName as String
    MustOverride ReadOnly Property ClassName() as String
      Get
        ClassName = "Person"
      End Get
    End Property
    NotOverridable ReadOnly Property BaseClassName() as String
      Get
        BaseClassName = "Person"
      End Get
    End Property
    Overidable Public Property FirstName() as String
    Get
      FirstName = c_sFirstName
    End Get
    Set(ByVal Value as string)
      c_sFirstName = Value
    End Set
  End Property
  Overidable Public Property LastName() as String
    Get
      LastName = c_sLastName
    End Get
    Set(ByVal Value as string)
      c_sLastName = Value
    End Set
  End Property
  Overridable Sub Speak()
    Console.WriteLine("I am " & c_sFirstName & " " & c_sLastName)
    Console.WriteLine(" and I am a Person.")
  End Sub
End Class
