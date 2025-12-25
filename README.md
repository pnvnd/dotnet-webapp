# .NET Web App
Start by installing the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0), which includes runtime for `.NET`, `ASP.NET Core`, and `.NET Desktop`. Then, create an application with:
```
dotnet new webapp -n dotnet-webapp
```

# Instrument with New Relic .NET Agent
Edit the `dotnet-webapp.csproj` and add the following to instrument the application with the New Relic .NET Agent:
```
<ItemGroup>
  <PackageReference Include="NewRelic.Agent" Version="10.47.2" />
  <PackageReference Include="NewRelic.Agent.Api" Version="10.47.2" />
</ItemGroup>
```

Edit the `Pages/Shared/_Layout.cshtml` to add the Browser Agent right after the `meta` tags:
```
@Html.Raw(NewRelic.Api.Agent.NewRelic.GetBrowserTimingHeader())
```
# Running the Application
Run the app locally with this command:
```
dotnet run
```