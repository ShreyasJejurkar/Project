using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using System.IO;
using System.Threading.Tasks;

namespace Project
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var cmd = new RootCommand
            {
                new Option<bool>(
                    "--m",
                    getDefaultValue: () => false,
                    "Creates minimilistic project structure with src, tests, solution file and git related files."
                )
            };

            cmd.Handler = CommandHandler.Create<bool, IConsole>(HandleProjectCommand);
            return cmd.InvokeAsync(args).Result;
        }

        private static async Task HandleProjectCommand(bool isMinimal, IConsole console)
        {
            console.Out.WriteLine("Initializing new project...");
            string fullPath = Path.GetFullPath(Directory.GetCurrentDirectory()).TrimEnd(Path.DirectorySeparatorChar);
            string projectName = Path.GetFileName(fullPath);

            await CreateFile($"{projectName}.sln", content: Constant.SolutionFileContentInBytes);
            await CreateFile(".gitignore", content: Constant.GitIgnoreFileContentInBytes);
            await CreateFile(".gitattributes");
            await CreateFile("LICENSE");
            await CreateFile("README.md");
            CreateFolder("src");
            CreateFolder("tests");

            if (!isMinimal)
            {
                console.Out.WriteLine("minimal");
                await CreateFile("build.cmd", content: Constant.BuildCmdContentInBytes);
                await CreateFile("build.sh", content: Constant.BuildCmdContentInBytes);
                await CreateFile("NuGet.Config", content: Constant.NugetConfigContentInBytes);
                CreateFolder("artifacts");
                CreateFolder("build");
                CreateFolder("docs");
                CreateFolder("lib");
                CreateFolder("packages");
                CreateFolder("samples");
            }

            console.Out.WriteLine($"Project structure has been created. Click on {projectName}.sln to open solution.");
        }

        private static async Task CreateFile(string fileName, byte[]? content = null)
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
