using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManualGenerator : MonoBehaviour
{
  [SerializeField] private GameObject blackCube, whiteCube, greenCube;
  [SerializeField] private GameObject roomOne, roomTwo, roomThree;
   private float distanceBetweenTiles = 1f;

   private void Update()
   {
      //room 2 and 3 
   }

   [ContextMenu("GenerateCubesRoom1")]
   private void GenerateCubesRoom1()
   {
      // room 10 by 20 black and white
      for (int i = 0; i < 10; i++)
      {
         Vector3 newPostion = new Vector3(0, 0, i * distanceBetweenTiles);
         Instantiate(whiteCube,  newPostion, Quaternion.identity,roomOne.transform);
      }
   }
   
   [ContextMenu("GenerateCubesRoom2")]
   private void GenerateCubesRoom2()
   {
      
      // in update move each row by spped * time.delta 
      // room 10 by 20 red and white alternating rows move on update
      for (int i = 0; i < 10; i++)
      {
         Vector3 newPostion = new Vector3(0, 0, i * distanceBetweenTiles);
         Instantiate(whiteCube,  newPostion, Quaternion.identity,roomOne.transform);
      }
   }
   
   [ContextMenu("GenerateCubesRoom3")]
   private void GenerateCubesRoom3()
   {
      
      // in update move each row by spped * time.delta 
      // room 10 by 20 red and black solid color fllor, cross on player row and column 
      for (int i = 0; i < 10; i++)
      {
         Vector3 newPostion = new Vector3(0, 0, i * distanceBetweenTiles);
         Instantiate(whiteCube,  newPostion, Quaternion.identity,roomOne.transform);
      }
   }
}
