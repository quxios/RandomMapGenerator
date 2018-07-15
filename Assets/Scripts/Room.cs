using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RMG {
  public class Room : MonoBehaviour {
    [SerializeField] private Bounds _bounds;
    public Bounds bounds {
      get { return _bounds; }
    }

    public RoomSpawn[] spawns {
      get; private set;
    }

    public List<RoomSpawn> openSpawns {
      get; set;
    }

    public Dictionary<Dir, List<RoomSpawn>> sortedSpawns {
      get; private set;
    }

    public List<Room> connections {
      get; private set;
    }

    public int distanceFromHome = 0;

    public void Init() {
      spawns = GetComponentsInChildren<RoomSpawn>(true);
      connections = new List<Room>();
      openSpawns = new List<RoomSpawn>(spawns);
      sortedSpawns = new Dictionary<Dir, List<RoomSpawn>>() {
        {Dir.top, new List<RoomSpawn>()},
        {Dir.bottom, new List<RoomSpawn>()},
        {Dir.left, new List<RoomSpawn>()},
        {Dir.right, new List<RoomSpawn>()}
      };
      foreach (RoomSpawn spawn in spawns) {
        spawn.Clear();
        spawn.position = spawn.transform.position;
        Dir dir = Utils.Vector3ToDir(spawn.position);
        sortedSpawns[dir].Add(spawn);
      }
    }

    public void CloseSpawn(RoomSpawn spawn, Room connection) {
      spawn.Connect(connection);
      openSpawns.Remove(spawn);
    }

    public void AddConnection(Room room) {
      connections.Add(room);
    }

    public bool HasExit(Dir dir) {
      return sortedSpawns[dir].Count > 0;
    }

    private void OnDrawGizmosSelected() {
      Gizmos.color = Color.red;
      Gizmos.DrawWireCube(transform.position + bounds.center, bounds.size);
    }

  }
}