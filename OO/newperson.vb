Public Class NewPerson
  Inherits Person
  MustOverride Overrides Public ReadOnly Property ClassName() as String
    Get
      ClassName = "NewPerson"
    End Get
  End Property
  Overrides Sub Speak()
    Console.WriteLine("My name is " & c_sFirstName & " " & c_sLastName)
    Console.WriteLine(" and I am a new person.")
  End Sub
End Public
