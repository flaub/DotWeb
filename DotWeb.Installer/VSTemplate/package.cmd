rmdir /s /q %1\tmp
mkdir %1\tmp

%1\VSTemplate\7za.exe a -tzip %1\tmp\ClassLibrary.zip %1\VSTemplate\ClassLibrary\*
%1\VSTemplate\7za.exe a -tzip %1\tmp\MvcWebApplication.zip %1\VSTemplate\MvcWebApplication\*
