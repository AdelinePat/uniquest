# uniquest
Small RPG in Unity


# Install
1. Download Unity Hub and create account on https://unity.com/download ( if you already have an account you can just login here https://unity.com/fr )
2. Make sure VS Code is installed on host (visual studio is not needed even if unity recommand it)
3. Install if needed `C# dev kit` extension
4. Create new project in Unity Hub `Universal 2D` , project name `uniquest` location `browse your git repo location`
5. To link Unity Editor and VS code go in Unity Editor (needs to open project) : Edit > Preferences > External Tools > choose Visual Studio Code 
Make sure to check those items from `Generate .csproj files for`:
- Embedded packages ✅
- Local packages ✅
- Registry packages ✅
- Git packages ✅
If you had to check some boxes, click on `regenerate project files`.
6. All future script will be in Assets > Scripts