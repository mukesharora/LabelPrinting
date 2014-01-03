using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;

namespace LabelPrinting
{
    public class PrintBatchJobRepository
    {
        public void UpdatePrintJobStatus(string printedBy, string printJobName, string printStatus)
        {
            Database database = DatabaseFactory.CreateDatabase();
            using (DbCommand dbCommand = database.GetSqlStringCommand("UPDATE PrintJob SET PrintStatus = @PrintStatus, PrintedOn = @PrintedOn, PrintedBy = @PrintedBy WHERE JobName = @JobName"))
            {
                database.AddInParameter(dbCommand, "@JobName", DbType.String, printJobName);
                database.AddInParameter(dbCommand, "@PrintStatus", DbType.String, printStatus);
                database.AddInParameter(dbCommand, "@PrintedOn", DbType.DateTime, DateTime.Now.ToUniversalTime());
                database.AddInParameter(dbCommand, "@PrintedBy", DbType.String, printedBy);
                database.ExecuteNonQuery(dbCommand);
            }
        }

        public void UpdatePrintJobDetailStatus(string printJobName, int assetTypeID, int assetID, bool success, string remarks)
        {
            Database database = DatabaseFactory.CreateDatabase();
            using (DbCommand dbCommand = database.GetSqlStringCommand("UPDATE PrintJobDetail SET Success = @Success,Remarks = @Remarks FROM PrintJobDetail PD INNER JOIN PrintJob P ON PD.FK_ID_PrintJob = P.ID  WHERE P.JobName = @JobName AND PD.FK_ID_AssetType = @FK_ID_AssetType AND PD.FK_ID_Asset = @FK_ID_Asset"))
            {
                database.AddInParameter(dbCommand, "@Success", DbType.Boolean, success);
                database.AddInParameter(dbCommand, "@Remarks", DbType.String, remarks);
                database.AddInParameter(dbCommand, "@JobName", DbType.String, printJobName);
                database.AddInParameter(dbCommand, "@FK_ID_AssetType", DbType.Int32, assetTypeID);
                database.AddInParameter(dbCommand, "@FK_ID_Asset", DbType.Int32, assetID);
                database.ExecuteNonQuery(dbCommand);
            }
        }

    }
}
