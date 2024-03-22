
using Library.AnalizerProjectLibrary.Analizer;
using Library.AnalizerProjectLibrary.Entities;

namespace AnalizarProject.Front {

    public class Program
    {
        static void Main(string[] args)
        {
            var path = GetPath();
            Analizer analizer = new Analizer();
            var apis = analizer.AnalizePath(path);
            apis.ForEach(api => {
                Console.WriteLine(api.Name);
            });
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
