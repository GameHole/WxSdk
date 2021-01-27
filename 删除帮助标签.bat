@echo off
cd %~dp0
git tag -d helper.1.0.0
git push origin :refs/tags/helper.1.0.0
