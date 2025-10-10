# uniquest
Small RPG in Unity for a school projet. It is not meant for commercial use, it is only meant to learn how to use Unity without minding Assets creation and all.

# Git workflow (for team)
Please never use `git add .` but add Assets/Scripts/ only instead making sure you won't add unecessary files to distant repository
```bash
git add Assets/Scripts
```

# Stack 
- Unity 6.2 (6.000.2.6f1 from september 2025)
- C#

# Install
1. Download Unity Hub and create account on https://unity.com/download ( if you already have an account you can just login here https://unity.com/fr )
2. Make sure VS Code is installed on host (visual studio is not needed even if unity recommand it)
3. Install if needed `C# dev kit` extension
4. Create new project in Unity Hub `2D (Built-In Render Pipeline)` , project name `uniquest` location `browse your git repo location`
5. To link Unity Editor and VS code go in Unity Editor (needs to open project) : Edit > Preferences > External Tools > choose Visual Studio Code 
Make sure to check those items from `Generate .csproj files for`:
- Embedded packages ✅
- Local packages ✅
- Registry packages ✅
- Git packages ✅

If you had to check some boxes, click on `regenerate project files`.

# Assets 
- We are using [Tiny Swords](https://pixelfrog-assets.itch.io/tiny-swords) asset pack from PixelFrog
- We downloaded the `TS_old version_CC0 Licensed` (jan 03, 2024).
- Creator of this pack is PixelFrog [PixelFrog instagram](https://www.instagram.com/pixelfrogstudio/) & [PixelFrog twitter](https://x.com/PixelFrogStudio)

6. All future script will be in Assets > Scripts