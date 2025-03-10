# WPF Material Design Integration

> A modern WPF application that demonstrates how to integrate **Material Design in XAML Toolkit** to create visually appealing, user-friendly, and responsive desktop applications.

---

## Overview

This project serves as a starting point for developers who want to build WPF applications with **Material Design principles**. It leverages the [Material Design in XAML Toolkit](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit) to enhance the aesthetics and usability of WPF applications with clean, modern UI components.

## demontration
![Demo Screenshot](https://github.com/MohamedKhattat/setup-material-design-for-wpf-csharp/blob/main/github-moderneui.PNG)

![Demo Screenshot](https://github.com/MohamedKhattat/setup-material-design-for-wpf-csharp/blob/main/github-moderneui2.PNG)


---

## Goals

- Implement **Material Design principles** in a WPF application.
- Showcase **responsive layouts** and **modern UI elements**.
- Provide reusable components and templates for common WPF controls.
- Serve as a boilerplate for building scalable WPF projects with a focus on design.

---

## Features

- Fully integrated **Material Design in XAML Toolkit**.
- Pre-styled controls (buttons, textboxes, combo boxes, etc.) with Material Design themes.
- Light and Dark Mode support.
- Customizable color palettes and typography.
- Responsive layouts that adapt to various screen sizes.
- Included examples of dialogs, navigation drawers, and snackbars.

---

## Getting Started

### Prerequisites

- Windows OS with Visual Studio installed.
- **.NET Framework version 4.8 or higher** is required.
- Basic knowledge of WPF and XAML.

---

### Installation

Follow these steps to set up the project:

1. **Uninstall/re-install any existing conflicting packages**:
   ```bash
   Uninstall-Package MaterialDesignThemes.MahApps -Force
   Uninstall-Package MaterialDesignThemes -Force
   Uninstall-Package MaterialDesignColors -Force
   Uninstall-Package MahApps.Metro -Force
   Uninstall-Package ControlzEx -Force
   Uninstall-Package Microsoft.Xaml.Behaviors.Wpf -Force

   Install-Package MahApps.Metro -Version 2.4.9
   Install-Package ControlzEx -Version 4.3.0
   Install-Package MaterialDesignColors -Version 2.0.0
   Install-Package MaterialDesignThemes -Version 4.0.0
   Install-Package MaterialDesignThemes.MahApps -Version 0.1.6
   Install-Package Microsoft.Xaml.Behaviors.Wpf -Version 1.1.39
---



