@echo off
cd %~dp0
git subtree split --prefix=Assets/WxSDK --branch ump
git tag 1.0.0 ump
git push origin ump --tags
pause
