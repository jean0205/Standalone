Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.SQLite

Public Class AccessBD

    Dim conString As String = My.Settings.cnString
    Dim conString2 As String = My.Settings.cnString2
    Dim conSqlite As String = "Data Source=KioskDB.db;Version=3"

    Function getEmployerInfo(ByVal employerNo As Integer, ByVal employerSub As Integer) As Employer
        Dim query As String = "SELECT [Id],[EmployerNo],[EmployerSub],[BusinessName],[RealName],[BusinessAddress],[BusinessTown],[BusinesssParish],[RealAddress],[RealTown],[RealParish],
                                        [RealPhone],[BusinessPhone],[Email1],[Email2]
                                      FROM [dbo].[EMPR]
                                      where EmployerNo= @EmployerNo and EmployerSub= @EmployerSub"
        Dim emper As New Employer
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    command.Parameters.AddWithValue("@EmployerNo", SqlDbType.Int).Value = employerNo
                    command.Parameters.AddWithValue("@EmployerSub", SqlDbType.Int).Value = employerSub
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read
                        If Not reader.IsDBNull(0) Then
                            emper.Id = reader(0)
                        End If
                        If Not reader.IsDBNull(1) Then
                            emper.EmployerNo = reader(1)
                        End If
                        If Not reader.IsDBNull(2) Then
                            emper.EmployerSub = reader(2)
                        End If
                        If Not reader.IsDBNull(3) Then
                            emper.BusinessName = reader(3)
                        End If
                        If Not reader.IsDBNull(4) Then
                            emper.RealName = reader(4)
                        End If
                        If Not reader.IsDBNull(5) Then
                            emper.BusinessAddress = reader(5)
                        End If
                        If Not reader.IsDBNull(6) Then
                            emper.BusinessTown = reader(6)
                        End If
                        If Not reader.IsDBNull(7) Then
                            emper.BusinesssParish = reader(7)
                        End If
                        If Not reader.IsDBNull(8) Then
                            emper.RealAddress = reader(8)
                        End If
                        If Not reader.IsDBNull(9) Then
                            emper.RealTown = reader(9)
                        End If
                        If Not reader.IsDBNull(10) Then
                            emper.RealParish = reader(10)
                        End If
                        If Not reader.IsDBNull(11) Then
                            emper.RealPhone = reader(11)
                        End If
                        If Not reader.IsDBNull(12) Then
                            emper.BusinessPhone = reader(12)
                        End If
                        If Not reader.IsDBNull(13) Then
                            emper.Email1 = reader(13)
                        End If
                        If Not reader.IsDBNull(14) Then
                            emper.Email2 = reader(14)
                        End If
                    End While
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
        Return emper
    End Function
    Function getEmployeeInfo(ByVal nisNumber As Integer) As Employee
        Dim query As String = "SELECT [Id],[NisNumber],[FirstName],[LastName],[MaidenName],[DateOB],[Address],[Town],[Parish],[Phone],[Email1],[Email2]
                                    FROM [dbo].[EMPE]
                                    Where NisNumber=@NisNumber"
        Dim empe As New Employee
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    command.Parameters.AddWithValue("@NisNumber", SqlDbType.Int).Value = nisNumber
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read
                        If Not reader.IsDBNull(0) Then
                            empe.Id = reader(0)
                        End If
                        If Not reader.IsDBNull(1) Then
                            empe.NisNumber = reader(1)
                        End If
                        If Not reader.IsDBNull(2) Then
                            empe.FirstName = Trim(reader(2).ToString).ToUpper
                        End If
                        If Not reader.IsDBNull(3) Then
                            empe.Lastname = Trim(reader(3).ToString).ToUpper
                        End If
                        If Not reader.IsDBNull(4) Then
                            empe.MaidenName = Trim(reader(4).ToString).ToUpper
                        End If
                        If Not reader.IsDBNull(5) Then
                            empe.DateOB = Trim(reader(5).ToString).ToUpper
                        End If
                        If Not reader.IsDBNull(6) Then
                            empe.Address = Trim(reader(6).ToString).ToUpper
                        End If
                        If Not reader.IsDBNull(7) Then
                            empe.Twon = Trim(reader(7).ToString).ToUpper
                        End If
                        If Not reader.IsDBNull(8) Then
                            empe.Parish = Trim(reader(8).ToString).ToUpper
                        End If
                        If Not reader.IsDBNull(9) Then
                            empe.Phone = Trim(reader(9).ToString)
                        End If
                        If Not reader.IsDBNull(10) Then
                            empe.Email1 = Trim(reader(10).ToString).ToUpper
                        End If
                        If Not reader.IsDBNull(11) Then
                            empe.Email2 = Trim(reader(11).ToString).ToUpper
                        End If
                    End While
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
        Return empe
    End Function
    Function getBusinessName(ByVal employerNo As Integer, ByVal employerSub As Integer) As String
        Dim query As String = "SELECT [BusinessName] FROM [dbo].[EMPR] where EmployerNo=@EmployerNo and EmployerSub=@EmployerSub"
        Dim name As String = String.Empty
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    command.Parameters.AddWithValue("@EmployerNo", SqlDbType.Int).Value = employerNo
                    command.Parameters.AddWithValue("@EmployerSub", SqlDbType.Int).Value = employerSub
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read
                        name = Trim(reader(0).ToString.ToUpper)
                    End While
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
        Return name
    End Function
    Function employerExist(ByVal employerNo As Integer, ByVal employerSub As Integer) As Boolean
        Dim query As String = "select * from EMPR where EmployerNo=@EmployerNo and EmployerSub=@EmployerSub"
        Dim table As New DataTable
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    command.Parameters.AddWithValue("@EmployerNo", SqlDbType.Int).Value = employerNo
                    command.Parameters.AddWithValue("@EmployerSub", SqlDbType.Int).Value = employerSub
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    Return reader.Read
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
        Return False
    End Function

    Function employeeExist(ByVal nisNumber As Integer) As Boolean
        Dim query As String = "SELECT * FROM [dbo].[EMPE] where NisNumber=@NisNumber"
        Dim table As New DataTable
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    command.Parameters.AddWithValue("@NisNumber", SqlDbType.Int).Value = nisNumber
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    Return reader.Read
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
        Return False
    End Function

