//
//  NativeXTheme.h
//NativeX
//
//  Created by Andrew Marinov on 28.02.2013.
//
//

#import <Foundation/Foundation.h>

@interface NativeXTheme : NSObject

@property (nonatomic, strong) UIColor *backgroundColor;

@property (nonatomic, strong) UIImage *toolbarBackgroundImagePortrait;
@property (nonatomic, strong) UIImage *toolbarBackgroundImageLandscape;

@property (nonatomic, strong) UIColor *titleTextColor;

@property (nonatomic, strong) UIColor *activeButtonTextColor;
@property (nonatomic, strong) UIColor *inactiveButtonTextColor;
@property (nonatomic, strong) UIColor *offerNameTextColor;
@property (nonatomic, strong) UIColor *offerBackgroundColor;

@property (nonatomic, strong) UIImage *offerBackgroundImage;
@property (nonatomic, strong) UIImage *footerBackgroundImage;

@property (nonatomic, strong) UIImage *sortBarPortraitBackgroundImage;
@property (nonatomic, strong) UIImage *sortBarLandscapeBackgroundImage;

@property (nonatomic, strong) UIColor *separatorColor;

@property (nonatomic, strong) UIImage *historyPortraitBackgroundImage;
@property (nonatomic, strong) UIImage *historyLandscapeBackgroundImage;

@property (nonatomic, strong) UIImage *currencyViewImage;

@end
