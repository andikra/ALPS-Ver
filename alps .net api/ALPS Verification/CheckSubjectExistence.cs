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
using alps.net.api.ALPS.ALPSModelElements.ALPSSIDComponents;

public class CheckSubjectExistence
    {
    public void CheckRestrictions(IList<IMessageExchange> implementing, IList<ICommunicationRestriction> specifying)
    {
        Console.WriteLine("\nSpecified Restrictions:");

        foreach (ICommunicationRestriction i in specifying)
        {
            Console.WriteLine(i.getModelComponentLabelsAsStrings()[0]);

           // Console.WriteLine("Between " + i.getSender() + " and " + i.getReceiver());



            foreach (var j in implementing)
            {
                if (j.getSender()==i.getSender())
                {
                    if (j.getReceiver()==i.getReceiver())
                    {
                        Console.WriteLine("Restriction violated!");

                    }
                }

            }
            
        }

    }
    public void CheckExistence(IList<IImplementingElement<ISubject>> implementing, IList<ISubject> specifying)
    {
        Console.WriteLine("\nSpecified Subjects:");

        foreach (ISubject i in specifying)
        {
            int z = 0;
            Console.WriteLine(i.getUriModelComponentID()) ;

            foreach (var j in implementing)
            {
                foreach (string ID in j.getImplementedInterfacesIDReferences())
                {
                    if (i.getUriModelComponentID() == ID)
                    {
                       z++;
                      //  Console.WriteLine(ID);

                    }

                }
                
            }
            switch (z)
            {
                case 1:
                    Console.WriteLine("Element implemented!");
                    break;
                case > 1:
                    Console.WriteLine("Element implemented " + z + " times!");
                    break;
                case < 1:
                    Console.WriteLine("Element not implemented!");
                    break;
            }
        }

    }
    public void CheckExistenceMessage(IList<IImplementingElement<IMessageExchange>> implementing_message, IList<IMessageExchange> specifying_message)
    {
        Console.WriteLine("\nSpecified Messages:");

        foreach (IMessageExchange i in specifying_message)
        {
            int z = 0;
            Console.WriteLine(i.getUriModelComponentID());

            foreach (var j in implementing_message)
            {
                foreach (string ID in j.getImplementedInterfacesIDReferences())
                {
                    if (i.getUriModelComponentID() == ID)
                    {
                        z++;
                        //Console.WriteLine(ID);

                    }

                }

            }
            switch (z)
            {
                case 1:
                    Console.WriteLine("Element implemented!");
                    break;
                case > 1:
                    Console.WriteLine("Element implemented " + z + " times!");
                    break;
                case < 1:
                    Console.WriteLine("Element not implemented!");
                    break;
            }
        }

    }
    public void CheckExistenceMessageSpecs(IList<IImplementingElement<IMessageSpecification>> implementing_message, IList<IMessageSpecification> specifying_message)
    {
        Console.WriteLine("\nSpecified MessageSpecs:");

        foreach (IMessageSpecification i in specifying_message)
        {
            int z = 0;
            Console.WriteLine(i.getUriModelComponentID());

            foreach (var j in implementing_message)
            {
                foreach (string ID in j.getImplementedInterfacesIDReferences())
                {
                    if (i.getUriModelComponentID() == ID)
                    {
                        z++;
                        //Console.WriteLine(ID);

                    }

                }

            }
            switch (z)
            {
                case 1:
                    Console.WriteLine("Element implemented!");
                    break;
                case > 1:
                    Console.WriteLine("Element implemented " + z + " times!");
                    break;
                case < 1:
                    Console.WriteLine("Element not implemented!");
                    break;
            }
        }

    }
}

