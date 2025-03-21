using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Grid : MonoBehaviour
        
    {
        private Dictionary<Vector3Int,GameObject> gameObjects = new Dictionary<Vector3Int,GameObject>();
        public bool Add(Vector3Int tileCoordinates, GameObject gameObject)
        {
            if (gameObjects.ContainsKey(tileCoordinates)) return false;
            gameObjects.Add(tileCoordinates, gameObject);
            return true;
        }
        public void Remove(Vector3Int tileCoordinates)
        {
            if (!gameObjects.ContainsKey(tileCoordinates)) return;
            Destroy(gameObjects[tileCoordinates]);
            gameObjects.Remove(tileCoordinates);
        }
        public static Vector3Int WorldToGrid(Vector3 worldPosition)
        {
            int GridX=Mathf.RoundToInt(worldPosition.x);
            int GridY=Mathf.RoundToInt(worldPosition.y);
            int GridZ=Mathf.RoundToInt(worldPosition.z);
            return new Vector3Int(GridZ, GridX, GridY); 
        }
        public static Vector3Int WorldT0Grid(Vector3Int gridPostion)
        {
       
            Vector3Int worldPosition = WorldT0Grid(gridPostion);
            return worldPosition;
        }
    }
}


