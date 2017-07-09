using System.Collections;
using UnityEngine;

public class PoliceController : MonoBehaviour 
{
	#region PlayerState
	public enum PlayerState
	{
		ATTACKING,
		BLEND,
		CROUCH,
		CrouchMoving,
		DEAD,
		DYING,
		IDLE,
		RUNNING,
		SLAP,
		WALKING,
	};
	
	public PlayerState m_currentState;
	public PlayerState m_previousState;
    #endregion

    #region Variables Declaration
        [SerializeField] float m_walkSpeed , m_runSpeed;
    #endregion

    #region GetState()
	private PlayerState GetState()
	{
		return m_currentState;
	}
	#endregion

    #region SetState()
	public void SetState(PlayerState newState)
	{
		if (m_currentState == newState)
		{
			return;
		}
		
		m_previousState = m_currentState;
		m_currentState = newState;
	}
	#endregion
}
