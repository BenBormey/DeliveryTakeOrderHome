//using DeliveryTakeOrder.ApplicationFrameworks;
//using DeliveryTakeOrder.DatabaseFrameworks;
//using DeliveryTakeOrder.Declares;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace DeliveryTakeOrder.Classes
//{
//      public class ClsDeliveryTakeOrder
//    {
//        private string query;
//        private DatabaseFramework Data = new DatabaseFramework();
//        private ApplicationFramework App = new ApplicationFramework();
//        private DatabaseFramework_MySQL MyData = new DatabaseFramework_MySQL();
//        private string DatabaseName;


//        public ClsDeliveryTakeOrder()
//        {

//        }

//        public  bool CheckNewCodeForCustomer(string CmbProducts , string CmbBillTo)
//        {
//            bool IsNewCode = false;
//            string query = @"
//DECLARE @Barcode AS NVARCHAR(MAX) = '{1}';
//DECLARE @CusNum AS NVARCHAR(8) = '{2}';
//SELECT [Id], [OldProNumy], [ProName], [ProPackSize], [NewProNumy], [Delto], [Telephone], [CusNum]
//FROM [Stock].[dbo].[TPRProductNewCodeAlert]
//WHERE ([OldProNumy] = @Barcode OR [NewProNumy] = @Barcode) AND [CusNum] = @CusNum;
//";
//            query = string.Format(query, DatabaseName, CmbProducts, CmbBillTo);
//            DataTable lists = Data.Selects(query, Initialized.GetConnectionType(Data, App));
//            if (lists != null && lists.Rows.Count > 0)
//            {
//                IsNewCode = true;
//            }
//            return IsNewCode;
//        }
        
//        public void CustomerLoadingManually(string Programname)
//        {
//            if (Programname.Equals("Sale_Team"))
//            {
//                this.query = @"
//                   DECLARE @distributorId NVARCHAR(MAX) = N'{3}';

//IF (
//       (@distributorId IS NULL)
//       OR (@distributorId = N'')
//       OR (@distributorId = N'( select all )')
//   )
//    SET @distributorId = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);

//SET @distributorId = CASE
//                         WHEN RIGHT(@distributorId, 1) = N',' THEN
//                             @distributorId
//                         ELSE
//                             CONCAT(@distributorId, N',')
//                     END;
//DECLARE @distributorIdList AS TABLE
//(
//    [distributorId] UNIQUEIDENTIFIER NULL
//);
//WITH distributorIdList ([distributorId], [items])
//AS (SELECT LEFT(@distributorId, CHARINDEX(N',', @distributorId) - 1) [distributorId],
//           STUFF(@distributorId, 1, CHARINDEX(N',', @distributorId), N'') [items]
//    UNION ALL
//    SELECT LEFT([items], CHARINDEX(N',', [items]) - 1) [distributorId],
//           STUFF([items], 1, CHARINDEX(N',', [items]), N'') [items]
//    FROM distributorIdList
//    WHERE [items] <> N'')
//INSERT INTO @distributorIdList
//(
//    [distributorId]
//)
//SELECT [distributorId]
//FROM distributorIdList
//GROUP BY [distributorId]
//OPTION (MAXRECURSION 32767);

//WITH customerList
//AS (SELECT [lc].[CusNum],
//           [lc].[CusName]
//    FROM [Stock].[dbo].[TPRCustomer] lc
//    WHERE ([lc].[Status] = 'Activate')
//          AND ([lc].[CusName] LIKE 'YN %')
//          AND
//          (
//              ([lc].[distributorUnderId] IN
//               (
//                   SELECT [distributorId] FROM @distributorIdList GROUP BY [distributorId]
//               )
//              )
//              OR (CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)IN
//                  (
//                      SELECT [distributorId] FROM @distributorIdList GROUP BY [distributorId]
//                  )
//                 )
//          ))
//SELECT [lc].[CusNum],
//       [lc].[CusName]
//FROM customerList lc
//GROUP BY [lc].[CusNum],
//         [lc].[CusName]
//ORDER BY [lc].[CusName];
//                ";
//            }
//            else
//            {
//                this.query = @"DECLARE @distributorId NVARCHAR(MAX) = N'{3}';

//IF (
//       (@distributorId IS NULL)
//       OR (@distributorId = N'')
//       OR (@distributorId = N'( select all )')
//   )
//    SET @distributorId = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);

//SET @distributorId = CASE
//                         WHEN RIGHT(@distributorId, 1) = N',' THEN
//                             @distributorId
//                         ELSE
//                             CONCAT(@distributorId, N',')
//                     END;
//DECLARE @distributorIdList AS TABLE
//(
//    [distributorId] UNIQUEIDENTIFIER NULL
//);
//WITH distributorIdList ([distributorId], [items])
//AS (SELECT LEFT(@distributorId, CHARINDEX(N',', @distributorId) - 1) [distributorId],
//           STUFF(@distributorId, 1, CHARINDEX(N',', @distributorId), N'') [items]
//    UNION ALL
//    SELECT LEFT([items], CHARINDEX(N',', [items]) - 1) [distributorId],
//           STUFF([items], 1, CHARINDEX(N',', [items]), N'') [items]
//    FROM distributorIdList
//    WHERE [items] <> N'')
//INSERT INTO @distributorIdList
//(
//    [distributorId]
//)
//SELECT [distributorId]
//FROM distributorIdList
//GROUP BY [distributorId]
//OPTION (MAXRECURSION 32767);

//WITH customerList
//AS (SELECT [lc].[CusNum],
//           [lc].[CusName]
//    FROM [Stock].[dbo].[TPRCustomer] lc
//    WHERE ([lc].[Status] = 'Activate')
//          AND
//          (
//              ([lc].[distributorUnderId] IN
//               (
//                   SELECT [distributorId] FROM @distributorIdList GROUP BY [distributorId]
//               )
//              )
//              OR (CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)IN
//                  (
//                      SELECT [distributorId] FROM @distributorIdList GROUP BY [distributorId]
//                  )
//                 )
//          ))
//SELECT [lc].[CusNum],
//       [lc].[CusName]
//FROM customerList lc
//GROUP BY [lc].[CusNum],
//         [lc].[CusName]
//ORDER BY [lc].[CusName];
//                ";
//            }
//            this.query = string.Format(this.query, DatabaseName,
//    (Initialized.vIsNestleOnly == true && !this.chkallitems.Checked ? "" : "--"),
//    AppSetting.SaleManagerID, distributorSelected);
//            this.lists = Data.Selects(this.query, Initialized.GetConnectionType(Data, App));
//            DataSources(this.CmbBillTo, this.lists, "CusName", "CusNum");
//            this.CmbBillTo.SelectedIndex = -1;
//            this.Cursor = Cursors.Default;
//        }
//    }
//}
