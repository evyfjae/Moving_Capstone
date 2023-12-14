using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Text.RegularExpressions;

public class S3Uploader : MonoBehaviour
{
    private string s3BucketUrl = "https://capston-moving.s3.ap-northeast-2.amazonaws.com";
    private string accessKeyId = "AKIAQ4Y3T4EDMZOXWMDT";
    private string secretAccessKey = "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";
    private string filePath = Application.dataPath + "/Upload/Unitytest.json"; // 수정된 부분
    private string fileName = "Unitytest.json";

    private IEnumerator Start()
    {
        byte[] fileData = System.IO.File.ReadAllBytes(filePath);
        string url = s3BucketUrl + "/" + fileName;
        UnityWebRequest request = UnityWebRequest.Put(url, fileData);

        string region = ExtractRegionFromUrl(s3BucketUrl);
        string date = DateTime.UtcNow.ToString("yyyyMMddTHHmmssZ");

        // Content Type 지정
        request.SetRequestHeader("Content-Type", "application/json");

        // 아마존 S3 서명 추가
        request.SetRequestHeader("Authorization", S3AuthorizationHeader("PUT", fileName, fileData, region, date));
        request.SetRequestHeader("x-amz-date", date);
        request.SetRequestHeader("x-amz-content-sha256", ByteArrayToHexString(ComputeHash(fileData)).ToLower());

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("File upload successful!");
        }
        else
        {
            Debug.LogError("File upload failed: " + request.error);
        }
    }

    private string S3AuthorizationHeader(string httpVerb, string fileName, byte[] fileData, string region, string date)
    {
        string canonicalRequest = httpVerb + "\n/" + fileName + "\n\ncontent-type:application/json\nhost:" + s3BucketUrl + "\nx-amz-content-sha256:" + ByteArrayToHexString(ComputeHash(fileData)).ToLower() + "\nx-amz-date:" + date + "\n\ncontent-type;host;x-amz-content-sha256;x-amz-date\n" + ByteArrayToHexString(ComputeHash(fileData)).ToLower();
        string stringToSign = "AWS4-HMAC-SHA256\n" + date + "\n" + date.Substring(0, 8) + "/" + region + "/s3/aws4_request\n" + ByteArrayToHexString(ComputeHash(System.Text.Encoding.UTF8.GetBytes(canonicalRequest))).ToLower();
        string signature = HmacSHA256(HmacSHA256(HmacSHA256(HmacSHA256(HmacSHA256("AWS4" + secretAccessKey, date.Substring(0, 8)), region), "s3"), "aws4_request"), stringToSign);

        return "AWS4-HMAC-SHA256 Credential=" + accessKeyId + "/" + date.Substring(0, 8) + "/" + region + "/s3/aws4_request, SignedHeaders=content-type;host;x-amz-content-sha256;x-amz-date, Signature=" + signature;
    }

    private string HmacSHA256(string key, string data)
    {
        byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);
        using (System.Security.Cryptography.HMACSHA256 hmac = new System.Security.Cryptography.HMACSHA256(keyBytes))
        {
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
            return ByteArrayToHexString(hmac.ComputeHash(dataBytes)).ToLower();
        }
    }

    private string ByteArrayToHexString(byte[] bytes)
    {
        return BitConverter.ToString(bytes).Replace("-", "");
    }

    private byte[] ComputeHash(byte[] data)
    {
        using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
        {
            return sha256.ComputeHash(data);
        }
    }

    private string ExtractRegionFromUrl(string url)
    {
        string pattern = @"\.s3\.([a-zA-Z0-9-]+)\.amazonaws\.com";
        Regex regex = new Regex(pattern);
        Match match = regex.Match(url);

        if (match.Success && match.Groups.Count > 1)
        {
            return match.Groups[1].Value;
        }

        // 기본적으로 us-east-1 사용
        return "us-east-1";
    }
    // 나머지 함수들은 그대로 두세요.
    // ...
}
