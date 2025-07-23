# Mabup-v2021.2

## Overview

**MABUP** is an educational web platform developed in **ASP.NET Core 3.1 (C# 8.0)** that integrates various tools to support students in task management, access to multimedia resources by subject, and collaboration through discussion forums. The system allows users to register, log in, manage their academic tasks, participate in thematic forums, and access educational videos organized by subject.

---

## Main Features

1.  **User Authentication and Registration**
    * Registration of new users with data validation and password confirmation.
    * Login with database validation.
    * Estimation of average time for tasks, used to personalize the experience.

2.  **Task Manager**
    * Viewing of pending tasks per user.
    * Adding new tasks with title, due date/time, subject, difficulty, and topic.
    * Marking tasks as completed.

3.  **Educational Streaming Service**
    * Subject selection panel (Mathematics, Physics, Chemistry, Biology, Educational Psychology, Geography, English, Environmental Care).
    * Selection of specific topics within each subject.
    * Educational video player associated with each topic.

4.  **Discussion Forum**
    * Search and listing of existing forums, showing topic, subject, and author.
    * Creation of new forums, associating topic and subject.
    * Access to forums to view and participate in discussions.
    * Posting comments in forums, with author and date/time registration.

5.  **Navigation and User Experience**
    * Personalized main window after login, with quick access to task manager, forums, and streaming.
    * Friendly and student-adapted visual interface.

---

## Project Structure

* **Controllers**: Business logic and route handling for authentication, task manager, forums, and streaming.
* **Models**: Data models for users, tasks, forums, comments, subjects, and videos.
* **Views**: Razor views for each functionality, including forms, panels, and players.
* **wwwroot**: Static resources such as images, CSS, and JS libraries (Bootstrap, jQuery Validation).

---

## How to Install Mabup-v2021.2 Locally

This guide details the procedure for installing and configuring **Mabup-v2021.2** for execution in a local machine environment. The application's operation in this mode is autonomous, not requiring external services or remote server infrastructure. The functionality and stability of Mabup-v2021.2 are directly conditioned by the pre-existence and correct configuration of various software dependencies on the host operating system.

### Software Dependencies

The correct execution of Mabup-v2021.2 requires the availability of the following components on the local system:

#### 1. .NET Core Runtimes

Mabup-v2021.2 is built on the .NET Core platform, so it requires specific execution environments to operate.

* **Microsoft.NETCore.App 3.1.0:**
    This is the fundamental .NET Core 3.1.0 runtime. It provides the execution environment (CoreCLR) and the base class library (BCL) set that are essential for loading and running any .NET Core application. Its function is similar to a lightweight virtual machine that interprets and executes the compiled application code.
    * **Download:** [https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-3.1.0-windows-x64-installer](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-3.1.0-windows-x64-installer)

* **Microsoft.AspNetCore.App 3.1.0:**
    This runtime extends the .NET Core environment with ASP.NET Core-specific components. It includes libraries for developing web applications and services, indicating that Mabup-v2021.2 uses functionalities related to web user interfaces (e.g., embedded Blazor or Razor Pages) or communication services based on the ASP.NET Core framework, even for its local operation.
    * **Download:** [https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-3.1.0-windows-x64-installer](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-3.1.0-windows-x64-installer)

#### 2. Local Database Instance

Mabup-v2021.2 requires a database for the persistence of operational and configuration data.

* **Microsoft SQL Server 2019 LocalDB:**
    LocalDB is a lightweight variant of the SQL Server Express database engine, optimized for development, testing, and local application deployment scenarios that need a relational database. It runs as an on-demand user process without the complexity of a full SQL Server installation, making it ideal for local machine environments. Mabup-v2021.2 will connect to this LocalDB instance to store and retrieve its data.
    * **Acquisition:** LocalDB is typically distributed as a selectable component within **SQL Server Express** installers or included with Microsoft's development tools suite, such as **Visual Studio 2022 Community**.

#### 3. Development Environment and Tools

The following tool is essential for acquiring some dependencies and for the overall work environment.

* **Visual Studio 2022 Community:**
    This is Microsoft's primary Integrated Development Environment (IDE). Its installation is crucial for several reasons:
    * **LocalDB Acquisition:** Visual Studio often provides the easiest way to install and configure SQL Server LocalDB and its associated management tools (such as SQL Server Object Explorer).
    * **SDKs and Tools:** It may include or facilitate the installation of additional .NET SDKs, build tools, and components that, while not strictly runtimes, may be necessary for the correct functioning or deployment of Mabup-v2021.2, especially if the application interacts with other .NET platform services or components that require specific tools.

### Verifying Dependency Installation

Once the corresponding installers for each dependency have been run, it is recommended to verify their correct integration into the system:

#### Verifying .NET Runtimes

Confirm the existence of the following directories in the file system, which house the runtime components:

* `C:\Program Files\dotnet\shared\Microsoft.NETCore.App\3.1.0`
* `C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App\3.1.0`

#### Verifying Microsoft SQL Server 2019 LocalDB

The presence of Microsoft SQL Server 2019 LocalDB can be confirmed by:

* The "Apps & features" list in Windows settings.
* Attempting to initiate a database connection to the `(localdb)\mssqllocaldb` instance through tools like SQL Server Management Studio (SSMS) or SQL Server Object Explorer within Visual Studio.
* The ability of the Mabup-v2021.2 application to initialize and connect to its local database when executed.

#### Verifying Visual Studio 2022 Community

Confirm the correct installation of Visual Studio 2022 Community by:

* Its listing in Windows "Apps & features".
* The ability to launch the IDE from the start menu and access its main functionalities, including SQL Server Object Explorer if the data development component was installed.

With all these dependencies correctly installed and verified, the environment will be properly configured for the deployment and execution of Mabup-v2021.2.
