Public Class Available_Statistics
    Dim spssProbs As CreateSPSSProblems
    Public Sub New(ByVal app As CreateSPSSProblems)
        spssProbs = app
    End Sub
    Public Sub GetStatList(ByVal lb As ListBox)
        lb.Items.Add("Level of Measurement")
        lb.Items.Add("Percentiles and Zscores")
        'lb.Items.Add("Frequency Distribution - Reading Tables")
        'lb.Items.Add("Frequency Distribution - Interpretation")
        lb.Items.Add("Frequency Distribution - Probability")
        lb.Items.Add("Describing the Sample")
        lb.Items.Add("ComparingCentralTendencyVariability")

        'lb.Items.Add("Preferred Measure of Central Tendency")
        'lb.Items.Add("Preferred Measure of Variability")
        'lb.Items.Add("Measures of Central Tendency")
        'lb.Items.Add("Measures of Variability")
        lb.Items.Add("One Sample T-Test of Population Mean")
        lb.Items.Add("Chi-square Goodness of Fit")
        lb.Items.Add("Two Sample T-Test")
        lb.Items.Add("Paired-Samples T-Test")
        lb.Items.Add("Mann-Whitney U Test")
        lb.Items.Add("Chi-square test of independence")

        ''' not in SPSS lb.Items.Add("One Sample T-Test of Population Median")
        'lb.Items.Add("Crosstabulation")
        'lb.Items.Add("Elaboration of Bivariate Tables")
        'lb.Items.Add("Lambda")
        'lb.Items.Add("Gamma")
        'lb.Items.Add("Comparing Central Tendency and Variability")
        'lb.Items.Add("Probability of a sample mean")
        'lb.Items.Add("Estimation")
        'lb.Items.Add("Comparing groups with confidence intervals")
        'lb.Items.Add("Chi-square test of independence specific relationship")
        ' lb.Items.Add("One-way ANOVA")
        lb.Items.Add("One-way ANOVA with Post Hoc Test")
        lb.Items.Add("Correlation and Regression")
        lb.Items.Add("SW388R6 Problems")
        'lb.Items.Add("Multiple Regression - SW318")
        'lb.Items.Add("-----------------------------------------------------------")

        'lb.Items.Add("Missing Data Analysis")
        'lb.Items.Add("Missing Data Analysis - Summary Question")
        'lb.Items.Add("Univariate Outliers")
        'lb.Items.Add("Multivariate Outliers")
        'lb.Items.Add("Outliers - Summary Question")
        'lb.Items.Add("Assumption of Normality")
        'lb.Items.Add("Assumption of Linearity")
        'lb.Items.Add("Multivariate Assumptions - Summary Question")
        'lb.Items.Add("Assumption of Homoscedasticity")
        'lb.Items.Add("Principal Components - Basic Relationships")
        lb.Items.Add("Principal Components - Basic Summary")
        'lb.Items.Add("Principal Components - Complete Problems")
        lb.Items.Add("Principal Components - Complete Summary")

        'lb.Items.Add("Multiple Regression - Hierarchical Problems")
        'lb.Items.Add("Multiple Regression - Stepwise Problems")
        lb.Items.Add("Simple Linear Regression - Basic Relationship")
        lb.Items.Add("Simple Linear Regression - Testing Assumptions")
        lb.Items.Add("Simple Linear Regression - Satisfying Assumptions")
        lb.Items.Add("Multiple Regression - Basic Summary")
        lb.Items.Add("Multiple Regression - Complete Summary")
        lb.Items.Add("Multiple Regression - Complete Standard Summary")

        lb.Items.Add("Standard Multiple Regression with Dummy Variables")
        lb.Items.Add("Hierarchical Multiple Regression with Dummy Variables")
        lb.Items.Add("Stepwise Multiple Regression with Dummy Variables")

        lb.Items.Add("Standard Binary Logistic Regression")
        lb.Items.Add("Hierarchical Binary Logistic Regression")
        lb.Items.Add("Stepwise Binary Logistic Regression")


        lb.Items.Add("GLM - T-test")
        lb.Items.Add("GLM - One-way ANOVA")
        lb.Items.Add("GLM - Multiple Regression")
        lb.Items.Add("GLM - Multiple Regression with Factor")

        lb.Items.Add("Two Factor ANOVA")
        lb.Items.Add("Two Factor ANCOVA")
        lb.Items.Add("Repeated Measures ANOVA")
        lb.Items.Add("Mixed Models ANOVA")
        'lb.Items.Add("Multiple Regression - Complete Hierarchical Summary")
        'lb.Items.Add("Multiple Regression - Complete Stepwise Summary")
        'lb.Items.Add("Multiple Regression - Basic Relationships")
        'lb.Items.Add("Multiple Regression - Complete Problems")

        'lb.Items.Add("Discriminant Analysis - Basic Relationships - Standard")
        'lb.Items.Add("Discriminant Analysis - Basic Relationships - Stepwise")
        'lb.Items.Add("Discriminant Analysis - Complete Problems - Standard")
        'lb.Items.Add("Discriminant Analysis - Complete Problems - Stepwise")

        'lb.Items.Add("Discriminant Analysis - Basic Standard Summary")
        'lb.Items.Add("Discriminant Analysis - Basic Stepwise Summary")
        'lb.Items.Add("Discriminant Analysis - Complete Standard Summary")
        'lb.Items.Add("Discriminant Analysis - Complete Stepwise Summary")

        'lb.Items.Add("Binary Logistic Regression - Basic Problems - Standard")
        'lb.Items.Add("Binary Logistic Regression - Basic Problems - Hierarchical")
        'lb.Items.Add("Binary Logistic Regression - Basic Problems - Stepwise")

        'lb.Items.Add("Binary Logistic Regression - Basic Summary - Standard")
        'lb.Items.Add("Binary Logistic Regression - Basic Summary - Hierarchical")
        'lb.Items.Add("Binary Logistic Regression - Basic Summary - Stepwise")

        lb.Items.Add("Binary Logistic Regression - Complete Problems - Standard")
        lb.Items.Add("Binary Logistic Regression - Complete Problems - Hierarchical")
        lb.Items.Add("Binary Logistic Regression - Complete Problems - Stepwise")
        lb.Items.Add("Multinomial Logistic Regression - Basic Relationships")


    End Sub

End Class
