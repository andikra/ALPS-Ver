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

public class GetCorrespondingElements
{

    public List<Tuple<ISubject, ISubject>> GetCorrElements(IList<IImplementingElement<ISubject>> implementing, IList<ISubject> specifying)
    {
        Console.WriteLine("\nCorresponding Elements:");
        var Elements = new List<Tuple<ISubject, ISubject>>();
        {
        };
        foreach (ISubject i in specifying)
        {
            int z = 0;
            Console.WriteLine(i.getUriModelComponentID());

            foreach (ISubject j in implementing)
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
                    break;
                case > 1:
                    Console.WriteLine("Element implemented " + z + " times!");
                    break;
                case < 1:
                    Console.WriteLine("Element not implemented!");
                    break;
            }
        }
        return Elements;

    }
}