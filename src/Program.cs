using System;
using System.IO;
using System.Threading.Tasks;

namespace Project
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Initializing new project...");
            string fullPath = Path.GetFullPath(Directory.GetCurrentDirectory()).TrimEnd(Path.DirectorySeparatorChar);
            string projectName = Path.GetFileName(fullPath);

            await CreateFile($"{projectName}.sln", content: Constant.SolutionFileContentInBytes);
            await CreateFile(".gitignore", content: Constant.GitIgnoreFileContentInBytes);
            await CreateFile(".gitattributes");
            await CreateFile("build.cmd", content: Constant.BuildCmdContentInBytes);
            await CreateFile("build.sh", content: Constant.BuildCmdContentInBytes);
            await CreateFile("LICENSE");
            await CreateFile("NuGet.Config", content: Constant.NugetConfigContentInBytes);
            await CreateFile("README.md");
            await CreateFile("Directory.Build.props", content: Constant.DirectoryBuildPropsContentInBytes);
            CreateFolder("src");
            CreateFolder("artifacts");
            CreateFolder("build");
            CreateFolder("docs");
            CreateFolder("lib");
            CreateFolder("packages");
            CreateFolder("samples");
            CreateFolder("tests");

            Console.WriteLine($"Project structure has been created. Click on {projectName}.sln to open solution.");
        }

        private static async Task CreateFile(string fileName, byte[] content = null)
        {
            using FileStream fs = File.Create(Path.Combine(Constant.DirectoryPath, fileName));

            if (content is not null)
            {
                await fs.WriteAsync(content);
            }
        }

        private static void CreateFolder(string folderName)
        {
            Directory.CreateDirectory(Path.Combine(Constant.DirectoryPath, folderName));
        }
    }
}
