@echo off
color 0f
echo 3d 2048 installer
echo.
echo Sie benötigen KINECT SDK 1.8!
cls
echo.
echo Installiere.
@copy "res\2048.lnk" "C:\users\%username%\Desktop">NUL
echo.
echo Installiere..
echo.
echo C:\users\%username%\Desktop
cls
mkdir C:\users\%username%\rsc
echo.
echo Installiere...
echo.
echo C:\users\%username%\rsc
cls
mkdir C:\users\%username%\rsc\3d2048
echo.
echo Installiere....
echo.
echo C:\users\%username%\rsc\3d2048
cls
@copy "src\" "C:\users\%username%\rsc\3d2048">NUL
echo.
echo Installiere.....
echo.
echo C:\users\%username%\rsc\3d2048
cls
echo Fertig!
start C:\users\%username%\Desktop\2048.lnk
ping -n 2 127.0.0.1>NUL
exit

