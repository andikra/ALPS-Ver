
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








       
        }

    }





