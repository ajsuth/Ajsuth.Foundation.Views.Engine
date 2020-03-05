# Extended Sitecore Commerce Views
Custom Sitecore Commerce views plugin project with extended functionality for the Business Tools.

- [Supported Sitecore Experience Commerce Versions](#supported-sitecore-experience-commerce-versions)
- [Features](#features)
- [Installation Instructions](#installation-instructions)
- [Known Issues](#known-issues)
- [Disclaimer](#disclaimer)

## Supported Sitecore Experience Commerce Versions
- XC 9.3

## Features
- [Ui Hints, UI Types, and Icons Constants](#ui-hints-ui-types-and-icons-constants)

### Ui Hints, UI Types, and Icons Constants
Remove the guessing game and human error by improving development efficiency with the comprehensive list of UI Hint, UI Type, and Icon names stored as constants.

To simplify usage, add the `using static` statement to the constants path.
```
using static Ajsuth.Foundation.Views.ViewsConstants.ViewProperty;
```


```
var viewProperty = new ViewProperty()
{
    Name = "RichTextField",
    UiType = UiTypes.RichText
};
```

_Sample Usage._

## Installation Instructions
1. Download the repository.
2. Add the **Ajsuth.Foundation.Views.Engine.csproj** to the _**Sitecore Commerce Engine**_ solution.
3. Add the **Ajsuth.Foundation.Views.Engine.csproj** as a reference to the desired projects.

## Known Issues
| Feature                 | Description | Issue |
| ----------------------- | ----------- | ----- |
|                         |             |       |

## Disclaimer
The code provided in this repository is sample code only. It is not intended for production usage and not endorsed by Sitecore.
Both Sitecore and the code author do not take responsibility for any issues caused as a result of using this code.
No guarantee or warranty is provided and code must be used at own risk.
