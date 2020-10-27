using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snow.GraphQL
{
    public class SnowSchema : Schema
    {
        public SnowSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<SnowQuery>();
            Mutation = resolver.Resolve<SnowMutation>();
            Subscription = resolver.Resolve<SnowSubscription>();
        }
    }
}
