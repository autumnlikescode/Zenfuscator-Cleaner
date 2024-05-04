using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenfuscator_Cleaner.Protections.Anti_De4dot
{
    internal class Antide4dotCleaner
    {
        public static void CleanAntiDe4dot(ModuleDefMD module)
        {
            // Iterate through all types in the module
            foreach (var type in module.Types.ToList())
            {
                // Check if the type has any interfaces
                if (!type.HasInterfaces)
                    continue; // If not, continue to the next type

                // Iterate through the interfaces of the current type
                foreach (var interfaceType in type.Interfaces.ToList())
                {
                    // Check if the interface type is not null
                    if (interfaceType.Interface != null)
                    {
                        // Check if the current type is not an interface itself
                        if (!type.IsInterface)
                        {
                            // If the above conditions are met, remove the type from the module
                            module.Types.Remove(type);
                            // Print a message indicating the removed type's name
                            Console.WriteLine($"Removed attributes -> {type.Name}");
                        }
                    }
                }
            }
        }
    }
}
