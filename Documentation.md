Out of laziness only public will be listed. Sorry! code should be pretty readable if you need to know the private stuff.

# class MapGenerator
Generates a map using from gameobjects with a `Room` component.

## Fields / Properties
- `public int minRooms` | field 
  The minimum amount of rooms
- `public int maxRooms` | field 
  The maximum amount of rooms
- `public List<Room> spawnedRooms` | property | public get, private set 
  A List of all the room it spawned
- `public System.Random rng` | property | public get, private set 
  The Random class that was used. If you're randomizing inside your room, you should use this Random class that way if you need to regenerate the same map the outcome will be the same.
- `public int seed` | property | public get, private set 
  The last seed used for the Random. You can access this value incase you need to save it if you need to return to this random map. Ex; going back a previous map.

## Methods
- `public void Generate()` 
  Generates a map using a random seed
- `public void Generate(int newSeed)` 
  Generates a map using the seed passed in

# class Room
## Fields / Properties
- `public Bounds bounds` | property | public get, private set
  The bounds of the room. Used for collision testing when trying to place a room
- `public RoomSpawn[] spawns` | property | public get, private set
  A List of spawns. (I see no reason for this to be used other then for the MapGenerator)
- `public List<RoomSpawn> openSpawns` | property | public get, private set
  A List of spawns that haven't spawned. (I see no reason for this to be used other then for the MapGenerator)
- `public Dictionary<Dir, List<RoomSpawn>> sortedSpawns` | property | public get, private set
  A Dictionary of the spawns sorted by their Dir. (I see no reason for this to be used other then for the MapGenerator)
- `public List<Room> connections` | property | public get, private set
  A List of the rooms this room is connected to
- `public int distanceFromHome` | field
  The number of rooms this room is away from the start room.

## Methods
All these public methods should only be used from `MapGenerator`. I see no reason for them to be used otherwise.
- `public void Init()` 
  Initializes properties.
- `public void CloseSpawn(RoomSpawn spawn, Room connection)` 
  Closes a spawn and sets it's connection.
- `public void AddConnection(Room room)` 
  Adds a room it connected to
- `public bool HasExit(Dir dir)` 
  Checks if it has a spawn for the passed Dir

# class RoomSpawn
## Fields / Properties
- `public bool spawned` | property | public get, private set 
  return true if this spawn was already spawned
- `public Room connectedTo` | property | public get, private set 
  returns the `Room` its connected to

## Methods
All these public methods should only be used from `Room`. I see no reason for them to be used otherwise.
- `public void Clear()` 
  Resets the `spawned` and `connectedto` properties
- `public void Connect(Room room) `
  Connects this spawn