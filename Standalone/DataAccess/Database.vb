Imports System.Data.SqlClient

Public Class Database
    Dim conString As String = My.Settings.cnString

    Sub backupDB()

        Dim query As String = "DECLARE @BackupFile varchar(100)" +
                " SET @BackupFile = 'C:\\Database\\Standalone_' +" +
                " REPLACE(convert(nvarchar(20), GetDate(), 120), ':', '-') + " +
                "'.BAK' " +
                "BACKUP DATABASE Standalone to disk = @BackupFile"

        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
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
    Sub RestoreDB(file As String)
        Dim query As String = " Alter database Standalone  set offline with rollback immediate RESTORE DATABASE Standalone FROM DISK ='" & file & "' WITH REPLACE alter database Standalone set online"
        Using connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, connection)
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

End Class
