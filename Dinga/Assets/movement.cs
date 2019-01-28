using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class movement : MonoBehaviour {
    public UnityStandardAssets.Cameras.AutoCam moveCamera;
    public UnityStandardAssets.Cameras.LookatTarget lookCamera;
	// Use this for initialization
	void Start () {
		
	}
    bool _grounded = true;
    public bool grounded
    {
        get {/*
            RaycastHit hit;
            if (Physics.Raycast(GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips).position

                + Vector3.up / 10, Vector3.down, out hit, 1, 1 << 9))
            {

                if (hit.collider.name == "Terrain")
                    return true;
                else
                    return false;
            }
            else {
                return false; }*/
            return true;
            }
        set { _grounded = value; }
    }

    bool _canmove = true;
	public bool canMove { get {
            if (GetComponent<RagdollHelper>().ragdolled )
            return false;
            else
            return _canmove;
        } set { _canmove = value; } }

    float groundPoint() {
        float ret = 0;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2, 1 << 9))
        {

            if (hit.collider.name == "Terrain")
                ret = hit.point.y;
        }

        return ret;
    }

    private void Update()
    {
        GetComponent<Rigidbody>().isKinematic = GetComponent<RagdollHelper>().ragdolled;
        GetComponent<Collider>().enabled = !GetComponent<RagdollHelper>().ragdolled;
        moveCamera.enabled = !GetComponent<RagdollHelper>().ragdolled;
        lookCamera.enabled = GetComponent<RagdollHelper>().ragdolled;
        if (transform.position.y < -3)
            transform.position = transform.position + Vector3.up * 5;

    }



    public float x;
    public float z;

    public bool touchControlsEnabled;
    // Update is called once per frame
    void LateUpdate () {
        
        if (!canMove)
            return;
        
        if (grounded) {
            if (!touchControlsEnabled)
            {
                x = Input.GetAxis("Horizontal");
                z = Input.GetAxis("Vertical");

                if (z > 0.5f)
                    GetComponent<StairDismount>().rise();
            }
            else
            {
                z = CrossPlatformInputManager.GetAxis("Vertical");
                x = CrossPlatformInputManager.GetAxis("Horizontal");
              
            }

            Rigidbody rb = GetComponent<Rigidbody>();    

            GetComponent<Animator>().SetFloat("Forward", z);
            GetComponent<Animator>().SetFloat("Turn", x);

        }
	}
}
