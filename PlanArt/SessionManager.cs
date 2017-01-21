using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace PlanArt
{
    public static class SessionManager
    {
        public static ISession session;

        public static ISession GetSession()
        {
            if (session == null)
            {
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                session = cluster.Connect("PlanArt2");
                //ICqlClient client = CqlClientConfiguration.ForSession(session).BuildCqlClient();
            }

            return session;
        }
    }
}
