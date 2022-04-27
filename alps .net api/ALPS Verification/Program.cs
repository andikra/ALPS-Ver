﻿
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using alps.net.api.StandardPASS;
using System.Linq;
using alps.net.api.parsing;
using VDS.RDF;
using System.Collections.Generic;
using alps.net.api.ALPS;

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
       // LoaderClass load = new LoaderClass();
       //IList<IPASSProcessModel> models = load.importModels();

        HelperClass helper = new HelperClass();
        IList<IPASSProcessModel> models = helper.importModels();





        // Check if all Subjects of model 0 are implemented in model 1
        IList<IImplementingElement<ISubject>> implementingElementsSet = models[1].getAllElements().Values.OfType<IImplementingElement<ISubject>>().ToList();
        IList<IImplementingElement<IMessageSpecification>> implementingElementsMessage = models[1].getAllElements().Values.OfType<IImplementingElement<IMessageSpecification>>().ToList();
        IList<IImplementingElement<IMessageSpecification>> implementingElementsMessageSpecs = models[1].getAllElements().Values.OfType<IImplementingElement<IMessageSpecification>>().ToList();

        IList<ISubject> specifyingElementsSubject = models[0].getAllElements().Values.OfType<ISubject>().ToList();
        IList<IMessageSpecification> specifyingElementsMessages = models[0].getAllElements().Values.OfType<IMessageSpecification>().ToList();
        IList<IMessageExchange> impElementsMessages = models[1].getAllElements().Values.OfType<IMessageExchange>().ToList();

        IList<ICommunicationRestriction> specifyingElementsRestrictions = models[0].getAllElements().Values.OfType<ICommunicationRestriction>().ToList();





        CheckSubjectExistence checkSubject = new CheckSubjectExistence();
        GetCorrespondingElements getelements = new GetCorrespondingElements();
        getelements.GetCorrElements(implementingElementsSet, specifyingElementsSubject);
        checkSubject.CheckExistence(implementingElementsSet, specifyingElementsSubject);
        checkSubject.CheckExistenceMessage(implementingElementsMessage, specifyingElementsMessages);
        checkSubject.CheckRestrictions(impElementsMessages, specifyingElementsRestrictions);

        IList<ISubject> returnsubjects = checkSubject.CheckExistence(implementingElementsSet, specifyingElementsSubject);
        Console.WriteLine(returnsubjects);

        List<Tuple<ISubject, ISubject>> test = getelements.GetCorrElements(implementingElementsSet, specifyingElementsSubject);
        Console.WriteLine(test[0].Item1.getUriModelComponentID());






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





