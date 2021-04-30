## dotnet-new-project

A dotnet CLI tool which will create following .NET project structure in folder.

```
$/
  artifacts/
  build/
  docs/
  lib/
  packages/
  samples/
  src/
  tests/
  .editorconfig
  .gitignore
  .gitattributes
  build.cmd
  build.sh
  LICENSE
  NuGet.Config
  README.md
  {solution}.sln
```

### Install as CLI tool

```
dotnet tool install --global dotnet-new-project
```


This folder is considered as [standard folder structure](https://gist.github.com/davidfowl/ed7564297c61fe9ab814) for .NET project in the ecosystem, which is being used for many of the .NET foundation project.
