using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Master : MonoBehaviour
{

    public Car[] cars;

    public List<Car> carsList;
    public float timeBeforeDogSpawn;
    private float tmptimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        carsList = new List<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
    }

    public IEnumerator Spawndog(){

        bool spawn = false;
        while(spawn == false){
            int rng = Random.Range(0, cars.Length);
            if(cars[rng].isAlive == false){
                cars[rng].DogNeedHelp();
                spawn = true;
            }
            yield return null;
        }
        spawn = false;
    }

    void CountTime(){
        tmptimer += Time.deltaTime;
        if(tmptimer > timeBeforeDogSpawn){
            if(cars.Length > 0){
                StartCoroutine(Spawndog());
                tmptimer = 0f;

            }
        }
    }
}
