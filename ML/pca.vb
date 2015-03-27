Imports System

Imports Extreme.Mathematics
Imports Extreme.Mathematics.LinearAlgebra.IO
Imports Extreme.Statistics
Imports Extreme.Statistics.Multivariate

Namespace Extreme.Numerics.QuickStart.VB

    ' Demonstrates how to use classes that implement
    ' Principal Component Analysis (PCA).
    Module PCAnalysis

        Sub Main()

            ' This QuickStart Sample demonstrates how to perform
            ' a principal component analysis on a set of data.
            '
            ' The classes used in this sample reside in the
            ' Extreme.Statistics.Multivariate namespace..

            ' First, our dataset, 'depress.txt', which is from
            '     Computer-Aided Multivariate Analysis, 4th Edition
            '     by A. A. Afifi, V. Clark and S. May, chapter 16
            '     See http:'www.ats.ucla.edu/stat/Stata/examples/cama4/default.htm

            ' The data is in delimited text format. Use a matrix reader to load it into a matrix.
            Dim reader As New DelimitedTextMatrixReader("..\..\..\..\Data\Depress.txt")
            reader.MergeConsecutiveDelimiters = True
            reader.SetColumnDelimiters(" "c)
            Dim m As Matrix = reader.ReadMatrix()

            ' The data we want is in columns 8 through 27:
            m = m.GetSubmatrix(0, m.RowCount - 1, 8, 27)

            ' 
            ' Principal component analysis
            '

            ' We can construct PCA objects in many ways. Since we have the data in a matrix,
            ' we use the constructor that takes a matrix as input.
            Dim pca As New PrincipalComponentAnalysis(m)
            ' and immediately perform the analysis:
            pca.Compute()

            ' We can get the contributions of each component:
            Console.WriteLine(" #    Eigenvalue Difference Contribution Contrib. %")
            For i As Integer = 0 To 4
                ' We get the ith component from the model...
                Dim component As PrincipalComponent = pca.Components(i)
                ' and write out its properties
                Console.WriteLine("{0,2}{1,12:F4}{1,11:F4}{2,14:F3}%{3,10:F3}%", _
                    i, component.Eigenvalue, component.EigenvalueDifference, _
                    100 * component.ProportionOfVariance, _
                    100 * component.CumulativeProportionOfVariance)
            Next

            ' To get the proportions for all components, use the
            ' properties of the PCA object:
            Dim proportions As Vector = pca.VarianceProportions

            ' To get the number of components that explain a given proportion
            ' of the variation, use the GetVarianceThreshold method:
            Dim count As Integer = pca.GetVarianceThreshold(0.9)
            Console.WriteLine("Components needed to explain 90% of variation: {0}", count)
            Console.WriteLine()

            ' The value property gives the components themselves:
            Console.WriteLine("Components:")
            Console.WriteLine("Var.      1       2       3       4       5")
            Dim pcs As PrincipalComponentCollection = pca.Components
            For i As Integer = 0 To pcs.Count - 1

                Console.WriteLine("{0,4}{1,8:F4}{2,8:F4}{3,8:F4}{4,8:F4}{5,8:F4}", _
                    i, pcs(0).Value(i), pcs(1).Value(i), pcs(2).Value(i), pcs(3).Value(i), pcs(4).Value(i))
            Next
            Console.WriteLine()

            ' The scores are the coefficients of the observations expressed as a combination
            ' of principal components.
            Dim scores As Matrix = pca.ScoreMatrix

            ' To get the predicted observations based on a specified number of components,
            ' use the GetPredictions method.
            Dim prediction As VariableCollection = pca.GetPredictions(count)
            Console.WriteLine("Predictions imports {0} components:", count)
            Console.WriteLine("   Pr. 1  Act. 1   Pr. 2  Act. 2   Pr. 3  Act. 3   Pr. 4  Act. 4", count)
            For i As Integer = 0 To 9
                Console.WriteLine("{0,8:F4}{1,8:F4}{2,8:F4}{3,8:F4}{4,8:F4}{5,8:F4}{6,8:F4}{7,8:F4}", _
                    prediction(0).GetValue(i), m(i, 0), _
                    prediction(1).GetValue(i), m(i, 1), _
                    prediction(2).GetValue(i), m(i, 2), _
                    prediction(3).GetValue(i), m(i, 3))
            Next

            Console.Write("Press any key to exit.")
            Console.ReadLine()
        End Sub
    End Module
End Namespace
