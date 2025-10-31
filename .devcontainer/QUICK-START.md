# DevContainer Quick Start

## 🚀 5-Minute Setup

### 1️⃣ Install Prerequisites (One-Time)

**Install Docker Desktop:**
- Windows/Mac: https://www.docker.com/products/docker-desktop
- Linux: https://docs.docker.com/engine/install/

**Install VS Code Extension:**
```bash
code --install-extension ms-vscode-remote.remote-containers
```

### 2️⃣ Open in DevContainer

1. Open this workspace in VS Code
2. Press `Ctrl+Shift+P` (or `Cmd+Shift+P` on Mac)
3. Type: "Dev Containers: Reopen in Container"
4. ☕ Wait 5-10 minutes for first-time setup

### 3️⃣ Start Developing!

Once the container is ready:

```bash
# Verify everything works
node --version && dotnet --version

# Build all projects
npx nx run-many -t build

# Run the Angular app
npx nx serve my-angular-app
# Open: http://localhost:4200

# Run the .NET app
npx nx run my-dotnet-app
```

## ✅ What You Get

- ✨ .NET SDK 9.0 pre-installed
- ✨ Node.js 20.x pre-installed
- ✨ All VS Code extensions pre-configured
- ✨ Git ready to use
- ✨ Same environment for everyone on the team
- ✨ No "works on my machine" issues

## 🎯 Benefits

| Without DevContainer | With DevContainer |
|---------------------|-------------------|
| Install .NET SDK manually | ✅ Pre-installed |
| Install Node.js manually | ✅ Pre-installed |
| Configure VS Code extensions | ✅ Auto-installed |
| Deal with version mismatches | ✅ Everyone identical |
| "Works on my machine" issues | ✅ Works everywhere |
| Setup takes hours | ✅ Setup takes minutes |

## 🔄 Daily Workflow

### Opening the Workspace

Just open VS Code in the workspace folder - it automatically reopens in the container!

### Making Changes

Edit files normally - changes are immediately reflected on your host machine.

### Running Commands

All commands run inside the container with the correct environment.

### Stopping Work

Just close VS Code - the container stops automatically.

## 🆘 Troubleshooting

**Container won't start?**
```bash
# Rebuild from scratch
Command Palette -> Dev Containers: Rebuild Container Without Cache
```

**Slow on Windows?**
- Use WSL 2: Docker Desktop -> Settings -> General -> "Use WSL 2 based engine"
- Clone repo in WSL: `\\wsl$\Ubuntu\home\username\projects`

**Extensions not working?**
```bash
# Reload window
Command Palette -> Developer: Reload Window
```

## 📚 Full Documentation

See [.devcontainer/README.md](.devcontainer/README.md) for complete documentation.

## 👥 Team Onboarding

New team member checklist:
1. ✅ Install Docker Desktop
2. ✅ Install Remote-Containers extension
3. ✅ Clone repo
4. ✅ Open in VS Code
5. ✅ Click "Reopen in Container"
6. ✅ Wait for setup
7. ✅ Start coding!

**Total time: ~15 minutes** (including Docker installation)

---

**Questions?** Check the [full documentation](.devcontainer/README.md) or ask the team!
