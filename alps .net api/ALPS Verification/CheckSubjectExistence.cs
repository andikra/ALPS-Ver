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


    public class CheckSubjectExistence
    {
    public void CheckExistence(IList<IImplementingElement<ISubject>> implementing, IList<ISubject> specifying)
    {
        Console.WriteLine("Specified Subjects:");

        foreach (ISubject i in specifying)
        {
            int z = 0;
            Console.WriteLine(i.getModelComponentID()) ;

            foreach (var j in implementing)
            {
                foreach (string ID in j.getImplementedInterfacesIDReferences())
                {
                    if (i.getModelComponentID() == ID)
                    {
                       z++;
                        Console.WriteLine(ID);

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

