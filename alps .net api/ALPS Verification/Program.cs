
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
        //Load models and ontologies
        LoaderClass load = new LoaderClass();
        IList<IPASSProcessModel> models = load.importModels();


        // Check if all Subjects of model 0 are implemented in model 1
        IList<IImplementingElement<ISubject>> implementingElementsSet = models[1].getAllElements().Values.OfType<IImplementingElement<ISubject>>().ToList();
        IList<IImplementingElement<IMessageExchange>> implementingElementsMessage = models[1].getAllElements().Values.OfType<IImplementingElement<IMessageExchange>>().ToList();

        IList<ISubject> specifyingElementsSubject = models[0].getAllElements().Values.OfType<ISubject>().ToList();
        IList<IMessageExchange> specifyingElementsMessages = models[0].getAllElements().Values.OfType<IMessageExchange>().ToList();




        CheckSubjectExistence checkSubject = new CheckSubjectExistence();
        checkSubject.CheckExistence(implementingElementsSet, specifyingElementsSubject);
        checkSubject.CheckExistenceMessage(implementingElementsMessage, specifyingElementsMessages);





        ISet<IImplementingElement<IMessageExchange>> implementingMessagesSet = new HashSet<IImplementingElement<IMessageExchange>>(models[1].getAllElements().Values.OfType<IImplementingElement<IMessageExchange>>().ToList());

        IList<ISubject> Subjects1 = models[1].getAllElements().Values.OfType<ISubject>().ToList();
        IList<ISubject> Subjects0 = models[0].getAllElements().Values.OfType<ISubject>().ToList();

        IList<IMessageExchange> Message0 = models[0].getAllElements().Values.OfType<IMessageExchange>().ToList();
        IList<IMessageExchange> Message1 = models[1].getAllElements().Values.OfType<IMessageExchange>().ToList();
        IDictionary<string, IMessageExchange> MessagesIncoming = new Dictionary<string, IMessageExchange>();

        LogWriter log = new LogWriter("Kra");
       


        Console.WriteLine("\nAbstract Model Subjects: ");

        for (int i = 0; i < Subjects0.Count; i++)

        {
            string a = Subjects0[i].getModelComponentID();
            Console.WriteLine(a);

        }
        Console.WriteLine("\nImplementing Model Subjects: ");

        for (int j = 0; j < Subjects1.Count; j++)
        {
            Console.WriteLine(Subjects1[j].getModelComponentID());
            


        }

        Console.WriteLine("\nAbstract Model Messages: ");

        for (int i = 0; i < Message0.Count; i++)
        {
            Console.WriteLine(Message0[i].getModelComponentID());
            Console.WriteLine(Message0[i].getMessageType());

        }

        Console.WriteLine("\nImplementing Model Messages: ");

        for (int i = 0; i < Message1.Count; i++)
        {
            Console.WriteLine(Message1[i].getModelComponentID());
            Console.WriteLine(Message1[i].getMessageType());



        }

        Console.WriteLine("\nCommunication Restrictions: ");

        for (int i = 0; i < Subjects1.Count; i++)
        {
            Console.WriteLine(Subjects1[i].GetType());
            // Console.WriteLine(Message1[i].getModelComponentLabelsAsStrings());

        }

       


        Console.WriteLine("\nImplementations for SID Subjects");
        int x = 0;
        foreach (IImplementingElement<ISubject> i in implementingElementsSet)
        {
            foreach (string referencemodelID in i.getImplementedInterfacesIDReferences() )
            {
                
                Console.WriteLine(referencemodelID);
                foreach (ISubject BaseSubjectID in Subjects0)
                {
                    if (referencemodelID==BaseSubjectID.ToString())
                    {
                         x = x + 1;
                    }

                }
                if (x==1)
                {
                    Console.WriteLine("Element impemented!");

                }
                else if (x<1)
                {
                    Console.WriteLine("Element not implemented!");

                }
                else
                {
                    Console.WriteLine("Element implemented " + x + " times!");

                }

            }

            }
        }

    }





