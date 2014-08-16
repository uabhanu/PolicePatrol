using UnityEngine;
using System.Collections;

public class GUIPosition : MonoBehaviour 
{
	public GUISkin guiSkin;
	private float guiRatio , sWidth;
	private Vector3 GUIsF;

	void Awake()
	{
		sWidth = Screen.width;
		guiRatio = sWidth / 1920;
		GUIsF = new Vector3(guiRatio , guiRatio , 1);
	}

	void OnGUI() 
	{
		GUI.matrix = Matrix4x4.TRS(new Vector3(GUIsF.x , GUIsF.y , 0) , Quaternion.identity , GUIsF);
		GUI.Label(new Rect(20 , 20 , 258 , 89) , "" , guiSkin.customStyles[0]);
		GUI.matrix = Matrix4x4.TRS(new Vector3(Screen.width - 258 * GUIsF.x , Screen.height - 89 * GUIsF.y , 0) , Quaternion.identity , GUIsF);
		GUI.Label(new Rect(-20 , -20 , 258 , 89) , "" , guiSkin.customStyles[0]);
		GUI.matrix = Matrix4x4.TRS(new Vector3(GUIsF.x , Screen.height - 89 * GUIsF.y , 0) , Quaternion.identity , GUIsF);
		GUI.Label(new Rect(20 , -20 , 258 , 89) , "" , guiSkin.customStyles[0]);
		GUI.matrix = Matrix4x4.TRS(new Vector3(Screen.width - 258 * GUIsF.x , GUIsF.y , 0) , Quaternion.identity , GUIsF);
		GUI.Label(new Rect(-20 , 20 , 258 , 89) , "" , guiSkin.customStyles[0]);
	}
}
