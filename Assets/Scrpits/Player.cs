using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

namespace TowerDefense
{
    public class Player : MonoBehaviour
    {
        public GameObject towerPrefab;
        public int gold;
        Cursor cursor;
        UICursorCapture cursorCapture;



        Grid grid;
        private void Awake()
        {
            grid = FindObjectOfType<Grid>();
            cursorCapture = FindAnyObjectByType<UICursorCapture>();
            cursor = GetComponentInChildren<Cursor>();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0)&& !cursorCapture.cursorOverUi)
            {
                TryPlaceTower(grid, Grid.WorldToGrid(cursor.transform.position));
            }
        }
        public bool TryPlaceTower(Grid grid, Vector3Int tileCoordinates)
        {
            if (gold < Tower_SO.GetCost(towerPrefab)) return false;
        
            if (grid.Occupied(tileCoordinates)) return false;
            GameObject Newtower=Instantiate(towerPrefab,tileCoordinates,Quaternion.identity);
            grid.Add(tileCoordinates, Newtower);
                
                gold-=Tower_SO.GetCost(towerPrefab);
            ValueDisplay.OnValueChanged.Invoke("PlayerGold", gold);
                return true;
            }


        }
    }
