Imports System

Imports Extreme.Statistics
Imports Extreme.Statistics.Multivariate

Namespace Extreme.Numerics.QuickStart.VB

    ' <summary>
    ' Demonstrates how to use classes that implement
    ' hierarchical and K-means clustering.
    ' </summary>
    Module ClusterAnalysis

        Sub Main()
            ' This QuickStart Sample demonstrates how to run two
            ' common multivariate analysis techniques:
            ' hierarchical cluster analysis and K-means cluster analysis.
            '
            ' The classes used in this sample reside in the
            ' Extreme.Statistics.Multivariate namespace..

            ' First, our dataset, which is from
            '     Computer-Aided Multivariate Analysis, 4th Edition
            '     by A. A. Afifi, V. Clark and S. May, chapter 16
            '     See http:'www.ats.ucla.edu/stat/Stata/examples/cama4/default.htm
            Dim ror5 As New NumericalVariable("ror5", New Double() _
                {13.0, 13.0, 13.0, 12.2, 10.0, 9.8, 9.9, 10.3, 9.5, 9.9, 7.9, 7.3, 7.8, _
                    6.5, 9.2, 8.9, 8.4, 9.0, 12.9, 15.2, 18.4, 9.9, 9.9, 10.2, 9.2})
            Dim de As New NumericalVariable("de", New Double() _
                {0.7, 0.7, 0.4, 0.2, 0.4, 0.5, 0.5, 0.3, 0.4, 0.4, 0.4, 0.6, 0.4, _
                    0.4, 2.7, 0.9, 1.2, 1.1, 0.3, 0.7, 0.2, 1.6, 1.1, 0.5, 1.0})
            Dim salesgr5 As New NumericalVariable("salesgr5", New Double() _
                {20.2, 17.2, 14.5, 12.9, 13.6, 12.1, 10.2, 11.4, 13.5, 12.1, 10.8, 15.4, 11.0, _
                    18.7, 39.8, 27.8, 38.7, 22.1, 16.0, 15.3, 15.0, 9.6, 17.9, 12.6, 11.6})
            Dim eps5 As New NumericalVariable("eps5", New Double() _
                {15.5, 12.7, 15.1, 11.1, 8.0, 14.5, 7.0, 8.7, 5.9, 4.2, 16.0, 4.9, 3.0, _
                    -3.1, 34.4, 23.5, 24.6, 21.9, 16.2, 11.6, 11.6, 24.3, 15.3, 18.0, 4.5})
            Dim npm1 As New NumericalVariable("npm1", New Double() _
                {7.2, 7.3, 7.9, 5.4, 6.7, 3.8, 4.8, 4.5, 3.5, 4.6, 3.4, 5.1, 5.6, _
                    1.3, 5.8, 6.7, 4.9, 6.0, 5.7, 1.5, 1.6, 1.0, 1.6, 0.9, 0.8})
            Dim pe As New NumericalVariable("pe", New Double() _
                {9.0, 8.0, 8.0, 9.0, 5.0, 6.0, 10.0, 9.0, 11.0, 9.0, 7.0, 7.0, 7.0, _
                    10.0, 21.0, 22.0, 19.0, 19.0, 14.0, 8.0, 9.0, 6.0, 8.0, 6.0, 7.0})
            Dim payoutr1 As New NumericalVariable("payoutr1", New Double() _
                {0.426398, 0.380693, 0.40678, 0.568182, 0.324544, 0.5108083, 0.378913, _
                    0.481928, 0.573248, 0.490798, 0.48913, 0.272277, 0.315646, 0.384, _
                    0.390879, 0.16129, 0.30303, 0.303318, 0.2875, 0.59893, 0.578313, _
                    0.194946, 0.32107, 0.453731, 0.594966})
            Dim variables As NumericalVariable() = {ror5, de, salesgr5, eps5, npm1, pe, payoutr1}
            Dim collection As New VariableCollection(variables)

            ' 
            ' Hierarchical cluster analysis
            '

            Console.WriteLine("Hierarchical clustering")

            ' Create the model:
            Dim hc As New HierarchicalClusterAnalysis(variables)
            ' Rescale the variables to their Z-scores before doing the analysis:
            hc.Standardize = True
            ' The linkage method defaults to centroid:
            hc.LinkageMethod = LinkageMethod.Centroid
            ' We could set the distance measure. We use the default:
            hc.DistanceMeasure = DistanceMeasures.SquaredEuclidianDistance

            ' Compute the model:
            hc.Compute()

            ' We can partition the cases into clusters:
            Dim partition As HierarchicalClusterCollection = hc.GetClusterPartition(5)
            ' Individual clusters are accessed through an index, or through enumeration.            
            For Each cluster As HierarchicalCluster In partition
                Console.WriteLine("Cluster {0} has {1} members.", cluster.Index, cluster.Size)
            Next

            ' And get a filter for the observations in a single cluster:
            collection.Filter = partition(3).MemberFilter
            Console.WriteLine("Number of items in filtered collection: {0}", collection.Observations.Count)
            collection.Filter = Nothing

            ' Get a variable that shows memberships:
            Dim memberships As CategoricalVariable = partition.GetMemberships()
            For i As Integer = 15 To memberships.Length - 1
                Console.WriteLine("Observation {0} belongs to cluster {1}", i, memberships.GetLevelIndex(i))
            Next i

            ' A dendrogram is a graphical representation of the clustering in the form of a tree.
            ' You can get all the information you need to draw a dendrogram starting from 
            ' the root node of the dendrogram:
            Dim root As DendrogramNode = hc.DendrogramRoot
            ' Position and DistanceMeasure give the x and y coordinates:
            Console.WriteLine("Root position: ({0:F4}, {1:F4})", root.Position, root.DistanceMeasure)
            ' The left and right children:
            Console.WriteLine("Position of left child: {0:F4}", root.LeftChild.Position)
            Console.WriteLine("Position of right child: {0:F4}", root.RightChild.Position)

            ' You can also get a filter that defines a sort order suitable for
            ' drawing the dendrogram:
            Dim sortOrder As Filter = hc.GetDendrogramOrder()
            Console.WriteLine()

            '
            ' K-Means Clustering
            '

            Console.WriteLine("K-means clustering")

            ' Create the model. We need to specify the number of clusters up front:
            Dim kmc As New KMeansClusterAnalysis(variables, 3)
            ' Rescale the variables to their Z-scores before doing the analysis:
            kmc.Standardize = True

            ' Compute the model:
            kmc.Compute()

            ' We can partition the cases into clusters:
            Dim clusters As KMeansClusterCollection = kmc.GetClusters()
            ' Individual clusters are accessed through an index, or through enumeration.            
            For Each cluster As KMeansCluster In clusters

                Console.WriteLine("Cluster {0} has {1} members. Sum of squares: {2:F4}", _
                    cluster.Index, cluster.Size, cluster.SumOfSquares)
                Console.WriteLine("Center: {0:F4}", cluster.Center)
            Next

            ' The distances between clusters are also available:
            Console.WriteLine(kmc.GetClusterDistances().ToString("F4"))

            ' You can get a filter for the observations in a single cluster:
            collection.Filter = clusters(1).MemberFilter
            Console.WriteLine("Number of items in filtered collection: {0}", collection.Observations.Count)

            ' Get a variable that shows memberships:
            memberships = clusters.GetMemberships()
            ' And one that shows the distances to the centers:
            Dim distances As NumericalVariable = clusters.GetDistancesToCenters()
            For i As Integer = 18 To memberships.Length - 1
                Console.WriteLine("Observation {0} belongs to cluster {1}, distance: {2:F4}.", _
                    i, memberships.GetLevelIndex(i), distances(i))
            Next

            Console.Write("Press any key to exit.")
            Console.ReadLine()
        End Sub

    End Module

End Namespace
