using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class AWS3 : MonoBehaviour
{
    private string accessKey = ""; // AWS Access Key ID
    private string secretKey = ""; // AWS Secret Access Key
    private string bucketName = ""; // S3 Bucket Name
    private RegionEndpoint bucketRegion = RegionEndpoint.APNortheast2; // The Amazon S3 Region your bucket is in

    private async Task UploadFileAsync(string filePath, string keyName)
    {
        try
        {
            var s3Client = new AmazonS3Client(accessKey, secretKey, bucketRegion);
            var fileTransferUtility = new TransferUtility(s3Client);

            await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);
            Debug.Log($"{keyName} upload completed successfully");
        }
        catch (AmazonS3Exception e)
        {
            Debug.Log($"Error encountered on server. Message:'{e.Message}' when writing an object");
        }
        catch (Exception e)
        {
            Debug.Log($"Unknown encountered on server. Message:'{e.Message}' when writing an object");
        }
    }

    public void UploadClick()
    {
        string jsonKeyName = "6-3-0.json"; // The key for the new object
        string jsonFilePath = "Video/6-3-0.json"; // The file to upload
        Task.Run(() => UploadFileAsync(jsonFilePath, jsonKeyName)).ContinueWith(t =>
        {
            if (t.IsFaulted)
            {
                Debug.Log($"Upload failed: {t.Exception?.Flatten().Message}");
            }
        });

        string mp4KeyName = "6-3-0.mp4"; // The key for the new object
        string mp4FilePath = "Video/6-3-0.mp4"; // The file to upload
        Task.Run(() => UploadFileAsync(mp4FilePath, mp4KeyName)).ContinueWith(t =>
        {
            if (t.IsFaulted)
            {
                Debug.Log($"Upload failed: {t.Exception?.Flatten().Message}");
            }
        });
    }
}
