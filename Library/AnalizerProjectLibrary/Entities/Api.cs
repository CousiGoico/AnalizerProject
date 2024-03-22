using System;
using System.Collections;

namespace Library.AnalizerProjectLibrary.Entities {

    public class Api {

        #region Properties

        public string Name {get;set;} = string.Empty;

        public string Route { get; set; } = string.Empty;

        public List<ApiMethod>? Methods {get;set;} = null;

        #endregion
    }

}