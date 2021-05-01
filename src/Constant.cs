using System.IO;
using System.Text;

namespace Project
{
    public static class Constant
    {
        #region Private fields

        private static readonly string _solutionFileContent = @"Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 16.0.31220.234
MinimumVisualStudioVersion = 10.0.40219.1
Global
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {346B8E55-4F98-411A-B190-929B790EC1AA}
	EndGlobalSection
EndGlobal";

        private static readonly string _gitignoreContent = @"[Oo]bj/
[Bb]in/
.nuget/
_ReSharper.*
packages/
artifacts/
*.user
*.suo
*.userprefs
*DS_Store
*.sln.ide";

        private static readonly string _nugetConfigContent = @"<?xml version=""1.0"" encoding=""utf-8""?>
<configuration>
  <packageSources>
    <!--To inherit the global NuGet package sources remove the <clear/> line below -->
    <clear />
    <add key=""nuget"" value=""https://api.nuget.org/v3/index.json"" />
  </packageSources>
</configuration>
";

        private static readonly string _directoryBuildPropsContent = @"
<Project>
	<PropertyGroup>
		<BaseIntermediateOutputPath>$(SolutionDir)\artifacts\$(MSBuildProjectName)\$(Configuration)</BaseIntermediateOutputPath>
		<BaseOutputPath>$(SolutionDir)\artifacts\$(MSBuildProjectName)\$(Configuration)</BaseOutputPath>
		<RepositoryType>git</RepositoryType>
	</PropertyGroup>
</Project>
";

        #endregion


        private static readonly string _buildCmdContent = @$"dotnet build";

        public static readonly string DirectoryPath = Directory.GetCurrentDirectory();
        public static readonly byte[] SolutionFileContentInBytes = Encoding.UTF8.GetBytes(_solutionFileContent);
        public static readonly byte[] GitIgnoreFileContentInBytes = Encoding.UTF8.GetBytes(_gitignoreContent);
        public static readonly byte[] BuildCmdContentInBytes = Encoding.UTF8.GetBytes(_buildCmdContent);
        public static readonly byte[] NugetConfigContentInBytes = Encoding.UTF8.GetBytes(_nugetConfigContent);
        public static readonly byte[] DirectoryBuildPropsContentInBytes = Encoding.UTF8.GetBytes(_directoryBuildPropsContent);
    }
}
