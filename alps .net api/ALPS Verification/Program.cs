
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using alps.net.api.StandardPASS;
using alps.net.api.StandardPASS.BehaviorDescribingComponents;
using alps.net.api.StandardPASS.InteractionDescribingComponents;
using System.Linq;
using alps.net.api.StandardPASS.SubjectBehaviors;
using alps.net.api.parsing;
using VDS.RDF;
using System.Collections.Generic;

// See https://aka.ms/new-console-template for more information


public class OtherClass
{

    public static void Method()
    {

        Console.WriteLine("Start loading models");


    }
}
public class OriginalClass
{
     


    public static void Main(string[] args)
    {
        OtherClass.Method();
        PASSReaderWriter graph = PASSReaderWriter.getInstance();
        graph.loadOWLParsingStructure(new List<string> { "../../../Ont/standard_PASS_ont_v_1.1.0.owl", "../../../Ont/abstract-layered-pass-ont.owl" });
        IList<IPASSProcessModel> models = graph.loadModels(new List<string> { "../../../Ont/Testmodel.owl", "../../../Ont/Precendence.owl" });
        Console.WriteLine("Test");
        //

        IList<ISubject> Subjects1 = models[1].getAllElements().Values.OfType<ISubject>().ToList();
        IList<ISubject> Subjects0 = models[0].getAllElements().Values.OfType<ISubject>().ToList();
        // IMessageSpecification Spec0 = models[0].getAllElements().Values.OfType<IMessageSpecification>();



        IList<IMessageExchange> Message0 = models[0].getAllElements().Values.OfType<IMessageExchange>().ToList();
        IList<IMessageExchange> Message1 = models[1].getAllElements().Values.OfType<IMessageExchange>().ToList();
        IDictionary<string, IMessageExchange> MessagesIncoming = new Dictionary<string, IMessageExchange>();



        LogWriter log = new LogWriter("Kra");



        Console.WriteLine("\nAbstract Model Subjects: ");

        for (int i = 0; i < Subjects1.Count; i++)

        {
            string a = Subjects1[i].getModelComponentID();
            //string b = Subjects1[i].getModelComponentLabelsAsStrings();

            Console.WriteLine(a);
            //Console.WriteLine(b);

            // Console.WriteLine(ComponentLabels1[i]);
            // Console.WriteLine(MessagesIncoming.TryGetValue(a, out IMessageExchange value));

        }
        Console.WriteLine("\nImplementing Model Subjects: ");

        for (int j = 0; j < Subjects0.Count; j++)
        {
            Console.WriteLine(Subjects0[j].getModelComponentID());
            


        }

        Console.WriteLine("\nAbstract Model Messages: ");

        for (int i = 0; i < Message1.Count; i++)
        {
            Console.WriteLine(Message1[i].getModelComponentID());
            Console.WriteLine(Message1[i].getMessageType());

        }

        Console.WriteLine("\nImplementing Model Messages: ");

        for (int i = 0; i < Message0.Count; i++)
        {
            Console.WriteLine(Message0[i].getModelComponentID());
            Console.WriteLine(Message0[i].getMessageType());



        }

        Console.WriteLine("Communication Restrictions: ");

        for (int i = 0; i < Subjects1.Count; i++)
        {
            Console.WriteLine(Subjects1[i].GetType());
            // Console.WriteLine(Message1[i].getModelComponentLabelsAsStrings());

        }





    }

}


