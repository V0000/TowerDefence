﻿using UnityEngine;
using System.Collections;

public class BarracksSpawnController : SpawnController 
{

    public int level = 1;
    public bool isWarriorDefault = true;   
    private int maxLevel;

    override void Start () {
        
		base.Start ()
        maxLevel = typesOfUnits.minionWarriors.Length;
        spawnTimer = selectedUnit.trainingTime;
        

    }
	
	
    override public LevelData GetUnitForBuild()
    {
        LevelData levelData;
        if (isWarriorDefault)
        {
            levelData = typesOfUnits.minionWarriors[level-1]; //level start with 1, but array with 0
         }

        else
        {
            levelData = typesOfUnits.minionArchers[level-1];
        }
        return levelData;
    }
}
