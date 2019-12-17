#
# Copyright (c) .NET Foundation and contributors. All rights reserved.
# Licensed under the MIT license. See LICENSE file in the project root for full license information.
#

[cmdletbinding()]
param(
    [string]$VersionFilter,
    [string]$OSFilter,
    [string]$Registry,
    [string]$RepoPrefix,
    [ValidateSet('runtime', 'sdk', 'aspnet', 'wcf')]
    [string[]]$TestCategories = @(),
    [switch]$PullImages,
    [string]$ImageInfoPath
)

function Log {
    param ([string] $Message)

    Write-Output $Message
}

function Exec {
    param ([string] $Cmd)

    Log "Executing: '$Cmd'"
    Invoke-Expression $Cmd
    if ($LASTEXITCODE -ne 0) {
        throw "Failed: '$Cmd'"
    }
}

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

# Install the .NET Core SDK
$dotnetInstallDir = "$PSScriptRoot/../.dotnet"
if (!(Test-Path "$dotnetInstallDir")) {
    mkdir "$dotnetInstallDir" | Out-Null
}

$dotnetInstallScript = "dotnet-install.ps1";
$dotnetInstallScriptPath = "$dotnetInstallDir/$DotnetInstallScript"
if (!(Test-Path $dotnetInstallScriptPath)) {
    $dotnetInstallScriptUrl = "https://raw.githubusercontent.com/dotnet/cli/release/2.1/scripts/obtain/$dotnetInstallScript"
    Invoke-WebRequest $dotnetInstallScriptUrl -OutFile $dotnetInstallScriptPath
}

& $dotnetInstallScriptPath -Channel "2.1" -Version "latest" -Architecture x64 -InstallDir $dotnetInstallDir
if ($LASTEXITCODE -ne 0) { throw "Failed to install the .NET Core SDK" }

# Run Tests
$env:IMAGE_OS_FILTER = $OSFilter
$env:IMAGE_VERSION_FILTER = $VersionFilter
$env:REGISTRY = $Registry
$env:REPO_PREFIX = $RepoPrefix
$env:IMAGE_INFO_PATH = $ImageInfoPath

if ($PullImages) {
    $env:PULL_IMAGES = 1
}
else {
    $env:PULL_IMAGES = $null
}

$testFilter = ""
if ($TestCategories) {
    # Construct an expression that filters the test to each of the
    # selected TestCategories (using an OR operator between each category).
    # See https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests
    $TestCategories | foreach {
        if ($testFilter) {
            $testFilter += "|"
        }

        $testFilter += "Category=$_"
    }

    $testFilter = "--filter `"$testFilter`""
}

Exec "dotnet test $testFilter -c Release --logger:trx $PSScriptRoot/Microsoft.DotNet.Framework.Docker.Tests/Microsoft.DotNet.Framework.Docker.Tests.csproj"
