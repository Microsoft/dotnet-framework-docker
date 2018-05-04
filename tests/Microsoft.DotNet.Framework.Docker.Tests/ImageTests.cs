﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.DotNet.Framework.Docker.Tests
{
    public class ImageTests
    {
        private const string WSC_LTSC2016 = "windowsservercore-ltsc2016";
        private const string WSC_1709 = "windowsservercore-1709";

        private static string OSFilter => Environment.GetEnvironmentVariable("IMAGE_OS_FILTER");
        private static string RepoOwner => Environment.GetEnvironmentVariable("REPO_OWNER") ?? "microsoft";
        private static string VersionFilter => Environment.GetEnvironmentVariable("IMAGE_VERSION_FILTER");

        private static ImageDescriptor[] TestData = new ImageDescriptor[]
            {
                new ImageDescriptor { RuntimeVersion = "3.5", BuildVersion = "3.5", OsVariant = WSC_LTSC2016 },
                new ImageDescriptor { RuntimeVersion = "3.5", BuildVersion = "3.5", OsVariant = WSC_1709 },
                new ImageDescriptor { RuntimeVersion = "4.6.2", BuildVersion = "4.7.1", OsVariant = WSC_LTSC2016 },
                new ImageDescriptor { RuntimeVersion = "4.7", BuildVersion = "4.7.1", OsVariant = WSC_LTSC2016 },
                new ImageDescriptor { RuntimeVersion = "4.7.1", BuildVersion = "4.7.1", OsVariant = WSC_LTSC2016 },
                new ImageDescriptor { RuntimeVersion = "4.7.1", BuildVersion = "4.7.1", OsVariant = WSC_1709 },
            };

        private DockerHelper DockerHelper { get; set; }

        public ImageTests(ITestOutputHelper outputHelper)
        {
            DockerHelper = new DockerHelper(outputHelper);
        }

        public static IEnumerable<object[]> GetVerifyImagesData()
        {
            string versionFilterPattern = VersionFilter != null ? GetFilterRegexPattern(VersionFilter) : null;
            string osFilterPattern = OSFilter != null ? GetFilterRegexPattern(OSFilter) : null;

            // Filter out test data that does not match the active os and version filters.
            return TestData
                .Where(imageDescriptor => OSFilter == null
                    || Regex.IsMatch(imageDescriptor.OsVariant, osFilterPattern, RegexOptions.IgnoreCase))
                .Where(imageDescriptor => VersionFilter == null
                    || Regex.IsMatch(imageDescriptor.RuntimeVersion, versionFilterPattern, RegexOptions.IgnoreCase))
                .Select(imageDescriptor => new object[] { imageDescriptor });
        }

        private static string GetFilterRegexPattern(string filter)
        {
            return $"^{Regex.Escape(filter).Replace(@"\*", ".*").Replace(@"\?", ".")}$";
        }

        [Theory]
        [MemberData(nameof(GetVerifyImagesData))]
        public void VerifyImages(ImageDescriptor imageDescriptor)
        {
            string baseBuildImage = $"{RepoOwner}/dotnet-framework-build:{imageDescriptor.BuildVersion}-{imageDescriptor.OsVariant}";
            VerifyImageExist(baseBuildImage);

            string baseRuntimeImage = $"{RepoOwner}/dotnet-framework:{imageDescriptor.RuntimeVersion}-{imageDescriptor.OsVariant}";
            VerifyImageExist(baseRuntimeImage);

            string appId = $"dotnetapp-{DateTime.Now.ToFileTime()}";
            string workDir = Path.Combine(
                Directory.GetCurrentDirectory(),
                "projects",
                $"dotnetapp-{imageDescriptor.RuntimeVersion}");

            try
            {
                DockerHelper.Build(
                    tag: appId,
                    dockerfile: Path.Combine(workDir, "Dockerfile"),
                    buildContextPath: workDir,
                    buildArgs: new string[]
                    {
                        $"BASE_BUILD_IMAGE={baseBuildImage}",
                        $"BASE_RUNTIME_IMAGE={baseRuntimeImage}",
                    });

                DockerHelper.Run(image: appId, containerName: appId);
            }
            finally
            {
                DockerHelper.DeleteImage(appId);
            }
        }

        [Theory]
        [MemberData(nameof(GetVerifyImagesData))]
        public void VerifyImagesWithWebApps(ImageDescriptor imageDescriptor)
        {
            string baseBuildImage = $"{RepoOwner}/dotnet-framework-build:{imageDescriptor.BuildVersion}-{imageDescriptor.OsVariant}";
            VerifyImageExist(baseBuildImage);

            string webAppId = $"webapp-{DateTime.Now.ToFileTime()}";
            string webWorkDir = Path.Combine(
                Directory.GetCurrentDirectory(),
                "projects",
                $"webapp-{imageDescriptor.RuntimeVersion}");

            try
            {
                DockerHelper.Build(
                    tag: webAppId,
                    dockerfile: Path.Combine(webWorkDir, "Dockerfile"),
                    buildContextPath: webWorkDir,
                    buildArgs: new string[]
                    {
                        $"BASE_BUILD_IMAGE={baseBuildImage}",
                    });

                DockerHelper.Run(image: webAppId, containerName: webAppId);
            }
            finally
            {
                DockerHelper.DeleteImage(webAppId);
            }
        }


        private void VerifyImageExist(string image)
        {
            Assert.True(DockerHelper.ImageExists(image), $"`{image}` could not be found on disk.");
        }
    }
}
