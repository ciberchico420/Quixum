// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.5.39
// 

using Colyseus.Schema;

public class UserState : Schema {
	[Type(0, "string")]
	public string sessionId = "";

	[Type(1, "string")]
	public string name = "";

	[Type(2, "number")]
	public float gems = 0;

	[Type(3, "number")]
	public float energy = 0;

	[Type(4, "map", typeof(MapSchema<ArenaItemState>))]
	public MapSchema<ArenaItemState> shop = new MapSchema<ArenaItemState>();

	[Type(5, "map", typeof(MapSchema<ArenaItemState>))]
	public MapSchema<ArenaItemState> board = new MapSchema<ArenaItemState>();
}

