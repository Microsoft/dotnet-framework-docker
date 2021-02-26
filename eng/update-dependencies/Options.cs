// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.CommandLine;

namespace Microsoft.DotNet.Framework.UpdateDependencies
{
    public class Options
    {
        public string? DateStampAll { get; private set; }

        public string? DateStampRuntime { get; private set; }

        public string? DateStampSdk { get; private set; }

        public string? DateStampAspnet { get; private set; }

        public string? DateStampWcf { get; private set; }

        public string? GitHubEmail { get; private set; }

        public string? GitHubPassword { get; private set; }

        public string GitHubProject => "dotnet-framework-docker";

        public string GitHubUpstreamBranch => "main";

        public string GitHubUpstreamOwner => "Microsoft";

        public string? GitHubUser { get; private set; }

        public bool UpdateOnly => GitHubEmail == null || GitHubPassword == null || GitHubUser == null;

        public Options(string? datestampAll, string? datestampRuntime, string? datestampSdk, string? datestampAspnet, string? datestampWcf, string? email,
            string? password, string? user)
        {
            DateStampAll = datestampAll;
            DateStampRuntime = datestampRuntime;
            DateStampSdk = datestampSdk;
            DateStampAspnet = datestampAspnet;
            DateStampWcf = datestampWcf;
            GitHubEmail = email;
            GitHubPassword = password;
            GitHubUser = user;
        }

        public static IEnumerable<Symbol> GetCliSymbols() =>
            new Symbol[]
            {
                new Option<string?>("--datestamp-all", "Tag date stamp to assign to all image types"),
                new Option<string?>("--datestamp-runtime", "Tag date stamp to assign to runtime image types (overrides datestamp-all)"),
                new Option<string?>("--datestamp-sdk", "Tag date stamp to assign to SDK image types (overrides datestamp-all)"),
                new Option<string?>("--datestamp-aspnet", "Tag date stamp to assign to ASP.NET image types (overrides datestamp-all)"),
                new Option<string?>("--datestamp-wcf", "Tag date stamp to assign to WCF image types (overrides datestamp-all)"),
                new Option<string?>("--email", "GitHub email used to make PR (if not specified, a PR will not be created)"),
                new Option<string?>("--password", "GitHub password used to make PR (if not specified, a PR will not be created)"),
                new Option<string?>("--user", "GitHub user used to make PR (if not specified, a PR will not be created)")
            };
    }
}
