// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.12
// 

using Colyseus.Schema;

public partial class MapInfo : Schema {
	[Type(0, "map", typeof(MapSchema<ObjectState>))]
	public MapSchema<ObjectState> objects = new MapSchema<ObjectState>();

	[Type(1, "string")]
	public string name = default(string);
}

