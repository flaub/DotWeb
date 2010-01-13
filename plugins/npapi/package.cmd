rmdir /s /q dist
mkdir dist
mkdir dist\plugins
mkdir dist\skin
copy xpi\chrome.manifest dist\chrome.manifest
copy xpi\install.rdf dist\install.rdf
copy xpi\skin\icon.png dist\skin\icon.png
copy %1\NPDotWeb.dll dist\plugins\NPDotWeb.dll
del %1\DotWeb.xpi
7za.exe a -tzip %1\DotWeb.xpi .\dist\*
