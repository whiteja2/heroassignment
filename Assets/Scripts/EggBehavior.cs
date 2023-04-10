using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    private const float kEggSpeed = 40f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (kEggSpeed * Time.smoothDeltaTime);
        if (GlobalBehavior.sTheGlobalBehavior.ObjectCollideWorldBound(GetComponent<Renderer>().bounds) == GlobalBehavior.WorldBoundStatus.Outside)
        {
            Destroy(gameObject);  // this.gameObject, this is destroying the game object
            GlobalBehavior.sTheGlobalBehavior.DecEggCount();
        };
    }

    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     // Check if the collision involves the other game object you're interested in
    //     if (col.gameObject.name == "Enemy")
    //     {
    //         Destroy(gameObject);  // this.gameObject, this is destroying the game object
    //         GlobalBehavior.sTheGlobalBehavior.DecEggCount();
    //     };
    // }

}