#Region "KiosDB"
    Function getNISrate() As String
        Dim query As String = "SELECT [Value] FROM [dbo].[Parameters] where id=1"
        Dim nis As String = String.Empty
        Using connection As New SqlConnection(conString2)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read Then
                        nis = reader(0)
                    End If
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
        Return nis
    End Function
    Sub UpdateNisRate(ByVal nisRate As String)
        Dim query As String = "UPDATE [dbo].[Parameters]   SET [Value] = @NisRate
                                WHERE Name='NisRate'"

        Using connection As New SqlConnection(conString2)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@NisRate", SqlDbType.VarChar).Value = nisRate
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
    End Sub
    Function getVoluntaryRate() As String
        Dim query As String = "SELECT [Value] FROM [dbo].[Parameters] where id=4"
        Dim nis As String = String.Empty
        Using connection As New SqlConnection(conString2)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read Then
                        nis = reader(0)
                    End If
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
        Return nis
    End Function
    Sub UpdateVoluntaryRate(ByVal rate As String)
        Dim query As String = "UPDATE [dbo].[Parameters] SET [Value] = @NisRate
                                WHERE Name='Voluntary'"
        Using connection As New SqlConnection(conString2)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@NisRate", SqlDbType.VarChar).Value = rate
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
    End Sub
    Function getHoliday(dateH As Date) As Boolean
        Dim query As String = "SELECT * FROM [dbo].[Holidays] where Holyday= @Holyday"
        Using connection As New SqlConnection(conString2)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Holyday", SqlDbType.Date).Value = dateH
                Try
                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read Then
                        Return True
                    Else
                        Return False
                    End If
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
    End Function
    Sub insertRemittance(ByVal employerNo As Integer, ByVal employerSub As Integer, ByVal year As Integer, ByVal month As Integer, ByVal nisNumber As String,
                                      ByVal name As String, ByVal frequence As String, weeksW As Integer, ByVal Earnings As Decimal, ByVal contribution As Decimal,
                                        ByVal penalties As Decimal, ByVal interes As Decimal, ByVal week1 As String, ByVal week2 As String, ByVal week3 As String,
                                        ByVal week4 As String, ByVal week5 As String, ByVal dateP As DateTime)
        Dim query As String = "INSERT INTO [dbo].[Remittance]([EmployerNo],[EmployerSub],[Year],[Month],[NisNumber],[Name],[Frequence],[WeekW],[Earnings],
                                    [Contribution],[Penalties],[Interest],[Week1],[Week2],[Week3],[Week4],[Week5],[RecordDate])
                                     VALUES
                                           (@EmployerNo, @EmployerSub, @Year, @Month, @NisNumber, @Name, @Frequence, @WeekW, @Earnings, @Contribution, @Penalties,
                                                @Interest, @Week1, @Week2, @Week3, @Week4, @Week5, @RecordDate)"
        Using connection As New SqlConnection(conString2)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@EmployerNo", SqlDbType.Int).Value = employerNo
                command.Parameters.AddWithValue("@EmployerSub", SqlDbType.Int).Value = employerSub
                command.Parameters.AddWithValue("@Year", SqlDbType.Int).Value = year
                command.Parameters.AddWithValue("@Month", SqlDbType.Int).Value = month
                command.Parameters.AddWithValue("@NisNumber", SqlDbType.Int).Value = nisNumber
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = name
                command.Parameters.AddWithValue("@Frequence", SqlDbType.VarChar).Value = frequence
                command.Parameters.AddWithValue("@WeekW", SqlDbType.Int).Value = weeksW
                command.Parameters.AddWithValue("@Earnings", SqlDbType.Decimal).Value = Earnings
                command.Parameters.AddWithValue("@Contribution", SqlDbType.Decimal).Value = contribution
                command.Parameters.AddWithValue("@Penalties", SqlDbType.Decimal).Value = penalties
                command.Parameters.AddWithValue("@Interest", SqlDbType.Decimal).Value = interes
                command.Parameters.AddWithValue("@Week1", SqlDbType.VarChar).Value = week1
                command.Parameters.AddWithValue("@Week2", SqlDbType.VarChar).Value = week2
                command.Parameters.AddWithValue("@Week3", SqlDbType.VarChar).Value = week3
                command.Parameters.AddWithValue("@Week4", SqlDbType.VarChar).Value = week4
                command.Parameters.AddWithValue("@Week5", SqlDbType.VarChar).Value = week5
                command.Parameters.AddWithValue("@RecordDate", SqlDbType.DateTime).Value = dateP
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
    End Sub
    Function getRemittance(ByVal employerNo As Integer, employerSub As Integer) As DataTable

        Dim query As String = "SELECT [Id],[EmployerNo],[EmployerSub],[Year],[Month],[NisNumber],[Name],[Frequence],[WeekW],[Earnings]
      ,[Contribution],[Penalties],[Interest],[Week1],[Week2],[Week3],[Week4],[Week5] FROM [dbo].[Remittance]
                            where EmployerNo=@EmployerNo and EmployerSub=@EmployerSub"
        Dim table As New DataTable
        Using connection As New SqlConnection(conString2)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@EmployerNo", SqlDbType.Int).Value = employerNo
            command.Parameters.AddWithValue("@EmployerSub", SqlDbType.Int).Value = employerSub
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                table.Load(reader)
                reader.Close()
                connection.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return table
    End Function
    Sub deleteRemittance(ByVal employerNo As Integer, ByVal employerSub As Integer)
        Dim query As String = "DELETE FROM [dbo].[Remittance]
                                WHERE EmployerNo=@EmployerNo and EmployerSub=@EmployerSub"
        Using connection As New SqlConnection(conString2)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@EmployerNo", SqlDbType.Int).Value = employerNo
                command.Parameters.AddWithValue("@EmployerSub", SqlDbType.Int).Value = employerSub
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
    End Sub
    Function getTotalByPeriods(ByVal employerNo As Integer, employerSub As Integer) As DataTable
        Dim query As String = " select distinct year, MONTH, sum(contribution) from Remittance
                      where EmployerNo=@EmployerNo and EmployerSub=@EmployerSub
                      group by year, month"
        Dim table As New DataTable
        Using connection As New SqlConnection(conString2)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@EmployerNo", SqlDbType.Int).Value = employerNo
            command.Parameters.AddWithValue("@EmployerSub", SqlDbType.Int).Value = employerSub
            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                table.Load(reader)
                reader.Close()
                connection.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return table
    End Function
    Sub ResetEarnings(ByVal employerNo As Integer, ByVal employerSub As Integer)
        Dim query As String = "UPDATE [dbo].[Remittance] SET [Frequence]= '',WeekW= '', [Earnings] = 0.00,[Contribution] = 0.00,[Penalties] =0.00, [Interest] = 0.00 ,[Week1] ='' ,[Week2] ='' ,[Week3] ='' ,[Week4] ='' ,[Week5] = ''
                                WHERE EmployerNo=@EmployerNo and EmployerSub=@EmployerSub"
        Using connection As New SqlConnection(conString2)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@EmployerNo", SqlDbType.VarChar).Value = employerNo
                command.Parameters.AddWithValue("@EmployerSub", SqlDbType.VarChar).Value = employerSub
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
    End Sub
    Sub insertRemittanceSent(ByVal employerNo As Integer, ByVal employerSub As Integer, ByVal year As Integer, ByVal month As Integer, ByVal nisNumber As String,
                                     ByVal name As String, ByVal frequence As String, weeksW As Integer, ByVal Earnings As Decimal, ByVal contribution As Decimal,
                                       ByVal penalties As Decimal, ByVal interes As Decimal, ByVal week1 As String, ByVal week2 As String, ByVal week3 As String,
                                       ByVal week4 As String, ByVal week5 As String, ByVal dateP As Date)
        Dim query As String = "INSERT INTO [dbo].[RemittanceSent]([EmployerNo],[EmployerSub],[Year],[Month],[NisNumber],[Name],[Frequence],[WeekW],[Earnings],
                                    [Contribution],[Penalties],[Interest],[Week1],[Week2],[Week3],[Week4],[Week5],[RecordDate])
                                     VALUES
                                           (@EmployerNo, @EmployerSub, @Year, @Month, @NisNumber, @Name, @Frequence, @WeekW, @Earnings, @Contribution, @Penalties,
                                                @Interest, @Week1, @Week2, @Week3, @Week4, @Week5, @RecordDate)"
        Using connection As New SqlConnection(conString2)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@EmployerNo", SqlDbType.Int).Value = employerNo
                command.Parameters.AddWithValue("@EmployerSub", SqlDbType.Int).Value = employerSub
                command.Parameters.AddWithValue("@Year", SqlDbType.Int).Value = year
                command.Parameters.AddWithValue("@Month", SqlDbType.Int).Value = month
                command.Parameters.AddWithValue("@NisNumber", SqlDbType.Int).Value = nisNumber
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = name
                command.Parameters.AddWithValue("@Frequence", SqlDbType.VarChar).Value = frequence
                command.Parameters.AddWithValue("@WeekW", SqlDbType.Int).Value = weeksW
                command.Parameters.AddWithValue("@Earnings", SqlDbType.Decimal).Value = Earnings
                command.Parameters.AddWithValue("@Contribution", SqlDbType.Decimal).Value = contribution
                command.Parameters.AddWithValue("@Penalties", SqlDbType.Decimal).Value = penalties
                command.Parameters.AddWithValue("@Interest", SqlDbType.Decimal).Value = interes
                command.Parameters.AddWithValue("@Week1", SqlDbType.VarChar).Value = week1
                command.Parameters.AddWithValue("@Week2", SqlDbType.VarChar).Value = week2
                command.Parameters.AddWithValue("@Week3", SqlDbType.VarChar).Value = week3
                command.Parameters.AddWithValue("@Week4", SqlDbType.VarChar).Value = week4
                command.Parameters.AddWithValue("@Week5", SqlDbType.VarChar).Value = week5
                command.Parameters.AddWithValue("@RecordDate", SqlDbType.DateTime).Value = dateP
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
    End Sub
