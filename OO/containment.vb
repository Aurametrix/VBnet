Private c_oDog as Dog
Public Property MyDog() as Dog
  Get
    MyDog = c_oDog
  End Get
End Property
Public Sub GetADog(ByVal Breed as String, ByVal Name as String)
  c_oDog = New Dog(Breed,Name)
End Sub
