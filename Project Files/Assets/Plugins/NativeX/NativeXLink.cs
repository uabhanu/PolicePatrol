using UnityEngine;
using System.Collections;

public class NativeXLink : MonoBehaviour {

	public void moveScene(string scene)
	{
		Application.LoadLevel(scene);
	}
}
