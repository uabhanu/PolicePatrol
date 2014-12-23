using UnityEngine;
using System.Collections;

public class PoliceController : MonoBehaviour 
{
    public float m_moveSpeed;
    public float m_jumpHeight;
    
    public bool m_isFacingRight = true;
    public bool m_shouldFlip = false;
    public bool m_isGrounded = false;

    //---------------------------------------------------------------------------------------------------
	// Use this for initialization
	void Start () 
    {
	   
	}
	//---------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------
	// Update is called once per frame
	void Update () 
    {
        CheckIfGrounded();
	}

    private void CheckIfGrounded()
    {
        
    }

    //---------------------------------------------------------------------------------------------------
}
