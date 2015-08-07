# Orc.LogViewer

[![Join the chat at https://gitter.im/WildGums/Orc.LogViewer](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/WildGums/Orc.LogViewer?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

![License](https://img.shields.io/github/license/wildgums/orc.logviewer.svg)
![NuGet downloads](https://img.shields.io/nuget/dt/orc.logviewer.svg)
![Version](https://img.shields.io/nuget/v/orc.logviewer.svg)
![Pre-release version](https://img.shields.io/nuget/vpre/orc.logviewer.svg)

An advanced log viewer for WPF applications.

Run the demo project to see the control in action:

![Orc.LogViewer demo](doc/images/Orc.LogViewer.Demo.png)

Use level toggle buttons to show/hide log records:

![Level toggle buttons](doc/images/Orc.LogViewer.Demo.LevelToggleButtons.png)

Start typing in filter box to filter log records:  

![Filtering](doc/images/Orc.LogViewer.Demo.FilterBox.png)

Select a type name in combobox to filter log records by type name:

![Type names](doc/images/Orc.LogViewer.Demo.TypeNames1.png)

![Type names](doc/images/Orc.LogViewer.Demo.TypeNames.png)

Use Time stamp toggle button to show/hide timestamps:

![Time stamps](doc/images/Orc.LogViewer.Demo.TimeStamps.png)

### How to use LogViewer

Here are the main properties, which are used to configure the LogViewer control:

Filtering: 

- **Level** => The log records types which will be shown.
- **LogListenerType** => Type. The log listener type. 
- **IgnoreCatelLogging** => boolean. Ignore Catel logging if true.

Visualisation:

- **ShowFilterBox** => boolean. Show Filter box if true.
- **ShowTypeNames** => boolean. Show Type names combobox if true.
- **AccentColorBrush** => Brush. The accent color.

```
<orc:AdvancedLogViewerControl AccentColorBrush="Orange" />
```

