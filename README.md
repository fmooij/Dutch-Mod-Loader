# Dutch's Mod Loader

A simple installer for Red Dead Redemption 2 mods using DMI config files.

## Usage

1. Run `DutchModInstaller.exe`.
2. Select your RDR2 game folder (auto-detect is attempted).
3. Select your `.dmi` mod configuration file.
4. Click **Start** to install mods.

## DMI File Syntax

Each line should be: `ModFileOrFolder:RDR2Destination`
Comments start with `#` and empty lines are ignored.
Example:
```
MyMod.asi:mods
CoolModFolder:mods
```
