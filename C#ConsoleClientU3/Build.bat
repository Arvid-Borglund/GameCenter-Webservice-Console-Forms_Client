

wsdl /out:WebServiceGameCenter.cs http://localhost/WebApplicationGameCenter/WebServiceGameCenter.asmx?WSDL

csc /target:library /out:WebServiceGameCenter.dll /reference:System.Web.Services.dll WebServiceGameCenter.cs MyKeyValuePairCustom.cs

csc /reference:WebServiceGameCenter.dll /out:GameCenter.exe GameCenterMain.cs

GameCenter.exe

