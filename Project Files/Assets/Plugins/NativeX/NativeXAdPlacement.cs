using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public sealed class NativeXAdPlacement {
	
	private readonly string name;
	private readonly int index;
	
	private static readonly Dictionary<string, NativeXAdPlacement> instance = new Dictionary<string,NativeXAdPlacement>();
	
	public static readonly NativeXAdPlacement GAMELAUNCH = new NativeXAdPlacement(1, "Game Launch");
	public static readonly NativeXAdPlacement MAINMENU = new NativeXAdPlacement(2, "Main Menu Screen");
	public static readonly NativeXAdPlacement PAUSEMENU = new NativeXAdPlacement(3, "Pause Menu Screen");
	public static readonly NativeXAdPlacement PLAYERGENERATED = new NativeXAdPlacement(4, "Player Generated Event");
	public static readonly NativeXAdPlacement LEVELCOMPLETE = new NativeXAdPlacement(5, "Level Completed");
	public static readonly NativeXAdPlacement LEVELFAILED = new NativeXAdPlacement(6, "Level Failed");
	public static readonly NativeXAdPlacement PLAYERLEVELUP = new NativeXAdPlacement(7, "Player Levels Up");
	public static readonly NativeXAdPlacement P2PWIN = new NativeXAdPlacement(8, "P2P competition won");
	public static readonly NativeXAdPlacement P2PLOST = new NativeXAdPlacement(9, "P2P competition lost");
	public static readonly NativeXAdPlacement STOREOPEN = new NativeXAdPlacement(10, "Store Open");
	public static readonly NativeXAdPlacement EXITAPP = new NativeXAdPlacement(11, "Exit Ad from Application");
	
	
	
	private NativeXAdPlacement(int a, string b)
	{
		index = a;
		name = b;
		instance[b] = this;
	}
	
	public override string ToString()
	{
		return name;	
	}
	
	public static implicit operator string(NativeXAdPlacement obj)
	{
		NativeXAdPlacement result;
		if(null != obj){
			if(instance.TryGetValue(obj.name, out result)){
				return result.name;
			}else{
				throw new UnityException("Was not able to cast provided value: "+obj.name);
			}
		}else{
				throw new UnityException("Was not able to cast provided value: null ");
		}
	}
}
