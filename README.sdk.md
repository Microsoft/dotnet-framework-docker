# Featured Tags

* `4.8`
  * `docker pull mcr.microsoft.com/dotnet/framework/sdk:4.8`
* `3.5`
  * `docker pull mcr.microsoft.com/dotnet/framework/sdk:3.5`

# About This Image

This image contains the .NET Framework SDK which is comprised of the following parts:

1. .NET Framework Runtime
1. Visual Studio Build Tools
1. Visual Studio Test Agent
1. NuGet CLI
1. .NET Framework Targeting Packs
1. ASP.NET Web Targets

Use this image for your development process (developing, building and testing applications).

Watch [dotnet/announcements](https://github.com/dotnet/announcements/labels/Docker) for Docker-related .NET announcements.

# How to Use the Image

The [.NET Framework Docker samples](https://github.com/microsoft/dotnet-framework-docker/blob/master/samples/README.md) show various ways to use .NET Framework and Docker together.

## Building .NET Framework Apps with Docker

* [.NET Framework Console Docker Sample](dotnetapp/README.md) - This [sample](dotnetapp/Dockerfile) builds, tests, and runs the sample. It includes and builds multiple projects.
* [ASP.NET Web Forms Docker Sample](aspnetapp/README.md) - This [sample](aspnetapp/Dockerfile) demonstrates using Docker with an ASP.NET Web Forms app.
* [ASP.NET MVC Docker Sample](aspnetmvcapp/README.md) - This [sample](aspnetmvcapp/Dockerfile) demonstrates using Docker with an ASP.NET MVC app.
* [WCF Docker Sample](wcfapp/README.md) - This [sample](wcfapp/) demonstrates using Docker with a WCF app.

# Related Repos

.NET Framework:

* [dotnet/framework/aspnet](https://hub.docker.com/_/microsoft-dotnet-framework-aspnet/): ASP.NET Web Forms and MVC
* [dotnet/framework/runtime](https://hub.docker.com/_/microsoft-dotnet-framework-runtime/): .NET Framework Runtime
* [dotnet/framework/wcf](https://hub.docker.com/_/microsoft-dotnet-framework-wcf/): Windows Communication Framework (WCF)
* [dotnet/framework/samples](https://hub.docker.com/_/microsoft-dotnet-framework-samples/): .NET Framework, ASP.NET and WCF Samples

.NET Core:

* [dotnet/core](https://hub.docker.com/_/microsoft-dotnet-core/): .NET Core
* [dotnet/core-nightly](https://hub.docker.com/_/microsoft-dotnet-core-nightly/): .NET Core (Preview)
* [dotnet/core/samples](https://hub.docker.com/_/microsoft-dotnet-core-samples/): .NET Core Samples

# Full Tag Listing

## Windows Server, version 1903 amd64 Tags
Tag | Dockerfile
---------| ---------------
4.8-20190724-windowsservercore-1903, 4.8-windowsservercore-1903, 4.8, latest | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/4.8/sdk/windowsservercore-1903/Dockerfile)
3.5-20190724-windowsservercore-1903, 3.5-windowsservercore-1903, 3.5 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/3.5/sdk/windowsservercore-1903/Dockerfile)

## Windows Server 2019 amd64 Tags
Tag | Dockerfile
---------| ---------------
4.8-20190724-windowsservercore-ltsc2019, 4.8-windowsservercore-ltsc2019, 4.8, latest | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/4.8/sdk/windowsservercore-ltsc2019/Dockerfile)
4.7.2-20190724-windowsservercore-ltsc2019, 4.7.2-windowsservercore-ltsc2019, 4.7.2 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/4.7.2/sdk/windowsservercore-ltsc2019/Dockerfile)
3.5-20190724-windowsservercore-ltsc2019, 3.5-windowsservercore-ltsc2019, 3.5 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/3.5/sdk/windowsservercore-ltsc2019/Dockerfile)

## Windows Server, version 1803 amd64 Tags
Tag | Dockerfile
---------| ---------------
4.8-20190724-windowsservercore-1803, 4.8-windowsservercore-1803, 4.8, latest | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/4.8/sdk/windowsservercore-1803/Dockerfile)
4.7.2-20190724-windowsservercore-1803, 4.7.2-windowsservercore-1803, 4.7.2 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/4.7.2/sdk/windowsservercore-1803/Dockerfile)
3.5-20190724-windowsservercore-1803, 3.5-windowsservercore-1803, 3.5 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/3.5/sdk/windowsservercore-1803/Dockerfile)

## Windows Server 2016 amd64 Tags
Tag | Dockerfile
---------| ---------------
4.8-20190724-windowsservercore-ltsc2016, 4.8-windowsservercore-ltsc2016, 4.8, latest | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/4.8/sdk/windowsservercore-ltsc2016/Dockerfile)
4.7.2-20190724-windowsservercore-ltsc2016, 4.7.2-windowsservercore-ltsc2016, 4.7.2 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/4.7.2/sdk/windowsservercore-ltsc2016/Dockerfile)
4.7.1-20190724-windowsservercore-ltsc2016, 4.7.1-windowsservercore-ltsc2016, 4.7.1 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/4.7.1/sdk/windowsservercore-ltsc2016/Dockerfile)
3.5-20190724-windowsservercore-ltsc2016, 3.5-windowsservercore-ltsc2016, 3.5 | [Dockerfile](https://github.com/microsoft/dotnet-framework-docker/blob/master/3.5/sdk/windowsservercore-ltsc2016/Dockerfile)

You can retrieve a list of all available tags for dotnet/framework/sdk at https://mcr.microsoft.com/v2/dotnet/framework/sdk/tags/list.

# Support

See the [.NET Framework Lifecycle FAQ](https://support.microsoft.com/en-us/help/17455/lifecycle-faq-net-framework)

# Feedback

* [File a .NET Framework Docker issue](https://github.com/microsoft/dotnet-framework-docker/issues)
* [Report a .NET Framework problem](https://developercommunity.visualstudio.com/spaces/61/index.html)
* [Ask on Stack Overflow](https://stackoverflow.com/questions/tagged/.net)
* [Contact Microsoft Support](https://support.microsoft.com/contactus/)

# License

The .NET Framework images use the same license as the [Windows Server Core base image](https://hub.docker.com/_/microsoft-windows-servercore/).