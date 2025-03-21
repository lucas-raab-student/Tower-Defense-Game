
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{ 
public class Path : MonoBehaviour
{

        [SerializeField] private List<Vector3> points = new List<Vector3>();
         void Awake()
        {
            CollectPoints();
        }

        private void CollectPoints()
        {
            points = new List<Vector3>();
          
            // Will require a GameObject to have a Grid script attached to it.
            Grid grid = FindObjectOfType<Grid>();

            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                Vector3 point = child.transform.position;

                points.Add(point);
                grid.Add(Grid.WorldToGrid(point), child);
                child.SetActive(false);
            }
        }
        public bool TryGetPoint(int  index,out Vector3 point)
        {
            point = Vector3.zero;
            if(index<0||index>=points.Count) return false;
            point = points[index];
            return true;
        }
    }
}