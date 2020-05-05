﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Spawns break in enemies. Gives them a defence point and notifies defence point enemy behaviour script.
 */

public class Spawner : MonoBehaviour
{
    public DefencePointEnemyBehaviour DefencePointEnemyBehaviour;

    [Header("Defence Point")]
    public int areaIndex;
    public DefencePoint defencePoint;

	void Start ()
    {
        DefencePointEnemyBehaviour = defencePoint.GetComponentInChildren<DefencePointEnemyBehaviour>();
	}
	
	void Update ()
    {
        //Testing.
        //if (Input.GetKeyDown(KeyCode.Alpha9))
        //    SpawnEnemy(enemyPrefab);
    }

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        //Switch in case I want to spawn a different type of enemy that has different behaviour.
        switch(enemyPrefab.tag)
        {
            case "BreakInEnemy":
                BreakInEnemy enemyToSpawn = Instantiate(enemyPrefab.GetComponent<BreakInEnemy>(), transform.position, Quaternion.identity);
                enemyToSpawn.defencePoint = defencePoint;
                enemyToSpawn.LeftDefencePointEvent += DefencePointEnemyBehaviour.OnEnemyLeaveDefencePoint;
                DefencePointEnemyBehaviour.AddEnemyToList(enemyToSpawn);
                DefencePointEnemyBehaviour.GiveEnemyTargetPositionAtSpawn(enemyToSpawn);
                break; 
        }
    }

}
