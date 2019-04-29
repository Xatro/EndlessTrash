@echo off
title Compiling Endless Trash
echo Compiling Endless Trash.exe
\Windows\Microsoft.NET\Framework\v4.0.30319\csc /nologo /out:"Endless Trash.exe" /t:winexe Code\*.cs
echo Completing Process...
pause