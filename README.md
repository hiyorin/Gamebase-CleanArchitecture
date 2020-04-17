# Gamebase-CleanArchitecture

<br><br><br><br>
## Table Of Contents
- [Description](#description)
- [Install](#install)
- [Usege](#usage)
  - [Create Project]("#create-project)
  - [Create File](#create-file)
- [License](#license)

<br><br><br><br>
## Description

<br><br><br><br>
## Install
Find `Packages/manifest.json` in your project and edit it to look like this:
```json
{
  "scopedRegistries": [
  {
    "name": "OpenUPM",
    "url": "https://package.openupm.com",
    "scopes": [
      "com.neuecc",
      "com.cysharp",
      "com.svermeulen",
      "com.coffee",
      "com.demigiant",
      ...
    ]
  }],
  "dependencies": {
    "com.coffee.git-dependency-resolver": "1.1.3",
    "com.coffee.upm-git-extension": "1.1.0-preview.12",
    "com.gamebase.loader": "https://github.com/hiyorin/Gamebase-CleanArchitecture.git",
    ...
  }
}
```
To update the package, change `#{version}` to the target version.  
Or, use [UpmGitExtension](https://github.com/mob-sakai/UpmGitExtension.git) to install or update the package.

<br><br><br><br>
## Usage

#### Create Project
- Right Click in folder within the Project tag and Choose `Create/Gamebase-CleanArchitecture/Project`.
- Please set RootFolder and Namespace.
- Click `Create` Button!

#### Create File
- Right Click in folder within the Project tag and Choose `Create/Gamebase-CleanArchitecture/*`.

<br><br><br><br>
## License
This library is under the MIT License.  
[here](LICENSE.md)