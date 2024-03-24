
using System;
using System.Reflection;
// using Library.AnalizerProjectLibrary.Analizer;
// using Library.AnalizerProjectLibrary.Entities;

namespace AnalizarProject.Front {

    public class Program
    {
        static void Main(string[] args)
        {

            // Load an assembly (replace with actual assembly file)
            Assembly externalAssembly = Assembly.LoadFile(@"N:\TrainingWorkplaceApp\slnTrainingWorkplace\TrainingWorkplace.Api\bin\Debug\net6.0\TrainingWorkplace.Api.dll");
            //Assembly externalAssembly2 = Assembly.LoadFrom(@"N:\InvisibleFriend\InvisibleFriendAPI\bin\Debug\net6.0\InvisibleFriendAPI.dll");

            // Get all the types in the assembly
            if (externalAssembly != null) {
                //Type[] assemblyTypes = externalAssembly2.GetTypes();
                Type[] assemblyTypes = GetTypesAssembly(externalAssembly);

                Type currentType = externalAssembly.GetType("TrainingWorkplace.Api.Controllers.CalendarController");

                // Find a specific type by its name
                if (assemblyTypes != null) {
                    Type targetType = assemblyTypes[26];

                    // Create an instance of the targetType (if found)
                    if (targetType != null)
                    {
                        MethodInfo[] methods = targetType.GetMethods();
                    }
                }
            }
            
            

            // var path = GetPath();
            // Analizer analizer = new Analizer();
            // var apis = analizer.AnalizePath(path);
            // apis.ForEach(api => {
            //     Console.WriteLine(api.ToString());
            // });
            // Console.ReadLine();
        }

        private static Type[] GetTypesAssembly(Assembly assembly){

            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null).ToArray();
            }

        }

        private static string GetPath() {
            Console.WriteLine("Escriba la ruta que desea analizar:");
            var path = Console.ReadLine();

            if (string.IsNullOrEmpty(path)) {
                return GetPath();
            }

            return path;

        }
    }

}
