copy %1\NPDotWeb.dll dist\plugins\NPDotWeb.dll
del %1\DotWeb.xpi
7za.exe a -tzip %1\DotWeb.xpi .\dist\*
