# WeTransferSDK
.NET API Library for wetransfer.com


`Download:`[https://github.com/loudKode/WeTransferSDK/releases](https://github.com/loudKode/WeTransferSDK/releases)
# Functions:
```vb.net
Function GetToken(Optional UserRandomID As String = Nothing) As Task(Of JSON_GetToken)
Function Upload(FileToUpload As Object, UploadType As OClient.UploadTypes, FileName As String, UToken As String, Optional ReportCls As IProgress(Of ReportStatus) = Nothing, Optional _proxi As ProxyConfig = Nothing, Optional token As Threading.CancellationToken = Nothing) As Task(Of JSON_Finalize)
```

# Example:
```vb.net
Dim cLENT As WeTransferSDK.IClient = New WeTransferSDK.OClient("xxxxxxxxx")
Dim RSLT = Await cLENT.GetToken
        Try
            Dim frm As New DeQma.FileFolderDialogs.VistaOpenFileDialog With {.Multiselect = False, .Title = "Select FILE/s to upload"}
            If frm.ShowDialog = DialogResult.OK AndAlso Not String.IsNullOrEmpty(frm.FileName) Then
                Dim UploadCancellationToken As New Threading.CancellationTokenSource()
                Dim progressIndicator_ReportCls As New Progress(Of WeTransferSDK.ReportStatus)(Sub(ReportClass As WeTransferSDK.ReportStatus)
                                                                                                   Label1.Text = String.Format("{0}/{1}", ISisFunctions.Bytes_To_KbMbGb.SetBytes(ReportClass.BytesTransferred), ISisFunctions.Bytes_To_KbMbGb.SetBytes(ReportClass.TotalBytes))
                                                                                                   ProgressBar1.Value = CInt(ReportClass.ProgressPercentage)
                                                                                                   Label2.Text = If(CStr(ReportClass.TextStatus) Is Nothing, "Uploading...", CStr(ReportClass.TextStatus))
                                                                                               End Sub)
                Dim rslt = Await cLENT.Upload(frm.FileName, WeTransferSDK.OClient.UploadTypes.FilePath, IO.Path.GetFileName(frm.FileName), "xxxxxxx", progressIndicator_ReportCls, Nothing, UploadCancellationToken.Token)
                DataGridView1.Rows.Add(rslt.url, rslt.state)
            End If
        Catch ex As WeTransferSDK.WeTransferException
            MsgBox(ex.Message)
        End Try
```
