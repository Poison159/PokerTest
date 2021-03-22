#tool "nuget:?package=xunit.runner.console"
var target = Argument("target","Default");

Task("Default")
    .IsDependentOn("xUnit");

Task("Build")
    .Does(() => {
        MSBuild("./PokerEval/PokerEval.sln");
    });

Task("xUnit")
    .IsDependentOn("Build")
    .Does(() => {
        DotNetCoreTest("./PokerEvalaulator.Tests/bin/Debug/netcoreapp3.1/PokerEvalaulator.Tests.dll");
    });

RunTarget(target);