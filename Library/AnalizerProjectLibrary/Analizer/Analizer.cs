using System;
using System.Collections;
using System.IO;
using Library.AnalizerProjectLibrary.Entities;

namespace Library.AnalizerProjectLibrary.Analizer {

    public class Analizer{

        #region Properties

        public string Extension { get; set; } = ".cs";
        private List<Api>? ApiList { get; set; } = null;
        private List<int> indexes {get;set;} = new List<int>();

        #endregion

        #region Methods

        public List<Api> AnalizePath(string path){
            this.ApiList = new List<Api>();
            SearchRecursively(path);
            return this.ApiList;
        }

        private void SearchRecursively (string path){

            var currentDirectory = new System.IO.DirectoryInfo(path);


            var files = currentDirectory.GetFiles().Where(archive => archive.Name.EndsWith($"Controller{this.Extension}") == true).ToList();
            Console.WriteLine($"{path} - {files.Count}");
            if (files.Any()){
                files.ForEach(archiveApi => {
                    if (this.ApiList != null && archiveApi != null)
                    {
                        var api = new Api() { Name = archiveApi.Name };
                        var code = ReadController(archiveApi.FullName);
                        api.Route = GetRoute(code, archiveApi.Name);
                        api.Methods = GetApiMethods(code);
                        this.ApiList.Add(api);
                    }
                });
            }
            

            // Search recursively for each folder.
            currentDirectory.GetDirectories().Where(d => d.Attributes == FileAttributes.Directory).ToList().ForEach(directory => {
                
                SearchRecursively(directory.FullName);
            });
        }
        
        private string ReadController(string controllerPath){
            return File.ReadAllText(controllerPath);
        }

        private string GetRoute(string code, string apiName){
            var route = string.Empty;
            if (code.IndexOf("[Route(\"[controller]\")]") > 0) { 
                route = apiName.Replace("Controller.cs", string.Empty);
            }
            else { 
                var index = code.IndexOf("[Route(");  
                var routeCode = code.Substring(index).Substring(0, code.Substring(index).IndexOf("]"));
                route = routeCode.Substring(routeCode.IndexOf("("), routeCode.IndexOf(")"));
            }
            return route;
        }

        private List<ApiMethod> GetApiMethods(string code){
            var verbs = new List<string>() {"HttpGet", "HttpPost", "HttpPut", "HttpDelete"};
            return SearchApiMethods(code, verbs);
        }

        private List<ApiMethod> SearchApiMethods(string code, List<string> verbs) {
            var apiMethods = new List<ApiMethod>();
            verbs.ForEach(verb => {
                if (code.IndexOf(verb) > 0) { 
                    indexes.Clear();
                    GetIndexes(code, verb);
                    indexes.ForEach(index => {
                        var codeAux = code.Substring(index);
                        if (codeAux.IndexOf("Name") > -1){
                            codeAux = codeAux.Substring(codeAux.IndexOf("Name"));
                            codeAux = codeAux.Substring(codeAux.IndexOf("\"") + 1);
                            var name = codeAux.Substring(0, codeAux.IndexOf("\""));
                            var newApi = new ApiMethod() { Verb = verb.Replace("Http", string.Empty), Url=$"\\{name}", Name=name, Description = "" };
                            apiMethods.Add(newApi);
                        }
                    });
                }
            });
            
            return apiMethods;
        }

        private void GetIndexes(string code, string verb){
            var codeToAnalize = code;
            if (codeToAnalize.IndexOf(verb) > 0){
                var index = codeToAnalize.IndexOf(verb);
                indexes.Add(index);
                codeToAnalize = codeToAnalize.Substring(index + verb.Length);
                GetIndexes(codeToAnalize, verb);
            }
        }

        #endregion

    }

}