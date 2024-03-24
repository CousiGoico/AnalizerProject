using System;
using System.Collections;
using System.IO;
using Library.AnalizerProjectLibrary.Entities;

namespace Library.AnalizerProjectLibrary.Analizer {

    public class AnalizerAssembly{

        #region Properties

        public string Extension { get; set; } = ".cs";
        private List<Api>? ApiList { get; set; } = null;
        private List<int> indexes {get;set;} = new List<int>();

        #endregion

         public List<Api> AnalizePath(string path){
            this.ApiList = new List<Api>();
            //SearchRecursively(path);
            return this.ApiList;
        }

        private void SearchRecursively (string path){

            // var currentDirectory = new System.IO.DirectoryInfo(path);


            // var files = currentDirectory.GetFiles().Where(archive => archive.Name.EndsWith($"Controller{this.Extension}") == true).ToList();
            
            // if (files.Any()){
            //     files.ForEach(archiveApi => {
            //         var type = Type.GetType(archiveApi);
            //         MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            //     });
            // }
            

            // // Search recursively for each folder.
            // currentDirectory.GetDirectories().Where(d => d.Attributes == FileAttributes.Directory).ToList().ForEach(directory => {
                
            //     SearchRecursively(directory.FullName);
            // });  
        }
    }

}