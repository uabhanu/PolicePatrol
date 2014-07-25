using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;

public class NativeXCurrencyData {

	public List<NativeXBalance> balances;
	public List<string> receipts;
	public List<NativeXMessage> messages;

	public NativeXCurrencyData()
	{
		balances = new List<NativeXBalance>();
		receipts = new List<string>();
	}

	public NativeXCurrencyData(NativeXBalance balance, string receipt, NativeXMessage message)
	{
		balances.Add(balance);
		receipts.Add(receipt);
		messages.Add(message);
	}

	public NativeXCurrencyData(NativeXBalance[] balance, string[] receipt, NativeXMessage[] message)
	{
		foreach(var b in balance){
			balances.Add(b);
		}
		foreach(var r in receipt){
			receipts.Add(r);
		}
		foreach(var m in message){
			messages.Add(m);
		}
	}

	public static NativeXCurrencyData convertJson(string json)
	{
		NativeXCurrencyData dBalances = JsonReader.Deserialize<NativeXCurrencyData>(json);
		return dBalances;
	}

	public override string ToString()
	{
		string stringBuilder = "";
		foreach( var b in balances)
		{
			stringBuilder+= "Balance:"+b.ToString();
			stringBuilder+="\n";
		}
		foreach(var r in receipts)
		{
			stringBuilder+="ReceiptId:"+r.ToString();
			stringBuilder+="\n";
		}
		foreach(var m in messages)
		{
			stringBuilder+="Messages:"+m.ToString();
			stringBuilder+="\n";
		}
		return stringBuilder;
	}
}
