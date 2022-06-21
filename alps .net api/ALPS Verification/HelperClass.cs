using alps.net.api.parsing;
using alps.net.api.StandardPASS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class HelperClass
    {
    LoaderClass load = new LoaderClass();
    public IList<IPASSProcessModel> importModels()
    {
        PASSReaderWriter graph = PASSReaderWriter.getInstance();
        graph.loadOWLParsingStructure(new List<string> { "../../../Ont/standard_PASS_ont_v_1.1.0.owl", "../../../Ont/abstract-layered-pass-ont.owl" });
         IList<IPASSProcessModel> models = graph.loadModels(new List<string> { "../../../Ont/AbstractModel.owl", "../../../Ont/ImplementingModel.owl" });
       // IList<IPASSProcessModel> models = graph.loadModels(new List<string> { "../../../Ont/VerTest.owl", "../../../Ont/VerTest.owl" });


        return models;



    }

 

}

