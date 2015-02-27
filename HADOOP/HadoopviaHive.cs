private void GetDataFromHive(){
   var conn = new OdbcConnection
                  {
                      ConnectionString = @"DRIVER={Microsoft Hive ODBC Driver};                                        
                                        Host=server_name;
                                        Port=10000;
                                        Schema=default;
                                        DefaultTable=table_name;
                                        HiveServerType=1;
                                        ApplySSPWithQueries=1;
                                        AsyncExecPollInterval=100;
                                        AuthMech=0;
                                        CAIssuedCertNamesMismatch=0;
                                        TrustedCerts=C:\Program Files\Microsoft Hive ODBC Driver\lib\cacerts.pem;"
                  };
    try 
    {
        conn.Open();

        var adp = new OdbcDataAdapter("Select * from table_name limit 10", conn); 
        var ds = new DataSet();
        adp.Fill(ds);

        foreach (var table in ds.Tables)  
        {
            var dataTable = table as DataTable;

            if (dataTable == null)
                continue;

            var dataRows = dataTable.Rows;

            if (dataRows == null)
                continue;

            //log.Info("Records found " + dataTable.Rows.Count);

            foreach (var row in dataRows)
            {
                var dataRow = row as DataRow;
                if (dataRow == null)
                    continue;

                //log.Info(dataRow[0].ToString() + " " + dataRow[1].ToString());
            }
        }

    }
    catch (Exception ex)
    {
       // log.Info("Failed to connect to data source");
    }
    finally
    {
        conn.Close();
    }
} 
