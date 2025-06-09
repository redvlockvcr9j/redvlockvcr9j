namespace Masa.Contrib.Storage.ObjectStorage.Aliyun.Options;

public class AliyunStorageOptions
{
    public string AccessKeyId { get; set; }

    public string AccessKeySecret { get; set; }

    public string RegionId { get; set; }

    public string RoleArn { get; set; }

    public string RoleSessionName { get; set; }

    private int _durationSeconds = 3600;

    /// <summary>
    /// Set the validity period of the temporary access credential, the minimum is 900, and the maximum is 43200.
    /// default: 3600
    /// unit: second
    /// </summary>
    public int DurationSeconds
    {
        get => _durationSeconds;
        set
        {
            if (value < 900 || value > 43200)
                throw new ArgumentOutOfRangeException(nameof(DurationSeconds), "DurationSeconds must be in range of 900-43200");

            _durationSeconds = value;
        }
    }

    /// <summary>
    /// If policy is empty, the user will get all permissions under this role
    /// </summary>
    public string Policy { get; set; }

    private string _temporaryCredentialsCacheKey = Const.TEMPORARY_CREDENTIALS_CACHEKEY;

    public string TemporaryCredentialsCacheKey
    {
        get => _temporaryCredentialsCacheKey;
        set => _temporaryCredentialsCacheKey = CheckNullOrEmptyAndReturnValue(value, nameof(TemporaryCredentialsCacheKey));
    }

    public AliyunStorageOptions() { }

    public AliyunStorageOptions(string accessKeyId, string accessKeySecret, string regionId, string roleArn, string roleSessionName) : this()
    {
        AccessKeyId = CheckNullOrEmptyAndReturnValue(accessKeyId, nameof(accessKeyId));
        AccessKeySecret = CheckNullOrEmptyAndReturnValue(accessKeySecret, nameof(accessKeySecret));
        RegionId = CheckNullOrEmptyAndReturnValue(regionId, nameof(regionId));
        RoleArn = CheckNullOrEmptyAndReturnValue(roleArn, nameof(roleArn));
        RoleSessionName = CheckNullOrEmptyAndReturnValue(roleSessionName, nameof(roleSessionName));
    }

    public AliyunStorageOptions SetPolicy(string policy)
    {
        Policy = policy;
        return this;
    }

    public AliyunStorageOptions SetTemporaryCredentialsCacheKey(string temporaryCredentialsCacheKey)
    {
        TemporaryCredentialsCacheKey = temporaryCredentialsCacheKey;
        return this;
    }

    public AliyunStorageOptions SetDurationSeconds(int durationSeconds)
    {
        DurationSeconds = durationSeconds;
        return this;
    }

    internal string CheckNullOrEmptyAndReturnValue(string? parameter, string parameterName)
    {
        if (string.IsNullOrEmpty(parameter))
            throw new ArgumentException($"{parameterName} cannot be null and empty string");

        return parameter;
    }
}
