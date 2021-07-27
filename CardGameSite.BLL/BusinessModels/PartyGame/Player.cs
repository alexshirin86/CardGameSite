using System;
using CardGameSite.BLL.BusinessModels.Item;
using CardGameSite.BLL.BusinessModels.Account.Interfaces;

namespace CardGameSite.BLL.BusinessModels.PartyGame {
	[Serializable]
	public class Player {
		public Deck<Card> DeckPlayer { get; }
		public Drop<Card> DropPlayer { get; }
		public ContainerFixed<Card> Hand { get; }
		public Container<Card> FieldFleet { get; }
		public Container<Card> FieldSupplyFleet { get; }
		public IAccount AccountPlayer { get; }
		public String Name { get; }

		public Player(IAccount account) {
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
