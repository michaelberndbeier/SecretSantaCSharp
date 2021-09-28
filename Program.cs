using System;
using System.Linq;
using System.Collections.Generic;

namespace SecretSantaCSharp
{
	class Program
	{
		static void Main(string[] args)
		{
			PrintPairings(GetPairings(GetSenders(GetParticipants(args))));
		}

		static void PrintPairings(List<Tuple<String, String>> pairings)
		{
			foreach (var pairing in pairings) { Console.WriteLine(pairing); }
		}

		static List<String> GetParticipants(string[] args)
		{
			// From pipe call
			if(Console.IsInputRedirected) { return GetParticipantsFromPipe(); }
			// Standard arguments call like dotnet run -- Alice Bob Tick Sebastian
			if(args.Length > 0) { return GetParticipantsFromArgs(args); }
			return GetDummyParticipants();
		}

        static List<String> GetParticipantsFromArgs(string[] args)
        {
			return new List<String>(args);
        }

		static List<String> GetParticipantsFromPipe()
		{
			var participants = new List<String>();
			String currentItem;
			while ((currentItem = Console.ReadLine()) != null) { participants.Add(currentItem); }
			return participants;
		}

		static List<String> GetDummyParticipants()
		{
			return new List<String>(){"Michael", "Alice", "Bob", "Charlie", "Detlef"};
		}

		static List<String> GetSenders(List<String> participants)
		{
			var rand = new Random();
			return participants.OrderBy(participant => rand.Next()).ToList();
		}

		static List<Tuple<String, String>> GetPairings(List<String> senders)
		{
			var pairings = new List<Tuple<String, String>>();

			var numParticipants = senders.Count;
			var offset = GetOffset(numParticipants);

			int senderIndex = 0;
			foreach (var sender in senders)
            { 
                pairings.Add(Tuple.Create(sender, senders[GetReceiverIndex(senderIndex++, numParticipants, offset)])); 
            }

			return pairings;
		}

		static int GetOffset(int numParticipants)
		{
			var rand = new Random();
            return rand.Next(numParticipants - 1) + 1;
		}

		static int GetReceiverIndex(int senderIndex, int numParticipants, int offset) {
			return (senderIndex + offset) % numParticipants;
		}

	}
}

