Imports System.IO
Imports Extreme.Mathematics
Imports Extreme.Mathematics.LinearAlgebra.IO
Imports Extreme.Statistics
Imports Extreme.Statistics.Tests

Namespace Extreme.Numerics.QuickStart.VB
    ' Illustrates building logistic regression models using 
    ' the LogisticRegressionModel class in the 
    ' Extreme.Statistics namespace of the Extreme
    ' Optimization Numerical Libraries for .NET.
    Module LogisticRegression

        Sub Main()
            ' Logistic regression can be performed using 
            ' the LogisticRegressionModel class.
            '
            ' This QuickStart sample uses data from a study of factors
            ' that determine low birth weight at Baystate Medical Center.
            ' from Belsley, Kuh and Welsch. The fields are as follows:
            '   AGE:  Mother's age.
            '   LWT:  Mother's weight.
            '   RACE: 1=white, 2=black, 3=other.
            '   FVT:  Number of physician visits during the 1st trimester.
            '   LOW:  Low birth weight indicator.

            ' First, read the data from a file into an ADO.NET DataTable. 
            ' For the sake of clarity, we put this code in its own method.
            Dim table As DataTable = ReadData()
            If table Is Nothing Then Exit Sub

            Dim data As VariableCollection = New VariableCollection(table)

            ' We need indicator variables for the race. We use the
            ' CreateIndicatorVariable method:
            Dim race As NumericalVariable = CType(data("RACE"), NumericalVariable)
            Dim race2 As NumericalVariable = race.CreateIndicatorVariable(2.0)
            data.Add(race2)
            Dim race3 As NumericalVariable = race.CreateIndicatorVariable(3.0)
            data.Add(race3)

            ' Now create the regression model. Parameters are the name 
            ' of the dependent variable, a string array containing 
            ' the names of the independent variables, and the VariableCollection
            ' containing all variables.
            Dim model As LogisticRegressionModel = New LogisticRegressionModel(data, "LOW", _
                New String() {"AGE", "LWT", "RACE(2)", "RACE(3)", "FTV"})

            ' The Compute method performs the actual regression analysis.
            model.Compute()

            ' The Parameters collection contains information about the regression 
            ' parameters.
            Console.WriteLine("Variable              Value    Std.Error  t-stat  p-Value")
            For Each parameter As Parameter In model.Parameters
                ' Parameter objects have the following properties:
                ' Name, usually the name of the variable:
                ' Estimated value of the parameter:
                ' Standard error:
                ' The value of the t statistic for the hypothesis that the parameter is zero.
                ' Probability corresponding to the t statistic.
                Console.WriteLine("{0,-20}{1,10:F5}{2,10:F5}{3,8:F2} {4,7:F4}", _
                    parameter.Name, _
                    parameter.Value, _
                    parameter.StandardError, _
                    parameter.Statistic, _
                    parameter.PValue)
            Next

            ' The log-likelihood of the computed solution is also available:
            Console.WriteLine("Log-likelihood: {0:F4}", model.GetLogLikelihood())

            ' We can test the significance by looking at the results
            ' of a log-likelihood test, which compares the model to
            ' a constant-only model:
            Dim lrt As SimpleHypothesisTest = model.GetLikelihoodRatioTest()
            Console.WriteLine("Likelihood-ratio test: chi-squared={0:F4}, p={1:F4}", lrt.Statistic, lrt.PValue)

            ' We can compute a model with fewer parameters:
            Dim model2 As LogisticRegressionModel = New LogisticRegressionModel(data, "LOW", _
                New String() {"LWT", "RACE(2)", "RACE(3)"})
            model2.Compute()

            ' Print the results...
            Console.WriteLine("Variable              Value    Std.Error  t-stat  p-Value")
            For Each parameter As Parameter In model2.Parameters
                Console.WriteLine("{0,-20}{1,10:F5}{2,10:F5}{3,8:F2} {4,7:F4}", _
                    parameter.Name, parameter.Value, parameter.StandardError, _
                    parameter.Statistic, parameter.PValue)
                ' ...including the log-likelihood:
            Next

            Console.WriteLine("Log-likelihood: {0:F4}", model.GetLogLikelihood())

            ' We can now compare the original model to this one, once again
            ' using the likelihood ratio test:
            lrt = model.GetLikelihoodRatioTest(model2)
            Console.WriteLine("Likelihood-ratio test: chi-squared={0:F4}, p={1:F4}", lrt.Statistic, lrt.PValue)


            '
            ' Multinomial (polytopous) logistic regression
            ' 

            ' The LogisticRegressionModel class can also be used
            ' for logistic regression with more than 2 responses.
            ' The following example is from "Applied Linear Statistical
            ' Models."

            ' Load the data into a matrix
            Dim reader As FixedWidthMatrixReader = New FixedWidthMatrixReader( _
                File.OpenText("..\..\..\Data\mlogit.txt"), _
                0, New Integer() {5, 10, 15, 20, 25, 32, 37, 42, 47}, _
                System.Globalization.NumberStyles.Integer, Nothing)
            Dim m As Matrix = reader.ReadMatrix()

            ' Next, convert the columns to variables.

            ' For multinomial regression, the response variable must be
            ' a CategoricalVariable:
            Dim duration As CategoricalVariable = _
                New NumericalVariable("duration", m.GetColumn(1)).ToCategoricalVariable()
            Dim nutritio As New NumericalVariable("nutritio", m.GetColumn(5))
            Dim agecat1 As New NumericalVariable("agecat1", m.GetColumn(6))
            Dim agecat3 As New NumericalVariable("agecat3", m.GetColumn(7))
            Dim alcohol As New NumericalVariable("alcohol", m.GetColumn(8))
            Dim smoking As New NumericalVariable("smoking", m.GetColumn(9))

            ' The constructor takes an extra argument of type
            ' LogisticRegressionMethod:
            Dim model3 As New LogisticRegressionModel(duration, _
                New NumericalVariable() {nutritio, agecat1, agecat3, alcohol, smoking}, _
                LogisticRegressionMethod.Nominal)

            ' Everything else is the same:
            model3.Compute()

            ' There is a set of parameters for each level of the
            ' response variable. The highest level is the reference 
            ' level and has no associated parameters.
            For Each p As Parameter In model3.Parameters
                Console.WriteLine(p.ToString())
            Next

            Console.WriteLine("Log likelihood: {0:F4}", model3.GetLogLikelihood())

            ' To test the hypothesis that all the slopes are zero,
            ' use the GetLikelihoodRatioTest method.
            lrt = model3.GetLikelihoodRatioTest()
            Console.WriteLine("Test that all slopes are zero: chi-squared={0:F4}, p={1:F4}", lrt.Statistic, lrt.PValue)

            Console.WriteLine("Press Enter key to continue.")
            Console.ReadLine()
        End Sub

        ' Reads the data from a text file into a <see cref="DataTable"/>.
        ' Returns a DataTable.
        Public Function ReadData() As DataTable
            Dim data As DataTable = New DataTable("savings")

            Dim whitespace As Char() = New Char() {" "c, Chr(9)}
            Dim sr As StreamReader
            Try
                sr = New StreamReader("..\..\..\Data\lowbwt.txt")
            Catch ex As FileNotFoundException
                Console.WriteLine("The data file could not be found. Please verify that the path is correct.")
                Return Nothing
            End Try

            ' Read the header and extract the field names.
            Dim line As String = sr.ReadLine()
            Dim pos As Integer = 0
            Dim pos2 As Integer
            Do
                Do While (Char.IsWhiteSpace(line.Chars(pos)))
                    pos = pos + 1
                Loop
                pos2 = line.IndexOfAny(whitespace, pos)
                If (pos2 < 0) Then
                    data.Columns.Add(line.Substring(pos), GetType(Double))
                    Exit Do
                Else
                    data.Columns.Add(line.Substring(pos, pos2 - pos), GetType(Double))
                End If
                pos = pos2
            Loop While (pos >= 0)

            ' Now read the data and add them to the table.
            ' Assumes all columns except the first are numerical.
            Dim rowData As Object() = New Object(data.Columns.Count - 1) {}
            line = sr.ReadLine()
            Do While (Not (line Is Nothing) AndAlso line.Length > 0)

                Dim column As Integer = 0
                pos = 0
                Do
                    Dim field As String
                    Do While (Char.IsWhiteSpace(line.Chars(pos)))
                        pos = pos + 1
                    Loop
                    pos2 = line.IndexOfAny(whitespace, pos)
                    If (pos2 < 0) Then
                        field = line.Substring(pos)
                    Else
                        field = line.Substring(pos, pos2 - pos)
                    End If
                    If (column = 0) Then
                        rowData(column) = field
                    Else
                        rowData(column) = Double.Parse(field)
                    End If
                    column = column + 1
                    pos = pos2
                Loop While (pos >= 0 And column < data.Columns.Count)

                data.Rows.Add(rowData)
                line = sr.ReadLine()
            Loop
            Return data
        End Function
    End Module

End Namespace
