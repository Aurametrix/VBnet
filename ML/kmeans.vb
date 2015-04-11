
Imports CenterSpace.NMath.Core
Imports CenterSpace.NMath.Stats

Namespace CenterSpace.NMath.Stats.Examples.VisualBasic

  ' A .NET example in Visual Basic showing how to perform a k-means cluster analysis on a data set.
  Module KMeansClusteringExample

    Sub Main()

      ' Class KMeansClustering performs k-means clustering on a set of data points.
      ' Instances are constructed from a matrix of data, where each row represents
      ' an object to be clustered. This code clusters 30 random vectors of length 3:
      Dim Data As New DoubleMatrix(12, 3, New RandGenUniform())
      Dim KM As New KMeansClustering(Data)

      Console.WriteLine()
      Console.WriteLine("{0} objects to cluster:", KM.N)
      Console.WriteLine(Data.ToTabDelimited("G7"))

      ' The Cluster() method clusters the data into the specified number
      ' of clusters. This code creates 3 clusters, using random starting
      ' cluster centers
      KM.Cluster(3)
      DisplayKMeansResults(KM, "K-MEANS CLUSTERING WITH RANDOM STARTING CENTERS")

      ' This code specifies the starting centers. K is inferred from the
      ' number of rows in the matrix.
      Dim Centers As New DoubleMatrix("3x3[ 0.25 0.25 0.25  0.50 0.50 0.50  0.75 0.75 0.75]")
      KM.Cluster(Centers)
      DisplayKMeansResults(KM, "K-MEANS CLUSTERING WITH SPECIFIED STARTING CENTERS")

      Console.WriteLine("Press Enter Key")
      Console.Read()

    End Sub

    ' Display the results of a k-means clustering
    Sub DisplayKMeansResults(ByVal KM As KMeansClustering, ByVal Title As String)

      Console.WriteLine()
      Console.WriteLine(Title)
      Console.WriteLine()

      Console.WriteLine("{0} clusters of sizes {1}", KM.K, IntArrayToString(KM.Sizes))
      Console.WriteLine()

      Console.WriteLine("Initial cluster centers:")
      Console.WriteLine(KM.InitialCenters.ToTabDelimited())

      Console.WriteLine("{0} iterations", KM.Iterations)
      Console.WriteLine("Stopped because max iterations of {0} met? {1}", KM.MaxIterations, KM.MaxIterationsMet)
      Console.WriteLine()

      Console.WriteLine("Final cluster centers:")
      Console.WriteLine(KM.FinalCenters.ToTabDelimited())

      Console.WriteLine("Clustering assignments:")
      Console.WriteLine(IntArrayToString(KM.Clusters))
      Console.WriteLine()

      Console.WriteLine("Within cluster sum of squares by cluster:")
      Console.WriteLine(KM.WithinSumOfSquares.ToString())
      Console.WriteLine()
    End Sub

    ' Convert an integer array to a string
    Function IntArrayToString(ByRef IntArray As Integer()) As String
      Dim Sarray = Array.ConvertAll(Of Integer, String)(IntArray, New Converter(Of Integer, String)(AddressOf Convert.ToString))
      Return String.Join(", ", Sarray)

    End Function

  End Module

End Namespace
