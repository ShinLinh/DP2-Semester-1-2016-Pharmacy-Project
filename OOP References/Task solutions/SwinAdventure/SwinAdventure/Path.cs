using System;

namespace SwinAdventure
{
	public class Path : IdentifiableObject
	{
		private Location _destination;
		private string _movementDescription;

		public Path (string [] ids, Location destination, string description): base (ids)
		{
			_destination = destination;
			_movementDescription = description;
		}

		public void MovePlayer(Player p)
		{
			p.Move (_destination);
		}

		public Location Destination
		{
			get
			{
				return _destination;
			}
		}

		public string Description
		{
			get
			{
				return _movementDescription;
			}
		}
	}
}

