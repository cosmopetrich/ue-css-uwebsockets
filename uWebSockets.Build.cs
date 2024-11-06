/*
 * This file is distributed via cosmopetrich/ue-thirdparty-release-action
 * Any local changes will be overwritten!
 */

using System.IO;
using UnrealBuildTool;

public class uWebSockets : ModuleRules {
    public uWebSockets(ReadOnlyTargetRules Target) : base(Target) {
        Type = ModuleType.External;
        PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "include"));

        var PlatformName = Target.Platform.ToString();

        var LibFolder = Path.Combine(ModuleDirectory, "lib", PlatformName);
        if (Target.Platform == UnrealTargetPlatform.Win64) {
            PublicAdditionalLibraries.AddRange(Directory.EnumerateFiles(LibFolder, "*.lib"));
        }
        else if (Target.Platform == UnrealTargetPlatform.Linux) {
            PublicAdditionalLibraries.AddRange(Directory.EnumerateFiles(LibFolder, "*.a"));
        }
    }
}
