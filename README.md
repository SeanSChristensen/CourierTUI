# CourierTUI

A lightweight Postman-inspired REST client built with **C#** and **Terminal.Gui**.

CourierTUI provides a terminal interface for testing HTTP APIs mainly utilising the https://tui-cs.github.io/Terminal.Gui/ library. It supports multiple HTTP methods, custom headers, request bodies, and formatted JSON responses. A fun tool for anyone wanting to test API end points while using a Terminal interface. 

![Model](https://github.com/SeanSChristensen/CourierTUI/blob/master/Capture.PNG)

---

## Built With

* C#
* .NET 8
* Terminal.Gui
* HttpClient
* System.Text.Json

---

## Getting Started

### Prerequisites

* .NET 8 SDK or later

### Clone the repository

```bash
git clone https://github.com/SeanSChristensen/CourierTUI.git
cd CourierTUI
```

### Build

```bash
dotnet build
```

### Run

```bash
dotnet run
```

---

## Usage

1. Enter the request URL.
2. Add any required headers.
3. Switch to the Body tab if sending data.
4. Choose the desired content type.
5. Press the send button.
6. View the formatted response in the Results panel.
