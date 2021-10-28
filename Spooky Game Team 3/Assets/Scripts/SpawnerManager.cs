using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public ProjectileSpawner leftSpawner;
    public ProjectileSpawner rightSpawner;
    public ProjectileSpawner leftUpSpawner;
    public ProjectileSpawner leftDownSpawner;
    public ProjectileSpawner rightUpSpawner;
    public ProjectileSpawner rightDownSpawner;
    public Player player;
    public LastChanceUI lc;
    private ProjectileSpawner[] spawners;

    public double beatDelay;
    public float lastChanceMultiplier;
    private bool lastChance = false;

    private int counter = 0;
    //This is the array that determines which spawners will fire on each beatDelay-length interval. It lasts for 8 beats and covers all 6 spawners
    private int[,] beatArray = new int[,] {{1,0,0,0,0,0,0,0}, {0,0,0,0,1,0,0,0}, {0,0,0,0,0,0,0,0}, {0,0,0,0,0,0,0,0}, {0,0,0,0,0,0,0,0}, {0,0,0,0,0,0,0,0}};

    // Start is called before the first frame update
    void Start()
    {
      Application.targetFrameRate = 60;
      spawners =  new ProjectileSpawner[6] {leftSpawner, rightSpawner, leftUpSpawner, leftDownSpawner, rightUpSpawner, rightDownSpawner};
    }

    /*leftSpawner.Fire();
    rightSpawner.Fire();
    leftUpSpawner.Fire();
    leftDownSpawner.Fire();
    rightUpSpawner.Fire();
    rightDownSpawner.Fire();*/

    // Update is called once per frame
    void Update()
    {
      if(Time.frameCount % beatDelay == 0){
        FireSpawners();
        counter++;
      }
    }

    void FireSpawners(){
      for (int x = 0; x < 6; x++)
      {
        if(beatArray[x, counter] == 1){
          spawners[x].Fire();
        }
      }
      if(counter == 7){
        if(!lastChance && player.health == 1){
          Debug.Log("LAST CHANCE TIME");
          lc.Display();
          lastChance = true;
          for(int x = 0; x < 6; x++){
            spawners[x].projectile.multiplier = lastChanceMultiplier;
          }
          counter = 0;
          ClearBeatArray();
        } else {
          counter = 0;
          FillBeatArray();
        }
      }
    }

    void FillBeatArray(){
      ClearBeatArray();
      int pNum = GetPatternNum();
      Debug.Log(pNum);
      switch (pNum){
        //This is the only moderately gross way I'm filling beatArray, beatArray[x,y] means spawner x fires at time y
        //Spawner numbers: 0: center left, 1: center right, 2: left up, 3: left down, 4: right up, 5: right down
        case 1:
          beatArray[0,0] = 1;
          beatArray[1,3] = 1;
          beatArray[0,7] = 1;
          break;
        case 2:
          beatArray[0,0] = 1;
          beatArray[2,2] = 1;
          beatArray[4,6] = 1;
          break;
        case 3:
          beatArray[4,0] = 1;
          beatArray[5,2] = 1;
          beatArray[4,4] = 1;
          beatArray[5,6] = 1;
          break;
        case 4:
          beatArray[3,0] = 1;
          beatArray[5,2] = 1;
          beatArray[0,4] = 1;
          beatArray[1,6] = 1;
          break;
        case 5:
          beatArray[5,0] = 1;
          beatArray[5,2] = 1;
          beatArray[1,4] = 1;
          beatArray[1,6] = 1;
          break;
        case 6:
        case 7:
        case 8:
        case 9:
        case 10:
          beatArray[1,0] = 1;
          beatArray[0,1] = 1;
          beatArray[1,2] = 1;
          beatArray[0,3] = 1;
          beatArray[3,4] = 1;
          beatArray[5,6] = 1;
          break;
        case 11:
        case 12:
        case 13:
        case 14:
          beatArray[0,0] = 1;
          beatArray[4,0] = 1;
          beatArray[1,2] = 1;
          beatArray[3,2] = 1;
          break;
        case 15:
        case 16:
        case 17:
          beatArray[1,0] = 1;
          beatArray[5,0] = 1;
          beatArray[0,2] = 1;
          beatArray[4,2] = 1;
          break;
        case 18:
        case 19:
        case 20:
          beatArray[2,0] = 1;
          beatArray[4,0] = 1;
          beatArray[3,1] = 1;
          beatArray[5,1] = 1;
          beatArray[2,2] = 1;
          beatArray[4,2] = 1;
          beatArray[0,4] = 1;
          beatArray[1,5] = 1;
          beatArray[2,7] = 1;
          beatArray[4,7] = 1;
          break;
        case 21:
        case 22:
        case 23:
          beatArray[0,0] = 1;
          beatArray[1,1] = 1;
          beatArray[0,2] = 1;
          beatArray[1,3] = 1;
          beatArray[3,2] = 1;
          beatArray[5,3] = 1;
          beatArray[0,4] = 1;
          beatArray[1,5] = 1;
          beatArray[0,6] = 1;
          beatArray[1,7] = 1;
          beatArray[2,6] = 1;
          beatArray[4,7] = 1;
          break;
        case 24:
        case 25:
        case 26:
        case 27:
        case 28:
          beatArray[5,0] = 1;
          beatArray[0,0] = 1;
          beatArray[3,2] = 1;
          beatArray[1,2] = 1;
          beatArray[0,3] = 1;
          beatArray[1,4] = 1;
          beatArray[5,5] = 1;
          beatArray[0,5] = 1;
          beatArray[3,7] = 1;
          beatArray[1,7] = 1;
          break;
        default:
          beatArray[0,0] = 1;
          beatArray[1,3] = 1;
          break;
      }
    }

    void ClearBeatArray(){
      for(int x = 0; x < 6; x++){
        for(int y = 0; y < 8; y++){
          beatArray[x,y] = 0;
        }
      }
    }

    int GetPatternNum(){
      if(lastChance)
        return Random.Range(20,40);
      else if(Time.frameCount <= beatDelay * 48)
        return Random.Range(0,6);
      else
        return Random.Range(4,40);
    }

}
