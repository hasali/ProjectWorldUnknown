using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FpsAiMovement : MonoBehaviour {

    public GameObject curLoc;
    public GameObject nextLoc;
    public GameObject[] allLocs;
    public int counter;
    public float speed;
    public bool moveToNextLoc;
	public bool playerControl;
	// Use this for initialization
	void Start () {
		
        counter = 0;
	}
	
    void FpsAiMovementUpdate()
    {
		TriggerStopTime trigTimer = curLoc.GetComponentInChildren<TriggerStopTime> ();
		if (trigTimer.ready && gameObject.name != "PlayerFollow")
		{
			trigTimer.time -= Time.deltaTime;
			if (trigTimer.time <= 0.0f)
			{
				moveToNextLoc = true;
				if (!isPlayer.instance.isWalking) {
					isPlayer.instance.isWalking = true;
					playerControl = false;
				}

			}
			if (moveToNextLoc && counter < allLocs.Length)
			{
				if (allLocs.Length > 0 && counter < allLocs.Length && gameObject.name != "PlayerFollow")
				{
					nextLoc = allLocs[counter];
				}
				Vector3 distance = nextLoc.transform.position - this.gameObject.transform.position;
				distance.y = 0;
				Vector3 direction = Vector3.Normalize(distance);
				Vector3 move = direction * speed * Time.deltaTime;
				FirstPersonController fpc = GetComponent<FirstPersonController> ();

				if (!playerControl && gameObject.name != "PlayerFollow")
				{
					
					if (fpc != null) 
					{
						fpc.enabled = false;
					}

					Vector3 newDir = Vector3.RotateTowards (transform.forward, distance, speed * Time.deltaTime, 0.0F);
					Debug.DrawRay (transform.position, newDir, Color.red);
					transform.rotation = Quaternion.LookRotation (newDir);

				}
				if (distance.magnitude < move.magnitude)
				{

					this.gameObject.transform.position += distance;
					curLoc = nextLoc;
					counter++;

					moveToNextLoc = false;
					if (isPlayer.instance.isWalking) 
					{
						isPlayer.instance.isWalking = false;
						playerControl = true;
						if (fpc != null) 
						{
							fpc.enabled = true;
						}
					}
				}
				else
				{
					
					this.gameObject.transform.position += move;
				}
			}
		}

    }

    // Update is called once per frame
    void Update () {
        FpsAiMovementUpdate();
	}
}
