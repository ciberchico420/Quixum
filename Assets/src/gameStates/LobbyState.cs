// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.5.39
// 

using Colyseus.Schema;

public class LobbyState : Schema {
	[Type(0, "map", typeof(MapSchema<MRoom>))]
	public MapSchema<MRoom> rooms = new MapSchema<MRoom>();
}

