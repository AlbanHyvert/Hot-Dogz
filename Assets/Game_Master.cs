using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Master : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _points = null;

    public Car[] cars;

    public List<Car> carsList;
    public float timeBeforeDogSpawn;
    private float tmptimer = 0f;

    private int _defeatCondition = 0;
    public int DefeatCondition { get { return _defeatCondition; } set { _defeatCondition = value; } }

    private int _getPoint = 0;
    public int GetPoint { get { return _getPoint; } set { _getPoint = value; } }

    // Start is called before the first frame update
    void Start()
    {
        EndGame();
        carsList = new List<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DefeatCondition >= cars.Length)
        {
            EndGame();
        }
        CountTime();
        OnPoints();
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

    public void EndGame()
    {
            Application.Quit();
    }

    private void OnPoints()
    {
        _points.text = "Scoring : " + _getPoint.ToString();
    }
}
