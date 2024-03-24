using System;
using System.Collections;

namespace Library.AnalizerProjectLibrary.Entities {

    public class Api {

        #region Properties

        public string Name {get;set;} = string.Empty;

        public string Route { get; set; } = string.Empty;

        public List<ApiMethod>? Methods {get;set;} = null;

        #endregion

        #region Methods

        public override string ToString(){
            if (this.Methods == null){
                return $"{this.Name} - {this.Route}";
            }
            else {
                string methodData = string.Empty;
                this.Methods.ForEach(method => {
                    methodData = $"{methodData}{method.Verb} - {method.Name} - {method.Url}{System.Environment.NewLine}";
                });
                return $"{this.Name} - {this.Route}{System.Environment.NewLine}{methodData}";
            }
            
        }

        #endregion
    }

}