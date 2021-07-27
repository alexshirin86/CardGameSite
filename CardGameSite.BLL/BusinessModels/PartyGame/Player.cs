using System;
using Model.Item;

namespace Model.PartyGame {
	[Serializable]
	public class Player {
		public Deck<Card> DeckPlayer { get; init; }
		public Drop<Card> DropPlayer { get; init; }
		public ContainerFixed<Card> Hand { get; init; }
		public Container<Card> FieldFleet { get; init; }
		public Container<Card> FieldSupplyFleet { get; init; }
		public Interfaces.IAccount AccountPlayer { get; init; }
		public String Name { get; init; }

		public Player(Interfaces.IAccount account) {
			AccountPlayer = account;
			Name = AccountPlayer.Name;
			DropPlayer =new  Drop<Card>();
			Hand = new ContainerFixed<Card>( 7 );
			FieldFleet =new Container<Card>();
			FieldSupplyFleet =new Container<Card>();
			DeckPlayer = new Deck<Card>( AccountPlayer.GetIdGameDeck() );
		}
		public void AddCarHand(int count) {
			for(int i = count; i >= 0; i-- )
			{
				Hand.Add( DeckPlayer.Dequeue() );
			}
		}
		public void DropCardFromHand(int count) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void DropCardFromDeck(int count) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void DropCardFromFleet(int count) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void DropCardFromSupplyFleet(int count) {
			throw new System.NotImplementedException("Not implemented");
		}

		private Game game;

	}

}
