using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class NativeXBannerPosition {

	private readonly string name;
	private readonly int index;

	/*//portrait: 320x50 or 768x66
	//landscape: 480x32 or 1024x66
	kBannerPositionTop,
	kBannerPositionBottom,
	//landscape only: 100x320 or 120x768
	kBannerPositionLandscapeLeft,
	kBannerPositionLandscapeRight,
	*/
	
	private static readonly Dictionary<string, NativeXBannerPosition> instance = new Dictionary<string,NativeXBannerPosition>();

	//PORTAIT: 320x50 or 768x66
	//LANDSCAPE: 480x32 or 1024x66
	public static readonly NativeXBannerPosition TOP = new NativeXBannerPosition(1, "NATIVEX_BANNER_TOP");
	public static readonly NativeXBannerPosition BOTTOM = new NativeXBannerPosition(2, "NATIVEX_BANNER_BOTTOM");
//	//LANDSCAPE ONLY: 100x320 or 120x768
//	public static readonly NativeXBannerPosition LEFT = new NativeXBannerPosition(3, "PNATIVEX_BANNER_LEFT");
//	public static readonly NativeXBannerPosition RIGHT = new NativeXBannerPosition(4, "NATIVEX_BANNER_RIGHT");
	
	
	private NativeXBannerPosition(int a, string b)
	{
		index = a;
		name = b;
		instance[b] = this;
	}
	
	public override string ToString()
	{
		return name;	
	}
	
	public static implicit operator string(NativeXBannerPosition obj)
	{
		NativeXBannerPosition result;
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
