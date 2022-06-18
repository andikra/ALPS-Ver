using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alps.net.api.StandardPASS;
using System.Linq;
using alps.net.api.parsing;
using VDS.RDF;
using System.Collections.Generic;
using alps.net.api.ALPS;

public class GetCorrespondingElementsALL
{        



    public List<Tuple<ISubject, ISubject>> GetSubjects(IList<IPASSProcessModel> Models)
    {

        LogWriter Sub = new LogWriter("Subjects:");


        IList<ISubject> Subjects0 = Models[0].getAllElements().Values.OfType<ISubject>().ToList();
        IList<ISubject> Subjects1 = Models[1].getAllElements().Values.OfType<ISubject>().ToList();


        Console.WriteLine("\nSubject Implementation:");
        var Elements = new List<Tuple<ISubject, ISubject>>();


        foreach (ISubject i in Subjects0)
        {
            
            int z = 0;
            Console.WriteLine(i.getUriModelComponentID());
            LogWriter log = new LogWriter(i.getUriModelComponentID());

            foreach (ISubject j in Subjects1)
            {
                foreach (string ID in j.getImplementedInterfacesIDReferences())
                {
                    if (i.getUriModelComponentID() == ID)
                    {

                        z++;
                        Elements.Add(new Tuple<ISubject, ISubject>(i, j));
                        //  Console.WriteLine(ID);
                       
                    }

                }
                

            }
            switch (z)
            {
                case 1:
                    Console.WriteLine("Element implemented!");
                    LogWriter logcor = new LogWriter(i+" Element implemented!");
                    break;
                case > 1:
                    Console.WriteLine("Element implemented " + z + " times!");
                    LogWriter logcor2 = new LogWriter(i+" Element implemented" + z + " times!");

                    break;
                case < 1:
                    Console.WriteLine("Element not implemented!");
                    LogWriter logcor3 = new LogWriter(i+" Element not implemented!");
                    Elements.Add(new Tuple<ISubject, ISubject>(i, i ));

                    break;
            }
        }
        return Elements;
       
    }
    public List<Tuple<IMessageExchange, IImplementingElement<IMessageExchange>>> GetMessages(IList<IPASSProcessModel> Models)
    {

        LogWriter Sub = new LogWriter("Messages:");


        IList<IMessageExchange> Message0 = Models[0].getAllElements().Values.OfType<IMessageExchange>().ToList();
        IList<IImplementingElement<IMessageExchange>> Message1 = Models[1].getAllElements().Values.OfType<IImplementingElement<IMessageExchange>>().ToList();


        Console.WriteLine("\nMessage Implementation:");
        var Messages = new List<Tuple<IMessageExchange, IImplementingElement<IMessageExchange>>>();


        foreach (IMessageExchange i in Message0)
        {

            int z = 0;
            Console.WriteLine(i.getUriModelComponentID());
            LogWriter log = new LogWriter(i.getUriModelComponentID());

            foreach (IImplementingElement<IMessageExchange> j in Message1)
            {
                foreach (string ID in j.getImplementedInterfacesIDReferences())
                {
                    if (i.getUriModelComponentID() == ID)
                    {

                        z++;
                        Messages.Add(new Tuple<IMessageExchange, IImplementingElement<IMessageExchange>>(i, j));
                        //  Console.WriteLine(ID);

                    }

                }


            }
            switch (z)
            {
                case 1:
                    Console.WriteLine("Element implemented!");
                    LogWriter logcor = new LogWriter(i + " Element implemented!");
                    break;
                case > 1:
                    Console.WriteLine("Element implemented " + z + " times!");
                    LogWriter logcor2 = new LogWriter(i + " Element implemented" + z + " times!");

                    break;
                case < 1:
                    Console.WriteLine("Element not implemented!");
                    LogWriter logcor3 = new LogWriter(i + " Element not implemented!");
                    Messages.Add(new Tuple<IMessageExchange, IImplementingElement<IMessageExchange>>(i, null));


                    break;
            }
        }
        return Messages;

    }

