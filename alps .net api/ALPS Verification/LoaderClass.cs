using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alps.net.api.StandardPASS;
using alps.net.api.StandardPASS.BehaviorDescribingComponents;
using alps.net.api.StandardPASS.InteractionDescribingComponents;
using System.Linq;
using alps.net.api.StandardPASS.SubjectBehaviors;
using alps.net.api.parsing;
using VDS.RDF;
using System.Collections.Generic;


    public class LoaderClass
    //Loads models and parsing structures. 

    {
        public IList<IPASSProcessModel> importModels()
        {
            PASSReaderWriter graph = PASSReaderWriter.getInstance();
            graph.loadOWLParsingStructure(new List<string> { "../../../Ont/standard_PASS_ont_v_1.1.0.owl", "../../../Ont/abstract-layered-pass-ont.owl" });
            IList<IPASSProcessModel> models = graph.loadModels(new List<string> { "../../../Ont/Customer_is_king.owl", "../../../Ont/Precendence.owl" });
            Console.WriteLine("Test");


            return models;



    }


    }

