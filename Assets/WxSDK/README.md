一．安卓设置
选择WX->设置sdk参数即可一键完成打包所需全部设置；
二．IOS - 即将添加自动设置
1Unity设置
打开Player Settings 找到如下添Element加并填入微信Appid
2.API：
WxSDKInitor.cs 初始化脚本
说明：请挂载至合适的位置并填写其中的各项参数
特别说明：UniversalLinks 参数如后台的小伙伴提供直接填入即可，否则请参考该网址：
https://www.jianshu.com/p/128d09cff44b
WX.cs
静态成员：WX.onLogined 回调传递的参数 分别为 headurl和nickName
静态函数：WX.Login（）用于调起微信登录界面
静态函数：WX.isWechatInstalled（）用于查询是否安装微信
3 XCode工程
找到 导出目录\Classes\UnityAppController.mm
添加头文件
#include "Libraries/Plugins/IOS/WXSDK/WXApi.h"
#include "Libraries/Plugins/IOS/WXApiManager.h"

搜索OpenUrl
找到OpenUrl方法
然后替换为如下代码
- (BOOL)application:(UIApplication*)app openURL:(NSURL*)url options:(NSDictionary<NSString*, id>*)options
{
    id sourceApplication = options[UIApplicationOpenURLOptionsSourceApplicationKey], annotation = options[UIApplicationOpenURLOptionsAnnotationKey];

    NSMutableDictionary<NSString*, id>* notifData = [NSMutableDictionary dictionaryWithCapacity: 3];
    if (url) notifData[@"url"] = url;
    if (sourceApplication) notifData[@"sourceApplication"] = sourceApplication;
    if (annotation) notifData[@"annotation"] = annotation;

    AppController_SendNotificationWithArg(kUnityOnOpenURL, notifData);
    return [WXApi handleOpenURL:url delegate:[WXApiManager shareManager]];
}
+(BOOL)application:(UIApplication*)app handleOpenURL:(NSURL*)url {
    return [WXApi handleOpenURL:url delegate:[WXApiManager shareManager]];
}
- (BOOL)application:(UIApplication *)application continueUserActivity:(NSUserActivity *)userActivity restorationHandler:(void (^)(NSArray *))restorationHandler
{
    return [WXApi handleOpenUniversalLink:userActivity delegate:[WXApiManager shareManager]];
    
}
设置XcodeProject
参考特别说明 UniversalLinks 