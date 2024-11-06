# ue-css-uwebsockets

A version of the [uWebSockets](https://github.com/uNetworking/uWebSockets) C++ library built with [vcpkg](https://github.com/microsoft/vcpkg) for use in Satisfactory modding.

- Uses the directory structure that UE expects.
- Includes libraries for both Linux and Windows.
- Support for static linking.
- Provides debug symbols so that errors include proper stack traces.
- Built with the appropriate C compiler version to avoid mismatches with Unreal Engine.

## Usage

The headers and library files are not checked in to git. Instead, they are distributed using Github Releases.
You can grab the newest release from [the releases page](https://github.com/cosmopetrich/ue-css-uwebsockets/releases) and
[set it up as a third-party library](https://docs.ficsit.app/satisfactory-modding/latest/Development/Cpp/thirdparty.html)
manually if desired. The binaries are only a few MB and thus are unlikely to cause any major problems if checked in to Git.

Alternatively, read on for information on handling it in a semi-automated way.
The commands below assume that you're using the "Git Bash" command-line included in Git for Windows.

1. Add this repository as a [git submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules).

   ```bash
   cd SatisfactoryModLoader/Mods/MyMod
   git submodule add https://github.com/cosmopetrich/ue-css-uwebsockets Source/uWebSockets
   ```

2. Update your mod's Build.cs file as normal.

   ```cs
   PrivateDependencyModuleNames.AddRange(new string[] {
     // [...]
     "uWebSockets",
     // [...]
   });
   ```

3. Add a note to your `CONTRIBUTING.md` or equivilant so that contributors know what to do.

   ```markdown
   When updating the repository, be sure to also update the submodules.

       git pull --recurse-submodules

   You can also set git up to do this automatically when you run a regular `git pull`.

       git config submodule.recurse true
   ```

3. Retrieve the files.

   ```bash
   Source/uWebSockets/update-files
   ```

If the command exists successfully then you'll have `include` and `lib` folders containing the library and can develop your mod as usual.

To update

1. Update the submodule.

   ```bash
   git -C Source/uWebSockets pull
   git commit -m "Update uWebSockets" Source/uWebsockets .gitmodules
   ```

2. Re-run the `retrieve-files script.


   ```bash
   Source/uWebSockets/update-files
   ```

It's safe to run `retrieve-files` whenever you want to. It will detect if anything has changed and pull down the release automatically.

## License

The any scripts etc within this repository are licensed under the GPL v3.
However, the packaged libraries retain their own licenses which can be found in the "share" directory of the release artifacts.
