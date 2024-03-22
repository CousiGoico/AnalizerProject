using System;
using System.Collections;
using System.IO;
using Library.AnalizerProjectLibrary.Entities;

namespace Library.AnalizerProjectLibrary.Analizer {

    public class Analizer{

        #region Properties

        public string Extension { get; set; } = ".cs";
        private List<Api>? ApiList { get; set; } = null;

        #endregion

        #region Methods

        public List<Api> AnalizePath(string path){
            SearchRecursively(path);
            this.ApiList = new List<Api>();
            return new List<Api>();
        }

        private void SearchRecursively (string path){

            var currentDirectory = new System.IO.DirectoryInfo(path);

            currentDirectory.GetFiles().Where(archive => archive.Extension == this.Extension && archive.Name.EndsWith("controller") == true).ToList().ForEach(archiveApi => {
                if (this.ApiList != null && archiveApi != null)
                {
                    this.ApiList.Add(new Api() { Name = archiveApi.Name });
                }
                
            });

            // Search recursively for each folder.
            currentDirectory.GetDirectories().Where(d => d.Attributes == FileAttributes.Directory).ToList().ForEach(directory => {
                SearchRecursively(directory.FullName);
            });
        }

        #endregion

    }

}