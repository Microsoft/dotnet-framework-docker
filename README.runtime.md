# Featured Tags

* `4.8`
  * `docker pull mcr.microsoft.com/dotnet/framework/runtime:4.8`
* `3.5`
  * `docker pull mcr.microsoft.com/dotnet/framework/runtime:3.5`

# About This Image

This image contains the .NET Framework runtimes and libraries and is optimized for running .NET Framework apps in production.

Watch [dotnet/announcements](https://github.com/dotnet/announcements/labels/Docker) for Docker-related .NET announcements.

# How to Use the Image

The [.NET Framework Docker samples](https://github.com/microsoft/dotnet-framework-docker/blob/master/samples/README.md) show various ways to use .NET Framework and Docker together.

## Container sample: Run a simple application

You can quickly run a container with a pre-built [.NET Framework Docker image](https://hub.docker.com/_/microsoft-dotnet-framework-samples/), based on the [.NET Framework console sample](https://github.com/microsoft/dotnet-framework-docker/blob/master/samples/dotnetapp/README.md).

Type the following command to run a sample console application:

```console
docker run --rm mcr.microsoft.com/dotnet/framework/samples:dotnetapp
```

# Related Repos

.NET Framework:

* [dotnet/framework/sdk](https://hub.docker.com/_/microsoft-dotnet-framework-sdk/): .NET Framework SDK
* [dotnet/framework/aspnet](https://hub.docker.com/_/microsoft-dotnet-framework-aspnet/): ASP.NET Web Forms and MVC
* [dotnet/framework/wcf](https://hub.docker.com/_/microsoft-dotnet-framework-wcf/): Windows Communication Foundation (WCF)
* [dotnet/framework/samples](https://hub.docker.com/_/microsoft-dotnet-framework-samples/): .NET Framework, ASP.NET and WCF Samples

.NET Core:

* [dotnet/core](https://hub.docker.com/_/microsoft-dotnet-core/): .NET Core
* [dotnet/core-nightly](https://hub.docker.com/_/microsoft-dotnet-core-nightly/): .NET Core (Preview)
* [dotnet/core/samples](https://hub.docker.com/_/microsoft-dotnet-core-samples/): .NET Core Samples

# Full Tag Listing

## Windows Server, version 2009 amd64 Tags
Tag | Dockerfile
---------| ---------------
4.8-20200908-windowsservercore-2009, 4.8-windowsservercore-2009, 4.8, latest | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/4.8/windowsservercore-2009/Dockerfile)
3.5-20200908-windowsservercore-2009, 4.8-3.5-20200908-windowsservercore-2009, 3.5-windowsservercore-2009, 4.8-3.5-windowsservercore-2009, 3.5 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/3.5/windowsservercore-2009/Dockerfile)

## Windows Server, version 2004 amd64 Tags
Tag | Dockerfile
---------| ---------------
4.8-20201013-windowsservercore-2004, 4.8-windowsservercore-2004, 4.8, latest | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/4.8/windowsservercore-2004/Dockerfile)
3.5-20201013-windowsservercore-2004, 4.8-3.5-20201013-windowsservercore-2004, 3.5-windowsservercore-2004, 4.8-3.5-windowsservercore-2004, 3.5 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/3.5/windowsservercore-2004/Dockerfile)

## Windows Server, version 1909 amd64 Tags
Tag | Dockerfile
---------| ---------------
4.8-20201013-windowsservercore-1909, 4.8-windowsservercore-1909, 4.8, latest | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/4.8/windowsservercore-1909/Dockerfile)
3.5-20201013-windowsservercore-1909, 3.5-windowsservercore-1909, 3.5 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/3.5/windowsservercore-1909/Dockerfile)

## Windows Server, version 1903 amd64 Tags
Tag | Dockerfile
---------| ---------------
4.8-20201013-windowsservercore-1903, 4.8-windowsservercore-1903, 4.8, latest | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/4.8/windowsservercore-1903/Dockerfile)
3.5-20201013-windowsservercore-1903, 3.5-windowsservercore-1903, 3.5 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/3.5/windowsservercore-1903/Dockerfile)

## Windows Server 2019 amd64 Tags
Tag | Dockerfile
---------| ---------------
4.8-20201013-windowsservercore-ltsc2019, 4.8-windowsservercore-ltsc2019, 4.8, latest | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/4.8/windowsservercore-ltsc2019/Dockerfile)
4.7.2-20201013-windowsservercore-ltsc2019, 4.7.2-windowsservercore-ltsc2019, 4.7.2 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/4.7.2/windowsservercore-ltsc2019/Dockerfile)
3.5-20201013-windowsservercore-ltsc2019, 3.5-windowsservercore-ltsc2019, 3.5 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/3.5/windowsservercore-ltsc2019/Dockerfile)

## Windows Server 2016 amd64 Tags
Tag | Dockerfile
---------| ---------------
4.8-20201013-windowsservercore-ltsc2016, 4.8-windowsservercore-ltsc2016, 4.8, latest | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/4.8/windowsservercore-ltsc2016/Dockerfile)
4.7.2-20201013-windowsservercore-ltsc2016, 4.7.2-windowsservercore-ltsc2016, 4.7.2 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/4.7.2/windowsservercore-ltsc2016/Dockerfile)
4.7.1-20201013-windowsservercore-ltsc2016, 4.7.1-windowsservercore-ltsc2016, 4.7.1 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/4.7.1/windowsservercore-ltsc2016/Dockerfile)
4.7-20201013-windowsservercore-ltsc2016, 4.7-windowsservercore-ltsc2016, 4.7 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/4.7/windowsservercore-ltsc2016/Dockerfile)
4.6.2-20201013-windowsservercore-ltsc2016, 4.6.2-windowsservercore-ltsc2016, 4.6.2 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/4.6.2/windowsservercore-ltsc2016/Dockerfile)
3.5-20201013-windowsservercore-ltsc2016, 3.5-windowsservercore-ltsc2016, 3.5 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/src/runtime/3.5/windowsservercore-ltsc2016/Dockerfile)

You can retrieve a list of all available tags for dotnet/framework/runtime at https://mcr.microsoft.com/v2/dotnet/framework/runtime/tags/list.

# Support

See the [.NET Framework Lifecycle FAQ](https://support.microsoft.com/help/17455/lifecycle-faq-net-framework)

# Image Update Policy

* We update the supported .NET Framework images within 12 hours of any updates to their base images (e.g. windows/servercore:1909, windows/servercore:ltsc2019, etc.).
* We publish .NET Framework images as part of releasing new versions of .NET Framework including major/minor and servicing.

# Feedback

* [File a .NET Framework Docker issue](https://github.com/microsoft/dotnet-framework-docker/issues)
* [Report a .NET Framework problem](https://developercommunity.visualstudio.com/spaces/61/index.html)
* [File a Visual Studio Docker Tools issue](https://github.com/microsoft/dockertools/issues)
* [File a Microsoft Container Registry (MCR) issue](https://github.com/microsoft/containerregistry/issues)
* [Ask on Stack Overflow](https://stackoverflow.com/questions/tagged/.net)
* [Contact Microsoft Support](https://support.microsoft.com/contactus/)

# License

* Legal Notice: [Container License Information](https://aka.ms/mcr/osslegalnotice)

The .NET Framework images use the same license as the [Windows Server Core base image](https://hub.docker.com/_/microsoft-windows-servercore/).