#End Region
#Region "SQLite"

    Function getRemittanceLite(ByVal employerNo As Integer, ByVal employerSub As Integer) As DataTable
        Dim table As New DataTable
        Dim query As String = "SELECT Id,EmployerNo,EmployerSub,Year,Month,NisNumber,Name,Frequence,WeekW,Earnings,Contribution,Penalties,Interest,
                                   Week1,Week2,Week3,Week4,Week5 FROM Remittance
                                    where EmployerNo =@EmployerNo and EmployerSub=@EmployerSub;"
        Using connection As New SQLiteConnection(conSqlite)
            Dim command As New SQLiteCommand(query, connection)
            command.Parameters.AddWithValue("@EmployerNo", SqlDbType.Int).Value = employerNo
            command.Parameters.AddWithValue("@EmployerSub", SqlDbType.Int).Value = employerSub
            Try
                connection.Open()
                Dim reader As SQLiteDataReader = command.ExecuteReader()
                table.Load(reader)
                reader.Close()
                connection.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return table
    End Function
    Function getRemittanceByMonthLite(ByVal employerNo As Integer, ByVal employerSub As Integer, ByVal month As Integer, ByVal year As Integer) As DataTable
        Dim table As New DataTable
        Dim query As String = "SELECT Id,EmployerNo,EmployerSub,Year,Month,NisNumber,Name,Frequence,WeekW,Earnings,Contribution,Penalties,Interest,
                                   Week1,Week2,Week3,Week4,Week5,RecordDate FROM Remittance
                                    where EmployerNo =@EmployerNo and EmployerSub=@EmployerSub 
                                    and strftime('%m', `RecordDate`)=@Month  AND strftime('%Y', RecordDate) =@Year;"
        Using connection As New SQLiteConnection(conSqlite)
            Dim command As New SQLiteCommand(query, connection)
            command.Parameters.AddWithValue("@EmployerNo", SqlDbType.Int).Value = employerNo
            command.Parameters.AddWithValue("@EmployerSub", SqlDbType.Int).Value = employerSub
            command.Parameters.AddWithValue("@Month", SqlDbType.Int).Value = month
            command.Parameters.AddWithValue("@Year", SqlDbType.Int).Value = year
            Try
                connection.Open()
                Dim reader As SQLiteDataReader = command.ExecuteReader()
                table.Load(reader)
                reader.Close()
                connection.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return table
    End Function
    Sub insertRemittanceLite(ByVal employerNo As Integer, ByVal employerSub As Integer, ByVal year As Integer, ByVal month As Integer, ByVal nisNumber As String,
                                     ByVal name As String, ByVal frequence As String, weeksW As Integer, ByVal Earnings As Decimal, ByVal contribution As Decimal,
                                       ByVal penalties As Decimal, ByVal interes As Decimal, ByVal week1 As String, ByVal week2 As String, ByVal week3 As String,
                                       ByVal week4 As String, ByVal week5 As String, ByVal dateP As String)
        Dim query As String = "INSERT INTO Remittance(EmployerNo,EmployerSub,Year,Month,NisNumber,Name,Frequence,WeekW,Earnings,
                                    Contribution,Penalties,Interest,Week1,Week2,Week3,Week4,Week5,RecordDate)
                                     VALUES
                                           (@EmployerNo, @EmployerSub, @Year, @Month, @NisNumber, @Name, @Frequence, @WeekW, @Earnings, @Contribution, @Penalties,
                                                @Interest, @Week1, @Week2, @Week3, @Week4, @Week5, @RecordDate)"
        Using connection As New SQLiteConnection(conSqlite)
            Using command As New SQLiteCommand(query, connection)
                command.Parameters.AddWithValue("@EmployerNo", employerNo)
                command.Parameters.AddWithValue("@EmployerSub", employerSub)
                command.Parameters.AddWithValue("@Year", year)
                command.Parameters.AddWithValue("@Month", month)
                command.Parameters.AddWithValue("@NisNumber", nisNumber)
                command.Parameters.AddWithValue("@Name", name)
                command.Parameters.AddWithValue("@Frequence", frequence)
                command.Parameters.AddWithValue("@WeekW", weeksW)
                command.Parameters.AddWithValue("@Earnings", Earnings)
                command.Parameters.AddWithValue("@Contribution", contribution)
                command.Parameters.AddWithValue("@Penalties", penalties)
                command.Parameters.AddWithValue("@Interest", interes)
                command.Parameters.AddWithValue("@Week1", week1)
                command.Parameters.AddWithValue("@Week2", week2)
                command.Parameters.AddWithValue("@Week3", week3)
                command.Parameters.AddWithValue("@Week4", week4)
                command.Parameters.AddWithValue("@Week5", week5)
                command.Parameters.AddWithValue("@RecordDate", dateP)
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
    End Sub
    Sub deleteRemittanceLite(ByVal employerNo As Integer, ByVal employerSub As Integer)
        Dim query As String = "DELETE FROM Remittance
                                WHERE EmployerNo=@EmployerNo and EmployerSub=@EmployerSub"
        Using connection As New SQLiteConnection(conSqlite)
            Using command As New SQLiteCommand(query, connection)
                command.Parameters.AddWithValue("@EmployerNo", employerNo)
                command.Parameters.AddWithValue("@EmployerSub", employerSub)
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using
        End Using
    End Sub

#End Region

End Class
