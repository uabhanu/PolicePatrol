//
//  NativeXCore.m
//  Unity-iPhone
//
//  Created by Josh Ruis on 1/17/13.
//
//

#import "NativeXCore.h"
#import "NativeXPublisherSBJsonWriter.h"

#define kNativeXTestAppURL		@"NativeXTestAppURL"

UIViewController *UnityGetGLViewController();

void UnityPause( bool pause );

void UnitySendMessage( const char * className, const char * methodName, const char * param );

static NativeXCore *sharedInstance;

@implementation NativeXCore

+ (void)inititialize {
    if(!sharedInstance) {
        sharedInstance = [[[self class]alloc]init];
        }
}

- (void)dealloc
{
    [super dealloc];
}

+ (NativeXCore*) instance
{
    if(!sharedInstance) {
        return sharedInstance = [[[self class]alloc]init];
    }
    return sharedInstance;
    
}

-(void)startWithApplicationId:(NSString*)appId publisherId:(NSString*)pubId enableLogging:(bool)enableLogging
{    
    if([[[NSBundle mainBundle] bundleIdentifier] isEqualToString:@"com.w3i.W3iUnityTest"]){
        [[NSUserDefaults standardUserDefaults] setObject:_URL forKey:kNativeXTestAppURL];
    }
    [[NSUserDefaults standardUserDefaults] setObject:@"Unity" forKey:@"NativeXBuildType"];
    [[NativeXSDK sharedInstance] createSessionWithAppId:appId andPublisherUserId:pubId];
    [[NativeXSDK sharedInstance] setDelegate:self];
    if(enableLogging){
        [[NativeXSDK sharedInstance] setShouldOutputDebugLog:YES];
    }else{
        [[NativeXSDK sharedInstance] setShouldOutputDebugLog:NO];
    }
}

-(void)fetchAd:(NSString*)customPlacement
{
    [[NativeXSDK sharedInstance] fetchAdWithCustomPlacement:customPlacement delegate:self];
}

-(void)showAd:(NSString *)customPlacement
{
    [[NativeXSDK sharedInstance] fetchAdWithCustomPlacement:customPlacement delegate:self];
    [[NativeXSDK sharedInstance] showAdWithCustomPlacement:customPlacement];
}

-(void)dismissAd:(NSString *)name
{
    [[NativeXSDK sharedInstance] dismissAdWithCustomPlacement:name];
}

//-(void)fetchBanner:(NSString *)name withRect:(CGRect)position
//{
//    self.bannerView = [[NativeXAdView alloc] initWithFrame:position placement:name delegate:self];
//    
//}
//
//-(void)showBanner:(NSString *)name withRect:(CGRect)position
//{
//        if(self.bannerView)
//        {
//            [self.bannerView displayAdView];
//        }else{
//            self.bannerView = [[NativeXAdView alloc] initWithFrame:position placement:name delegate:self];
//            [self.bannerView displayAdView];
//        }
//}

-(void)fetchBanner:(NSString *)name withPosition:(NSString *)position
{
    if([position isEqualToString:@"NATIVEX_BANNER_TOP"]){
        [[NativeXSDK sharedInstance] fetchBannerWithCustomPlacement:name position:kBannerPositionTop delegate:self];
        return;
    }else if ([position isEqualToString:@"NATIVEX_BANNER_BOTTOM"]){
        [[NativeXSDK sharedInstance] fetchBannerWithCustomPlacement:name position:kBannerPositionBottom delegate:self];
        return;
    }
}

-(void)showBanner:(NSString *)name withPosition:(NSString *)position
{
    if([position isEqualToString:@"NATIVEX_BANNER_TOP"]){
        [[NativeXSDK sharedInstance] fetchBannerWithCustomPlacement:name position:kBannerPositionTop delegate:self];
        [[NativeXSDK sharedInstance] showBannerWithCustomPlacement:name position:kBannerPositionTop];
        return;
    }else if ([position isEqualToString:@"NATIVEX_BANNER_BOTTOM"]){
        [[NativeXSDK sharedInstance] fetchBannerWithCustomPlacement:name position:kBannerPositionBottom delegate:self];
        [[NativeXSDK sharedInstance] showBannerWithCustomPlacement:name position:kBannerPositionBottom];
        return;
    }
}

