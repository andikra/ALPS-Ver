
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

        HelperClass helper = new HelperClass();
        IList<IPASSProcessModel> models = helper.importModels();
        LogWriter log = new LogWriter("Kra");
        





        // Used SID Values from the implementing model:
        IList<IImplementingElement<ISubject>> implementingElementsSet = models[1].getAllElements().Values.OfType<IImplementingElement<ISubject>>().ToList();
        IList<IImplementingElement<IMessageSpecification>> implementingElementsMessage = models[1].getAllElements().Values.OfType<IImplementingElement<IMessageSpecification>>().ToList();
        IList<IImplementingElement<IMessageSpecification>> implementingElementsMessageSpecs = models[1].getAllElements().Values.OfType<IImplementingElement<IMessageSpecification>>().ToList();
        IList<IImplementingElement> implementingElements = models[1].getAllElements().Values.OfType<IImplementingElement>().ToList();
        IList<IMessageExchange> impElementsMessages = models[1].getAllElements().Values.OfType<IMessageExchange>().ToList();
        IList<IPASSProcessModelElement> implementingElementsStandard = models[1].getAllElements().Values.OfType<IPASSProcessModelElement>().ToList();

 // Used SID Values from the specifying model:
        IList<IALPSSIDComponent> specElements = models[0].getAllElements().Values.OfType<IALPSSIDComponent>().ToList();
        IList<ISubject> specifyingElementsSubject = models[0].getAllElements().Values.OfType<ISubject>().ToList();
        IList<IMessageSpecification> specifyingElementsMessages = models[0].getAllElements().Values.OfType<IMessageSpecification>().ToList();
        IList<ICommunicationRestriction> specifyingElementsRestrictions = models[0].getAllElements().Values.OfType<ICommunicationRestriction>().ToList();
        IList<IPASSProcessModelElement> specifyingElementsStandard = models[0].getAllElements().Values.OfType<IPASSProcessModelElement>().ToList();




//Methods for SID Implementation Existence checks:
        GetCorrespondingElementsALL GetAll = new GetCorrespondingElementsALL();

        List<Tuple<ISubject, ISubject>> Subjects = GetAll.GetSubjects(models);
        List<Tuple<IMessageExchange, IImplementingElement<IMessageExchange>>> Messages = GetAll.GetMessages(models);
        List<Tuple<ICommunicationAct, IImplementingElement<ICommunicationAct>>> Transitions = GetAll.GetMessageTransitions(models);
        List<Tuple<ICommunicationRestriction, IImplementingElement<ICommunicationRestriction>>> restrictions = GetAll.GetMessageRestriction(models);
        List<Tuple<IState, IState>> States =GetAll.GetStates(models);
        List<Tuple<ITransition, ITransition>> SBDTransitions = GetAll.GetTransitions(models);



        //Methods for SID Validity checks: 
        CheckSID CheckSID = new CheckSID();
        int ResultCheckSIDRestrictions = CheckSID.CheckCommunicationRestrictions(specifyingElementsRestrictions, impElementsMessages);
        CheckSID.CheckSubject(Subjects);
        CheckSID.CheckMessageconnectors(Transitions);

//Methods for SID Validity checks: 
        CheckSBD CheckSBD = new CheckSBD();








        /*

        //Testing Section
        IList<ISubject> Subjects1 = models[1].getAllElements().Values.OfType<ISubject>().ToList();
        IList<ISubject> Subjects0 = models[0].getAllElements().Values.OfType<ISubject>().ToList();

        IList<IMessageExchange> Message0 = models[0].getAllElements().Values.OfType<IMessageExchange>().ToList();
        IList<IMessageExchange> Message1 = models[1].getAllElements().Values.OfType<IMessageExchange>().ToList();
        IDictionary<string, IMessageExchange> MessagesIncoming = new Dictionary<string, IMessageExchange>();



        Console.WriteLine("\nSpecifying Model Subject Types: ");

        for (int i = 0; i < Subjects0.Count; i++)

        {
            
            Console.WriteLine(Subjects0[i].GetType());

        }
        Console.WriteLine("\nSpecifying Model Subjects: ");

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

        Console.WriteLine("\nSpecifying Model Messages: ");

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

            }*/
        }

    }





