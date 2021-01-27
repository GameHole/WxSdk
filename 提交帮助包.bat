@echo off
cd %~dp0
git subtree split --prefix=Assets/AndrodBuildHelper --branch ump_helper
git tag helper.1.0.0 ump_helper
git push origin ump_helper --tags