-(void)dismissBanner:(NSString *)name
{
    [[NativeXSDK sharedInstance] dismissBannerWithCustomPlacement:name];
}

-(void)actionTaken:(NSString *)actionId
{
    [[NativeXSDK sharedInstance] actionTakenWithActionID:actionId];
}

-(void)redeemCurrency:(bool)show
{
    self.showMessages = show;
    [[NativeXSDK sharedInstance]redeemCurrency];
}

-(void)trackInAppPurchase:(NativeXInAppPurchaseTrackRecord *)record
{
    [[NativeXSDK sharedInstance]trackInAppPurchaseWithTrackRecord:record delegate:self];
}

-(void)close
{
    [[NativeXSDK sharedInstance] close];
}


//_________________________________________________________________________________________________
//Publisher Delegates
//_________________________________________________________________________________________________

-(void)nativeXSDKDidCreateSession
{
    UnitySendMessage("NativeXHandler", "didSDKinitialize", "1");
    UnitySendMessage("NativeXHandler", "sessionId", [[[NativeXSDK sharedInstance] getSessionId] UTF8String]);
}

-(void)nativeXSDKDidFailToCreateSession:(NSError *)error
{
    NSLog(@"SDK Inititalization failed with Error: %@", error);
    UnitySendMessage("NativeXHandler", "didSDKinitialize", "0");
}

-(void)nativeXSDKDidRedeemWithCurrencyInfo:(NativeXRedeemedCurrencyInfo *)redeemedCurrencyInfo
{
    
    if(redeemedCurrencyInfo)
    {
        NativeXPublisherSBJsonWriter *jsonWriter = [NativeXPublisherSBJsonWriter new];
        NSString *json = [jsonWriter stringWithObject:redeemedCurrencyInfo];
        if(!json)
        {
            NSLog(@"Failed to parse NativeXRedeemCurrencyInfo into Json");
        }
        NSLog(@"JSON(inXCode): %s", [json UTF8String]);
        UnitySendMessage("NativeXHandler", "balanceTransfered", [json UTF8String]);
    }else{
        NSLog(@"No balance returned");
    }
    if(self.showMessages){
        [redeemedCurrencyInfo showRedeemAlert];
    }
}

-(void)didRedeemWithBalances:(NSArray *)balances andReceiptId:(NSString *)receiptId
{
    NSLog(@"We hit the old redeem balance delegate call");
}

-(void)nativeXSDKDidRedeemWithError:(NSError *)error
{
    NSLog(@"Redemption failed with Error: %@", error);
    UnitySendMessage("NativeXHandler", "actionFailed", "0");
} 

-(UIViewController *)presentingViewControllerForAdView:(NativeXAdView *)adView
{
    NSLog(@"We have hit the Instuction View");
    return UnityGetGLViewController();
}

-(void)SDKWillRedirectUser
{
    UnitySendMessage("NativeXHandler", "userLeavingApplication", "1");
}

//_________________________________________________________________________________________________
//Ad Delegates
//_________________________________________________________________________________________________
-(void)nativeXAdView:(NativeXAdView *)adView didLoadWithPlacement:(NSString *)placement
{
    if(placement){
        UnitySendMessage("NativeXHandler", "didAdLoad", [placement UTF8String]);
    }else{
        UnitySendMessage("NativeXHandler", "didAdLoad", "NAME_UNDEFINED");
    }
    if(adView.adInfo)
    {
        NativeXPublisherSBJsonWriter *jsonWriter = [NativeXPublisherSBJsonWriter new];
        NSString *json = [jsonWriter stringWithObject:adView.adInfo];
        if(!json)
        {
            NSLog(@"Failed to parse adInfo into Json");
        }
        NSLog(@"JSON(inXCode): %s", [json UTF8String]);
        UnitySendMessage("NativeXHandler", "adInfo", [json UTF8String]);
    }

}

