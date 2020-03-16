# Extended Sitecore Commerce Views
Custom Sitecore Commerce views plugin project with extended functionality for the Business Tools.

- [Supported Sitecore Experience Commerce Versions](#supported-sitecore-experience-commerce-versions)
- [Features](#features)
- [Installation Instructions](#installation-instructions)
- [Known Issues](#known-issues)
- [Disclaimer](#disclaimer)

## Supported Sitecore Experience Commerce Versions
- XC 9.2

## Features
- [Ui Hints, UI Types, and Icons Constants](#ui-hints-ui-types-and-icons-constants)
- [Target Attribute Support for Hyperlink Values](#target-attribute-support-for-hyperlink-values)

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

### Target Attribute Support for Hyperlink Values
Links in BizFx may direct the user away from the current page, counter-intuitive to the flow of user navigation. Enabling the target attribute to be configured for links, specifically for opening links in a new window or tab via the '_blank' value, improves the UX of customisations to the Business Tools.

For the '_blank' target type, the link is opened in a new window or tab and is rendered with a '^' to signify that the link will be opened externally.

**Dependencies:** https://github.com/ajsuth/Ajsuth.BizFx/tree/release/9.2/master

![Blank Target opens link in a new window or tab](./images/blank-target-link.png)

_Sample 'Flat' entity view with various UI Types._

To configure a link, the view property should be configured with a new policy with PolicyId "Target" and single model with Name _\<target type\>_, e.g. "_blank". The plugin Ajsuth.Foundation.Views.Engine contains the view property extension method _SetTargetPolicy()_ and contains constants for available values to improve development.

```
// Default target value is '_blank'
entityLinkViewProperty.SetTargetPolicy();

// Specify the target type
itemLinkViewProperty.SetTargetPolicy(ViewsConstants.ViewProperty.Targets.Self);
```

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
