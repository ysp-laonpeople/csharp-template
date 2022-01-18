using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Server5.Actor
{
    public static class ActorHelper
    {        
        static Dictionary<string, IActorRef> actors = new Dictionary<string, IActorRef>();
        public static void AddActor(string name, IActorRef actor)
        {
            actors.Add(name, actor);
        }
        public static string GetPath(string name)
        {
            string result = string.Empty;
            result = actors.Where(g => g.Key.ToUpper() == name.ToUpper()).FirstOrDefault().Value.Path.ToString();
            return result;
        }
        public static Dictionary<string, string> GetPaths()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var actor in actors)
            {
                result.Add(actor.Key, actor.Value.Path.ToString());
            }
            return result;
        }
        public static Dictionary<string, IActorRef> GetActors()
        {
            return actors;
        }
        public static IActorRef GetActor(string name)
        {
            return actors[name];
        }
    }
}
