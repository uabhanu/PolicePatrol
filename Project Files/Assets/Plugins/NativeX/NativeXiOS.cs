using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class NativeXiOS {

	public string appId;
	public string publisherUserId;
	private string appName;
	public int actionId;
	public bool enableLogging = false;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public NativeXiOS(int applicationId, string applicationName, string pubName)
	{
		appId = applicationId.ToString();
		appName = applicationName;
		publisherUserId = pubName;
	}

	public NativeXiOS(int applicationId, string pubName)
	{
		appId = applicationId.ToString();
		publisherUserId = pubName;
	}

	public NativeXiOS(string applicationId, string pubName)
	{
		appId = applicationId;
		publisherUserId = pubName;
	}

	public override string ToString()
	{
		return "AppId:"+appId+" PublisherUserId:"+publisherUserId+" ActionId:"+actionId;
	}
}
