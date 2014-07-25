//
//  W3iWrapper.cpp
//  Unity-iPhone
//
//  Created by Josh Ruis on 1/18/13.
//
//

#import "NativeXCore.h"

#define GetStringParam( _x_ ) ( _x_ != NULL ) ? [NSString stringWithUTF8String:_x_] : [NSString stringWithUTF8String:""]

#define GetStringParamOrNil( _x_ ) ( _x_ != NULL && strlen( _x_ ) ) ? [NSString stringWithUTF8String:_x_] : nil

void uStartWithNameAndApplicationId(const char *appId, const char *pubId, bool enableLogging, bool showRedeemAlert)
{
    [[NativeXCore instance] setShowMessages:showRedeemAlert];
    [[NativeXCore instance] startWithApplicationId:GetStringParamOrNil(appId) publisherId:GetStringParamOrNil(pubId) enableLogging:enableLogging];
}

void uSelectServer(const char *url)
{
    [[NativeXCore instance] setURL:GetStringParamOrNil(url)];
}

void uFetchAd(const char* placement)
{
    [[NativeXCore instance] fetchAd:GetStringParamOrNil(placement) ];
}

void uShowAd(const char* placement)
{
    [[NativeXCore instance] showAd:GetStringParamOrNil(placement)];
}

void uDismissAd(const char* placement)
{
    [[NativeXCore instance] dismissAd:GetStringParamOrNil(placement)];
}
//
//void uFetchBanner(const char* placement, int x, int y, int height, int width)
//{
//    [[NativeXCore instance] fetchBanner:GetStringParam(placement) withRect:CGRectMake(x, y, width, height)];
//}
//
//void uShowBanner(const char* placement, int x, int y, int height, int width)
//{
//    [[NativeXCore instance] showBanner:GetStringParam(placement) withRect:CGRectMake(x, y, width, height)];
//}

void uFetchBannerWithPosition(const char* placement, const char* position)
{
    [[NativeXCore instance] fetchBanner:GetStringParam(placement) withPosition:GetStringParam(position)];
}

void uShowBannerWithPosition(const char* placement, const char* position)
{
    [[NativeXCore instance] showBanner:GetStringParam(placement) withPosition:GetStringParam(position)];
}

void uDismissBanner(const char* placement)
{
    [[NativeXCore instance] dismissBanner:GetStringParamOrNil(placement)];
}

void uActionTakenWithActionId(const char *actionId)
{
    [[NativeXCore instance]actionTaken:GetStringParamOrNil(actionId)];
}

void uRedeemCurrency(bool show)
{
    [[NativeXCore instance] redeemCurrency:show];
}

void uTrackInAppPurchase(const char *storeProdId, const char *storeTransId, float cost, int quantity, const char *prodTitle)
{
    NativeXInAppPurchaseTrackRecord *myRecord = [[NativeXInAppPurchaseTrackRecord alloc] init];
    
    myRecord.storeProductID = GetStringParam(storeProdId);
    myRecord.storeTransactionID = GetStringParam(storeTransId);
    myRecord.costPerItem = [[NSDecimalNumber alloc] initWithFloat:cost];
    myRecord.quantity = quantity;
    myRecord.productTitle = GetStringParam(prodTitle);
    myRecord.currencyLocale = [NSLocale currentLocale];
    myRecord.storeTransactionTime = [NSDate date];
    
    [[NativeXCore instance]trackInAppPurchase:myRecord];
}

void uClose()
{
    [[NativeXCore instance] close];
}