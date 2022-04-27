using alps.net.api.StandardPASS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GetLists
{
    public IList<ISubject> GetStandardSubjects(IList<IImplementingElement<ISubject>> implementing, IList<ISubject> specifying)
    {
        IList<ISubject> StandardSubjects = new List<ISubject>();

        foreach (ISubject i in specifying)
        {

            foreach (var j in implementing)
            {
                foreach (string ID in j.getImplementedInterfacesIDReferences())
                {
                    if (i.getUriModelComponentID() == ID)
                    {
                        StandardSubjects.Add(i);
                        //  Console.WriteLine(ID);

                    }

                }

            }
        }
        return StandardSubjects;    
    }
}
