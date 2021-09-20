using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretSantaCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var participants = new List<String>();
            participants.Add("Michael");
            participants.Add("Alice");
            participants.Add("Bob");
            participants.Add("Charlie");

            var pairings = GetPairingsClassic(participants);
            PrintPairings(pairings);

        }

static void PrintPairings(List<Tuple<String, String>> pairings)
{
    foreach(var pair in pairings)
    {
        Console.WriteLine("{0} -> {1}", pair.Item1, pair.Item2);
    }

}

        static int GetOffset(int numParticipants)
        {
            var random = new Random();
            return random.Next(1, numParticipants);
        }

        static int GetReceiverIndex(int senderIndex, int numParticipants, int offset)
        {
            int virtualIndex = senderIndex + offset;
            int adjustedIndex = virtualIndex % numParticipants;
            return adjustedIndex;
        }

        static List<Tuple<String, String>> GetPairingsClassic(List<String> senders)
        {

            var retVal = new List<Tuple<String, String>>();
            var numParticipants = senders.Count;
            var offset = GetOffset(numParticipants);


            var senderIndex = 0;
            foreach(var sender in senders)
            {
                var receiver = senders[GetReceiverIndex(senderIndex, numParticipants, offset)];
                retVal.Add(new Tuple<String, String>(sender, receiver));
                senderIndex++;
            }

            return retVal;
        }

    }
}