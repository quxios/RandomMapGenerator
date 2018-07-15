using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RMG {
  public class RoomSpawn : MonoBehaviour {
    [HideInInspector] public Vector3 position;
    public bool spawned {
      get; private set;
    }
    public Room connectedTo {
      get; private set;
    }

    public void Clear() {
      spawned = false;
      connectedTo = null;
    }

    public void Connect(Room room) {
      spawned = true;
      connectedTo = room;
    }

    private void OnDrawGizmos() {
      Gizmos.color = connectedTo != null ? Color.green : Color.grey;
      Gizmos.DrawSphere(transform.position, 0.5f);
    }
  }
}