using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newControlleur : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 3.0F;
    public float _tempSpeed = 0;
    public float rotateSpeed = 3.0F;
    public GameObject[] doggo;
    public GameObject spawnPoint;
    public float launchforce = 10f;
    private float _slowDown = 0f;
    public float SlowDown { get { return _slowDown; } set { _slowDown = value; } }

    [HideInInspector] public bool DogInHand = false;
    private GameObject actualDoggo;
    void Start()
    {
        _tempSpeed = speed;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(speed <= 0)
        {
            speed = 0;
        }
        Debug.Log(speed);
        MovePlayer();
        if(DogInHand)
        {
            if(SlowDown <= speed)
                SlowDown += 0.001f;
            LaunchDoggo();
            speed = speed - SlowDown * Time.deltaTime;
        }

        if(!DogInHand)
        {
            speed = _tempSpeed;
        }
    
    }

    void LaunchDoggo(){
        if(Input.GetKeyDown(KeyCode.A)){
            actualDoggo.transform.SetParent(null);
            actualDoggo.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            actualDoggo.GetComponent<Rigidbody>().AddForce(actualDoggo.transform.forward * launchforce * Time.deltaTime);
            DogInHand = false;
        }
    }

    void MovePlayer(){
        // Rotate around y - axis
    transform.Rotate(0, Input.GetAxis("HorizontalMVT") * rotateSpeed, 0);

    // Move forward / backward
    Vector3 forward = transform.TransformDirection(Vector3.forward);
    float curSpeed = speed * Input.GetAxis("VerticalMVT");
    characterController.SimpleMove(forward * curSpeed);

    }


    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.Space) && DogInHand == false && other.tag == "car"){
            other.GetComponent<Car>().isAlive = false;
            other.GetComponent<Car>().DogSave();
            actualDoggo = Instantiate(doggo[Random.Range(0, doggo.Length)], spawnPoint.transform.position, spawnPoint.transform.rotation, transform);
            DogInHand = true;
        }
    }
}
