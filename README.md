# What
A .NET Core 3 API project template, with Hangfire configured (including 3 queues).

# Install
```console
git clone git@github.com:vitawebsitedesign/dotnet-core-hangfire-template.git
```

# Usage
There is some example API endpoint and Hangfire task code.

You can start editing the template to your liking, but if you want to try it out, follow instructions in below section.

# Demo
```sql
CREATE DATABASE HangfireTest;
GO
CREATE DATABASE DatabaseTest;
GO

USE DatabaseTest;
GO

CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
```

1. Open project in Visual Studio
1. Add your connection strings to `HangfireExample/connectionstrings.json`
1. Run project via Visual Studio
1. Goto `/api/v1/entities/carseny`
1. Goto `/hangfire` to view successful job
