#!/usr/bin/env pwsh
[cmdletbinding(
    DefaultParameterSetName = "BuildAndTest"
)]
param(
    [ValidateSet("runtime", "sdk", "aspnet", "wcf")]
    [string[]]$RepoFilter = @(),
    [string]$VersionFilter = "*",
    [string]$OSFilter = "*",
    [Parameter(ParameterSetName = "Build")]
    [switch]$BuildOnly,
    [Parameter(ParameterSetName = "Test")]
    [switch]$TestOnly,
    [Parameter(ParameterSetName = "Build")]
    [Parameter(ParameterSetName = "BuildAndTest")]
    [string]$OptionalImageBuilderArgs
)

if ($PSCmdlet.ParameterSetName -eq "BuildAndTest") {
    $build = $true
    $test = $true
}
else {
    $build = $BuildOnly
    $test = $TestOnly
}

if ($RepoFilter.Count -eq 0) {
    $PathFilters = $null
    $testCategories = @()
}
else {
    $PathFilters = ""
    $RepoFilter | foreach {
        $PathFilters += " --path '$VersionFilter/$_/$OSFilter'"
    }
    $testCategories = $RepoFilter
}

if ($build) {
    & ./eng/common/build.ps1 `
        -VersionFilter $VersionFilter `
        -OSFilter $OSFilter `
        -PathFilters $PathFilters `
        -OptionalImageBuilderArgs $OptionalImageBuilderArgs
}
if ($test) {
    & ./tests/run-tests.ps1 `
        -VersionFilter $VersionFilter `
        -OSFilter $OSFilter `
        -TestCategories $testCategories
}
