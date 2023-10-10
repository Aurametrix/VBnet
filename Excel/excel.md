Excel-based tool for building networks from surveys: http://partnertool.net/
explore network graphs with Excel: http://nodexl.codeplex.com/

Excel is Pretty Dang Cool
https://buttondown.email/hillelwayne/archive/excel-is-pretty-dang-cool/

[History of Pivot Tables](https://qz.com/1903322/why-pivot-tables-are-the-spreadsheets-most-powerful-tool)


    =FILTER(Stories!B2:D13,Stories!F2:F13=A2)
First parameter, "Stories!B2:D13" is a group of cells showing some stories.
Second parameter, "Stories!F2:F13=A2" is the column where each cell is compared to the value of A2. Rows that match are then copied into wherever the =FILTER formula is placed.



    =IF(NOT(ISBLANK(A2)),HYPERLINK("https://jira-instance.atlassian.net/browse/PROJECT-"&A2,"PROJECT-"&A2),"")
That says: If the cell A2 is not blank, append its value onto the url given, and show that as a link with the text PROJECT- with the value of A2 appended.

