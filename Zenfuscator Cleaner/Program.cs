using dnlib.DotNet;
using dnlib.DotNet.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenfuscator_Cleaner.Protections.Attributes;
using Zenfuscator_Cleaner.Protections.Anti_De4dot;
using Zenfuscator_Cleaner.Protections.Strings;

namespace Zenfuscator_Cleaner
{
    internal class Program
    {
        private static ModuleDefMD module;

        static void Main(string[] args)
        {
            module = ModuleDefMD.Load(args[0]); // Load the input assembly/module specified in the command line arguments

            Junk_Attributes.CleanJunk(module);
            RemoveFakeAttributes.CleanAttributes(module);
            Antide4dotCleaner.CleanAntiDe4dot(module);
            Decryption.DecryptBase64(module);

            var outputPath = Path.GetFileNameWithoutExtension(args[0]) + "_cleaned.exe";
            module.Write(outputPath, new ModuleWriterOptions(module) // Write the cleaned module to the specified output path
            {
                Logger = DummyLogger.NoThrowInstance  // Use a dummy logger that doesn't throw exceptions for any logging during the writing process
            });
            Console.WriteLine($"Module saved - {outputPath}\n"); // Log an information message indicating the successful saving of the cleaned module

            Console.ReadKey();

        }
    }
}
