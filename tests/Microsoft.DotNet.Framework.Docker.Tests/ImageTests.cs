﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.DotNet.Framework.Docker.Tests
{
    public abstract class ImageTests
    {
        protected ImageTests(ITestOutputHelper outputHelper)
        {
            ImageTestHelper = new ImageTestHelper(outputHelper);
        }

        protected abstract string ImageType { get; }

        protected ImageTestHelper ImageTestHelper { get; }

        protected void VerifyCommmonNgenQueuesAreEmpty(ImageDescriptor imageDescriptor)
        {
            VerifyNgenQueueIsUpToDate(imageDescriptor, ImageType, @"\Windows\Microsoft.NET\Framework64\v4.0.30319\ngen display");
            VerifyNgenQueueIsUpToDate(imageDescriptor, ImageType, @"\Windows\Microsoft.NET\Framework\v4.0.30319\ngen display");
        }

        protected void VerifyCommonEnvironmentVariables(IEnumerable<EnvironmentVariableInfo> variables, ImageDescriptor imageDescriptor)
        {
            const char delimiter = '|';
            IEnumerable<string> echoParts;
            string invokeCommand;
            char delimiterEscape;

            if (DockerHelper.IsLinuxContainerModeEnabled)
            {
                echoParts = variables.Select(envVar => $"${envVar.Name}");
                invokeCommand = $"/bin/sh -c";
                delimiterEscape = '\\';
            }
            else
            {
                echoParts = variables.Select(envVar => $"%{envVar.Name}%");
                invokeCommand = $"CMD /S /C";
                delimiterEscape = '^';
            }

            string appId = $"envvar-{DateTime.Now.ToFileTime()}";

            string combinedValues = ImageTestHelper.DockerHelper.Run(
                image: ImageTestHelper.GetImage(ImageType, imageDescriptor.Version, imageDescriptor.OsVariant),
                name: appId,
                command: $"{invokeCommand} \"echo {String.Join($"{delimiterEscape}{delimiter}", echoParts)}\"");

            string[] values = combinedValues.Split(delimiter);
            Assert.Equal(variables.Count(), values.Count());

            for (int i = 0; i < values.Count(); i++)
            {
                EnvironmentVariableInfo variable = variables.ElementAt(i);

                string actualValue;
                // Process unset variables in Windows
                if (!DockerHelper.IsLinuxContainerModeEnabled
                    && string.Equals(values[i], $"%{variable.Name}%", StringComparison.Ordinal))
                {
                    actualValue = string.Empty;
                }
                else
                {
                    actualValue = values[i];
                }

                if (variable.AllowAnyValue)
                {
                    Assert.NotEmpty(actualValue);
                }
                else
                {
                    Assert.Equal(variable.ExpectedValue, actualValue);
                }
            }
        }

        private void VerifyNgenQueueIsUpToDate(ImageDescriptor imageDescriptor, string imageType, string ngenCommand)
        {
            string appId = $"ngen-{DateTime.Now.ToFileTime()}";

            string result = ImageTestHelper.DockerHelper.Run(
                image: ImageTestHelper.GetImage(imageType, imageDescriptor.Version, imageDescriptor.OsVariant),
                name: appId,
                entrypointOverride: "cmd",
                command: $"/c {ngenCommand}");

            Assert.DoesNotContain("(StatusPending)", result);
        }
    }
}