-(void)nativeXAdViewNoAdContent:(NativeXAdView *)adView
{
    NSLog(@"We were unable to load any content for Enhanced Ad.");
    UnitySendMessage("NativeXHandler", "didAdLoad", "NO_AD_LOADED");
    UnitySendMessage("NativeXHandler", "noAdLoaded", [adView.placement UTF8String]);
}

-(void)nativeXAdView:(NativeXAdView *)adView didFailWithError:(NSError *)error
{
    NSLog(@"Enhanced Ad failed to inititialize with Error: %@", error);
    if(adView.placement){
        UnitySendMessage("NativeXHandler", "actionFailed", [adView.placement UTF8String]);
    }else{
        UnitySendMessage("NativeXHandler", "actionFailed", "NAME_UNDEFINED");
    }
}

-(void)nativeXAdView:(NativeXAdView *)adView willResizeToFrame:(CGRect)newFrame
{
    if(adView.placement)
    {
        UnitySendMessage("NativeXHandler", "adWillResize", [adView.placement UTF8String]);
    }else{
        UnitySendMessage("NativeXHandler", "adWillResize", "NAME_UNDEFINED");
    }
}

-(void)nativeXAdViewWillExpand:(NativeXAdView *)adView
{
    if(adView.placement)
    {
        UnitySendMessage("NativeXHandler", "adWillExpand", [adView.placement UTF8String]);
    }else{
        UnitySendMessage("NativeXHandler", "adWillExpand", "NAME_UNDEFINED");
    }
}

-(void)nativeXAdViewWillCollapse:(NativeXAdView *)adView
{
    if(adView.placement)
    {
        UnitySendMessage("NativeXHandler", "adWillCollapse", [adView.placement UTF8String]);
    }else{
        UnitySendMessage("NativeXHandler", "adWillCollapse", "NAME_UNDEFINED");
    }
}

-(void)nativeXAdViewWillDisplay:(NativeXAdView *)adView
{
    if(adView.placement)
    {
        UnitySendMessage("NativeXHandler", "didAdLoad", [adView.placement UTF8String]);
    }else{
        UnitySendMessage("NativeXHandler", "didAdLoad", "NAME_UNDEFINED");
    }
    
    
    if(adView.willPlayAudio)
    {
        UnitySendMessage("NativeXHandler", "willPlayAudio", "1");
    }
}

-(void)nativeXAdViewDidDismiss:(NativeXAdView *)adView
{
   if(adView.placement){
        UnitySendMessage("NativeXHandler", "actionComplete", [adView.placement UTF8String]);
    }else{
        UnitySendMessage("NativeXHandler", "actionComplete", "NAME_UNDEFINED");
    }
    adView = nil;
}

-(void)nativeXAdViewDidExpire:(NativeXAdView *)adView
{
    if(adView.placement){
        UnitySendMessage("NativeXHandler", "adDidExpire", [adView.placement UTF8String]);
    }else{
        UnitySendMessage("NativeXHandler", "adDidExpire", "NAME_UNDEFINED");
    }
    adView = nil;
}

//_________________________________________________________________________________________________
//Tracking Delegates
//_________________________________________________________________________________________________

-(void)trackInAppPurchaseDidSucceedForRequest:(NativeXInAppPurchaseTrackRequest *)inAppPurchaseRequest
{
    NSLog(@"Tracking did Succeed");
    UnitySendMessage("NativeXHandler", "didTrackInAppPurchaseSucceed", "1");
}

-(void)trackInAppPurchaseForRequest:(NativeXInAppPurchaseTrackRequest *)inAppPurchaseRequest didFailWithError:(NSError *)error
{
    NSLog(@"Tracking failed with Error: %@", error);
    UnitySendMessage("NativeXHandler", "didTrackInAppPurchaseSucceed", "0");
}

@end
