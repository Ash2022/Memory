#import "OverrideUnityAppController.h"

#include "PluginBase/AppDelegateListener.h"


@implementation OverrideUnityAppController

- (BOOL)application:(UIApplication*)application openURL:(NSURL*)url sourceApplication:(NSString*)sourceApplication annotation:(id)annotation
{
    NSMutableArray* keys	= [NSMutableArray arrayWithCapacity:3];
    NSMutableArray* values	= [NSMutableArray arrayWithCapacity:3];
    
    auto addItem = [&](NSString* key, id value)
    {
        [keys addObject:key];
        if (value == nil) {
            [values addObject:[NSNull null]];
        } else {
            [values addObject:value];
        }
    };
    
    addItem(@"url", url);
    addItem(@"sourceApplication", sourceApplication);
    addItem(@"annotation", annotation);
    
    NSDictionary* notifData = [NSDictionary dictionaryWithObjects:values forKeys:keys];
    AppController_SendNotificationWithArg(kUnityOnOpenURL, notifData);
    return YES;
}

@end

IMPL_APP_CONTROLLER_SUBCLASS(OverrideUnityAppController)
