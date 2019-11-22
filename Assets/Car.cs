using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    Animator animatorCar;
    public float timebeforedogDie = 8f;
    float tmptimer;
    [HideInInspector] public bool isAlive = false;
    
    void Start()
    {
        animatorCar = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive){
            tmptimer += Time.deltaTime;
            if(tmptimer > timebeforedogDie){
                Destroy(gameObject);
            }
        }else{
            tmptimer = 0f;
        }
        
    }

    public void DogNeedHelp(){

        animatorCar.SetTrigger("Activate");
        isAlive = true;

    }

    public void DogSave(){
        animatorCar.SetTrigger("Save");
    }

}
