# Integration Examples

This document demonstrates how the different projects in the workspace interact with each other.

## .NET Project Integration

### Library → Application

The `.NET` console application (`my-dotnet-app`) uses the class library (`my-dotnet-lib`) to demonstrate code reusability.

#### Library Code (`libs/my-dotnet-lib/Class1.cs`)

```csharp
namespace my_dotnet_lib;

public class Calculator
{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;
    public double Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero");
        return (double)a / b;
    }
}
```

#### Application Code (`apps/my-dotnet-app/Program.cs`)

```csharp
using my_dotnet_lib;

Console.WriteLine("Hello from .NET Console App in Nx!");

var calculator = new Calculator();
Console.WriteLine($"5 + 3 = {calculator.Add(5, 3)}");
```

#### How It Works

1. **Project Reference**: The console app has a project reference to the library:
   ```bash
   dotnet add reference ../../libs/my-dotnet-lib/my-dotnet-lib.csproj
   ```

2. **Nx Dependency Graph**: Nx automatically detects this relationship by parsing the `.csproj` files

3. **Automatic Build Order**: When you build the app, Nx ensures the library is built first:
   ```bash
   npx nx build my-dotnet-app
   # Output shows: "1/1 dependent project tasks succeeded"
   ```

4. **Caching**: If the library hasn't changed, Nx uses cached results for faster builds

## Angular Project Integration

### Library → Application

The Angular application (`my-angular-app`) imports and uses components from the shared library (`my-angular-lib`).

#### Library Component (`libs/my-angular-lib/src/lib/my-angular-lib/my-angular-lib.ts`)

```typescript
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'lib-my-angular-lib',
  imports: [CommonModule],
  templateUrl: './my-angular-lib.html',
  styleUrl: './my-angular-lib.css',
})
export class MyAngularLib {
  title = 'My Angular Library Component';
  items = ['Item 1', 'Item 2', 'Item 3'];

  addItem(): void {
    this.items.push(`Item ${this.items.length + 1}`);
  }
}
```

#### Application Usage (`apps/my-angular-app/src/app/app.ts`)

```typescript
import { Component } from '@angular/core';
import { MyAngularLib } from '@nx-example/my-angular-lib';

@Component({
  imports: [MyAngularLib],
  selector: 'app-root',
  templateUrl: './app.html',
})
export class App {
  protected title = 'my-angular-app';
}
```

#### Template (`apps/my-angular-app/src/app/app.html`)

```html
<div class="app-container">
  <h1>Welcome to {{ title }}!</h1>
  <lib-my-angular-lib></lib-my-angular-lib>
</div>
```

#### How It Works

1. **TypeScript Path Mapping**: Import uses the path alias defined in `tsconfig.base.json`:
   ```json
   {
     "paths": {
       "@nx-example/my-angular-lib": ["libs/my-angular-lib/src/index.ts"]
     }
   }
   ```

2. **Nx Dependency Detection**: Nx analyzes imports to build the dependency graph

3. **Development Mode**: In dev mode (`nx serve`), changes to the library are instantly reflected in the app

4. **Production Builds**: Library code is bundled with the application for optimal performance

## Running the Projects

### .NET Console Application

```bash
# Build and run the console app
npx nx run my-dotnet-app

# Expected output:
# Hello from .NET Console App in Nx!
# =====================================
# 
# Using the Calculator library:
# 5 + 3 = 8
# 10 - 4 = 6
# 6 * 7 = 42
# 20 / 5 = 4
# 
# ✓ Successfully using my-dotnet-lib in my-dotnet-app!
```

### Angular Application

```bash
# Serve the Angular app
npx nx serve my-angular-app

# Open browser at http://localhost:4200
# You'll see:
# - Welcome message
# - The library component with interactive button
# - Nx welcome component
```

## Nx Smart Features in Action

### 1. Dependency Graph

Visualize project dependencies:

```bash
npx nx graph
```

You'll see:
- `my-angular-app` depends on `my-angular-lib`
- `my-dotnet-app` depends on `my-dotnet-lib`

### 2. Affected Commands

Only build/test projects affected by your changes:

```bash
# If you change the .NET library
npx nx affected -t build
# Only rebuilds: my-dotnet-lib, my-dotnet-app

# If you change the Angular library
npx nx affected -t build
# Only rebuilds: my-angular-lib, my-angular-app
```

### 3. Task Dependencies

Nx automatically builds dependencies in the correct order:

```bash
# This command will:
# 1. Build my-dotnet-lib (if needed)
# 2. Build my-dotnet-app (using the library)
npx nx build my-dotnet-app
```

### 4. Computation Caching

Run the same build twice:

```bash
npx nx build my-dotnet-app
# First run: ~2-3 seconds

npx nx build my-dotnet-app
# Second run: <1 second (cache hit)
```

### 5. Parallel Execution

Build multiple unrelated projects at once:

```bash
# Builds both .NET projects in parallel (they don't depend on each other)
npx nx run-many -t build -p my-dotnet-lib my-angular-lib
```

## Testing the Integration

### Test .NET Integration

```bash
# Build library
npx nx build my-dotnet-lib

# Build app (depends on library)
npx nx build my-dotnet-app

# Run app (uses library)
npx nx run my-dotnet-app
```

### Test Angular Integration

```bash
# Test library
npx nx test my-angular-lib

# Test app (imports library)
npx nx test my-angular-app

# Serve app with live reload
npx nx serve my-angular-app
# Make changes to the library and see them reflected instantly
```

## Cross-Technology Benefits

While .NET and Angular projects don't directly interact in this example, they benefit from being in the same Nx workspace:

1. **Unified CI/CD**: Single pipeline for all projects
2. **Consistent Tooling**: Same commands work across technologies
3. **Shared Configuration**: Common linting, formatting, and CI configs
4. **Dependency Visibility**: See how changes in any project affect the entire workspace
5. **Efficient Caching**: Nx caches build artifacts for both .NET and Angular
6. **Affected Analysis**: Only rebuild/test what changed, regardless of technology

## Next Steps

To further explore the integration:

1. Add more methods to the `Calculator` class and use them in the console app
2. Create additional Angular components in the library
3. Add unit tests for both .NET and Angular libraries
4. Create a .NET Web API and have the Angular app consume it
5. Set up E2E tests that interact with both .NET and Angular projects

## Resources

- [Nx Task Pipeline Configuration](https://nx.dev/concepts/task-pipeline-configuration)
- [Nx Dependency Management](https://nx.dev/concepts/dependency-management)
- [.NET Project References](https://learn.microsoft.com/en-us/dotnet/core/tools/dependencies)
- [Angular Libraries](https://angular.io/guide/libraries)
