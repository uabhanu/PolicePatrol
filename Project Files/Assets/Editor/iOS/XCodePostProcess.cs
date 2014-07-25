using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.XCodeEditor;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Xml;

public static class XCodePostProcess
{
	private static NativeXPostProcess process = new NativeXPostProcess();
	private static bool enableDeepLinking = false;

	[PostProcessBuild]
	public static void OnPostProcessBuild( BuildTarget target, string path )
	{
		if (target != BuildTarget.iPhone) {
			UnityEngine.Debug.LogWarning("Target is not iPhone. XCodePostProcess will not run");
			return;
		}

		// Create a new project object from build target
		XCProject project = new XCProject( path );

		// Find and run through all projmods files to patch the project.
		//Please pay attention that ALL projmods files in your project folder will be excuted!
		string[] files = Directory.GetFiles( Application.dataPath, "*.projmods", SearchOption.AllDirectories );
		foreach( string file in files ) {
			project.ApplyMod( file );
		}

		UnityEngine.Debug.Log("Saving Project");
		// Finally save the xcode project
		project.Save();

		if(enableDeepLinking){
			process.schemes.Add("W3iUnityTest");
			process.CFBundleURLName = "com.w3i.W3iUnityTest";
			process.productName = "W3iUnityTest";
			process.sceneName = "Options";

			string plistPath = path+"/info.plist";
			process.processPlist(plistPath);

			string controllerPath = path+"/Classes/AppController.mm";
			process.addOpenUrl(controllerPath);
		}
	}
	
}