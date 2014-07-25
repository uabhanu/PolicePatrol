//
//  NativeXCore.h
//  Unity-iPhone
//
//  Created by Josh Ruis on 1/17/13.
//
//

#import <Foundation/Foundation.h>
#import "NativeXSDK.h"
#import "NativeXAdView.h"
//
//extern UIView * UnityGetGLView();
//extern UIViewController * UnityGetGLViewController();

@interface NativeXCore : NSObject <NativeXSDKDelegate, NativeXInAppPurchaseTrackDelegate, NativeXAdViewDelegate >
{
@private
    BOOL showInterstitial;
    
}

@property (nonatomic) BOOL showMessages;
@property (nonatomic, strong) NativeXAdView* bannerView;

+ (NativeXCore*) instance;

-(void)startWithApplicationId:(NSString*)appId publisherId:(NSString*)pubId enableLogging:(bool) enableLogging;
-(void)fetchAd:(NSString*)name;
-(void)showAd:(NSString*)name;
-(void)dismissAd:(NSString*)name;
//-(void)fetchBanner:(NSString*)name withRect:(CGRect)position;
//-(void)showBanner:(NSString*)name withRect:(CGRect)position;
-(void)fetchBanner:(NSString *)name withPosition:(NSString*)position;
-(void)showBanner:(NSString *)name withPosition:(NSString*)position;
-(void)dismissBanner:(NSString*)name;
-(void)actionTaken:(NSString*)actionId;
-(void)redeemCurrency:(bool)show;
-(void)trackInAppPurchase:(NativeXInAppPurchaseTrackRecord*)record;
-(void)close;

@property (nonatomic, retain) NSString *URL;


@end
