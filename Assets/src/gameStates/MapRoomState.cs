// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.12
// 

using Colyseus.Schema;

public partial class MapRoomState : Schema {
	[Type(0, "map", typeof(MapSchema<MapInfo>))]
	public MapSchema<MapInfo> maps = new MapSchema<MapInfo>();
}

