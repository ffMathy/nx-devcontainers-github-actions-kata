# NxExample

# nx-example

<a alt="Nx logo" href="https://nx.dev" target="_blank" rel="noreferrer"><img src="https://raw.githubusercontent.com/nrwl/nx/master/images/nx-logo.png" width="45"></a>

✨ **Nx Monorepo with .NET and Angular** ✨

[![Open in Dev Containers](https://img.shields.io/static/v1?label=Dev%20Containers&message=Open&color=blue&logo=visualstudiocode)](https://vscode.dev/redirect?url=vscode://ms-vscode-remote.remote-containers/cloneInVolume?url=https://github.com/YOUR_REPO)

This is a sample Nx workspace demonstrating how to use .NET and Angular projects together in a monorepo setup.

## Project Structure

This workspace contains:

### Applications (`apps/`)
- **my-angular-app** - Angular standalone application with routing
- **my-dotnet-app** - .NET console application

### Libraries (`libs/`)
- **my-angular-lib** - Angular standalone component library
- **my-dotnet-lib** - .NET class library

## Prerequisites

- Node.js (LTS version)
- .NET SDK 8.0 or higher (this workspace uses .NET 9)
- npm or yarn

### Option 1: DevContainer (Recommended)

For a consistent development environment with all tools pre-configured:

1. Install [Docker Desktop](https://www.docker.com/products/docker-desktop)
2. Install VS Code extension: [Dev Containers](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers)
3. Open workspace in VS Code
4. Click "Reopen in Container" when prompted

See [.devcontainer/README.md](.devcontainer/README.md) for detailed setup instructions.

### Option 2: Local Installation

Install the prerequisites above directly on your machine.

## Run tasks

To run tasks with Nx use:

```sh
npx nx <target> <project-name>
```

### Angular Commands

```sh
# Serve the Angular app
npx nx serve my-angular-app

# Build the Angular app
npx nx build my-angular-app

# Test the Angular app
npx nx test my-angular-app

# Lint the Angular app
npx nx lint my-angular-app

# Test the Angular library
npx nx test my-angular-lib
```

### .NET Commands

```sh
# Build the .NET console app
npx nx build my-dotnet-app

# Run the .NET console app
npx nx run my-dotnet-app

# Build the .NET library
npx nx build my-dotnet-lib

# Test the .NET library (if tests exist)
npx nx test my-dotnet-lib
```

## View Project Graph

Visualize your workspace structure and project dependencies:

```sh
npx nx graph
```

## List All Projects

```sh
npx nx show projects
```

## Add New Projects

### Adding Angular Projects

```sh
# Generate a new Angular app
npx nx g @nx/angular:app apps/new-app

# Generate a new Angular library
npx nx g @nx/angular:lib libs/new-lib
```

### Adding .NET Projects

```sh
# Create a new .NET console app
dotnet new console -o apps/new-dotnet-app

# Create a new .NET class library
dotnet new classlib -o libs/new-dotnet-lib

# Create a new .NET web API
dotnet new webapi -o apps/new-api
```

After creating .NET projects with the `dotnet` CLI, Nx will automatically detect them and make their build targets available.

## Technologies Used

- **Nx** (v22) - Smart monorepo build system
- **@nx/angular** - Angular plugin for Nx
- **@nx/dotnet** - .NET plugin for Nx (experimental)
- **Angular** - Frontend framework with standalone components
- **.NET 9** - Cross-platform .NET framework
- **Jest** - Unit testing for Angular
- **ESBuild** - Fast bundler for Angular

## Learn More

- [Nx Documentation](https://nx.dev)
- [Angular in Nx](https://nx.dev/docs/technologies/angular/introduction)
- [.NET in Nx](https://nx.dev/docs/technologies/dotnet/introduction)
- [Nx Console](https://nx.dev/getting-started/editor-setup) - VSCode/IntelliJ extension

## Community

- [Discord](https://go.nx.dev/community)
- [Follow us on X](https://twitter.com/nxdevtools) or [LinkedIn](https://www.linkedin.com/company/nrwl)
- [Youtube channel](https://www.youtube.com/@nxdevtools)
- [Blog](https://nx.dev/blog)

## Run tasks

To run tasks with Nx use:

```sh
npx nx <target> <project-name>
```

For example:

```sh
npx nx build myproject
```

These targets are either [inferred automatically](https://nx.dev/concepts/inferred-tasks?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects) or defined in the `project.json` or `package.json` files.

[More about running tasks in the docs &raquo;](https://nx.dev/features/run-tasks?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects)

## Add new projects

While you could add new projects to your workspace manually, you might want to leverage [Nx plugins](https://nx.dev/concepts/nx-plugins?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects) and their [code generation](https://nx.dev/features/generate-code?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects) feature.

To install a new plugin you can use the `nx add` command. Here's an example of adding the React plugin:
```sh
npx nx add @nx/react
```

Use the plugin's generator to create new projects. For example, to create a new React app or library:

```sh
# Generate an app
npx nx g @nx/react:app demo

# Generate a library
npx nx g @nx/react:lib some-lib
```

You can use `npx nx list` to get a list of installed plugins. Then, run `npx nx list <plugin-name>` to learn about more specific capabilities of a particular plugin. Alternatively, [install Nx Console](https://nx.dev/getting-started/editor-setup?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects) to browse plugins and generators in your IDE.

[Learn more about Nx plugins &raquo;](https://nx.dev/concepts/nx-plugins?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects) | [Browse the plugin registry &raquo;](https://nx.dev/plugin-registry?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects)

## Set up CI!

### Step 1

To connect to Nx Cloud, run the following command:

```sh
npx nx connect
```

Connecting to Nx Cloud ensures a [fast and scalable CI](https://nx.dev/ci/intro/why-nx-cloud?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects) pipeline. It includes features such as:

- [Remote caching](https://nx.dev/ci/features/remote-cache?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects)
- [Task distribution across multiple machines](https://nx.dev/ci/features/distribute-task-execution?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects)
- [Automated e2e test splitting](https://nx.dev/ci/features/split-e2e-tasks?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects)
- [Task flakiness detection and rerunning](https://nx.dev/ci/features/flaky-tasks?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects)

### Step 2

Use the following command to configure a CI workflow for your workspace:

```sh
npx nx g ci-workflow
```

[Learn more about Nx on CI](https://nx.dev/ci/intro/ci-with-nx#ready-get-started-with-your-provider?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects)

## Install Nx Console

Nx Console is an editor extension that enriches your developer experience. It lets you run tasks, generate code, and improves code autocompletion in your IDE. It is available for VSCode and IntelliJ.

[Install Nx Console &raquo;](https://nx.dev/getting-started/editor-setup?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects)

## Useful links

Learn more:

- [Learn more about this workspace setup](https://nx.dev/getting-started/intro#learn-nx?utm_source=nx_project&amp;utm_medium=readme&amp;utm_campaign=nx_projects)
- [Learn about Nx on CI](https://nx.dev/ci/intro/ci-with-nx?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects)
- [Releasing Packages with Nx release](https://nx.dev/features/manage-releases?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects)
- [What are Nx plugins?](https://nx.dev/concepts/nx-plugins?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects)

And join the Nx community:
- [Discord](https://go.nx.dev/community)
- [Follow us on X](https://twitter.com/nxdevtools) or [LinkedIn](https://www.linkedin.com/company/nrwl)
- [Our Youtube channel](https://www.youtube.com/@nxdevtools)
- [Our blog](https://nx.dev/blog?utm_source=nx_project&utm_medium=readme&utm_campaign=nx_projects)
