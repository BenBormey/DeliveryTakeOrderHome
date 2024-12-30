Imports DeliveryTakeOrder.Declares
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Windows.Forms
Imports System.Xml.Linq

Namespace DeliveryTakeOrder.Interfaces.Teamleader
    Public Partial Class SelectTeamForm
        Inherits Form
        Private db As RMDB

        Private bsWarehouse As BindingSource
        Private bsTeam As BindingSource
        Public Sub New()
            Me.InitializeComponent()
            Me.lblTitle.Text = String.Format("Welcome to {0}", DeliveryTakeOrder.Declares.AppSetting.AppName)
            Text = Me.lblTitle.Text
            db = New RMDB(DeliveryTakeOrder.Declares.AppSetting.ConnectionString)


            bsWarehouse = New BindingSource()
            AddHandler bsWarehouse.PositionChanged, New EventHandler(AddressOf Position_Changed)

            Me.warehouseNameLoading.Enabled = True
            Me.teamLoading.Enabled = True
        End Sub


        Private Sub Position_Changed(sender As Object, e As EventArgs)
            If bsWarehouse Is Nothing Then
                Cursor = Cursors.Default
                Return
            End If
            Dim currentWarehouseName As Teamleader.warehouseNameModel = CType(bsWarehouse.Current, Teamleader.warehouseNameModel)
            If currentWarehouseName Is Nothing Then
                Cursor = Cursors.Default
                Return
            End If
            'this.picWarehouseName.Image = currentWarehouseName.photo;
        End Sub
        Public Sub LoadTeam()

            Dim bsWarehouse As BindingSource
            Dim bsTeam As BindingSource

            Cursor = Cursors.WaitCursor
            Me.warehouseNameLoading.Enabled = False
            Dim sql = "DECLARE @RC INT; EXECUTE @RC = [DBWarehouses].[dbo].[getWarehouseNameList]; "
            Dim dt As DataTable = db.GetDataTable(sql)
            Dim result = GetDataTableToObject(Of DeliveryTakeOrder.Interfaces.Teamleader.warehouseNameModel)(dt)
            bsWarehouse = New BindingSource With {
                .DataSource = result
            }
            DeliveryTakeOrder.GeneralModule._BindCombo(Me.cmbWarehouseName, Me.bsWarehouse, "id", "warehouseName")
            Me.cmbWarehouseName.SelectedIndex = -1
            Cursor = Cursors.Default
        End Sub
        Private Sub SelectTeamForm_Load(sender As Object, e As EventArgs)
            Cursor = Cursors.WaitCursor
            Me.teamLoading.Enabled = False
            Dim sqlQuery As String = CStr(New XElement("SQL", New XCData("
SELECT *
INTO #team_
FROM DBUNTWHOLESALECOLTD.dbo.TblSetSaleManagerToSupplier s;

UPDATE x
SET [x].[TeamName] = N'Alpha',
    [x].[TeamID] = 1,
    [x].[SaleManagerID] = 1
FROM #team_ x
WHERE ([x].[TeamName] NOT IN ( N'Charlie', N'Delta' ));

UPDATE x
SET [x].[TeamName] = N'Charlie + Delta',
    [x].[TeamID] = 2,
    [x].[SaleManagerID] = 2
FROM #team_ x
WHERE ([x].[TeamName] IN ( N'Charlie', N'Delta' ));

SELECT DISTINCT
       s1.SaleManagerID,
       N'Team ' + s1.TeamName + N' - ' + REPLACE(STUFF(
                                                 (
                                                     SELECT ', ' + s2.SupName
                                                     FROM #team_ s2
                                                     WHERE s1.TeamID = s2.TeamID
                                                     ORDER BY SupName
                                                     FOR XML PATH('')
                                                 ),
                                                 1,
                                                 2,
                                                 N''
                                                      ),
                                                 N'&amp;',
                                                 N'&'
                                                ) AS SupName,
       1 AS OrderID
FROM #team_ s1
WHERE TeamID IS NOT NULL
ORDER BY OrderID,
         SaleManagerID;

DROP TABLE #team_;
")))

            Dim dt As DataTable = db.GetDataTable(sqlQuery)
            bsTeam = New BindingSource With {
                .DataSource = dt
            }
            DeliveryTakeOrder.GeneralModule._BindCombo(Me.cmbTeam, bsTeam, "SaleManagerID", "SupName")
            Cursor = Cursors.Default


            LoadTeam()





        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs)
            If Me.cmbTeam.Text.Trim().Equals("") = True Then
                MessageBox.Show("Please select a team!")
                '  DevExpress.XtraEditors.XtraMessageBox.Show("Please select a team!");
                Return
            End If
            If bsWarehouse Is Nothing Or Me.cmbWarehouseName.Text.Trim().Equals("") = True Then
                Cursor = Cursors.Default
                MessageBox.Show("Please select which warehouse you are standing!", "Select Warehouse", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ' DevExpress.XtraEditors.XtraMessageBox.Show("Please select which warehouse you are standing!", "Select Warehouse", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Return
            End If
            Dim currentWarehouseName As Teamleader.warehouseNameModel = CType(bsWarehouse.Current, Teamleader.warehouseNameModel)
            If currentWarehouseName Is Nothing Or Me.cmbWarehouseName.Text.Trim().Equals("") = True Then
                Cursor = Cursors.Default
                MessageBox.Show("Please select whcih warehouse you are stading!", "Select Warehouse", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                '  DevExpress.XtraEditors.XtraMessageBox.Show("Please select which warehouse you are standing!", "Select Warehouse", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Return
            End If

            DeliveryTakeOrder.Declares.Initialized.vIsNestleOnly = False
            'DataRow currentRow = currentRowView.Row;
            '    AppSetting.SaleManagerID = bsTeam.Current.rows("SaleManagerID");
            If DeliveryTakeOrder.Declares.AppSetting.SaleManagerID = 2 Then DeliveryTakeOrder.Declares.Initialized.vIsNestleOnly = True
            '  var frmLogin = new FrmPasswordLogin(currentWarehouseName);
            ' frmLogin.Show();
        End Sub
        Public Function GetDataTableToObject(Of T As New)(pDataTable As DataTable) As List(Of T)
            Dim ls As List(Of T) = New List(Of T)()

            For Each dr As DataRow In pDataTable.Rows
                Dim o As T = New T()
                Dim value As Object

                For Each p In GetType(T).GetProperties()
                    Try

                        If pDataTable.Columns.Contains(p.Name) Then
                            Dim propType = p.PropertyType
                            value = If(TypeOf dr(p.Name) Is DBNull, Nothing, Convert.ChangeType(dr(p.Name), propType))
                            p.SetValue(o, value, Nothing)
                        End If
                    Catch ex As Exception ' Handle the exception or log it Console.WriteLine("Error setting property: " + ex.Message); } } ls.Add(o); } return ls;

                    End Try
                Next
                ls.Add(o)
            Next
            Return ls
        End Function

        Private Sub cmbWarehouseName_SelectedIndexChanged(sender As Object, e As EventArgs)
            Me.picWarehouseName.Image = Nothing
            If TypeOf Me.cmbWarehouseName.SelectedValue Is DataRowView Or Me.cmbWarehouseName.SelectedValue Is Nothing Then Return
            If Me.cmbWarehouseName.Text.Trim().Equals("") = True Then Return

            Me.Position_Changed(Me.cmbWarehouseName, e)
        End Sub
    End Class
End Namespace



