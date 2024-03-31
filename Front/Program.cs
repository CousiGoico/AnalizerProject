
using System;
using System.Reflection;
using System.Text;

// using Library.AnalizerProjectLibrary.Analizer;
// using Library.AnalizerProjectLibrary.Entities;
using Library.AnalizerProjectLibrary;
using Library.AnalizerProjectLibrary.Output;

namespace AnalizarProject.Front {

    public class Program
    {
        static void Main(string[] args)
        {
            LoadAssembly();

            //CraeteDocument();
        }

        private static void CraeteDocument() {
            WordOutput.CreateDocument();
        }

        private static void LoadAssembly() {

            // Load an assembly (replace with actual assembly file)
            Assembly externalAssembly = Assembly.LoadFrom(@"N:\TrainingWorkplaceApp\slnTrainingWorkplace\TrainingWorkplace.Api\bin\Debug\net8.0\TrainingWorkplace.Api.dll");
            //Assembly externalAssembly2 = Assembly.LoadFrom(@"N:\InvisibleFriend\InvisibleFriendAPI\bin\Debug\net6.0\InvisibleFriendAPI.dll");
            //Assembly externalAssembly = Assembly.LoadFrom(@"N:\TrainingWorkplaceApp\slnTrainingWorkplace\TrainingWorkplace.Business.Contracts\bin\Debug\net8.0\TrainingWorkplace.Business.Contracts.dll");

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
                StringBuilder sb = new StringBuilder();
                foreach (Exception exSub in e.LoaderExceptions)
                {
                    sb.AppendLine(exSub.Message);
                    FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                    if (exFileNotFound != null)
                    {
                        if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                        {
                            sb.AppendLine("Fusion Log:");
                            sb.AppendLine(exFileNotFound.FusionLog);
                        }
                    }
                    sb.AppendLine();
                }
                string errorMessage = sb.ToString();
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