    public List<Tuple<ICommunicationAct, IImplementingElement<ICommunicationAct>>> GetMessageTransitions(IList<IPASSProcessModel> Models)
    {

        LogWriter Sub = new LogWriter("Message Transitions:");


        IList<ICommunicationAct> MessageTrans0 = Models[0].getAllElements().Values.OfType<ICommunicationAct>().ToList();
        IList<IImplementingElement<ICommunicationAct>> MessageTrans1 = Models[1].getAllElements().Values.OfType<IImplementingElement<ICommunicationAct>>().ToList();


        Console.WriteLine("\nMessage Transition Implementation:");
        var Messages = new List<Tuple<ICommunicationAct, IImplementingElement<ICommunicationAct>>>();


        foreach (ICommunicationAct i in MessageTrans0)
        {

            int z = 0;
            Console.WriteLine(i.getUriModelComponentID());
            LogWriter log = new LogWriter(i.getUriModelComponentID());

            foreach (IImplementingElement<ICommunicationAct> j in MessageTrans1)
            {
                foreach (string ID in j.getImplementedInterfacesIDReferences())
                {
                    if (i.getUriModelComponentID() == ID)
                    {

                        z++;
                        Messages.Add(new Tuple<ICommunicationAct, IImplementingElement<ICommunicationAct>>(i, j));
                        //  Console.WriteLine(ID);

                    }

                }


            }
            switch (z)
            {
                case 1:
                    Console.WriteLine("Element implemented!");
                    LogWriter logcor = new LogWriter(i + " Element implemented!");
                    break;
                case > 1:
                    Console.WriteLine("Element implemented " + z + " times!");
                    LogWriter logcor2 = new LogWriter(i + " Element implemented" + z + " times!");

                    break;
                case < 1:
                    Console.WriteLine("Element not implemented!");
                    LogWriter logcor3 = new LogWriter(i + " Element not implemented!");
                    Messages.Add(new Tuple<ICommunicationAct, IImplementingElement<ICommunicationAct>>(i, null));


                    break;
            }
        }
        return Messages;

    }

    public List<Tuple<ICommunicationRestriction, IImplementingElement<ICommunicationRestriction>>> GetMessageRestriction(IList<IPASSProcessModel> Models)
    {

        LogWriter Sub = new LogWriter("Message Restrictions:");


        IList<ICommunicationRestriction> MessageTrans0 = Models[0].getAllElements().Values.OfType<ICommunicationRestriction>().ToList();
        IList<IImplementingElement<ICommunicationRestriction>> MessageTrans1 = Models[1].getAllElements().Values.OfType<IImplementingElement<ICommunicationRestriction>>().ToList();


        Console.WriteLine("\nMessage Restriction Implementation:");
        var Messages = new List<Tuple<ICommunicationRestriction, IImplementingElement<ICommunicationRestriction>>>();


        foreach (ICommunicationRestriction i in MessageTrans0)
        {

            int z = 0;
            Console.WriteLine(i.getUriModelComponentID());
            LogWriter log = new LogWriter(i.getUriModelComponentID());

            foreach (IImplementingElement<ICommunicationRestriction> j in MessageTrans1)
            {
                foreach (string ID in j.getImplementedInterfacesIDReferences())
                {
                    if (i.getUriModelComponentID() == ID)
                    {

                        z++;
                        Messages.Add(new Tuple<ICommunicationRestriction, IImplementingElement<ICommunicationRestriction>>(i, j));
                        //  Console.WriteLine(ID);

                    }

                }


            }
            switch (z)
            {
                case 1:
                    Console.WriteLine("Element implemented!");
                    LogWriter logcor = new LogWriter(i + " Element implemented!");
                    break;
                case > 1:
                    Console.WriteLine("Element implemented " + z + " times!");
                    LogWriter logcor2 = new LogWriter(i + " Element implemented" + z + " times!");

                    break;
                case < 1:
                    Console.WriteLine("Element not implemented!");
                    LogWriter logcor3 = new LogWriter(i + " Element not implemented!");
                    Messages.Add(new Tuple<ICommunicationRestriction, IImplementingElement<ICommunicationRestriction>>(i, null));


                    break;
            }
        }
        return Messages;

    }
}