# Workspace Structure

This document provides an overview of the Nx monorepo structure with .NET and Angular projects.

## Directory Layout

```
nx-example/
├── apps/
│   ├── my-angular-app/          # Angular application
│   │   ├── src/
│   │   │   ├── app/
│   │   │   ├── index.html
│   │   │   ├── main.ts
│   │   │   └── styles.css
│   │   ├── project.json         # Nx project configuration
│   │   ├── tsconfig.json
│   │   └── jest.config.ts
│   │
│   └── my-dotnet-app/           # .NET console application
│       ├── Program.cs
│       └── my-dotnet-app.csproj
│
├── libs/
│   ├── my-angular-lib/          # Angular library
│   │   ├── src/
│   │   │   ├── lib/
│   │   │   └── index.ts
│   │   ├── project.json
│   │   └── jest.config.ts
│   │
│   └── my-dotnet-lib/           # .NET class library
│       ├── Class1.cs
│       └── my-dotnet-lib.csproj
│
├── node_modules/
├── nx.json                      # Nx workspace configuration
├── package.json
├── tsconfig.base.json
└── README.md
```

## Project Types

### Angular Projects

#### my-angular-app (Application)
- **Type**: Standalone Angular application
- **Location**: `apps/my-angular-app`
- **Features**: 
  - Routing enabled
  - Jest for unit testing
  - ESBuild for fast builds
  - ESLint for linting
- **Available targets**: serve, build, test, lint

#### my-angular-lib (Library)
- **Type**: Standalone Angular library
- **Location**: `libs/my-angular-lib`
- **Features**:
  - Reusable Angular components
  - Jest for unit testing
  - Can be imported by Angular apps
- **Available targets**: test, lint

### .NET Projects

#### my-dotnet-app (Console Application)
- **Type**: .NET Console Application
- **Location**: `apps/my-dotnet-app`
- **Framework**: .NET 9.0
- **Available targets**: build, run, clean, restore, publish, watch

#### my-dotnet-lib (Class Library)
- **Type**: .NET Class Library
- **Location**: `libs/my-dotnet-lib`
- **Framework**: .NET 9.0
- **Available targets**: build, clean, restore, pack, watch

## How Nx Integrates .NET and Angular

### Angular Integration
- Uses `@nx/angular` plugin
- Generates project.json files for each Angular project
- Integrates with Angular CLI schematics
- Provides caching for builds, tests, and lints

### .NET Integration
- Uses `@nx/dotnet` plugin (experimental in Nx 22+)
- Automatically detects .csproj, .fsproj, and .vbproj files
- Infers MSBuild targets as Nx targets
- No project.json needed - configuration is inferred from .csproj files
- Supports MSBuild configurations (Debug, Release)

## Key Configuration Files

### nx.json
Main Nx workspace configuration that includes:
- Task runner configuration
- Plugin configurations (@nx/angular and @nx/dotnet)
- Named inputs for caching
- Target defaults

### tsconfig.base.json
TypeScript configuration for the workspace:
- Path mappings for libraries
- Shared TypeScript compiler options
- Used by all TypeScript projects

### project.json (Angular only)
Project-specific configuration for Angular projects:
- Defines available targets (build, test, lint, serve)
- Specifies target options and configurations
- Not needed for .NET projects (inferred from .csproj)

### .csproj files (.NET only)
Standard .NET project files:
- Define project dependencies
- Specify framework version
- List project references
- Nx reads these to infer targets

## Nx Features

### Computation Caching
Nx caches task results. If you run a task that has already been executed with the same inputs, Nx will restore the results from cache instead of re-running the task.

```sh
# First run builds from scratch
npx nx build my-angular-app

# Second run uses cache (instant)
npx nx build my-angular-app
```

### Task Dependencies
Nx understands project dependencies and can build projects in the correct order.

### Affected Commands
Only run tasks for projects affected by your changes:

```sh
# Test only affected projects
npx nx affected -t test

# Build only affected projects
npx nx affected -t build
```

### Project Graph
Visualize your workspace and dependencies:

```sh
npx nx graph
```

## Adding Dependencies Between Projects

### Angular to Angular
In Angular projects, import from libraries using TypeScript path mappings:

```typescript
// In my-angular-app/src/app/app.ts
import { MyAngularLibComponent } from '@nx-example/my-angular-lib';
```

### .NET to .NET
Add project references in .NET:

```sh
cd apps/my-dotnet-app
dotnet add reference ../../libs/my-dotnet-lib/my-dotnet-lib.csproj
```

Then use in code:
```csharp
using MyDotnetLib;
```

## Environment Setup

### Required Software
1. **Node.js**: LTS version (v18 or v20)
2. **.NET SDK**: Version 8.0 or higher
3. **Git**: For version control
4. **VSCode** (recommended): With Nx Console extension

### VSCode Extensions
- Nx Console - Visual interface for Nx commands
- Angular Language Service - Angular support
- C# Dev Kit - C# and .NET support
- ESLint - JavaScript/TypeScript linting

## Common Tasks

### Starting Fresh
```sh
# Clean node_modules and reinstall
rm -rf node_modules
npm install

# Clean .NET artifacts
dotnet clean
```

### Running Multiple Projects
```sh
# Run Angular app in watch mode
npx nx serve my-angular-app

# In another terminal, run .NET app
npx nx run my-dotnet-app
```

### Running Tests
```sh
# Run all tests
npx nx run-many -t test

# Run tests for specific projects
npx nx test my-angular-app
npx nx test my-angular-lib
```

## Resources

- [Nx Documentation](https://nx.dev)
- [Nx Console](https://nx.dev/getting-started/editor-setup)
- [Angular with Nx](https://nx.dev/docs/technologies/angular/introduction)
- [.NET with Nx](https://nx.dev/docs/technologies/dotnet/introduction)
- [MSBuild Documentation](https://learn.microsoft.com/en-us/visualstudio/msbuild/msbuild)
