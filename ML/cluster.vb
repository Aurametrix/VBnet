Imports System

Imports CenterSpace.NMath.Core
Imports CenterSpace.NMath.Stats

Namespace CenterSpace.NMath.Stats.Examples.VisualBasic

  ' A .NET example in Visual Basic showing how to perform a hierarchical cluster analysis on a data set.
  Module ClusterExample

    Sub Main()

      ' Class ClusterAnalysis perform hierarchical cluster analysis. Instances 
      ' are constructed from a matrix of data, where each row represents an object
      ' to be clustered. This code clusters 8 random vectors of length 3:
      Dim Data As New DoubleMatrix(8, 3, New RandGenUniform())

      Console.WriteLine()
      Console.WriteLine("Data =")
      Console.WriteLine(Data.ToTabDelimited("F5"))

      Dim CA As New ClusterAnalysis(Data)

      ' The N property gets the number of objects clustered:
      Console.WriteLine("Number of objects clustered = " & CA.N)
      Console.WriteLine()

      ' Distances between objects are computed using a Distance.Function delegate.
      ' The default distance delegates is Distance.EuclideanFunction. Property
      ' Distances gets the vector of distances between all possible object pairs,
      ' computed using the current distance delegate. For n objects, the distance
      ' vector is of length (n-1)(n/2), with distances arranged in the order:
      ' (1,2), (1,3), ..., (1,n), (2,3), ..., (2,n), ..., ..., (n-1,n)
      Console.WriteLine("Results using Euclidean distance and Single linkage...")
      Console.WriteLine()
      Console.WriteLine("Distances: ")
      Console.WriteLine(CA.Distances.ToString("F3"))
      Console.WriteLine()

      ' Distances between clusters of objects are computed using a Linkage.Function
      ' delegate. The default linkage delegate is Linkage.SingleFunction.
      ' The Linkages property gets the complete hierarchical linkage tree, computed
      ' from Distances using the current linkage delegate. At each level in the tree,
      ' Columns 1 and 2 contain the indices of the clusters linked to form the next
      ' cluster. Column 3 contains the distances between the clusters.
      Console.WriteLine("Linkages: ")
      Console.WriteLine(CA.Linkages.ToTabDelimited("F3"))

      ' The CopheneticDistances property gets the vector of cophenetic distances
      ' between all possible object pairs. The cophenetic distance between two
      ' objects is defined to be the intergroup distance when the objects are first
      ' combined into a single cluster in the linkage tree. The correlation between
      ' the original Distances and the CopheneticDistances is sometimes taken as a
      ' measure of appropriateness of a cluster analysis relative to the original data:
      Dim R As Double = StatsFunctions.Correlation(CA.Distances, CA.CopheneticDistances)
      Console.WriteLine("Cophenetic correlation = " & R)
      Console.WriteLine()

      ' Delegates are provided as static variables on class Distance for
      ' euclidean, squared euclidean, city-block (Manhattan), maximum (Chebychev),
      ' and power distance functions. Delegates are provided as static variables
      ' on class Linkage for single, complete, unweighted average, weighted average,
      ' centroid, median, and Ward's linkage functions. You can also easily create 
      ' your own distance or linkage functions. This code repeats the analysis using
      ' different distance and linkage delegates:
      CA.Update(Data, Distance.SquaredEuclideanFunction, Linkage.CompleteFunction)
      Console.WriteLine("Results using Squared Euclidean distance and Complete linkage...")
      Console.WriteLine()
      Console.WriteLine("Distances:")
      Console.WriteLine(CA.Distances.ToString("F3"))
      Console.WriteLine()
      Console.WriteLine("Linkages: ")
      Console.WriteLine(CA.Linkages.ToTabDelimited("F3"))

      ' The CutTree() method constructs a set of clusters by cutting the
      ' hierarchical linkage tree either at the specified height, or into the
      ' specified number of clusters. This code cuts the tree into 3 clusters:
      Console.WriteLine("CutTree() into 3 clusters...")
      Dim CS As ClusterSet = CA.CutTree(3)
      Console.WriteLine("Cluster each object is assigned to: " & CS.ToString())

      ' The indexer on ClusterSet gets the cluster to which a given object is
      ' assigned.
      Console.WriteLine("Object 0 is in cluster: " & CS(0))
      Console.WriteLine("Object 3 is in cluster: " & CS(3))

      ' The Cluster() method returns an array of integers indentifying the objects
      ' assigned to a given cluster.
      Dim Objects As Array = CS.Cluster(1)
      Console.Write("Objects in cluster 1: ")
      Dim I As Integer
      For I = 0 To Objects.Length - 1
        Console.Write(Objects(I) & " ")
      Next
      Console.WriteLine()

      Console.WriteLine()
      Console.WriteLine("Press Enter Key")
      Console.Read()

    End Sub

  End Module

End Namespace
