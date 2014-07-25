//
//  AfppUIThemeConfigManager.h
//NativeX
//
//  This file is subject to the SDK Source Code License Agreement defined in file
//  "SDK_SourceCode_LicenseAgreement", which is part of this source code package.
//
//  Created by Bozhidar Mihaylov on 12/2/11.
//  Copyright (c) 2011 MentorMate. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "NativeXTheme.h"

@interface NativeXThemeManager : NSObject

+ (id)sharedInstance;

- (void)setTheme:(NativeXTheme *) theme;

@end
