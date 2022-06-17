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



    public class CheckSID
    {
        //Use the communications with the getcorrespondents method to check whether communication exists while being forbidden
        //Klären: Bidirektional oder nicht?
        public int CheckCommunicationRestrictions (IList<ICommunicationRestriction> SpecifiedRestrictions, IList<IMessageExchange> ImplementingMessages )
        {
            int result = 0;
            Console.WriteLine("\nCheck Communication Restrictions:");
            foreach (ICommunicationRestriction r in SpecifiedRestrictions)

            {
                ISubject A = r.getCorrespondentA();
                ISubject B = r.getCorrespondentB();

                foreach (IMessageExchange m in ImplementingMessages)
                {

                    ISubject C = m.getSender();
                    ISubject D = m.getReceiver();
                    if ((C == A || C == B) && (D == A || D == B))
                    {
                        Console.WriteLine(r + " violated!");
                        result++;
                    }
                }
                


            }
            if (result == 0)
            {
                Console.WriteLine("SID Restriction Implementation valid.");
                return 1;
            }
            else
            {
                Console.WriteLine("SID Restriction Implementation not valid.");
                return 0;
            }
        }





    }

