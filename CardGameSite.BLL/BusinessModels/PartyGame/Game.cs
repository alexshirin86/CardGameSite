using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;


namespace Model.PartyGame {
	[Serializable]
	public class Game {
		public Player PlayerOne { get; init; }
		public Player PlayerTwo { get; init; }

		public Game(Interfaces.IAccount accountOne, Interfaces.IAccount accountTwo) {
			PlayerOne = new Player(accountOne);
			PlayerTwo = new Player(accountTwo);
			
		}

		public void NextPlayerMove(Player player) {
			throw new System.NotImplementedException("Not implemented");
		}
		async public void WriteMoveJson() {
			using (FileStream fs = new FileStream($"{PlayerOne.Name}_{PlayerTwo.Name}.json", FileMode.OpenOrCreate))
			{
				await JsonSerializer.SerializeAsync<Game>(fs, this);				
			}
		}

		async static Task<Game> ReadGameJson(string jsonPath)
		{
			Game game;
			using (FileStream fs = new FileStream($"{jsonPath}.json", FileMode.Open))
			{
				game = await JsonSerializer.DeserializeAsync<Game>(fs);
			}
			return game;
		}



	}

}
