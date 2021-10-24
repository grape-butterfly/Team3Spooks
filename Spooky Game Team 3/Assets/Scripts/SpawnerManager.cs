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
    private ProjectileSpawner[] spawners;

    public double beatDelay;

    private int counter = 0;
    //This is the array that determines which spawners will fire on each beatDelay-length interval. It lasts for 8 beats and covers all 6 spawners
    private int[,] beatArray = new int[,] {{1,0,0,0,0,0,0,0}, {0,1,0,0,0,0,0,0}, {0,0,1,0,0,0,0,0}, {0,0,0,1,0,0,0,0}, {0,0,0,0,1,0,0,0}, {0,0,0,0,0,1,0,0}};

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
        counter = (counter + 1) % 8;
      }
    }

    void FireSpawners()
    {
      for (int x = 0; x < 6; x++)
      {
        if(beatArray[x, counter] == 1){
          spawners[x].Fire();
        }
      }
      if(counter == 7)
        FillBeatArray();
    }

    void FillBeatArray(){
      ClearBeatArray();

    }

    void ClearBeatArray(){
      for(int x = 0; x < 6; x++){
        for(int y = 0; y < 8; y++){
          beatArray[x,y] = 0;
        }
      }
    }
}
