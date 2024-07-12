## Serial Monitor
This is a lightweight app for monitoring incoming serial port data. Designed around monitoring the output of microcontrollers such as Arduino or ESP32, etc. Its main feature is configurable syntax coloring to help visualize events of interest. It's also meant to run for long periods of time (weeks to months) with large amounts of data without bogging app system down.

## Project Status
![alpha](https://img.shields.io/badge/status-alpha-blue)

App is currently functional, but some features are not fully implemented at this time.

_Note, this is a personal app that I designed for my specific needs and not necessarily for general purpose use. Updates will be made when changes are needed and as I have time._

## Roadmap
- [x] Ability to save console contents to file
- [x] Save settings to file and load upon start
	- [ ] Add UI for saving/loading from user selected file 
- [x] User configurable color scheme
- [x] Color syntax highlighting
- [ ] Add user interface for configuration of rules/colors
- [ ] Add triggered alerts
	- [ ] Sound
	- [ ] Flashing background
	- [ ] Text mobile device (or other mobile alert solution)
- [ ] Ability to search/highlight and jump to contents in the console
- [ ] Increase test coverage and general code cleanup and commenting

## Tech
This is a C# .NET Windows Form app written in Visual Studio 2022 with nUnit for test cases. Simply download/clone the repository and build it in VS. Should run in Windows 7 and up.
