# DevContainer Setup

This workspace includes DevContainer support for a consistent development environment across all team members.

## What's Included

The DevContainer provides:

- **.NET SDK 9.0** - Latest .NET development tools
- **Node.js 20.x** - LTS version with npm
- **Git** - Version control
- **Common utilities** - vim, nano, curl, wget, etc.

### Pre-installed VS Code Extensions

**Nx & Angular:**
- Nx Console - Visual interface for Nx commands
- Angular Language Service - Angular support and IntelliSense

**.NET:**
- C# Dev Kit - Complete C# development experience
- C# - C# language support
- .NET Runtime - .NET runtime installer

**General Development:**
- ESLint - JavaScript/TypeScript linting
- Prettier - Code formatter
- EditorConfig - Consistent coding styles
- GitHub Copilot - AI pair programmer (if you have access)

## Prerequisites

### Windows
- Docker Desktop for Windows
- WSL 2 (recommended)
- VS Code with Remote-Containers extension

### macOS
- Docker Desktop for Mac
- VS Code with Remote-Containers extension

### Linux
- Docker Engine
- Docker Compose
- VS Code with Remote-Containers extension

## Getting Started

### 1. Install Required Software

**Install Docker:**
- Windows/Mac: [Docker Desktop](https://www.docker.com/products/docker-desktop)
- Linux: [Docker Engine](https://docs.docker.com/engine/install/)

**Install VS Code Extension:**
```bash
code --install-extension ms-vscode-remote.remote-containers
```

Or search for "Dev Containers" in the VS Code extensions marketplace.

### 2. Open in DevContainer

**Option A: Using VS Code Command Palette**
1. Open the workspace folder in VS Code
2. Press `F1` or `Ctrl+Shift+P` (Windows/Linux) / `Cmd+Shift+P` (Mac)
3. Type "Dev Containers: Reopen in Container"
4. Wait for the container to build (first time takes 5-10 minutes)

**Option B: Using the Notification**
1. Open the workspace folder in VS Code
2. Click "Reopen in Container" when prompted

**Option C: Using the Remote Explorer**
1. Click the Remote Explorer icon in the Activity Bar
2. Select "Dev Containers" from the dropdown
3. Right-click the workspace and select "Open Folder in Container"

### 3. Wait for Setup

The first time you open the container:
1. Docker will build the image (~5-10 minutes)
2. VS Code will install extensions
3. `npm install` will run automatically (via `postCreateCommand`)

Subsequent opens are much faster (~30 seconds).

## Using the DevContainer

### Verify Everything Works

Once inside the container, open a terminal and verify:

```bash
# Check Node.js
node --version
# Should show: v20.x.x

# Check npm
npm --version
# Should show: 10.x.x or higher

# Check .NET
dotnet --version
# Should show: 9.0.x

# Check Git
git --version
```

### Run Your Projects

All Nx commands work the same as before:

```bash
# Build projects
npx nx build my-dotnet-app
npx nx build my-angular-app

# Run projects
npx nx run my-dotnet-app
npx nx serve my-angular-app

# Run tests
npx nx test my-angular-lib
npx nx test my-angular-app

# View project graph
npx nx graph
```

### Forwarded Ports

The following ports are automatically forwarded to your host machine:
- **4200** - Angular development server
- **5000** - .NET HTTP applications
- **5001** - .NET HTTPS applications

Access them at `http://localhost:4200`, `http://localhost:5000`, etc.

## File Permissions

The DevContainer runs as the `vscode` user (UID 1000, GID 1000) to avoid permission issues with files created inside the container.

All files created inside the container will have the same permissions as your host user.

## Persistent Data

The following data is persisted in Docker volumes for better performance:

- **node_modules** - npm packages (improves npm install speed)
- **.nuget/packages** - .NET packages (improves dotnet restore speed)

Your source code is bind-mounted from the host, so all changes are immediately reflected on both sides.

## Customization

### Add More VS Code Extensions

Edit `.devcontainer/devcontainer.json`:

```json
"customizations": {
  "vscode": {
    "extensions": [
      "nrwl.angular-console",
      "your-publisher.your-extension"
    ]
  }
}
```

### Add More Tools

Edit `.devcontainer/Dockerfile`:

```dockerfile
# Add your custom tools
RUN apt-get update && apt-get install -y \
    your-package-name \
    && apt-get clean -y
```

### Change Node.js Version

Edit `.devcontainer/Dockerfile` and change:

```dockerfile
RUN curl -fsSL https://deb.nodesource.com/setup_20.x | bash -
```

To your desired version (e.g., `setup_18.x`).

### Add Environment Variables

Edit `.devcontainer/docker-compose.yml`:

```yaml
environment:
  - DOTNET_CLI_TELEMETRY_OPTOUT=1
  - YOUR_VAR=your_value
```

## Troubleshooting

### Container Won't Start

```bash
# Rebuild container without cache
# Command Palette -> Dev Containers: Rebuild Container Without Cache
```

### Permission Denied Errors

Make sure Docker has access to your workspace folder:
- **Windows**: Check Docker Desktop -> Settings -> Resources -> File Sharing
- **macOS**: Check Docker Desktop -> Settings -> Resources -> File Sharing
- **Linux**: Check user is in docker group: `sudo usermod -aG docker $USER`

### npm install Fails

```bash
# Clear npm cache
npm cache clean --force

# Remove node_modules volume and rebuild
docker volume rm nx-example_node_modules
# Then rebuild container
```

### Slow Performance on Windows

Use WSL 2 backend instead of Hyper-V:
1. Docker Desktop -> Settings -> General
2. Enable "Use the WSL 2 based engine"
3. Clone your repo inside WSL: `\\wsl$\Ubuntu\home\username\projects`

### Extension Not Working

```bash
# Reinstall extensions in container
# Command Palette -> Developer: Reload Window
```

## Working with Git

Git is configured to trust the workspace directory automatically via `postStartCommand`.

Your host Git credentials are automatically available in the container via credential helpers.

```bash
# Git works as expected
git status
git commit -m "message"
git push
```

## Best Practices

### 1. Commit the .devcontainer folder

The `.devcontainer` folder should be committed to version control so all team members use the same environment.

### 2. Don't run docker commands inside the container

The DevContainer doesn't have Docker-in-Docker configured. Run docker commands from your host.

### 3. Use volume mounts for large dependencies

The `node_modules` and `.nuget/packages` volumes significantly improve performance, especially on Windows and macOS.

### 4. Keep the Dockerfile minimal

Only install tools that everyone on the team needs. Personal preferences can be added via VS Code's user settings sync.

### 5. Document custom changes

If you modify the DevContainer configuration, document it in this README.

## Advanced: Multi-Container Setup

For more complex setups (e.g., with databases), you can extend `docker-compose.yml`:

```yaml
services:
  devcontainer:
    # ... existing config ...
    depends_on:
      - postgres
  
  postgres:
    image: postgres:15
    environment:
      POSTGRES_PASSWORD: development
    ports:
      - "5432:5432"
```

## Resources

- [VS Code DevContainers Documentation](https://code.visualstudio.com/docs/devcontainers/containers)
- [DevContainer Specification](https://containers.dev/)
- [DevContainer Features](https://containers.dev/features)
- [Docker Documentation](https://docs.docker.com/)

## Team Setup Checklist

- [ ] Install Docker Desktop
- [ ] Install VS Code Remote-Containers extension
- [ ] Clone the repository
- [ ] Open workspace in VS Code
- [ ] Click "Reopen in Container"
- [ ] Wait for initial build
- [ ] Verify with `node --version`, `dotnet --version`, `npx nx --version`
- [ ] Run `npx nx run-many -t build` to verify all projects build

Once everyone completes this checklist, the entire team will have identical development environments!
