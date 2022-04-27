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

public class CheckSubjectExistence
    {
    public void CheckRestrictions(IList<IMessageExchange> implementing, IList<ICommunicationRestriction> specifying)
    {
        Console.WriteLine("\nSpecified Restrictions:");

        foreach (ICommunicationRestriction i in specifying)
        {
            ISubject CorrA = i.getCorrespondentA();
            ISubject CorrB = i.getCorrespondentB();

            Console.WriteLine(i.getModelComponentLabelsAsStrings()[0]);

            Console.WriteLine(i.getCorrespondentA().getUriModelComponentID());
            Console.WriteLine(i.getCorrespondentB().getUriModelComponentID());



            // Console.WriteLine("Between " + i.getSender() + " and " + i.getReceiver());



            foreach (var j in implementing)
            {
                if (j.getSender().getUriModelComponentID()==i.getCorrespondentA().getUriModelComponentID())
                {
                    if (j.getReceiver().getUriModelComponentID() == i.getCorrespondentB().getUriModelComponentID())
                    {
                        Console.WriteLine("Restriction violated!");

                    }
                }
                else if (j.getReceiver().getUriModelComponentID() == i.getCorrespondentB().getUriModelComponentID())
                {
                    if (j.getSender().getUriModelComponentID() == i.getCorrespondentA().getUriModelComponentID())
                    {
                        Console.WriteLine("Restriction violated!");

                    }
                }
                

            }
            
        }

    }
    public IList<ISubject> CheckExistence(IList<IImplementingElement<ISubject>> implementing, IList<ISubject> specifying)
    {
        Console.WriteLine("\nSpecified Subjects:");
        IList<ISubject> resultSubjectsImplemented = new List<ISubject>();
       
        foreach (ISubject i in specifying)
        {
            int z = 0;
            Console.WriteLine(i.getUriModelComponentID()) ;

            foreach (ISubject j in implementing)
            {
                foreach (string ID in j.getImplementedInterfacesIDReferences())
                {
                    if (i.getUriModelComponentID() == ID)
                    {
                       z++;
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
        return resultSubjectsImplemented;

    }
    public void CheckExistenceMessage(IList<IImplementingElement<IMessageSpecification>> implementing_message, IList<IMessageSpecification> specifying_message)
    {
        Console.WriteLine("\nSpecified Messages:");
        //MessageSpecification verwenden!
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

