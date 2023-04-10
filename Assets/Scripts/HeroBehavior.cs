using UnityEngine;	
using System.Collections;

public class HeroBehavior : MonoBehaviour {

	public float kHeroSpeed = 20f;
    public GameObject mEgg = null;
	private const float kHeroRotateSpeed = 90f/2f; // 90-degrees in 2 seconds

    private bool moveMode = false; // false = mouse, true = keyboard
    private float fireTime;

	// Use this for initialization
	void Start () {
        if (mEgg == null)
            mEgg = Resources.Load("Prefabs/Egg") as GameObject;
        fireTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
        // #region motion control
        // transform.position += Input.GetAxis ("Vertical")  * transform.up * 
		// 							(kHeroSpeed * Time.smoothDeltaTime);
        // transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") * 
        //                             (kHeroRotateSpeed * Time.smoothDeltaTime));
        // #endregion

        if (moveMode) 
        {
            #region motion control
            transform.position += transform.up * (kHeroSpeed * Time.smoothDeltaTime);
            transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") * 
                                        (kHeroRotateSpeed * Time.smoothDeltaTime));
            #endregion
            if (Input.GetKey("w"))
            {
                kHeroSpeed += 0.05f;
            }
            if (Input.GetKey("s"))
            {
                kHeroSpeed -= 0.05f;
            }
        }
        else
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;
        }
        if (Input.GetKeyDown("m"))
        {
            moveMode = !moveMode;
            GlobalBehavior.sTheGlobalBehavior.ChangeCM();
        }
        

        GlobalBehavior.sTheGlobalBehavior.ObjectClampToWorldBound(this.transform);

        if (Input.GetKey("space") && (Time.realtimeSinceStartup - fireTime) >= 0.2)  // VS. GetKeyDown <<-- even, one per key press
        { // space bar hit
            fireTime = Time.realtimeSinceStartup;
            GameObject e = Instantiate(mEgg) as GameObject;
            EggBehavior egg = e.GetComponent<EggBehavior>(); // Shows how to get the script from GameObject
            if (null != egg)
            {
                e.transform.position = transform.position;
                e.transform.up = transform.up;
            }
            GlobalBehavior.sTheGlobalBehavior.IncEggCount();
        }

    }
}
