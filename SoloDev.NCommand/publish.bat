nuget.exe delete SoloDev.NCommand 1.0.0 -ApiKey private.nuget -Source http://192.168.0.100:8081/api/v2/package
nuget.exe push bin\Release\PublishOutput\SoloDev.NCommand.1.0.0.nupkg private.nuget -Source http://192.168.0.100:8081/api/v2/package
pause