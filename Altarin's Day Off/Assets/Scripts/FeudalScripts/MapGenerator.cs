﻿using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {



	public GameObject normalTilePrefab;
	public int mapSize;
	public f_Tile[] specialTiles; // holds tile types of special tiles to replace tiles with.

	//NetworkManager networkManager;
	//bool isOffline;


	/*void FindNetworkManager(){

		networkManager = FindObjectOfType<NetworkManager> ();

		if (networkManager == null) {
				
			isOffline = true;
		
		}

		else{

			isOffline = false;

		}
	
	
	}*/


	
	void InstantiateTile(int x, int y, Vector3 position, GameObject prefab){

		GameObject tile;


		/*if (!isOffline) {
			tile = PhotonNetwork.Instantiate (prefab, position, Quaternion.identity) as GameObject;
			tile.AddComponent<PhotonView>();
			
		}*/




	
		tile = Instantiate (prefab, position, Quaternion.identity) as GameObject;

		f_Tile t = tile.GetComponent<f_Tile> ();

		t.x = x;
		t.y = y;


	
	}




	void GenerateMap(int size){

		Vector3 tilePos = new Vector3 (0, 0, 0);


		for(int y = 0; y < size; y++){

			tilePos.y = y * 1.06f;

			for(int x = 0; x < size; x++){

				tilePos.x = x * 1.06f;
				bool isSpecialUsed = false;

				for(int i = 0; i < specialTiles.Length; i++){

					if(specialTiles[i].x == x && specialTiles[i].y == y){

						specialTiles[i].transform.position = tilePos;
						isSpecialUsed = true;
					/*	if(!isOffline){

							specialTiles[i].gameObject.AddComponent<PhotonView>();

						}*/
						break;
					}

					else{}
					
				}

				if(!isSpecialUsed){

					InstantiateTile(x, y, tilePos, normalTilePrefab);

				}

				else{}
			}
			
		}
	
	}


	

	void Awake () {
	
		//FindNetworkManager ();
		GenerateMap (mapSize);


	}

}
