﻿using Masa.BuildingBlocks.Storage.ObjectStorage;

namespace Masa.Contrib.Storage.ObjectStorage.Aliyun.Tests;

[TestClass]
public class TestStorage
{
    [TestMethod]
    public void TestAddAliyunStorageReturnThrowArgumentException()
    {
        var services = new ServiceCollection();
        services.AddAliyunStorage();
        var serviceProvider = services.BuildServiceProvider();
        Assert.ThrowsException<ArgumentException>(() => serviceProvider.GetService<IClient>(),
            $"Failed to get {nameof(IOptionsMonitor<AliyunStorageOptions>)}");
    }

    [TestMethod]
    public void TestAddAliyunStorageByEmptySectionReturnThrowArgumentException()
    {
        var services = new ServiceCollection();
        Assert.ThrowsException<ArgumentException>(() => services.AddAliyunStorage(String.Empty));
    }

    [TestMethod]
    public void TestAddAliyunStorageReturnClientIsNotNull()
    {
        var services = new ServiceCollection();
        var configurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        services.AddSingleton<IConfiguration>(configurationRoot);
        services.AddAliyunStorage();
        var serviceProvider = services.BuildServiceProvider();
        Assert.IsNotNull(serviceProvider.GetService<IClient>());
    }

    [TestMethod]
    public void TestAddAliyunStorageAndNullALiYunStorageOptionsReturnThrowArgumentNullException()
    {
        var services = new ServiceCollection();
        AliyunStorageOptions aLiYunStorageOptions = null!;
        Assert.ThrowsException<ArgumentNullException>(() => services.AddAliyunStorage(aLiYunStorageOptions));
    }

    [TestMethod]
    public void TestAddAliyunStorageByEmptyALiYunStorageOptionsReturnThrowArgumentNullException()
    {
        var services = new ServiceCollection();
        Assert.ThrowsException<ArgumentException>(() => services.AddAliyunStorage(new AliyunStorageOptions()));
    }

    [TestMethod]
    public void TestAddAliyunStorageByALiYunStorageOptionsReturnClientNotNull()
    {
        var services = new ServiceCollection();
        services.AddAliyunStorage(new AliyunStorageOptions("accessKeyId", "AccessKeySecret", "regionId", "roleArn", "roleSessionName"));
        var serviceProvider = services.BuildServiceProvider();
        Assert.IsNotNull(serviceProvider.GetService<IClient>());
    }

    [TestMethod]
    public void TestAddMultiAliyunStorageReturnClientCountIs1()
    {
        var services = new ServiceCollection();
        AliyunStorageOptions options = new AliyunStorageOptions("accessKeyId", "accessKeySecret", "regionId", "roleArn", "roleSessionName");
        services.AddAliyunStorage(options).AddAliyunStorage(options);
        var serviceProvider = services.BuildServiceProvider();
        Assert.IsNotNull(serviceProvider.GetService<IClient>());
        Assert.IsTrue(serviceProvider.GetServices<IClient>().Count() == 1);
    }

    [TestMethod]
    public void TestAddAliyunStorageAndNullALiYunStorageOptionsFuncReturnThrowArgumentNullException()
    {
        var services = new ServiceCollection();
        Func<AliyunStorageOptions> func = null!;
        Assert.ThrowsException<ArgumentNullException>(() => services.AddAliyunStorage(func));
    }
}
