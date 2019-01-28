using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class StairDismount : MonoBehaviour {
	//Declare a member variables for distributing the impacts over several frames
	float impactEndTime=0;
	Rigidbody impactTarget=null;
	Vector3 impact;
    RagdollHelper helper;
    public AudioSource[] screams;
    public AudioSource[] impacts;


    public void impactsound() {
        impacts[Random.Range(0, impacts.Length)].Play();
    }

	//Current score
	public int score;

	// Use this for initialization
	void Start () {
        helper = GetComponent<RagdollHelper>();
        //Get all the rigid bodies that belong to the ragdoll
        Rigidbody[] rigidBodies=GetComponentsInChildren<Rigidbody>();
		
		//Add the RagdollPartScript to all the gameobjects that also have the a rigid body
		foreach (Rigidbody body in rigidBodies)
		{
			RagdollPartScript rps=body.gameObject.AddComponent<RagdollPartScript>();
			
			//Set the scripts mainScript reference so that it can access
			//the score and scoreTextTemplate member variables above
			rps.mainScript=this;
		}
	}
    float risetimer=1;

    public void jump() {
        
        if (GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips).GetComponent<Rigidbody>().velocity.magnitude > 1)
             return;
        risetimer = 1;
        helper.ragdolled = true;
        impactTarget = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips).GetComponent<Rigidbody>();
        impactEndTime = Time.time + 1f;
        impactTarget.AddForce((transform.forward * GetComponent<movement>().z * 800) + ((Vector3.up+transform.forward) * 1200), ForceMode.Impulse);
        screams[Random.Range(0, screams.Length)].Play();
    }

    public void rise() {
        if (GetComponent<movement>().grounded && risetimer <= 0)
        {

            helper.ragdolled = false;
        }
    }

    private void Update()
    {
        if (risetimer > 0)
            risetimer -= Time.deltaTime;
    }
    // Update is called once per frame
    void LateUpdate () {
      
        //if left mouse button clicked
        if (Input.GetButtonDown("Fire1") || CrossPlatformInputManager.GetButtonDown("Fire1"))
		{
            jump();


        }

        if (GetComponent<movement>().z>0.2)
		{

            rise();
		}	
		
		//Check if we need to apply an impact
		if (Time.time<impactEndTime)
		{
			impactTarget.AddForce(impact,ForceMode.VelocityChange);
		}
	}
}
