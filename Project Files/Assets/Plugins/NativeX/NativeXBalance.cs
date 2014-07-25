using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;



public class NativeXBalance{
	public double Amount;
	public string DisplayName;
	public string ExternalCurrencyId;
	public int Id;
	
	
	public NativeXBalance()
	{
		Amount = 0;
		DisplayName = "";
		ExternalCurrencyId = "";
		Id = 0;
	}
	
	public NativeXBalance(double amt, string dis, int i, string cur)
	{
		Amount = amt;
		DisplayName = dis;
		ExternalCurrencyId = cur;
		Id = i;
	}
	
	public static List<NativeXBalance> convertJson(string json)
	{
		Debug.Log("ConvertJson:" + json);
		
		NativeXBalance[] balances = JsonReader.Deserialize<NativeXBalance[]>(json);
		List<NativeXBalance> balanceList = new List<NativeXBalance>();
		
		foreach (var b in balances)
		{
			balanceList.Add(b);
		}
		
		return balanceList;
	}
	
	public string getAmount()
	{
		return Amount.ToString();
	}
	public void setAmount(int a)
	{
		Amount = a;
	}
	public string getDisplayName()
	{
		return DisplayName;
	}
	public void setDisplayName(string d)
	{
		DisplayName = d;
	}
	public string getExternalCurrencyId()
	{
		return ExternalCurrencyId;
	}
	public void setExternalCurrencyId(string c)
	{
		ExternalCurrencyId = c;
	}
	public string getId()
	{
		return Id.ToString();
	}
	public void setId(int i)
	{
		Id = i;
	}
	
	//This should be used to clear the Balance object after user has been creditted
	public void clear()
	{
		Amount = 0;
		DisplayName = "";
		ExternalCurrencyId = "";
		Id = 0;
	}
	public override string ToString()
	{
		return "Id:" + Id.ToString() + " DisplayName:" + DisplayName + " externalCurrencyId:" + ExternalCurrencyId + " Amount:" + Amount.ToString();
	}
}
