using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.Runtime.Serialization;
using System.Text;


public class NativeXPostProcess {

	public string CFBundleURLName;
	public List<string> schemes = new List<string>();
	public string productName;
	public string sceneName;


	public NativeXPostProcess()
	{
	}

	public void processPlist(string path)
	{
		XmlDocument doc = new XmlDocument();

		UnityEngine.Debug.Log("Loading Document");
		doc.Load(path);
		UnityEngine.Debug.Log("Assigning Element");
		XmlElement plist = doc.DocumentElement;

		UnityEngine.Debug.Log("Creating new Element");
		XmlElement URLTypes = doc.CreateElement("key");
		URLTypes.InnerText="CFBundleURLTypes";
		plist.LastChild.InsertAfter(URLTypes, plist.LastChild.LastChild);

		UnityEngine.Debug.Log("Loading XML");
		XmlElement firstArray = doc.CreateElement("array");
		XmlElement dict = doc.CreateElement("dict");
		XmlElement bundleURL = doc.CreateElement("key");
		bundleURL.InnerText = "CFBundleURLName";
		dict.AppendChild(bundleURL);
		XmlElement urlName = doc.CreateElement("string");
		urlName.InnerText = CFBundleURLName;
		dict.AppendChild(urlName);
		XmlElement urlScheme = doc.CreateElement("key");
		urlScheme.InnerText = "CFBundleURLSchemes";
		dict.AppendChild(urlScheme);
		XmlElement schemeArray = doc.CreateElement("array");
		if(schemes.Count>0)
		{
			foreach(var s in schemes){
				XmlElement scheme = doc.CreateElement("string");
				scheme.InnerText = s;
				schemeArray.AppendChild(scheme);
			}
		}else{
			UnityEngine.Debug.Log("No Schemes have been added");
		}
		dict.AppendChild(schemeArray);
		firstArray.AppendChild(dict);
		plist.LastChild.InsertAfter(firstArray, URLTypes);
		doc.Save(path);

		var stringWriter = new StringWriter();
		var xmlTextWriter = XmlWriter.Create(stringWriter);

		doc.WriteTo(xmlTextWriter);
		xmlTextWriter.Flush();
		UnityEngine.Debug.Log("XML: "+stringWriter.GetStringBuilder().ToString());


		FileStream file = new FileStream(path, FileMode.Open);
		stringWriter.GetStringBuilder().Replace("[]","");
		string finalPlist = stringWriter.GetStringBuilder().ToString();
		byte[] bytePlist = Encoding.UTF8.GetBytes(finalPlist);
		file.Position = 0;
		file.Write(bytePlist,0,bytePlist.Count());
		file.Close();

	} 

	public void addOpenUrl(string path)
	{
		StreamReader stream = new StreamReader(path);
		string controller = stream.ReadToEnd();
		stream.Close ();

		StringBuilder builder = new StringBuilder(controller);

		builder.Replace("@implementation AppController",
		                "@implementation AppController\n\n" +
		                "- (BOOL)application:(UIApplication *)application openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation\n"+
							"{\n"+
    							"BOOL returnValue = NO;\n"+
		                "NSString *stringUrl = [url absoluteString];\n\n"+
     
		                "// the product name will be the last section of the bundle name\n"+
		                "if([stringUrl hasPrefix:@\""+productName+"://\"]){\n\n"+
		                
		                "returnValue = YES;\n"+
		                "// Switch \"MainMenu\" with the name of the scene you wish to open.\n"+
		                "UnitySendMessage(\"NativeXLink\", \"moveScene\", \""+sceneName+"\");\n"+
		                "}\n"+
		                "return returnValue;\n"+
		                "}\n\n");


		FileStream file = new FileStream(path, FileMode.Open);
		byte[] byteController = Encoding.UTF8.GetBytes(builder.ToString());
		file.Position = 0;
		file.Write(byteController, 0, byteController.Count());
		file.Close();
	}

}

