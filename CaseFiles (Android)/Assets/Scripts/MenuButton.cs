using System.Collections;
using System.Runtime;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour 
{
	public Button button;
	public ColorBlock cb;
	public int levelToLoad;
	public string imageName;

	void Start () 
	{
		button = this.gameObject.GetComponent<Button>();
		cb = button.colors;

		if(imageName.Equals("Spr_Unlock"))
		{
			cb.pressedColor = Color.green;
			button.colors = cb;
		}
		
		if(imageName.Equals("Spr_Lock"))
		{
			cb.pressedColor = Color.red;
			button.colors = cb;
		}
	}

	public void ButtonClick(int levelToLoad)
	{
		if(imageName.Equals("Spr_Unlock"))
		{
			Application.LoadLevel(levelToLoad);
		}
	}

	void Update () 
	{
	
	}
}
