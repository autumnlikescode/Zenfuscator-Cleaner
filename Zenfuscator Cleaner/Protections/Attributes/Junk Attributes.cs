using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenfuscator_Cleaner.Protections.Attributes
{
    internal class Junk_Attributes
    {
        public static int removed;
        public static void CleanJunk(ModuleDefMD module)
        {
            // Iterate through all types in the module using ToList() to avoid modification during iteration
            foreach (TypeDef type in module.Types.ToList().Where(t => t.Name.Contains("ＰＲＯＪＥＣＴ-ＺＥＮ")))
            {
                // Remove the identified type from the module
                module.Types.Remove(type);

                // Increment the count of removed types
                removed++;

                // Log a success message indicating the removal of the junk method
                Console.WriteLine($"Removed junk type: {type.Name}");
            }
        }
    }
}
